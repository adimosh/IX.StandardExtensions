// <copyright file="FunctionNodeDecimalLogarithm.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Linq.Expressions;
using IX.Math.Extensibility;
using IX.Math.Nodes.Constants;
using JetBrains.Annotations;
using GlobalSystem = System;

namespace IX.Math.Nodes.Function.Unary;

/// <summary>
///     A node representing the <see cref="GlobalSystem.Math.Log10(double)" /> function.
/// </summary>
/// <seealso cref="NumericUnaryFunctionNodeBase" />
[DebuggerDisplay($"lg({{{nameof(Parameter)}}})")]
[CallableMathematicsFunction("lg")]
[UsedImplicitly]
internal sealed class FunctionNodeDecimalLogarithm : NumericUnaryFunctionNodeBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FunctionNodeDecimalLogarithm" /> class.
    /// </summary>
    /// <param name="parameter">The parameter.</param>
    public FunctionNodeDecimalLogarithm(NodeBase parameter)
        : base(parameter)
    {
    }

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>
    ///     A simplified node, or this instance.
    /// </returns>
    public override NodeBase Simplify()
    {
        if (Parameter is NumericNode numericParam)
        {
            return new NumericNode(GlobalSystem.Math.Log10(numericParam.ExtractFloat()));
        }

        return this;
    }

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>
    ///     A deep clone.
    /// </returns>
    public override NodeBase DeepClone(NodeCloningContext context) =>
        new FunctionNodeDecimalLogarithm(Parameter.DeepClone(context));

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>
    ///     The expression.
    /// </returns>
    protected override Expression GenerateExpressionInternal() =>
        GenerateStaticUnaryFunctionCall(
            typeof(GlobalSystem.Math),
            nameof(GlobalSystem.Math.Log10));

    /// <summary>
    ///     Generates the expression with tolerance that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The expression.</returns>
    protected override Expression GenerateExpressionInternal(Tolerance? tolerance) =>
        GenerateStaticUnaryFunctionCall(
            typeof(GlobalSystem.Math),
            nameof(GlobalSystem.Math.Log10),
            tolerance);
}