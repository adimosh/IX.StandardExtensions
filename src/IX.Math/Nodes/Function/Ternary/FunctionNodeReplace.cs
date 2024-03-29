// <copyright file="FunctionNodeReplace.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

using IX.Math.Extensibility;
using IX.Math.Nodes.Constants;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;

using JetBrains.Annotations;

namespace IX.Math.Nodes.Function.Ternary;

/// <summary>
///     A node representing the string replace function.
/// </summary>
/// <seealso cref="TernaryFunctionNodeBase" />
[DebuggerDisplay($"replace({{{nameof(FirstParameter)}}}, {{{nameof(SecondParameter)}}}, {{{nameof(ThirdParameter)}}})")]
[CallableMathematicsFunction(
    "repl",
    "replace")]
[UsedImplicitly]
internal sealed class FunctionNodeReplace : TernaryFunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FunctionNodeReplace" /> class.
    /// </summary>
    /// <param name="stringParameter">The string parameter.</param>
    /// <param name="numericParameter">The numeric parameter.</param>
    /// <param name="secondNumericParameter">The second numeric parameter.</param>
    public FunctionNodeReplace(
        NodeBase stringParameter,
        NodeBase numericParameter,
        NodeBase secondNumericParameter)
        : base(
            Requires.NotNull(stringParameter).Simplify(),
            Requires.NotNull(numericParameter).Simplify(),
            Requires.NotNull(secondNumericParameter).Simplify()) { }

    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>
    ///     The node return type.
    /// </value>
    public override SupportedValueType ReturnType => SupportedValueType.String;

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>
    ///     A deep clone.
    /// </returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new FunctionNodeReplace(
            FirstParameter.DeepClone(context),
            SecondParameter.DeepClone(context),
            ThirdParameter.DeepClone(context));

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify() =>
        FirstParameter is StringNode stringParam && SecondParameter is StringNode numericParam &&
        ThirdParameter is StringNode secondNumericParam
            ? new StringNode(
                stringParam.Value.Replace(
                    numericParam.Value,
                    secondNumericParam.Value))
            : this;

    /// <summary>
    ///     Strongly determines the node's type, if possible.
    /// </summary>
    /// <param name="type">The type to determine to.</param>
    public override void DetermineStrongly(SupportedValueType type)
    {
        if (type != SupportedValueType.String)
        {
            throw new ExpressionNotValidLogicallyException();
        }
    }

    /// <summary>
    ///     Weakly determines the node's type, if possible, and, optionally, strongly determines if there is only one possible
    ///     type left.
    /// </summary>
    /// <param name="type">The type or types to determine to.</param>
    public override void DetermineWeakly(SupportableValueType type)
    {
        if ((type & SupportableValueType.String) == 0)
        {
            throw new ExpressionNotValidLogicallyException();
        }
    }

    /// <summary>
    ///     Ensures the parameters are compatible for this node.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <param name="third">The third.</param>
    protected override void EnsureCompatibleParameters(
        NodeBase first,
        NodeBase second,
        NodeBase third)
    {
        first.DetermineStrongly(SupportedValueType.String);
        second.DetermineStrongly(SupportedValueType.String);
        third.DetermineStrongly(SupportedValueType.String);

        if (first.ReturnType != SupportedValueType.String || second.ReturnType != SupportedValueType.String ||
            third.ReturnType != SupportedValueType.String)
        {
            throw new ExpressionNotValidLogicallyException();
        }
    }

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal() => GenerateExpressionInternal(null);

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance)
    {
        MethodInfo mi = typeof(string).GetMethodWithExactParameters(
            nameof(string.Replace),
            typeof(string),
            typeof(string))!;

        if (mi == null)
        {
            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.FunctionCouldNotBeFound,
                    nameof(string.Replace)));
        }

        Expression e1, e2, e3;

        if (tolerance == null)
        {
            e1 = FirstParameter.GenerateStringExpression();
            e2 = SecondParameter.GenerateStringExpression();
            e3 = ThirdParameter.GenerateStringExpression();
        }
        else
        {
            e1 = FirstParameter.GenerateStringExpression(tolerance);
            e2 = SecondParameter.GenerateStringExpression(tolerance);
            e3 = ThirdParameter.GenerateStringExpression(tolerance);
        }

        return Expression.Call(
            e1,
            mi,
            e2,
            e3);
    }
}