// <copyright file="FilterableObservableMasterSlaveCollection{TItem,TFilter}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using IX.Observable.DebugAide;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

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
public class FilterableObservableMasterSlaveCollection<TItem, TFilter> : ObservableMasterSlaveCollection<TItem>
{
#region Internal state

    private TFilter? filter;
    private IList<TItem>? filteredElements;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="FilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    public FilterableObservableMasterSlaveCollection(Func<TItem, TFilter, bool> filteringPredicate)
    {
        FilteringPredicate = Requires.NotNull(filteringPredicate);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="FilterableObservableMasterSlaveCollection{TItem, TFilter}" /> class.
    /// </summary>
    /// <param name="filteringPredicate">The filtering predicate.</param>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="filteringPredicate" /> is <see langword="null" /> (
    ///     <see langword="Nothing" />) in Visual Basic.
    /// </exception>
    public FilterableObservableMasterSlaveCollection(
        Func<TItem, TFilter, bool> filteringPredicate,
        SynchronizationContext context)
        : base(context)
    {
        FilteringPredicate = Requires.NotNull(filteringPredicate);
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
            if (!IsFilter())
            {
                return base.Count;
            }

            if (filteredElements == null)
            {
                FillCachedList();
            }

            return filteredElements!.Count;
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
        get => filter;
        set
        {
            filter = value;

            ClearCachedContents();

            RaiseCollectionReset();
            RaisePropertyChanged(nameof(Count));
            RaisePropertyChanged(Constants.ItemsName);
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
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "This cannot be avoidable.")]
    public override IEnumerator<TItem> GetEnumerator()
    {
        if (!IsFilter())
        {
            return base.GetEnumerator();
        }

        if (filteredElements != null)
        {
            return filteredElements.GetEnumerator();
        }

        FillCachedList();

        return base.GetEnumerator();
    }

    /// <summary>
    ///     Called when an item is added to a collection.
    /// </summary>
    /// <param name="addedItem">The added item.</param>
    /// <param name="index">The index.</param>
    protected override void RaiseCollectionChangedAdd(
        TItem addedItem,
        int index)
    {
        if (IsFilter())
        {
            RaiseCollectionReset();
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
        if (IsFilter())
        {
            RaiseCollectionReset();
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
        if (IsFilter())
        {
            RaiseCollectionReset();
        }
        else
        {
            base.RaiseCollectionChangedRemove(
                removedItem,
                index);
        }
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "This cannot be avoidable.")]
    private IEnumerator<TItem> EnumerateFiltered()
    {
        TFilter? localFilter = Filter;

        using IEnumerator<TItem> enumerator = base.GetEnumerator();

        if (localFilter is null)
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
                if (FilteringPredicate(
                        current,
                        localFilter))
                {
                    yield return current;
                }
            }
        }
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "This cannot be avoidable.")]
    private void FillCachedList()
    {
        filteredElements = new List<TItem>(base.Count);

        using IEnumerator<TItem> enumerator = EnumerateFiltered();
        while (enumerator.MoveNext())
        {
            TItem current = enumerator.Current;
            filteredElements.Add(current);
        }
    }

    private void ClearCachedContents()
    {
        if (filteredElements == null)
        {
            return;
        }

        IList<TItem> coll = filteredElements;
        filteredElements = null;
        coll.Clear();
    }

    private bool IsFilter()
    {
        if (filter == null)
        {
            return true;
        }

        return !EqualityComparer<TFilter>.Default.Equals(
            filter,
            default!);
    }

#endregion
}