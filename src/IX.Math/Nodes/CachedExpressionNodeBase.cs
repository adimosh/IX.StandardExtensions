// <copyright file="CachedExpressionNodeBase.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Linq.Expressions;
using JetBrains.Annotations;

namespace IX.Math.Nodes;

/// <summary>
///     A node base that caches its generated expression.
/// </summary>
/// <seealso cref="NodeBase" />
[PublicAPI]
public abstract class CachedExpressionNodeBase : NodeBase
{
    private Expression? generatedExpression;
    private Expression? generatedStringExpression;

    /// <summary>
    /// Prevents a default instance of the <see cref="CachedExpressionNodeBase"/> class from being created.
    /// </summary>
    protected private CachedExpressionNodeBase()
    {
    }

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <returns>The generated <see cref="Expression" />.</returns>
    public sealed override Expression GenerateExpression() =>
        generatedExpression ??= GenerateCachedExpression();

    /// <summary>
    ///     Generates the expression that will be compiled into code.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>
    ///     The generated <see cref="Expression" />.
    /// </returns>
    public sealed override Expression GenerateExpression(Tolerance? tolerance) =>
        generatedExpression ??= GenerateCachedExpression(tolerance);

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <returns>The generated <see cref="Expression" /> that gives the values as a string.</returns>
    public sealed override Expression GenerateStringExpression() =>
        generatedStringExpression ??= GenerateCachedStringExpression();

    /// <summary>
    ///     Generates the expression that will be compiled into code as a string expression.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The generated <see cref="Expression" /> that gives the values as a string.</returns>
    public override Expression GenerateStringExpression(Tolerance? tolerance) =>
        generatedStringExpression ??= GenerateCachedStringExpression(tolerance);

    /// <summary>
    ///     Generates an expression that will be cached before being compiled.
    /// </summary>
    /// <returns>The generated <see cref="Expression" /> to be cached.</returns>
    public abstract Expression GenerateCachedExpression();

    /// <summary>
    ///     Generates an expression with tolerance that will be cached before being compiled.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>
    ///     The generated <see cref="Expression" /> to be cached.
    /// </returns>
    public virtual Expression GenerateCachedExpression(Tolerance? tolerance) => GenerateCachedExpression();

    /// <summary>
    ///     Generates a string expression that will be cached before being compiled.
    /// </summary>
    /// <returns>The generated <see cref="Expression" /> to be cached.</returns>
    public abstract Expression GenerateCachedStringExpression();

    /// <summary>
    ///     Generates a string expression that will be cached before being compiled.
    /// </summary>
    /// <param name="tolerance">The tolerance.</param>
    /// <returns>The generated <see cref="Expression" /> to be cached.</returns>
    public virtual Expression GenerateCachedStringExpression(Tolerance? tolerance) =>
        GenerateCachedStringExpression();
}