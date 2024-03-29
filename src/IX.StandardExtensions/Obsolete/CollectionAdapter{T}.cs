// <copyright file="CollectionAdapter{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace IX.Observable.Adapters;

// TODO: Remove in 0.8.0

/// <summary>
///     An adapter class for various collection types.
/// </summary>
/// <typeparam name="T">The type of items in the adapter.</typeparam>
/// <seealso cref="IX.Observable.Adapters.ICollectionAdapter{T}" />
[Obsolete("This type will no longer be exposed in the next major release. Please stop using it immediately. Use your own implementation of ICollectionAdapter interface if you need it.")]
[ExcludeFromCodeCoverage]
public abstract class CollectionAdapter<T> : ICollectionAdapter<T>
{
#region Events

    /// <summary>
    ///     Occurs when the owner of this list adapter must reset.
    /// </summary>
    public event EventHandler? MustReset;

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the number of items.
    /// </summary>
    /// <value>
    ///     The number of items.
    /// </value>
    public abstract int Count { get; }

    /// <summary>
    ///     Gets a value indicating whether this instance is read only.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if this instance is read only; otherwise, <see langword="false" />.
    /// </value>
    public abstract bool IsReadOnly { get; }

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Clears this instance.
    /// </summary>
    public abstract void Clear();

    /// <summary>
    ///     Determines whether the container list contains the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>
    ///     <see langword="true" /> if the container list contains the specified item; otherwise, <see langword="false" />.
    /// </returns>
    public abstract bool Contains(T item);

    /// <summary>
    ///     Copies the contents of the container to an array.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="arrayIndex">Index of the array.</param>
    public abstract void CopyTo(
        T[] array,
        int arrayIndex);

    /// <summary>
    ///     Adds the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The index of the freshly-added item.</returns>
    public abstract int Add(T item);

    /// <summary>
    ///     Removes the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The index of the removed item, or <c>-1</c> if removal was not successful.</returns>
    public abstract int Remove(T item);

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public abstract IEnumerator<T> GetEnumerator();

    /// <summary>Adds an item to the <see cref="ICollection{TItem}" />.</summary>
    /// <param name="item">The object to add to the <see cref="ICollection{TItem}" />.</param>
    /// <exception cref="NotSupportedException">The <see cref="ICollection{TItem}" /> is read-only.</exception>
    [ExcludeFromCodeCoverage]
    void ICollection<T>.Add(T item) => Add(item);

    /// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{TItem}" />.</summary>
    /// <param name="item">The object to remove from the <see cref="ICollection{TItem}" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="item" /> was successfully removed from the
    ///     <see cref="ICollection{TItem}" />; otherwise, <see langword="false" />. This method also returns
    ///     <see langword="false" /> if <paramref name="item" /> is not found in the original <see cref="ICollection{TItem}" />
    ///     .
    /// </returns>
    /// <exception cref="NotSupportedException">The <see cref="ICollection{TItem}" /> is read-only.</exception>
    [ExcludeFromCodeCoverage]
    bool ICollection<T>.Remove(T item) => Remove(item) != -1;

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    [ExcludeFromCodeCoverage]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

#endregion

    /// <summary>
    ///     Triggers the reset.
    /// </summary>
    protected void TriggerReset() =>
        MustReset?.Invoke(
            this,
            EventArgs.Empty);

#endregion
}