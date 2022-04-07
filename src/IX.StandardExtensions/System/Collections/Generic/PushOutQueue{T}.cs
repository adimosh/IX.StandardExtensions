// <copyright file="PushOutQueue{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using IX.Abstractions.Collections;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace IX.System.Collections.Generic;

/// <summary>
///     A queue that pushes out extra items above a certain limit.
/// </summary>
/// <typeparam name="T">The type of items in the queue.</typeparam>
/// <seealso cref="IX.System.Collections.Generic.PushingCollectionBase{T}" />
/// <seealso cref="IX.System.Collections.Generic.IQueue{T}" />
[DataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "PushOutQueueOf{0}")]
[PublicAPI]
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is really not necessary.")]
public class PushOutQueue<T> : PushingCollectionBase<T>,
    IQueue<T>
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="PushOutQueue{T}" /> class.
    /// </summary>
    public PushOutQueue()
        : this(Constants.DefaultPushDownLimit) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PushOutQueue{T}" /> class.
    /// </summary>
    /// <param name="limit">The limit.</param>
    /// <exception cref="IX.Abstractions.Collections.LimitArgumentNegativeException">
    ///     <paramref name="limit" /> is a negative
    ///     integer.
    /// </exception>
    public PushOutQueue(int limit)
        : base(limit) { }

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Dequeues an item from this push-out queue.
    /// </summary>
    /// <returns>The item.</returns>
    public T Dequeue()
    {
        if (!this.TryDequeue(out T item))
        {
            throw new InvalidOperationException(Resources.ErrorQueueIsEmpty);
        }

        return item;
    }

    /// <summary>
    ///     Enqueues the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    public void Enqueue(T item) => this.Append(item);

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    public void EnqueueRange(T[] items) => this.Append(items);

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
        this.Append(
            items,
            startIndex,
            count);

    /// <summary>
    ///     Peeks in the stack to view the topmost item, without removing it.
    /// </summary>
    /// <returns>The topmost element in the stack, if any.</returns>
    public T Peek()
    {
        if (!this.TryPeek(out T item))
        {
            throw new InvalidOperationException(Resources.ErrorQueueIsEmpty);
        }

        return item;
    }

    /// <summary>
    ///     Attempts to dequeue an item from this push-out queue.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>
    ///     <c>true</c> if the dequeue was successful, <c>false</c> otherwise.
    /// </returns>
    public bool TryDequeue(out T item)
    {
        this.RequiresNotDisposed();

        if (this.Limit == 0)
        {
            item = default!;

            return false;
        }

        using (this.WriteLock())
        {
            if (this.InternalContainer.Count == 0)
            {
                item = default!;

                return false;
            }

            item = this.InternalContainer[0];

            this.InternalContainer.RemoveAt(0);

            return true;
        }
    }

    /// <summary>
    ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
    /// </summary>
    /// <param name="item">The item, or default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.
    /// </returns>
    public bool TryPeek(out T item)
    {
        this.ThrowIfCurrentObjectDisposed();

        if (this.Limit == 0)
        {
            item = default!;

            return false;
        }

        using (this.ReadLock())
        {
            if (this.InternalContainer.Count == 0)
            {
                item = default!;

                return false;
            }

            item = this.InternalContainer[0];

            return true;
        }
    }

    /// <summary>
    ///     This method does nothing.
    /// </summary>
    void IQueue<T>.TrimExcess() { }

#endregion

#endregion
}