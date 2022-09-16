// <copyright file="ExpressionParsingServiceBase.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Reflection;
using IX.Math.Extensibility;
using IX.Math.Extraction;
using IX.Math.Generators;
using IX.Math.Nodes;
using IX.Math.Nodes.Constants;
using IX.Math.Registration;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using IX.StandardExtensions.Threading;
using IX.System.Collections.Generic;
using JetBrains.Annotations;
using DiagCA = System.Diagnostics.CodeAnalysis;

namespace IX.Math;

/// <summary>
///     A base class for an expression parsing service.
/// </summary>
/// <seealso cref="DisposableBase" />
/// <seealso cref="IExpressionParsingService" />
[PublicAPI]
public abstract class ExpressionParsingServiceBase : ReaderWriterSynchronizedBase,
    IExpressionParsingService
{
#region Internal state

    private readonly List<Assembly> assembliesToRegister;
    private readonly Dictionary<string, Type> binaryFunctions;

    private readonly LevelDictionary<Type, IConstantsExtractor> constantExtractors;
    private readonly LevelDictionary<Type, IConstantInterpreter> constantInterpreters;
    private readonly LevelDictionary<Type, IConstantPassThroughExtractor> constantPassThroughExtractors;

    private readonly Dictionary<string, Type> nonaryFunctions;
    private readonly List<IStringFormatter> stringFormatters;
    private readonly Dictionary<string, Type> ternaryFunctions;
    private readonly Dictionary<string, Type> unaryFunctions;

    private readonly MathDefinition workingDefinition;

    private int interpretationDone;

    private bool isInitialized;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ExpressionParsingServiceBase" /> class with a specified math
    ///     definition
    ///     object.
    /// </summary>
    /// <param name="definition">The math definition to use.</param>
    protected private ExpressionParsingServiceBase(MathDefinition definition)
    {
        // Preconditions
        Requires.NotNull(
            out workingDefinition,
            definition,
            nameof(definition));

        // Initialized internal state
        constantExtractors = new();
        constantInterpreters = new();
        constantPassThroughExtractors = new();
        stringFormatters = new();

        nonaryFunctions = new();
        unaryFunctions = new();
        binaryFunctions = new();
        ternaryFunctions = new();

        assembliesToRegister = new()
        {
            typeof(ExpressionParsingService).GetTypeInfo()
                .Assembly
        };
    }

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Returns the prototypes of all registered functions.
    /// </summary>
    /// <returns>All function names, with all possible combinations of input and output data.</returns>
    public string[] GetRegisteredFunctions()
    {
        ThrowIfCurrentObjectDisposed();

        using var innerLock = EnsureInitialization();

        // Capacity is sum of all, times 3; the "3" number was chosen as a good-enough average of how many overloads are defined, on average
        var bldr = new List<string>(
            (nonaryFunctions.Count +
             unaryFunctions.Count +
             binaryFunctions.Count +
             ternaryFunctions.Count) *
            3);

        bldr.AddRange(nonaryFunctions.Select(function => $"{function.Key}()"));

        (
            from KeyValuePair<string, Type> function in unaryFunctions
            from ConstructorInfo constructor in function.Value.GetTypeInfo()
                .DeclaredConstructors
            let parameters = constructor.GetParameters()
            where parameters.Length == 1
            let parameterName = parameters[0]
                .Name
            where parameterName != null
            let functionName = function.Key
            select (FunctionName: functionName, ParameterName: parameterName)).ForEach(
            (
                parameter,
                bldrL1) => bldrL1.Add($"{parameter.FunctionName}({parameter.ParameterName})"),
            bldr);

        (
            from KeyValuePair<string, Type> function in binaryFunctions
            from ConstructorInfo constructor in function.Value.GetTypeInfo()
                .DeclaredConstructors
            let parameters = constructor.GetParameters()
            where parameters.Length == 2
            let parameterNameLeft = parameters[0]
                .Name
            let parameterNameRight = parameters[1]
                .Name
            where parameterNameLeft != null && parameterNameRight != null
            let functionName = function.Key
            select (FunctionName: functionName, ParameterNameLeft: parameterNameLeft,
                ParameterNameRight: parameterNameRight)).ForEach(
            (
                parameter,
                bldrL1) => bldrL1.Add(
                $"{parameter.FunctionName}({parameter.ParameterNameLeft}, {parameter.ParameterNameRight})"),
            bldr);

        (
            from KeyValuePair<string, Type> function in ternaryFunctions
            from ConstructorInfo constructor in function.Value.GetTypeInfo()
                .DeclaredConstructors
            let parameters = constructor.GetParameters()
            where parameters.Length == 3
            let parameterNameLeft = parameters[0]
                .Name
            let parameterNameMiddle = parameters[1]
                .Name
            let parameterNameRight = parameters[2]
                .Name
            where parameterNameLeft != null && parameterNameMiddle != null && parameterNameRight != null
            let functionName = function.Key
            select (FunctionName: functionName, ParameterNameLeft: parameterNameLeft,
                ParameterNameMiddle: parameterNameMiddle, ParameterNameRight: parameterNameRight)).ForEach(
            (
                parameter,
                bldrL1) => bldrL1.Add(
                $"{parameter.FunctionName}({parameter.ParameterNameLeft}, {parameter.ParameterNameMiddle}, {parameter.ParameterNameRight})"),
            bldr);

        return bldr.ToArray();
    }

    /// <summary>
    ///     Interprets the mathematical expression and returns a container that can be invoked for solving using specific
    ///     mathematical types.
    /// </summary>
    /// <param name="expression">The expression to interpret.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A <see cref="ComputedExpression" /> that represents the interpreted expression.</returns>
    public abstract ComputedExpression Interpret(
        string expression,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Registers an assembly to extract compatible functions from.
    /// </summary>
    /// <param name="assembly">The assembly to register.</param>
    public void RegisterFunctionsAssembly(Assembly assembly)
    {
        _ = Requires.NotNull(
            assembly,
            nameof(assembly));

        ThrowIfCurrentObjectDisposed();

        using var innerLocker = AcquireReadWriteLock();

        if (isInitialized)
        {
            throw new InvalidOperationException(
                "Initialization has already completed, so you cannot register any more assemblies for this service.");
        }

        if (assembliesToRegister.Contains(assembly))
        {
            return;
        }

        innerLocker.Upgrade();

        assembliesToRegister.Add(assembly);
    }

    /// <summary>
    ///     Registers type formatters.
    /// </summary>
    /// <param name="formatter">The formatter to register.</param>
    /// <exception cref="InvalidOperationException">
    ///     This method was called after having called <see cref="Interpret" />
    ///     successfully for the first time.
    /// </exception>
    public void RegisterTypeFormatter(IStringFormatter formatter)
    {
        _ = Requires.NotNull(
            formatter,
            nameof(formatter));

        if (interpretationDone != 0)
        {
            throw new InvalidOperationException(
                Resources
                    .TheExpressionParsingServiceHasAlreadyDoneInterpretationAndCannotHaveAnyMoreFormattersRegistered);
        }

        stringFormatters.Add(formatter);
    }

#endregion

#region Disposable

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        nonaryFunctions.Clear();
        unaryFunctions.Clear();
        binaryFunctions.Clear();
        ternaryFunctions.Clear();

        stringFormatters.Clear();
        constantExtractors.Clear();
        constantInterpreters.Clear();
        constantPassThroughExtractors.Clear();

        assembliesToRegister.Clear();

        base.DisposeManagedContext();
    }

#endregion

    /// <summary>
    ///     Interprets the mathematical expression and returns a container that can be invoked for solving using specific
    ///     mathematical types.
    /// </summary>
    /// <param name="expression">The expression to interpret.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>
    ///     A <see cref="ComputedExpression" /> that represents a compilable form of the original expression, if the
    ///     expression itself makes sense.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="expression" /> is either null, empty or whitespace-only.</exception>
    [DiagCA.SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "We're OK with this.")]
    protected ComputedExpression InterpretInternal(
        string expression,
        CancellationToken cancellationToken = default)
    {
        _ = Requires.NotNullOrWhiteSpace(
            expression,
            nameof(expression));

        ThrowIfCurrentObjectDisposed();

        using var innerLock = EnsureInitialization();

        // Check expression through pass-through extractors
        if (constantPassThroughExtractors.KeysByLevel.SelectMany(p => p.Value)
            .Any(
                ConstantPassThroughExtractorPredicate,
                expression,
                this))
        {
            return new(
                expression,
                new StringNode(expression),
                true,
                new StandardParameterRegistry(stringFormatters),
                stringFormatters,
                null);
        }

        static bool ConstantPassThroughExtractorPredicate(
            Type cpteKey,
            string innerExpression,
            ExpressionParsingServiceBase innerThis) =>
            innerThis.constantPassThroughExtractors[cpteKey]
                     .Evaluate(innerExpression);

        ComputedExpression result;
        using (var workingSet = new WorkingExpressionSet(
                   expression,
                   workingDefinition.DeepClone(),
                   nonaryFunctions,
                   unaryFunctions,
                   binaryFunctions,
                   ternaryFunctions,
                   constantExtractors,
                   constantInterpreters,
                   stringFormatters,
                   cancellationToken))
        {
            (NodeBase? node, IParameterRegistry? parameterRegistry) = ExpressionGenerator.CreateBody(workingSet);

            result = !workingSet.Success
                ? new(
                    expression,
                    null,
                    false,
                    null,
                    stringFormatters,
                    null)
                : new ComputedExpression(
                    expression,
                    node,
                    true,
                    parameterRegistry,
                    stringFormatters,
                    workingSet.OfferReservedType);

            Interlocked.MemoryBarrier();
        }

        _ = Interlocked.Exchange(
            ref interpretationDone,
            1);

        return result;
    }

    [DiagCA.SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP017:Prefer using.",
        Justification = "This is required.")]
    private IDisposable EnsureInitialization()
    {
        var innerLock = AcquireReadLock();

        if (isInitialized)
        {
            return innerLock;
        }

        innerLock.Dispose();

        var innerWriteLock = AcquireReadWriteLock();

        if (isInitialized)
        {
            return innerWriteLock;
        }

        try
        {
            innerWriteLock.Upgrade();

            // Initializing functions dictionaries
            assembliesToRegister.GenerateInternalNonaryFunctionsDictionary(nonaryFunctions);
            assembliesToRegister.GenerateInternalUnaryFunctionsDictionary(unaryFunctions);
            assembliesToRegister.GenerateInternalBinaryFunctionsDictionary(binaryFunctions);
            assembliesToRegister.GenerateInternalTernaryFunctionsDictionary(ternaryFunctions);

            // Extractors
            InitializePassThroughExtractorsDictionary();
            InitializeExtractorsDictionary();
            InitializeInterpretersDictionary();

            isInitialized = true;
        }
        finally
        {
            innerWriteLock.Dispose();
        }

        return AcquireReadLock();
    }

    [DiagCA.SuppressMessage(
        "StyleCop.CSharp.ReadabilityRules",
        "SA1118:Parameter should not span multiple lines",
        Justification = "Parameters are very complex in this method.")]
    private void InitializeExtractorsDictionary()
    {
        constantExtractors.Add(
            typeof(StringExtractor),
            new StringExtractor(),
            1000);
        constantExtractors.Add(
            typeof(ScientificFormatNumberExtractor),
            new ScientificFormatNumberExtractor(),
            2000);

        var incrementer = 2001;
        assembliesToRegister.GetTypesAssignableFrom<IConstantsExtractor>()
            .Where(
                p => p.IsClass && !p.IsAbstract && !p.IsGenericTypeDefinition && p.HasPublicParameterlessConstructor())
            .Select(p => p.AsType())
            .Where(
                (
                    p,
                    thisL1) => !thisL1.constantExtractors.ContainsKey(p),
                this)
            .ForEach(
                (
                    in Type p,
                    ref int i,
                    ExpressionParsingServiceBase thisL1) =>
                {
                    if (p.Instantiate() is not IConstantsExtractor extractor)
                    {
                        return;
                    }

                    thisL1.constantExtractors.Add(
                        p,
                        extractor,
                        p.GetAttributeDataByTypeWithoutVersionBinding<ConstantsExtractorAttribute, int>(
                            out var explicitLevel)
                            ? explicitLevel
                            : Interlocked.Increment(ref i));
                },
                ref incrementer,
                this);
    }

    [DiagCA.SuppressMessage(
        "StyleCop.CSharp.ReadabilityRules",
        "SA1118:Parameter should not span multiple lines",
        Justification = "Parameters are very complex in this method.")]
    private void InitializePassThroughExtractorsDictionary()
    {
        var incrementer = 2001;
        assembliesToRegister.GetTypesAssignableFrom<IConstantPassThroughExtractor>()
            .Where(
                p => p.IsClass && !p.IsAbstract && !p.IsGenericTypeDefinition && p.HasPublicParameterlessConstructor())
            .Select(p => p.AsType())
            .Where(
                (
                    p,
                    thisL1) => !thisL1.constantPassThroughExtractors.ContainsKey(p),
                this)
            .ForEach(
                (
                    in Type p,
                    ref int i,
                    ExpressionParsingServiceBase thisL1) =>
                {
                    if (p.Instantiate() is not IConstantPassThroughExtractor extractor)
                    {
                        return;
                    }

                    thisL1.constantPassThroughExtractors.Add(
                        p,
                        extractor,
                        p.GetAttributeDataByTypeWithoutVersionBinding<ConstantsPassThroughExtractorAttribute, int>(
                            out var explicitLevel)
                            ? explicitLevel
                            : Interlocked.Increment(ref i));
                },
                ref incrementer,
                this);
    }

    [DiagCA.SuppressMessage(
        "StyleCop.CSharp.ReadabilityRules",
        "SA1118:Parameter should not span multiple lines",
        Justification = "Parameters are very complex in this method.")]
    private void InitializeInterpretersDictionary()
    {
        var incrementer = 2001;
        assembliesToRegister.GetTypesAssignableFrom<IConstantInterpreter>()
            .Where(
                p => p.IsClass && !p.IsAbstract && !p.IsGenericTypeDefinition && p.HasPublicParameterlessConstructor())
            .Select(p => p.AsType())
            .Where(
                (
                    p,
                    thisL1) => !thisL1.constantInterpreters.ContainsKey(p),
                this)
            .ForEach(
                (
                    in Type p,
                    ref int i,
                    ExpressionParsingServiceBase thisL1) =>
                {
                    if (p.Instantiate() is not IConstantInterpreter interpreter)
                    {
                        return;
                    }

                    thisL1.constantInterpreters.Add(
                        p,
                        interpreter,
                        p.GetAttributeDataByTypeWithoutVersionBinding<ConstantsInterpreterAttribute, int>(
                            out var explicitLevel)
                            ? explicitLevel
                            : Interlocked.Increment(ref i));
                },
                ref incrementer,
                this);
    }

#endregion
}