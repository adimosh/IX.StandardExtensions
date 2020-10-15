// <copyright file="Stack{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using JetBrains.Annotations;
using GlobalCollectionsGeneric = System.Collections.Generic;

namespace IX.System.Collections.Generic
{
    /// <summary>
    ///     Represents a variable-size last-in first-out (LIFO) collection of instances of the same specified type.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    /// <seealso cref="GlobalCollectionsGeneric.Stack{T}" />
    /// <seealso cref="IStack{T}" />
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "CA1010:Generic interface should also be implemented",
        Justification = "This is not necessary.")]
    public class Stack<T> : GlobalCollectionsGeneric.Stack<T>, IStack<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Stack{T}" /> class.
        /// </summary>
        public Stack()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Stack{T}" /> class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="Stack{T}" /> can contain.</param>
        public Stack(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Stack{T}" /> class.
        /// </summary>
        /// <param name="collection">The collection to copy elements from.</param>
        public Stack(GlobalCollectionsGeneric.IEnumerable<T> collection)
            : base(collection)
        {
        }

        /// <summary>
        ///     Gets a value indicating whether this stack is empty.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this stack is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => this.Count == 0;

        /// <summary>
        ///     Converts from a standard .NET stack.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>An IX Framework abstracted stack.</returns>
        public static Stack<T> FromStack(GlobalCollectionsGeneric.Stack<T> source) =>
            new Stack<T>(source?.ToArray() ?? throw new ArgumentNullException(nameof(source)));

        /// <summary>
        ///     Pushes a range of elements to the top of the stack.
        /// </summary>
        /// <param name="items">The item range to push.</param>
        /// <exception cref="ArgumentNullException">
        ///     items
        ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
        /// </exception>
        public void PushRange(T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (var item in items)
            {
                this.Push(item);
            }
        }

        /// <summary>
        ///     Pushes a range of elements to the top of the stack.
        /// </summary>
        /// <param name="items">The item range to push.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to push.</param>
        /// <exception cref="ArgumentNullException">
        ///     items
        ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     startIndex
        ///     or
        ///     count
        ///     represent an out-of-range set of arguments relative to the input array.
        /// </exception>
        public void PushRange(
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
                this.Push(item);
            }
        }

#if !NETSTANDARD2_1
        /// <summary>
        ///     Attempts to peek at the topmost item from the stack, without removing it.
        /// </summary>
        /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
        /// <returns>
        ///     <see langword="true" /> if an item is peeked at successfully, <see langword="false" /> otherwise, or if the
        ///     stack is empty.
        /// </returns>
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

        /// <summary>
        ///     Attempts to pop the topmost item from the stack, and remove it if successful.
        /// </summary>
        /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
        /// <returns>
        ///     <see langword="true" /> if an item is popped successfully, <see langword="false" /> otherwise, or if the
        ///     stack is empty.
        /// </returns>
        public bool TryPop(out T item)
        {
            if (this.Count == 0)
            {
                item = default!;
                return false;
            }

            item = this.Pop();
            return true;
        }
#endif
    }
}