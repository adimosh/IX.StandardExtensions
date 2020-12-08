// <copyright file="Queue{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using JetBrains.Annotations;
using GlobalCollectionsGeneric = System.Collections.Generic;

namespace IX.System.Collections.Generic
{
    /// <summary>
    ///     Represents a variable-size first-in first-out (FIFO) collection of instances of the same specified type.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    /// <seealso cref="GlobalCollectionsGeneric.Queue{T}" />
    /// <seealso cref="IQueue{T}" />
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "CA1010:Generic interface should also be implemented",
        Justification = "This is not necessary.")]
    public class Queue<T> : GlobalCollectionsGeneric.Queue<T>, IQueue<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Queue{T}" /> class.
        /// </summary>
        public Queue()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Queue{T}" /> class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="Queue{T}" /> can contain.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity" /> is less than zero.</exception>
        public Queue(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Queue{T}" /> class.
        /// </summary>
        /// <param name="collection">The collection to copy elements from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection" /> is <see langword="null" />.</exception>
        public Queue([NotNull] GlobalCollectionsGeneric.IEnumerable<T> collection)
            : base(collection)
        {
        }

        /// <summary>
        ///     Gets a value indicating whether this queue is empty.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this queue is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => this.Count == 0;

        /// <summary>
        ///     Converts from a standard .NET queue.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>An IX Framework abstracted queue.</returns>
        public static Queue<T> FromQueue(GlobalCollectionsGeneric.Queue<T> source) =>
            new Queue<T>(source?.ToArray() ?? throw new ArgumentNullException(nameof(source)));

        /// <summary>
        ///     Queues a range of elements, adding them to the queue.
        /// </summary>
        /// <param name="items">The item range to push.</param>
        /// <exception cref="ArgumentNullException">
        ///     items
        ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
        /// </exception>
        public void EnqueueRange(T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (var item in items)
            {
                this.Enqueue(item);
            }
        }

        /// <summary>
        ///     Queues a range of elements, adding them to the queue.
        /// </summary>
        /// <param name="items">The item range to enqueue.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to enqueue.</param>
        /// <exception cref="ArgumentNullException">
        ///     items
        ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" />
        ///     or
        ///     <paramref name="count" />
        ///     represent an out-of-range set of arguments relative to the input array.
        /// </exception>
        public void EnqueueRange(
            T[] items,
            int startIndex,
            int count)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (startIndex < 0 || startIndex >= items.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count <= 0 || count + startIndex > items.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            T[] innerArray = new T[count];
            Array.Copy(
                items,
                startIndex,
                innerArray,
                0,
                count);

            foreach (var item in items)
            {
                this.Enqueue(item);
            }
        }

#if !FRAMEWORK_ADVANCED
        /// <summary>
        ///     Attempts to de-queue an item and to remove it from queue.
        /// </summary>
        /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
        /// <returns>
        ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
        ///     queue is empty.
        /// </returns>
        public bool TryDequeue(out T item)
        {
            if (this.Count == 0)
            {
                item = default!;
                return false;
            }

            item = this.Dequeue();
            return true;
        }

        /// <summary>
        ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
        /// </summary>
        /// <param name="item">The item, or default if unsuccessful.</param>
        /// <returns><see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.</returns>
        public bool TryPeek(out T item)
        {
            if (this.Count == 0)
            {
                item = default!;
                return false;
            }

            item = this.Peek();
            return true;
        }
#endif
    }
}