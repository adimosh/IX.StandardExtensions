// <copyright file="ObservableReadOnlyCollectionBase{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using IX.Observable.Adapters;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using JetBrains.Annotations;

namespace IX.Observable;

/// <summary>
///     A base class for read-only collections that are observable.
/// </summary>
/// <typeparam name="T">The type of the item.</typeparam>
/// <seealso cref="INotifyPropertyChanged" />
/// <seealso cref="IEnumerable{T}" />
[PublicAPI]
public abstract class ObservableReadOnlyCollectionBase<T> : ObservableBase,
    IReadOnlyCollection<T>,
    ICollection
{
#region Internal state

    private readonly object resetCountLocker = new();
    private readonly ICollectionAdapter<T> internalContainer;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableReadOnlyCollectionBase{T}" /> class.
    /// </summary>
    /// <param name="internalContainer">The internal container of items.</param>
    protected ObservableReadOnlyCollectionBase(ICollectionAdapter<T> internalContainer)
    {
        Requires.NotNull(out this.internalContainer, internalContainer);
        this.internalContainer.MustReset -= this.InternalContainer_MustReset;
        this.internalContainer.MustReset += this.InternalContainer_MustReset;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableReadOnlyCollectionBase{T}" /> class.
    /// </summary>
    /// <param name="internalContainer">The internal container of items.</param>
    /// <param name="context">The synchronization context to use, if any.</param>
    protected ObservableReadOnlyCollectionBase(
        ICollectionAdapter<T> internalContainer,
        SynchronizationContext context)
        : base(context)
    {
        Requires.NotNull(out this.internalContainer, internalContainer);
        this.internalContainer.MustReset -= this.InternalContainer_MustReset;
        this.internalContainer.MustReset += this.InternalContainer_MustReset;
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the number of elements in the collection.
    /// </summary>
    /// <remarks>
    ///     <para>On concurrent collections, this property is read-synchronized.</para>
    /// </remarks>
    public virtual int Count =>
        this.InvokeIfNotDisposed(
            thisL1 => thisL1.ReadLock(
                thisL2 => thisL2.InternalContainer.Count,
                thisL1),
            this);

    /// <summary>
    ///     Gets a value indicating whether the <see cref="ObservableCollectionBase{T}" /> is read-only.
    /// </summary>
    public bool IsReadOnly =>
        this.InvokeIfNotDisposed(
            thisL1 => thisL1.ReadLock(
                thisL2 => thisL2.InternalContainer.IsReadOnly,
                thisL1),
            this);

    /// <summary>
    ///     Gets a value indicating whether this instance is synchronized.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if this instance is synchronized; otherwise, <see langword="false" />.
    /// </value>
    [Obsolete(
        "Please do not explicitly use these properties. The newest .NET Framework guidelines do not recommend doing collection synchronization using them.")]
    public bool IsSynchronized => false;

    /// <summary>
    ///     Gets the synchronization root.
    /// </summary>
    /// <value>
    ///     The synchronization root.
    /// </value>
    /// <remarks>
    ///     <para>
    ///         This property is inexplicably still used to &quot;synchronize&quot; access to the collections, even though MSDN
    ///         members themselves admit that it was a mistake that would not be repeated with generic collections.
    ///     </para>
    ///     <para>It is ill-advised to use it yourself, as it does not synchronize anything.</para>
    ///     <para>This property will always return an object, since UI frameworks (such as the XCeed Avalon) depend on it.</para>
    /// </remarks>
    [Obsolete(
        "Please do not explicitly use these properties. The newest .NET Framework guidelines do not recommend doing collection synchronization using them.")]
    public object SyncRoot { get; } = new();

    /// <summary>
    ///     Gets the internal object container.
    /// </summary>
    /// <value>
    ///     The internal container.
    /// </value>
    protected internal ICollectionAdapter<T> InternalContainer => this.internalContainer;

    /// <summary>
    ///     Gets the ignore reset count.
    /// </summary>
    /// <value>
    ///     The ignore reset count.
    /// </value>
    /// <remarks>
    ///     <para>
    ///         If this count is any number greater than zero, the <see cref="CollectionAdapter{T}.MustReset" /> event will
    ///         be ignored.
    ///     </para>
    ///     <para>
    ///         Each invocation of the collection adapter's <see cref="CollectionAdapter{T}.MustReset" /> event will decrease
    ///         this counter by one until zero.
    ///     </para>
    /// </remarks>
    protected int IgnoreResetCount { get; private set; }

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Returns a locking enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    ///     An atomic enumerator of type <see cref="StandardExtensions.Threading.AtomicEnumerator{TItem,TEnumerator}" /> that
    ///     can be used to iterate through the collection in a thread-safe manner.
    /// </returns>
    /// <remarks>
    ///     <para>This enumerator returns an atomic enumerator.</para>
    ///     <para>
    ///         The atomic enumerator read-locks the collection whenever the <see cref="IEnumerator.MoveNext" /> method is
    ///         called, and the result is cached.
    ///     </para>
    ///     <para>
    ///         The collection, however, cannot be held responsible for changes to the item that is held in
    ///         <see cref="IEnumerator{T}.Current" />.
    ///     </para>
    /// </remarks>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We're doing an atomic enumerator, so we don't care.")]
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "It's for the atomic enumerator.")]
    public virtual IEnumerator<T> GetEnumerator()
    {
        this.RequiresNotDisposed();

        if (this.SynchronizationLock == null)
        {
            return this.InternalContainer.GetEnumerator();
        }

        return AtomicEnumerator<T>.FromCollection(
            (CollectionAdapter<T>)this.InternalContainer,
            this.ReadLock);
    }

    /// <summary>
    ///     Copies the contents of the container to an array.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="index">Index of the array.</param>
    /// <remarks>
    ///     <para>On concurrent collections, this property is read-synchronized.</para>
    /// </remarks>
    void ICollection.CopyTo(
        Array array,
        int index)
    {
        this.RequiresNotDisposed();

        T[] tempArray;

        using (this.ReadLock())
        {
            tempArray = new T[this.InternalContainer.Count - index];
            this.InternalContainer.CopyTo(
                tempArray,
                index);
        }

        tempArray.CopyTo(
            array,
            index);
    }

    /// <summary>
    ///     Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    ///     An <see cref="IEnumerator" /> object that can be used to iterate through the collection.
    /// </returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable with this interface.")]
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

#endregion

    /// <summary>
    ///     Determines whether the <see cref="ObservableCollectionBase{T}" /> contains a specific value.
    /// </summary>
    /// <param name="item">The object to locate in the <see cref="ObservableCollectionBase{T}" />.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="item" /> is found in the <see cref="ObservableCollectionBase{T}" />;
    ///     otherwise, <see langword="false" />.
    /// </returns>
    /// <remarks>
    ///     <para>On concurrent collections, this method is read-synchronized.</para>
    /// </remarks>
    public bool Contains(T item)
    {
        this.RequiresNotDisposed();

        using (this.ReadLock())
        {
            return this.InternalContainer.Contains(item);
        }
    }

    /// <summary>
    ///     Copies the elements of the <see cref="ObservableCollectionBase{T}" /> to an <see cref="Array" />, starting at a
    ///     particular <see cref="Array" /> index.
    /// </summary>
    /// <param name="array">
    ///     The one-dimensional <see cref="Array" /> that is the destination of the elements copied from
    ///     <see cref="ObservableCollectionBase{T}" />. The <see cref="Array" /> must have zero-based indexing.
    /// </param>
    /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    /// <remarks>
    ///     <para>On concurrent collections, this method is read-synchronized.</para>
    /// </remarks>
    public void CopyTo(
        T[] array,
        int arrayIndex)
    {
        this.RequiresNotDisposed();

        using (this.ReadLock())
        {
            this.InternalContainer.CopyTo(
                array,
                arrayIndex);
        }
    }

    /// <summary>
    ///     Copies the elements of the <see cref="ObservableCollectionBase{T}" /> to a new <see cref="Array" />, starting at a
    ///     particular index.
    /// </summary>
    /// <param name="fromIndex">The zero-based index from which which copying begins.</param>
    /// <returns>A newly-formed array.</returns>
    /// <remarks>On concurrent collections, this method is read-synchronized.</remarks>
    public T[] CopyToArray(int fromIndex)
    {
        this.RequiresNotDisposed();

        using (this.ReadLock())
        {
            var containerCount = this.InternalContainer.Count;

            if (fromIndex >= containerCount || fromIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(fromIndex));
            }

            T[] array;

            if (fromIndex == 0)
            {
                array = new T[containerCount];
                this.InternalContainer.CopyTo(
                    array,
                    0);
            }
            else
            {
                array = this.InternalContainer.Skip(fromIndex)
                    .ToArray();
            }

            return array;
        }
    }

    /// <summary>
    ///     Copies the elements of the <see cref="ObservableCollectionBase{T}" /> to a new <see cref="Array" />.
    /// </summary>
    /// <returns>A newly-formed array.</returns>
    /// <remarks>On concurrent collections, this method is read-synchronized.</remarks>
    public T[] CopyToArray()
    {
        this.RequiresNotDisposed();

        using (this.ReadLock())
        {
            var containerCount = this.InternalContainer.Count;

            var array = new T[containerCount];
            this.InternalContainer.CopyTo(
                array,
                0);

            return array;
        }
    }

#region Disposable

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    [SuppressMessage(
        "ReSharper",
        "EmptyGeneralCatchClause",
        Justification = "Acceptable.")]
    protected override void DisposeManagedContext()
    {
        try
        {
            this.internalContainer.Clear();
        }
        catch
        {
        }

        base.DisposeManagedContext();
    }

#endregion

    /// <summary>
    ///     Increases the <see cref="IgnoreResetCount" /> by one.
    /// </summary>
    protected void IncreaseIgnoreMustResetCounter()
    {
        lock (this.resetCountLocker)
        {
            this.IgnoreResetCount++;
        }
    }

    /// <summary>
    ///     Increases the <see cref="IgnoreResetCount" /> by one.
    /// </summary>
    /// <param name="increaseBy">The amount to increase by.</param>
    protected void IncreaseIgnoreMustResetCounter(int increaseBy)
    {
        lock (this.resetCountLocker)
        {
            this.IgnoreResetCount += increaseBy;
        }
    }

    /// <summary>
    ///     Called when the contents may have changed so that proper notifications can happen.
    /// </summary>
    protected virtual void ContentsMayHaveChanged() { }

    private void InternalContainer_MustReset(
        object? sender,
        EventArgs e) =>
        this.Invoke(
            thisL1 =>
            {
                bool shouldReset;
                lock (thisL1.resetCountLocker)
                {
                    if (thisL1.IgnoreResetCount > 0)
                    {
                        thisL1.IgnoreResetCount--;
                        shouldReset = false;
                    }
                    else
                    {
                        shouldReset = true;
                    }
                }

                if (!shouldReset)
                {
                    return;
                }

                thisL1.RaiseCollectionReset();
                thisL1.RaisePropertyChanged(nameof(thisL1.Count));
                thisL1.ContentsMayHaveChanged();
            },
            this);

#endregion
}