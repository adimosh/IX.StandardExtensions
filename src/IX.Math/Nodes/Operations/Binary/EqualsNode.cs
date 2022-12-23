// <copyright file="EqualsNode.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.Math.Nodes.Constants;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;

namespace IX.Math.Nodes.Operations.Binary;

/// <summary>
///     A node representing an equation operation.
/// </summary>
/// <seealso cref="ComparisonOperationNodeBase" />
[DebuggerDisplay($"{{{nameof(Left)}}} = {{{nameof(Right)}}}")]
internal sealed class EqualsNode : ComparisonOperationNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EqualsNode" /> class.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    public EqualsNode(
        NodeBase left,
        NodeBase right)
        : base(
            Requires.NotNull(left).Simplify(),
            Requires.NotNull(right).Simplify()) { }

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify() =>
        Left switch
        {
            // NumericNode nnLeft when this.Right is NumericNode nnRight => new BoolNode(
            //    Convert.ToDouble(nnLeft.Value) == Convert.ToDouble(nnRight.Value)),
            StringNode snLeft when Right is StringNode snRight => new BoolNode(snLeft.Value == snRight.Value),
            BoolNode bnLeft when Right is BoolNode bnRight => new BoolNode(bnLeft.Value == bnRight.Value),
            ByteArrayNode baLeft when Right is ByteArrayNode baRight => new BoolNode(
                baLeft.Value.SequenceEqualsWithMsb(baRight.Value)),
            _ => this
        };

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new EqualsNode(
            Left.DeepClone(context),
            Right.DeepClone(context));

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal()
    {
        (Expression leftExpression, Expression rightExpression) = GetExpressionsOfSameTypeFromOperands();

        if (Left.ReturnType == SupportedValueType.ByteArray || Right.ReturnType == SupportedValueType.ByteArray)
        {
            return Expression.Call(
                typeof(ArrayExtensions).GetMethodWithExactParameters(
                    nameof(ArrayExtensions.SequenceEqualsWithMsb),
                    typeof(byte[]),
                    typeof(byte[]))!, leftExpression,
                rightExpression);
        }

        return Expression.Equal(
            leftExpression,
            rightExpression);
    }

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "We want it this way.")]
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance)
    {
        (Expression leftExpression, Expression rightExpression) = GetExpressionsOfSameTypeFromOperands(tolerance);

        if (Left.ReturnType == SupportedValueType.ByteArray || Right.ReturnType == SupportedValueType.ByteArray)
        {
            return Expression.Call(
                typeof(ArrayExtensions).GetMethodWithExactParameters(
                    nameof(ArrayExtensions.SequenceEqualsWithMsb),
                    typeof(byte[]),
                    typeof(byte[]))!, leftExpression,
                rightExpression);
        }

        if (Left.ReturnType == SupportedValueType.Numeric && Right.ReturnType == SupportedValueType.Numeric)
        {
            Expression? possibleTolerantExpression = GenerateNumericalToleranceEquateExpression(
                leftExpression,
                rightExpression,
                tolerance);

            if (possibleTolerantExpression != null)
            {
                // Valid tolerance expression
                return possibleTolerantExpression;
            }
        }

        // Exact equation
        return Expression.Equal(
            leftExpression,
            rightExpression);
    }
}