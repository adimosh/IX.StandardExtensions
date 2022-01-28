// <copyright file="ModernListAdapter{TItem,TEnumerator}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;

namespace IX.Observable.Adapters;

internal abstract partial class ModernListAdapter<TItem, TEnumerator> : ModernCollectionAdapter<TItem, TEnumerator>, IListAdapter<TItem>
    where TEnumerator : IEnumerator<TItem>
{
#region Properties and indexers

    /// <summary>
    ///     Gets a value indicating whether this instance is fixed size.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if this instance is fixed size; otherwise, <see langword="false" />.
    /// </value>
    /// <remarks>
    ///     <para>Since this is an adapter, this property always returns false.</para>
    /// </remarks>
    public bool IsFixedSize => false;

    /// <summary>
    ///     Gets or sets the item at the specified index.
    /// </summary>
    /// <value>
    ///     The item at the specified index.
    /// </value>
    /// <param name="index">The index.</param>
    /// <returns>The item.</returns>
    public abstract TItem this[int index] { get; set; }

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Determines the index of a specific item, if any.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The index of the item, or <c>-1</c> if not found.</returns>
    public abstract int IndexOf(TItem item);

    /// <summary>
    ///     Inserts an item at the specified index.
    /// </summary>
    /// <param name="index">The index at which to insert.</param>
    /// <param name="item">The item.</param>
    public abstract void Insert(
        int index,
        TItem item);

    /// <summary>
    ///     Removes an item at the specified index.
    /// </summary>
    /// <param name="index">The index at which to remove an item from.</param>
    public abstract void RemoveAt(int index);

#endregion

    /// <summary>
    ///     Adds a range of items to the list.
    /// </summary>
    /// <param name="items">The items.</param>
    /// <returns>The index of the firstly-introduced item.</returns>
    public abstract int AddRange(IEnumerable<TItem> items);

#endregion
}