// <copyright file="FunctionNodeRandomInt.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Extensibility;
using IX.Math.Generators;
using IX.StandardExtensions.Contracts;

using JetBrains.Annotations;

namespace IX.Math.Nodes.Function.Binary;

/// <summary>
///     A node representing the random integer function.
/// </summary>
/// <seealso cref="NumericBinaryFunctionNodeBase" />
[DebuggerDisplay($"randomint({{{nameof(FirstParameter)}}}, {{{nameof(SecondParameter)}}})")]
[CallableMathematicsFunction("randomint")]
[UsedImplicitly]
internal sealed class FunctionNodeRandomInt : NumericBinaryFunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FunctionNodeRandomInt" /> class.
    /// </summary>
    /// <param name="firstParameter">The first parameter.</param>
    /// <param name="secondParameter">The second parameter.</param>
    public FunctionNodeRandomInt(
        NodeBase firstParameter,
        NodeBase secondParameter)
        : base(
            Requires.NotNull(firstParameter).Simplify(),
            Requires.NotNull(secondParameter).Simplify())
    {
        if (firstParameter is ParameterNode up1)
        {
            _ = up1.DetermineInteger();
        }

        if (secondParameter is ParameterNode up2)
        {
            _ = up2.DetermineInteger();
        }
    }

    /// <summary>
    ///     Generates a random value.
    /// </summary>
    /// <param name="min">The minimum.</param>
    /// <param name="max">The maximum.</param>
    /// <returns>A random value.</returns>
    [UsedImplicitly]
    public static long GenerateRandom(
        long min,
        long max) =>
        RandomNumberGenerator.GenerateInt(
            min,
            max);

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify() => this;

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>
    ///     A deep clone.
    /// </returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new FunctionNodeRandomInt(
            FirstParameter.DeepClone(context),
            SecondParameter.DeepClone(context));

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal() =>
        GenerateStaticBinaryFunctionCall<FunctionNodeRandomInt>(nameof(GenerateRandom));

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance) =>
        GenerateStaticBinaryFunctionCall<FunctionNodeRandomInt>(
            nameof(GenerateRandom),
            tolerance);
}