// <copyright file="QueueCollectionAdapter{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Runtime.Serialization;

namespace IX.Observable.Adapters;

/// <summary>
///     A collection adapter for a queue.
/// </summary>
/// <typeparam name="T">The type of item in the queue.</typeparam>
/// <seealso cref="ModernCollectionAdapter{TItem, TEnumerator}" />
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "QueueAdapterOf{0}",
    ItemName = "Item")]
internal class QueueCollectionAdapter<T> : ModernCollectionAdapter<T, Queue<T>.Enumerator>
{
#region Internal state

    /// <summary>
    ///     The base queue.
    /// </summary>
    private readonly System.Collections.Generic.Queue<T> queue;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="QueueCollectionAdapter{T}" /> class.
    /// </summary>
    /// <param name="queue">The queue.</param>
    internal QueueCollectionAdapter(IEnumerable<T> queue) => this.queue = new System.Collections.Generic.Queue<T>(queue);

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the number of items.
    /// </summary>
    /// <value>The number of items.</value>
    public override int Count => queue.Count;

    /// <summary>
    ///     Gets a value indicating whether this instance is read only.
    /// </summary>
    /// <value><see langword="true" /> if this instance is read only; otherwise, <see langword="false" />.</value>
    public override bool IsReadOnly => false;

#endregion

#region Methods

    /// <summary>
    ///     Adds the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The index of the freshly-added item.</returns>
    public override int Add(T item)
    {
        queue.Enqueue(item);

        return queue.Count - 1;
    }

    /// <summary>
    ///     Clears this instance.
    /// </summary>
    public override void Clear() => queue.Clear();

    /// <summary>
    ///     Determines whether the container list contains the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>
    ///     <see langword="true" /> if the container list contains the specified item; otherwise, <see langword="false" />
    ///     .
    /// </returns>
    public override bool Contains(T item) => queue.Contains(item);

    /// <summary>
    ///     Copies the contents of the container to an array.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="arrayIndex">Index of the array.</param>
    public override void CopyTo(
        T[] array,
        int arrayIndex) =>
        queue.CopyTo(
            array,
            arrayIndex);

    /// <summary>
    ///     Removes the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The index of the removed item, or <c>-1</c> if removal was not successful.</returns>
    public override int Remove(T item) => -1;

    /// <summary>
    ///     De-queues an item from the queue.
    /// </summary>
    /// <returns>An item.</returns>
    public T Dequeue() => queue.Dequeue();

    /// <summary>
    ///     Enqueues the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    public void Enqueue(T item) => queue.Enqueue(item);

    /// <summary>
    ///     Peeks at the top item in the queue.
    /// </summary>
    /// <returns>An item.</returns>
    public T Peek() => queue.Peek();

    /// <summary>
    ///     Converts all items in the stack to an array.
    /// </summary>
    /// <returns>The array of items.</returns>
    public T[] ToArray() => queue.ToArray();

    /// <summary>
    ///     Trims the excess space in the stack.
    /// </summary>
    public void TrimExcess() => queue.TrimExcess();

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public override Queue<T>.Enumerator GetEnumerator() => queue.GetEnumerator();

#endregion
}