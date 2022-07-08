// <copyright file="RepeatableStack{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace IX.System.Collections.Generic;

/// <summary>
///     A stack that is able to accurately repeat the sequence of items that has been popped from it.
/// </summary>
/// <typeparam name="T">The type of items contained in this stack.</typeparam>
/// <seealso cref="IStack{T}" />
[PublicAPI]
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is not necessary.")]
public class RepeatableStack<T> : IStack<T>
{
#region Internal state

    private readonly List<T> internalRepeatingStack;
    private readonly IStack<T> internalStack;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="RepeatableStack{T}" /> class.
    /// </summary>
    public RepeatableStack()
    {
        internalStack = new Stack<T>();
        internalRepeatingStack = new List<T>();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RepeatableStack{T}" /> class.
    /// </summary>
    /// <param name="originalStack">The original stack.</param>
    /// <remarks>
    ///     <para>
    ///         Please note that the <paramref name="originalStack" /> will be taken and used as a source for this repeatable
    ///         stack, meaning that operations on this instance
    ///         will reflect to the original.
    ///     </para>
    /// </remarks>
    public RepeatableStack(IStack<T> originalStack)
    {
        Requires.NotNull(
            out internalStack,
            originalStack,
            nameof(originalStack));
        internalRepeatingStack = new List<T>();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="RepeatableStack{T}" /> class.
    /// </summary>
    /// <param name="originalData">The original data.</param>
    public RepeatableStack(IEnumerable<T> originalData)
    {
        Requires.NotNull(
            originalData,
            nameof(originalData));
        internalStack = new Stack<T>(originalData);
        internalRepeatingStack = new List<T>();
    }

#endregion

#region Properties and indexers

    /// <summary>Gets the number of elements in the collection.</summary>
    /// <returns>The number of elements in the collection. </returns>
    public int Count => ((IReadOnlyCollection<T>)internalStack).Count;

    /// <summary>
    ///     Gets a value indicating whether this stack is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this stack is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => Count == 0;

    /// <summary>
    ///     Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized (thread safe).
    /// </summary>
    public bool IsSynchronized => false;

    /// <summary>
    ///     Gets an object that can be used to synchronize access to the <see cref="ICollection" />.
    /// </summary>
    public object SyncRoot => internalStack;

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Copies the elements of the <see cref="ICollection" /> to an <see cref="Array" />, starting at a particular
    ///     <see cref="Array" /> index.
    /// </summary>
    /// <param name="array">
    ///     The one-dimensional <see cref="Array" /> that is the destination of the elements copied from
    ///     <see cref="ICollection" />. The <see cref="Array" /> must have zero-based indexing.
    /// </param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    public void CopyTo(
        Array array,
        int index) =>
        internalStack.CopyTo(
            array,
            index);

    /// <summary>Returns an enumerator that iterates through the collection.</summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    public IEnumerator<T> GetEnumerator() => internalStack.GetEnumerator();

    /// <summary>
    ///     Clears the observable stack.
    /// </summary>
    public void Clear() => internalStack.Clear();

    /// <summary>
    ///     Checks whether or not a certain item is in the stack.
    /// </summary>
    /// <param name="item">The item to check for.</param>
    /// <returns><see langword="true" /> if the item was found, <see langword="false" /> otherwise.</returns>
    public bool Contains(T item) => internalStack.Contains(item);

    /// <summary>
    ///     Peeks in the stack to view the topmost item, without removing it.
    /// </summary>
    /// <returns>The topmost element in the stack, if any.</returns>
    public T Peek() => internalStack.Peek();

    /// <summary>
    ///     Pops the topmost element from the stack, removing it.
    /// </summary>
    /// <returns>The topmost element in the stack, if any.</returns>
    public T Pop()
    {
        T item = internalStack.Pop();
        internalRepeatingStack.Add(item);

        return item;
    }

    /// <summary>
    ///     Pushes an element to the top of the stack.
    /// </summary>
    /// <param name="item">The item to push.</param>
    public void Push(T item) => internalStack.Push(item);

    /// <summary>
    ///     Pushes a range of elements to the top of the stack.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    public void PushRange(T[] items) => internalStack.PushRange(items);

    /// <summary>
    ///     Pushes a range of elements to the top of the stack.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to push.</param>
    public void PushRange(
        T[] items,
        int startIndex,
        int count) =>
        internalStack.PushRange(
            items,
            startIndex,
            count);

    /// <summary>
    ///     Copies all elements of the stack to a new array.
    /// </summary>
    /// <returns>An array containing all items in the stack.</returns>
    public T[] ToArray() => internalStack.ToArray();

    /// <summary>
    ///     Sets the capacity to the actual number of elements in the stack if that number is less than 90 percent of current
    ///     capacity.
    /// </summary>
    public void TrimExcess() => internalStack.TrimExcess();

    /// <summary>
    ///     Attempts to peek at the topmost item from the stack, without removing it.
    /// </summary>
    /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is peeked at successfully, <see langword="false" /> otherwise, or if the
    ///     stack is empty.
    /// </returns>
    public bool TryPeek([MaybeNullWhen(false)] out T item) => internalStack.TryPeek(out item);

    /// <summary>
    ///     Attempts to pop the topmost item from the stack, and remove it if successful.
    /// </summary>
    /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is popped successfully, <see langword="false" /> otherwise, or if the
    ///     stack is empty.
    /// </returns>
    public bool TryPop([MaybeNullWhen(false)] out T item)
    {
        if (!internalStack.TryPop(out T? item2))
        {
            item = default;

            return false;
        }

        internalRepeatingStack.Add(item2);
        item = item2;

        return true;
    }

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
    ///     Gets a repeat of the sequence of elements popped from this instance.
    /// </summary>
    /// <returns>A repeating stack.</returns>
    [SuppressMessage(
        "ReSharper",
        "AssignNullToNotNullAttribute",
        Justification = "We want this exception if it occurs.")]
    public IStack<T> Repeat() =>
        new Stack<T>(
            internalRepeatingStack.AsEnumerable()
                .Reverse()
                .ToArray());

#endregion
}