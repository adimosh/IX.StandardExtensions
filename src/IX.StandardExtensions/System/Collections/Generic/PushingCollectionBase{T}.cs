// <copyright file="PushingCollectionBase{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using IX.Abstractions.Collections;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using JetBrains.Annotations;
using Constants = IX.Abstractions.Collections.Constants;

// ReSharper disable once CheckNamespace
namespace IX.System.Collections.Generic;

/// <summary>
///     A base class for pushing collections.
/// </summary>
/// <typeparam name="T">The type of item in the pushing collection.</typeparam>
/// <seealso cref="ReaderWriterSynchronizedBase" />
/// <seealso cref="ICollection" />
[DataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "PushOutQueueOf{0}")]
[PublicAPI]
[SuppressMessage(
    "Design",
    "CA1010:Generic interface should also be implemented",
    Justification = "This is not needed, as we expect derived classes to implement it according to their own needs.")]
[SuppressMessage(
    "Naming",
    "CA1710:Identifiers should have correct suffix",
    Justification = "Analyzer misidentified issue.")]
public abstract class PushingCollectionBase<T> : ReaderWriterSynchronizedBase,
    ICollection
{
#region Internal state

    /// <summary>
    ///     The internal container.
    /// </summary>
    [DataMember(Name = "Items")]
    private List<T> internalContainer;

    /// <summary>
    ///     The limit.
    /// </summary>
    private int limit;

#endregion

#region Constructors and destructors

#region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="PushingCollectionBase{T}" /> class.
    /// </summary>
    /// <param name="limit">The limit.</param>
    /// <exception cref="LimitArgumentNegativeException">
    ///     <paramref name="limit" /> is a negative
    ///     integer.
    /// </exception>
    protected PushingCollectionBase(int limit)
    {
        if (limit < 0)
        {
            throw new LimitArgumentNegativeException(nameof(limit));
        }

        this.limit = limit;

        internalContainer = new List<T>();
    }

#endregion

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the number of elements in the push-out queue.
    /// </summary>
    /// <value>The current element count.</value>
    public int Count
    {
        get
        {
            ThrowIfCurrentObjectDisposed();

            using (ReadLock())
            {
                return internalContainer.Count;
            }
        }
    }

    /// <summary>
    ///     Gets a value indicating whether this pushing collection is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this pushing collection is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => Count == 0;

    /// <summary>
    ///     Gets a value indicating whether access to the <see cref="ICollection" /> is synchronized
    ///     (thread safe).
    /// </summary>
    /// <value><see langword="true" /> if this instance is synchronized; otherwise, <see langword="false" />.</value>
    bool ICollection.IsSynchronized => ((ICollection)internalContainer).IsSynchronized;

    /// <summary>
    ///     Gets an object that can be used to synchronize access to the <see cref="ICollection" />.
    /// </summary>
    /// <value>The synchronize root.</value>
    object ICollection.SyncRoot => ((ICollection)internalContainer).SyncRoot;

    /// <summary>
    ///     Gets or sets the number of items in the push-down stack.
    /// </summary>
    [DataMember]
    public int Limit
    {
        get => limit;
        set
        {
            ThrowIfCurrentObjectDisposed();

            if (value < 0)
            {
                throw new LimitArgumentNegativeException();
            }

            using (WriteLock())
            {
                limit = value;

                if (value != 0)
                {
                    while (internalContainer.Count > value)
                    {
                        internalContainer.RemoveAt(0);
                    }
                }
                else
                {
                    internalContainer.Clear();
                }
            }
        }
    }

    /// <summary>
    ///     Gets the internal container.
    /// </summary>
    /// <value>
    ///     The internal container.
    /// </value>
    protected List<T> InternalContainer => internalContainer;

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Copies the elements of the <see cref="PushingCollectionBase{T}" /> to an <see cref="Array" />,
    ///     starting at a particular <see cref="Array" /> index.
    /// </summary>
    /// <param name="array">
    ///     The one-dimensional <see cref="Array" /> that is the destination of the elements copied
    ///     from <see cref="PushingCollectionBase{T}" />. The <see cref="Array" /> must have zero-based
    ///     indexing.
    /// </param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    public void CopyTo(
        Array array,
        int index)
    {
        ThrowIfCurrentObjectDisposed();

        using (ReadLock())
        {
            ((ICollection)internalContainer).CopyTo(
                array,
                index);
        }
    }

    /// <summary>
    ///     Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>An <see cref="IEnumerator" /> object that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    [ExcludeFromCodeCoverage]
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

#endregion

    /// <summary>
    ///     Clears the observable stack.
    /// </summary>
    public void Clear()
    {
        ThrowIfCurrentObjectDisposed();

        using (WriteLock())
        {
            internalContainer.Clear();
        }
    }

    /// <summary>
    ///     Checks whether or not a certain item is in the stack.
    /// </summary>
    /// <param name="item">The item to check for.</param>
    /// <returns><see langword="true" /> if the item was found, <see langword="false" /> otherwise.</returns>
    public bool Contains(T item)
    {
        ThrowIfCurrentObjectDisposed();

        using (ReadLock())
        {
            return internalContainer.Contains(item);
        }
    }

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "We need this allocation here.")]
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We're returning a class enumerator, so we're expecting an allocation anyway.")]
    public IEnumerator<T> GetEnumerator() =>
        AtomicEnumerator<T>.FromCollection(
            internalContainer,
            ReadLock);

    /// <summary>
    ///     Copies all elements of the stack to a new array.
    /// </summary>
    /// <returns>An array containing all items in the stack.</returns>
    public T[] ToArray()
    {
        ThrowIfCurrentObjectDisposed();

        using (ReadLock())
        {
            return internalContainer.ToArray();
        }
    }

#region Disposable

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        Interlocked.Exchange(
                ref internalContainer,
                null!)
            ?.Clear();
    }

#endregion

    /// <summary>
    ///     Appends the specified item to this pushing collection.
    /// </summary>
    /// <param name="item">The item to append.</param>
    protected void Append(T item)
    {
        ThrowIfCurrentObjectDisposed();

        if (Limit == 0)
        {
            return;
        }

        using (WriteLock())
        {
            if (InternalContainer.Count == Limit)
            {
                InternalContainer.RemoveAt(0);
            }

            InternalContainer.Add(item);
        }
    }

    /// <summary>
    ///     Appends the specified items to this pushing collection.
    /// </summary>
    /// <param name="items">The items to append.</param>
    protected void Append(T[] items)
    {
        // Validate input
        ThrowIfCurrentObjectDisposed();
        Requires.NotNull(
            items,
            nameof(items));

        // Check disabled collection
        if (Limit == 0)
        {
            return;
        }

        // Lock on write
        using (WriteLock())
        {
            foreach (T item in items)
            {
                InternalContainer.Add(item);

                if (InternalContainer.Count == Limit + 1)
                {
                    InternalContainer.RemoveAt(0);
                }
            }
        }
    }

    /// <summary>
    ///     Appends the specified items to the pushing collection.
    /// </summary>
    /// <param name="items">The items to append.</param>
    /// <param name="startIndex">The start index in the array to begin taking items from.</param>
    /// <param name="count">The number of items to append.</param>
    protected void Append(
        T[] items,
        int startIndex,
        int count)
    {
        // Validate input
        ThrowIfCurrentObjectDisposed();
        Requires.NotNull(
            items,
            nameof(items));
        Requires.ValidArrayRange(
            in startIndex,
            in count,
            items,
            nameof(items));

        // Check disabled collection
        var innerLimit = Limit;
        if (innerLimit == 0)
        {
            return;
        }

        var copiedItems = new ReadOnlySpan<T>(
            items,
            startIndex,
            count);

        // Lock on write
        using (WriteLock())
        {
            // Add all items
            List<T> innerInternalContainer = InternalContainer;
            foreach (T item in copiedItems)
            {
                innerInternalContainer.Add(item);

                if (innerInternalContainer.Count == innerLimit + 1)
                {
                    innerInternalContainer.RemoveAt(0);
                }
            }
        }
    }

#endregion
}