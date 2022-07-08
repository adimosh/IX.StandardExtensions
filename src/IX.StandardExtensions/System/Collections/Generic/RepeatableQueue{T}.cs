// <copyright file="RepeatableQueue{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.System.Collections.Generic;

/// <summary>
///     A queue that is able to accurately repeat the sequence of items that has been dequeued from it.
/// </summary>
/// <typeparam name="T">The type of items contained in this queue.</typeparam>
/// <seealso cref="IQueue{T}" />
[PublicAPI]
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is not necessary.")]
public class RepeatableQueue<T> : IQueue<T>
{
#region Internal state

    private readonly IQueue<T> internalQueue;
    private readonly IQueue<T> internalRepeatingQueue;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="RepeatableQueue{T}" /> class.
    /// </summary>
    public RepeatableQueue()
    {
        internalQueue = new Queue<T>();
        internalRepeatingQueue = new Queue<T>();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RepeatableQueue{T}" /> class.
    /// </summary>
    /// <param name="originalQueue">The original queue.</param>
    public RepeatableQueue(IQueue<T> originalQueue)
    {
        Requires.NotNull(
            out internalQueue,
            originalQueue,
            nameof(originalQueue));
        internalRepeatingQueue = new Queue<T>();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RepeatableQueue{T}" /> class.
    /// </summary>
    /// <param name="originalData">The original data.</param>
    public RepeatableQueue(IEnumerable<T> originalData)
    {
        Requires.NotNull(
            originalData,
            nameof(originalData));

        internalQueue = new Queue<T>(originalData);
        internalRepeatingQueue = new Queue<T>();
    }

#endregion

#region Properties and indexers

    /// <summary>Gets the number of elements in the collection.</summary>
    /// <returns>The number of elements in the collection. </returns>
    public int Count => ((IReadOnlyCollection<T>)internalQueue).Count;

    /// <summary>
    ///     Gets a value indicating whether this queue is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this queue is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => Count == 0;

    /// <summary>Gets the number of elements contained in the <see cref="ICollection" />.</summary>
    /// <returns>The number of elements contained in the <see cref="ICollection" />.</returns>
    int ICollection.Count => Count;

    /// <summary>
    ///     Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized
    ///     (thread safe).
    /// </summary>
    /// <returns>
    ///     <see langword="true" /> if access to the <see cref="ICollection" /> is synchronized (thread
    ///     safe); otherwise, <see langword="false" />.
    /// </returns>
    bool ICollection.IsSynchronized => internalQueue.IsSynchronized;

    /// <summary>Gets an object that can be used to synchronize access to the <see cref="ICollection" />.</summary>
    /// <returns>An object that can be used to synchronize access to the <see cref="ICollection" />.</returns>
    object ICollection.SyncRoot => internalQueue.SyncRoot;

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Copies the elements of the <see cref="RepeatableQueue{T}" /> to an <see cref="Array" />, starting at
    ///     a particular <see cref="Array" /> index.
    /// </summary>
    /// <param name="array">
    ///     The one-dimensional <see cref="Array" /> that is the destination of the elements copied
    ///     from <see cref="RepeatableQueue{T}" />. The <see cref="Array" /> must have zero-based indexing.
    /// </param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="array" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index" /> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="array" /> is multidimensional.-or- The number of elements in the source
    ///     <see cref="RepeatableQueue{T}" /> is greater than the available space from <paramref name="index" /> to the end of
    ///     the destination <paramref name="array" />.-or-The type of the source <see cref="RepeatableQueue{T}" /> cannot be
    ///     cast automatically to the type of the destination <paramref name="array" />.
    /// </exception>
    public void CopyTo(
        Array array,
        int index) =>
        internalQueue.CopyTo(
            array,
            index);

    /// <summary>Returns an enumerator that iterates through the collection.</summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    public IEnumerator<T> GetEnumerator() => internalQueue.GetEnumerator();

    /// <summary>
    ///     Clears the queue of all elements.
    /// </summary>
    public void Clear()
    {
        internalQueue.Clear();
        internalRepeatingQueue.Clear();
    }

    /// <summary>
    ///     Verifies whether or not an item is contained in the queue.
    /// </summary>
    /// <param name="item">The item to verify.</param>
    /// <returns><see langword="true" /> if the item is queued, <see langword="false" /> otherwise.</returns>
    public bool Contains(T item) => internalQueue.Contains(item);

    /// <summary>
    ///     De-queues an item and removes it from the queue.
    /// </summary>
    /// <returns>The item that has been de-queued.</returns>
    public T Dequeue()
    {
        T dequeuedItem = internalQueue.Dequeue();
        internalRepeatingQueue.Enqueue(dequeuedItem);

        return dequeuedItem;
    }

    /// <summary>
    ///     Queues an item, adding it to the queue.
    /// </summary>
    /// <param name="item">The item to enqueue.</param>
    public void Enqueue(T item) => internalQueue.Enqueue(item);

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    public void EnqueueRange(T[] items) => internalQueue.EnqueueRange(items);

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to enqueue.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to enqueue.</param>
    public void EnqueueRange(
        T[] items,
        int startIndex,
        int count) =>
        internalQueue.EnqueueRange(
            items,
            startIndex,
            count);

    /// <summary>
    ///     Peeks at the topmost element in the queue, without removing it.
    /// </summary>
    /// <returns>The item peeked at, if any.</returns>
    public T Peek() => internalQueue.Peek();

    /// <summary>
    ///     Copies all elements of the queue into a new array.
    /// </summary>
    /// <returns>The created array with all element of the queue.</returns>
    public T[] ToArray() => internalQueue.ToArray();

    /// <summary>
    ///     Trims the excess free space from within the queue, reducing the capacity to the actual number of elements.
    /// </summary>
    public void TrimExcess() => internalQueue.TrimExcess();

    /// <summary>
    ///     Attempts to de-queue an item and to remove it from queue.
    /// </summary>
    /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
    ///     queue is empty.
    /// </returns>
    public bool TryDequeue([MaybeNullWhen(false)] out T item)
    {
        if (!internalQueue.TryDequeue(out item))
        {
            return false;
        }

        internalRepeatingQueue.Enqueue(item);

        return true;
    }

    /// <summary>
    ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
    /// </summary>
    /// <param name="item">The item, or default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.
    /// </returns>
    public bool TryPeek([MaybeNullWhen(false)] out T item) => internalQueue.TryPeek(out item);

    /// <summary>Returns an enumerator that iterates through a collection.</summary>
    /// <returns>An <see cref="IEnumerator" /> object that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    [ExcludeFromCodeCoverage]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

#endregion

    /// <summary>
    ///     Gets a repeat of the sequence of elements dequeued from this instance.
    /// </summary>
    /// <returns>A repeating queue.</returns>
    public IQueue<T> Repeat() => new Queue<T>(internalRepeatingQueue.ToArray());

#endregion
}