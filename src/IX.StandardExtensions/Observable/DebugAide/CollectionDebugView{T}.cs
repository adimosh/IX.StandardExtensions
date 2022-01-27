// <copyright file="CollectionDebugView{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.Observable.DebugAide;

/// <summary>
///     A debug view class for an observable collection.
/// </summary>
/// <typeparam name="T">The type of the collection.</typeparam>
[UsedImplicitly]
public sealed class CollectionDebugView<T>
{
#region Internal state

    private readonly ObservableCollectionBase<T> collection;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="CollectionDebugView{T}" /> class.
    /// </summary>
    /// <param name="collection">The collection.</param>
    /// <exception cref="ArgumentNullException">collection is null.</exception>
    [UsedImplicitly]
    public CollectionDebugView(ObservableCollectionBase<T> collection)
    {
        Requires.NotNull(out this.collection, collection);
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
            var items = new T[this.collection.InternalContainer.Count];
            this.collection.InternalContainer.CopyTo(
                items,
                0);

            return items;
        }
    }

#endregion
}