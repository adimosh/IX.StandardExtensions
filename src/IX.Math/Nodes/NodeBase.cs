// <copyright file="NodeBase.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using IX.StandardExtensions;

using JetBrains.Annotations;

namespace IX.Math.Nodes;

/// <summary>
///     A base class for mathematics nodes.
/// </summary>
/// <seealso cref="IDeepCloneable{T}" />
[PublicAPI]
public abstract class NodeBase : IContextAwareDeepCloneable<NodeCloningContext, NodeBase>
{
    /// <summary>
    ///     Prevents a default instance of the <see cref="NodeBase" /> class from being created.
    /// </summary>
    protected private NodeBase() { }

    /// <summary>
    ///     Gets a value indicating whether or not this node is actually a constant.
    /// </summary>
    /// <value><see langword="true" /> if the node is a constant, <see langword="false" /> otherwise.</value>
    public abstract bool IsConstant { get; }

    /// <summary>
    ///     Gets a value indicating whether this node supports tolerance.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is tolerant; otherwise, <c>false</c>.
    /// </value>
    public abstract bool IsTolerant { get; }

    /// <summary>
    ///     Gets the return type of this node.
    /// </summary>
    /// <value>The node return type.</value>
    public abstract SupportedValueType ReturnType { get; }

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <param name="context">The deep cloning context.</param>
    /// <returns>A deep clone.</returns>
    public abstract NodeBase DeepClone(NodeCloningContext context);

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>The generated <see cref="Expression" />.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public abstract Expression GenerateExpression();

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>
    ///     The generated <see cref="Expression" />.
    /// </returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public virtual Expression GenerateExpression(Tolerance? tolerance) => GenerateExpression();

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <returns>The generated <see cref="Expression" /> that gives the values as a string.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public abstract Expression GenerateStringExpression();

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The generated <see cref="Expression" /> that gives the values as a string.</returns>
    [RequiresUnreferencedCode(
        "This method uses reflection to get in-depth type information and to build a compiled expression tree.")]
    public virtual Expression GenerateStringExpression(Tolerance? tolerance) => GenerateStringExpression();

    /// <summary>
    ///     Simplifies this node, if possible, reflexively returns otherwise.
    /// </summary>
    /// <returns>A simplified node, or this instance.</returns>
    public abstract NodeBase Simplify();

    /// <summary>
    ///     Strongly determines the node's type, if possible.
    /// </summary>
    /// <param name="type">The type to determine to.</param>
    public abstract void DetermineStrongly(SupportedValueType type);

    /// <summary>
    ///     Weakly determines the node's type, if possible, and, optionally, strongly determines if there is only one possible
    ///     type left.
    /// </summary>
    /// <param name="type">The type or types to determine to.</param>
    public abstract void DetermineWeakly(SupportableValueType type);
}