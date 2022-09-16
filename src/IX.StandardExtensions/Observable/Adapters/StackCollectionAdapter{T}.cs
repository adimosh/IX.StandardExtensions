// <copyright file="StackCollectionAdapter{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Runtime.Serialization;

namespace IX.Observable.Adapters;

/// <summary>
///     A collection adapter for a stack.
/// </summary>
/// <typeparam name="T">The type of item in the stack.</typeparam>
/// <seealso cref="ModernCollectionAdapter{TItem, TEnumerator}" />
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "StackAdapterOf{0}",
    ItemName = "Item")]
internal class StackCollectionAdapter<T> : ModernCollectionAdapter<T, System.Collections.Generic.Stack<T>.Enumerator>
{
#region Internal state

    /// <summary>
    ///     The base stack.
    /// </summary>
    private readonly System.Collections.Generic.Stack<T> stack;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="StackCollectionAdapter{T}" /> class.
    /// </summary>
    /// <param name="stack">The stack.</param>
    internal StackCollectionAdapter(IEnumerable<T> stack) => this.stack = new(stack);

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the number of items.
    /// </summary>
    /// <value>The number of items.</value>
    public override int Count => stack.Count;

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
        stack.Push(item);

        return stack.Count - 1;
    }

    /// <summary>
    ///     Clears this instance.
    /// </summary>
    public override void Clear() => stack.Clear();

    /// <summary>
    ///     Determines whether the container list contains the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>
    ///     <see langword="true" /> if the container list contains the specified item; otherwise, <see langword="false" />
    ///     .
    /// </returns>
    public override bool Contains(T item) => stack.Contains(item);

    /// <summary>
    ///     Copies the contents of the container to an array.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="arrayIndex">Index of the array.</param>
    public override void CopyTo(
        T[] array,
        int arrayIndex) =>
        stack.CopyTo(
            array,
            arrayIndex);

    /// <summary>
    ///     Removes the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The index of the removed item, or <c>-1</c> if removal was not successful.</returns>
    public override int Remove(T item) => -1;

    /// <summary>
    ///     Pops an item in the stack.
    /// </summary>
    /// <returns>T.</returns>
    public T Pop() => stack.Pop();

    /// <summary>
    ///     Peeks at the top item in the stack.
    /// </summary>
    /// <returns>T.</returns>
    public T Peek() => stack.Peek();

    /// <summary>
    ///     Pushes the specified item in the stack.
    /// </summary>
    /// <param name="item">The item.</param>
    public void Push(T item) => stack.Push(item);

    /// <summary>
    ///     Converts all items in the stack to an array.
    /// </summary>
    /// <returns>The array of items.</returns>
    public T[] ToArray() => stack.ToArray();

    /// <summary>
    ///     Trims the excess space in the stack.
    /// </summary>
    public void TrimExcess() => stack.TrimExcess();

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public override System.Collections.Generic.Stack<T>.Enumerator GetEnumerator() => stack.GetEnumerator();

#endregion
}