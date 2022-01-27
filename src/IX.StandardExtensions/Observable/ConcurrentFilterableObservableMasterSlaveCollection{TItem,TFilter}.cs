// <copyright file="ConcurrentFilterableObservableMasterSlaveCollection{TItem,TFilter}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using IX.Observable.DebugAide;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using IX.System.Threading;
using JetBrains.Annotations;
using GlobalThreading = System.Threading;

namespace IX.Observable;

/// <summary>
///     An observable collection created from a master collection (to which updates go) and many slave, read-only
///     collections, whose items can also be filtered.
/// </summary>
/// <typeparam name="TItem">The type of the item.</typeparam>
/// <typeparam name="TFilter">The type of the filter.</typeparam>
/// <seealso cref="IX.Observable.ObservableMasterSlaveCollection{T}" />
[DebuggerDisplay("Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(CollectionDebugView<>))]
[PublicAPI]
public class ConcurrentFilterableObservableMasterSlaveCollection<TItem, TFilter> :
    ConcurrentObservableMasterSlaveCollection<TItem>
{
#region Internal state

    private IList<TItem>? cachedFilteredElements;

    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable.",
        Justification = "It is, but the analyzer can't tell.")]
    private IReaderWriterLock cacheLocker;

    private TFilter? filter;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="ConcurrentFilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    public ConcurrentFilterableObservableMasterSlaveCollection(Func<TItem, TFilter, bool> filteringPredicate)
    {
        this.FilteringPredicate = Requires.NotNull(filteringPredicate);
        this.cacheLocker = new ReaderWriterLockSlim(GlobalThreading.LockRecursionPolicy.NoRecursion);
    }

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="ConcurrentFilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    public ConcurrentFilterableObservableMasterSlaveCollection(
        Func<TItem, TFilter, bool> filteringPredicate,
        GlobalThreading.SynchronizationContext context)
        : base(context)
    {
        this.FilteringPredicate = Requires.NotNull(filteringPredicate);
        this.cacheLocker = new ReaderWriterLockSlim(GlobalThreading.LockRecursionPolicy.NoRecursion);
    }

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="ConcurrentFilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentFilterableObservableMasterSlaveCollection(
        Func<TItem, TFilter, bool> filteringPredicate,
        bool suppressUndoable)
        : base(suppressUndoable)
    {
        this.FilteringPredicate = Requires.NotNull(filteringPredicate);
        this.cacheLocker = new ReaderWriterLockSlim(GlobalThreading.LockRecursionPolicy.NoRecursion);
    }

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="ConcurrentFilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentFilterableObservableMasterSlaveCollection(
        Func<TItem, TFilter, bool> filteringPredicate,
        GlobalThreading.SynchronizationContext context,
        bool suppressUndoable)
        : base(
            context,
            suppressUndoable)
    {
        this.FilteringPredicate = Requires.NotNull(filteringPredicate);
        this.cacheLocker = new ReaderWriterLockSlim(GlobalThreading.LockRecursionPolicy.NoRecursion);
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the number of items in the collection.
    /// </summary>
    /// <value>
    ///     The item count.
    /// </value>
    public override int Count
    {
        get
        {
            if (this.IsFilter())
            {
                return this.CheckAndCache()
                    .Count;
            }

            return base.Count;
        }
    }

    /// <summary>
    ///     Gets the filtering predicate.
    /// </summary>
    /// <value>
    ///     The filtering predicate.
    /// </value>
    public Func<TItem, TFilter, bool> FilteringPredicate { get; }

    /// <summary>
    ///     Gets or sets the filter value.
    /// </summary>
    /// <value>
    ///     The filter value.
    /// </value>
    public TFilter? Filter
    {
        get => this.filter;
        set
        {
            this.filter = value;

            this.ClearCachedContents();

            this.RaiseCollectionReset();
            this.RaisePropertyChanged(nameof(this.Count));
            this.RaisePropertyChanged(Constants.ItemsName);
        }
    }

#endregion

#region Methods

    /// <summary>
    ///     Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    ///     An enumerator that can be used to iterate through the collection.
    /// </returns>
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We have to allocate an atomic enumerator.")]
    public override IEnumerator<TItem> GetEnumerator()
    {
        if (this.IsFilter())
        {
            return this.CheckAndCache()
                .GetEnumerator();
        }

        return base.GetEnumerator();
    }

#region Disposable

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        GlobalThreading.Interlocked.Exchange(
                ref this.cacheLocker,
                null!)
            ?.Dispose();
    }

#endregion

    /// <summary>
    ///     Called when an item is added to a collection.
    /// </summary>
    /// <param name="addedItem">The added item.</param>
    /// <param name="index">The index.</param>
    protected override void RaiseCollectionChangedAdd(
        TItem addedItem,
        int index)
    {
        if (this.IsFilter())
        {
            this.RaiseCollectionReset();
        }
        else
        {
            base.RaiseCollectionChangedAdd(
                addedItem,
                index);
        }
    }

    /// <summary>
    ///     Called when an item in a collection is changed.
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    /// <param name="newItem">The new item.</param>
    /// <param name="index">The index.</param>
    protected override void RaiseCollectionChangedChanged(
        TItem oldItem,
        TItem newItem,
        int index)
    {
        if (this.IsFilter())
        {
            this.RaiseCollectionReset();
        }
        else
        {
            base.RaiseCollectionChangedChanged(
                oldItem,
                newItem,
                index);
        }
    }

    /// <summary>
    ///     Called when an item is removed from a collection.
    /// </summary>
    /// <param name="removedItem">The removed item.</param>
    /// <param name="index">The index.</param>
    protected override void RaiseCollectionChangedRemove(
        TItem removedItem,
        int index)
    {
        if (this.IsFilter())
        {
            this.RaiseCollectionReset();
        }
        else
        {
            base.RaiseCollectionChangedRemove(
                removedItem,
                index);
        }
    }

    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We have to allocate an atomic enumerator.")]
    private IEnumerator<TItem> EnumerateFiltered()
    {
        TFilter? internalFilter = this.Filter;

        using IEnumerator<TItem> enumerator = base.GetEnumerator();

        if (internalFilter is null)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
        else
        {
            while (enumerator.MoveNext())
            {
                TItem current = enumerator.Current;
                if (this.FilteringPredicate(
                        current,
                        internalFilter))
                {
                    yield return current;
                }
            }
        }
    }

    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We have to allocate an atomic enumerator.")]
    private IList<TItem> CheckAndCache()
    {
        using var locker = new ReadWriteSynchronizationLocker(this.cacheLocker);

        if (this.cachedFilteredElements != null)
        {
            return this.cachedFilteredElements;
        }

        locker.Upgrade();

        this.cachedFilteredElements = new List<TItem>(this.InternalContainer.Count);

        using IEnumerator<TItem> enumerator = this.EnumerateFiltered();

        while (enumerator.MoveNext())
        {
            TItem current = enumerator.Current;
            this.cachedFilteredElements.Add(current);
        }

        return this.cachedFilteredElements;
    }

    private void ClearCachedContents()
    {
        using var synchronizationLocker = new WriteOnlySynchronizationLocker(this.cacheLocker);

        if (this.cachedFilteredElements == null)
        {
            return;
        }

        IList<TItem> coll = this.cachedFilteredElements;
        this.cachedFilteredElements = null;
        coll.Clear();
    }

    private bool IsFilter() =>
        this.Filter is not null &&
        !EqualityComparer<TFilter>.Default.Equals(
            this.Filter,
            default!);

#endregion
}