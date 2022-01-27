// <copyright file="QueueDebugView{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.Observable.DebugAide;

/// <summary>
///     A debug view for an observable queue.
/// </summary>
/// <typeparam name="T">The type of object in the queue.</typeparam>
[UsedImplicitly]
public sealed class QueueDebugView<T>
{
#region Internal state

    private readonly ObservableQueue<T> queue;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="QueueDebugView{T}" /> class.
    /// </summary>
    /// <param name="queue">The queue.</param>
    /// <exception cref="ArgumentNullException">queue is null.</exception>
    [UsedImplicitly]
    public QueueDebugView(ObservableQueue<T> queue)
    {
        Requires.NotNull(out this.queue, queue);
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the items.
    /// </summary>
    /// <value>
    ///     The items.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    [UsedImplicitly]
    public T[] Items
    {
        get
        {
            var items = new T[this.queue.InternalContainer.Count];
            this.queue.InternalContainer.CopyTo(
                items,
                0);

            return items;
        }
    }

#endregion
}