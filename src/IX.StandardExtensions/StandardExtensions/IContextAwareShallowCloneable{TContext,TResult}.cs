// <copyright file="IContextAwareShallowCloneable{TContext,TResult}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.StandardExtensions;

/// <summary>
///     Interface for implementing context-aware shallow cloning for an object.
/// </summary>
/// <typeparam name="TContext">The type of the cloning context.</typeparam>
/// <typeparam name="TResult">The type of object to clone.</typeparam>
[PublicAPI]
public interface IContextAwareShallowCloneable<in TContext, out TResult>
    where TContext : notnull
    where TResult : notnull
{
#region Methods

    /// <summary>
    ///     Creates a shallow clone of the source object based on an existing context.
    /// </summary>
    /// <param name="context">The shallow cloning context.</param>
    /// <returns>A shallow clone.</returns>
    TResult ShallowClone(TContext context);

#endregion
}