// <copyright file="ContextObjectEventArgs{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.StandardExtensions.EventModel;

/// <summary>
///     An event arguments class depicting a context object.
/// </summary>
/// <typeparam name="T">The type of context object to hold.</typeparam>
/// <seealso cref="EventArgs" />
[PublicAPI]
public class ContextObjectEventArgs<T> : EventArgs
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ContextObjectEventArgs{T}" /> class.
    /// </summary>
    /// <param name="contextObject">The context object.</param>
    public ContextObjectEventArgs(T contextObject)
    {
        this.Context = contextObject;
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the context.
    /// </summary>
    /// <value>The context object.</value>
    public T Context { get; }

#endregion
}