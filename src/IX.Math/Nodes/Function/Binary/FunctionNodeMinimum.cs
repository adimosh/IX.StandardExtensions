// <copyright file="FunctionNodeMinimum.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Linq.Expressions;
using IX.Math.Extensibility;
using IX.Math.Nodes.Constants;
using IX.Math.TypeHelpers;
using JetBrains.Annotations;
using GlobalSystem = System;

namespace IX.Math.Nodes.Function.Binary;

/// <summary>
///     A node representing the <see cref="GlobalSystem.Math.Min(double, double)" /> function.
/// </summary>
/// <seealso cref="NumericBinaryFunctionNodeBase" />
[DebuggerDisplay("min({" + nameof(FirstParameter) + "}, {" + nameof(SecondParameter) + "})")]
[CallableMathematicsFunction(
    "min",
    "minimum")]
[UsedImplicitly]
internal sealed class FunctionNodeMinimum : NumericBinaryFunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FunctionNodeMinimum" /> class.
    /// </summary>
    /// <param name="firstParameter">The first parameter.</param>
    /// <param name="secondParameter">The second parameter.</param>
    public FunctionNodeMinimum(
        NodeBase firstParameter,
        NodeBase secondParameter)
        : base(
            firstParameter?.Simplify(),
            secondParameter?.Simplify())
    {
    }

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>
    ///     A deep clone.
    /// </returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new FunctionNodeMinimum(
            this.FirstParameter.DeepClone(context),
            this.SecondParameter.DeepClone(context));

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify()
    {
        if (!(this.FirstParameter is NumericNode firstParam) || !(this.SecondParameter is NumericNode secondParam))
        {
            // Not simplifyable
            return this;
        }

        (object left, object right, bool isInteger) = NumericTypeHelper.DistillLowestCommonType(
            firstParam.Value,
            secondParam.Value);

        if (isInteger)
        {
            // Both are integer
            return new NumericNode(
                GlobalSystem.Math.Min(
                    (long)left,
                    (long)right));
        }

        // At least one is float
        return new NumericNode(
            GlobalSystem.Math.Min(
                (double)left,
                (double)right));
    }

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    protected override Expression GenerateExpressionInternal() =>
        this.GenerateStaticBinaryFunctionCall(
            typeof(GlobalSystem.Math),
            nameof(GlobalSystem.Math.Min));

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    protected override Expression GenerateExpressionInternal(Tolerance tolerance) =>
        this.GenerateStaticBinaryFunctionCall(
            typeof(GlobalSystem.Math),
            nameof(GlobalSystem.Math.Min),
            tolerance);
}