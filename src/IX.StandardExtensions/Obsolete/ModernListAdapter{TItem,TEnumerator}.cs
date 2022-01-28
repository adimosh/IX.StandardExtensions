// <copyright file="ModernListAdapter{TItem,TEnumerator}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace IX.Observable.Adapters;

#pragma warning disable CS0618
internal abstract partial class ModernListAdapter<TItem, TEnumerator>
{
#region Methods

#region Operators

    public static implicit operator ListAdapter<TItem>(ModernListAdapter<TItem, TEnumerator> instance) =>
        new ListShim(instance);

#endregion

#endregion

#region Nested types and delegates

    internal class ListShim : ListAdapter<TItem>
    {
#region Internal state

        private readonly ModernListAdapter<TItem, TEnumerator> instance;

#endregion

#region Constructors and destructors

        internal ListShim(ModernListAdapter<TItem, TEnumerator> instance)
        {
            this.instance = instance;
        }

#endregion

#region Properties and indexers

        /// <summary>
        ///     Gets the number of items.
        /// </summary>
        /// <value>
        ///     The number of items.
        /// </value>
        public override int Count => this.instance.Count;

        /// <summary>
        ///     Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///     <see langword="true" /> if this instance is read only; otherwise, <see langword="false" />.
        /// </value>
        public override bool IsReadOnly => this.instance.IsReadOnly;

        /// <summary>
        ///     Gets or sets the item at the specified index.
        /// </summary>
        /// <value>
        ///     The item at the specified index.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The item.</returns>
        public override TItem this[int index]
        {
            get => this.instance[index];
            set => this.instance[index] = value;
        }

#endregion

#region Methods

        /// <summary>
        ///     Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The index of the removed item, or <c>-1</c> if removal was not successful.</returns>
        public override int Remove(TItem item) => this.instance.Remove(item);

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        [SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "We don't care.")]
        public override IEnumerator<TItem> GetEnumerator() => this.instance.GetEnumerator();

        /// <summary>
        ///     Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The index of the freshly-added item.</returns>
        public override int Add(TItem item) => this.instance.Add(item);

        /// <summary>
        ///     Clears this instance.
        /// </summary>
        public override void Clear() => this.instance.Clear();

        /// <summary>
        ///     Determines whether the container list contains the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///     <see langword="true" /> if the container list contains the specified item; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Contains(TItem item) => this.instance.Contains(item);

        /// <summary>
        ///     Copies the contents of the container to an array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public override void CopyTo(
            TItem[] array,
            int arrayIndex) =>
            this.instance.CopyTo(
                array,
                arrayIndex);

        /// <summary>
        ///     Removes an item at the specified index.
        /// </summary>
        /// <param name="index">The index at which to remove an item from.</param>
        public override void RemoveAt(int index) => this.instance.RemoveAt(index);

        /// <summary>
        ///     Adds a range of items to the list.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The index of the firstly-introduced item.</returns>
        public override int AddRange(IEnumerable<TItem> items) => this.instance.AddRange(items);

        /// <summary>
        ///     Determines the index of a specific item, if any.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The index of the item, or <c>-1</c> if not found.</returns>
        public override int IndexOf(TItem item) => this.instance.IndexOf(item);

        /// <summary>
        ///     Inserts an item at the specified index.
        /// </summary>
        /// <param name="index">The index at which to insert.</param>
        /// <param name="item">The item.</param>
        public override void Insert(
            int index,
            TItem item) =>
            this.instance.Insert(
                index,
                item);

#endregion
    }

#endregion
}
#pragma warning restore CS0618