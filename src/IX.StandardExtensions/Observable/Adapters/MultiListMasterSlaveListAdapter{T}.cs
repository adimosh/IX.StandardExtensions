// <copyright file="MultiListMasterSlaveListAdapter{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;

namespace IX.Observable.Adapters;

internal class MultiListMasterSlaveListAdapter<T> : ModernListAdapter<T, IEnumerator<T>>
{
#region Internal state

    private readonly List<IEnumerable<T>> slaves;
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable.",
        Justification = "We do not own this instance, disposing it is not advisable.")]
    private IList<T>? master;

#endregion

#region Constructors and destructors

    internal MultiListMasterSlaveListAdapter()
    {
        this.slaves = new List<IEnumerable<T>>();
    }

#endregion

#region Properties and indexers

    public override int Count
    {
        get
        {
            this.master ??= new ObservableList<T>();

            return this.master.Count + this.slaves.Sum(p => p.Count());
        }
    }

    public override bool IsReadOnly
    {
        get
        {
            this.master ??= new ObservableList<T>();

            return this.master.IsReadOnly;
        }
    }

    public int SlavesCount => this.slaves.Count;

    internal int MasterCount
    {
        get
        {
            this.master ??= new ObservableList<T>();

            return this.master.Count;
        }
    }

    [SuppressMessage(
        "ReSharper",
        "PossibleMultipleEnumeration",
        Justification = "Appears unavoidable at this time.")]
    public override T this[int index]
    {
        get
        {
            this.master ??= new ObservableList<T>();

            if (index < this.master.Count)
            {
                return this.master[index];
            }

            var idx = index - this.master.Count;

            foreach (IEnumerable<T> slave in this.slaves)
            {
                var count = slave.Count();
                if (count > idx)
                {
                    return slave.ElementAt(idx);
                }

                idx -= count;
            }

            throw new IndexOutOfRangeException();
        }

        set
        {
            this.master ??= new ObservableList<T>();

            this.master[index] = value;
        }
    }

#endregion

#region Methods

    public override int Add(T item)
    {
        this.master ??= new ObservableList<T>();

        this.master.Add(item);

        return this.MasterCount - 1;
    }

    public override int AddRange(IEnumerable<T> items)
    {
        this.master ??= new ObservableList<T>();

        var index = this.master.Count;
        items.ForEach(
            (
                p,
                masterL1) => masterL1.Add(p),
            this.master);

        return index;
    }

    public override void Clear()
    {
        this.master ??= new ObservableList<T>();

        this.master.Clear();
    }

    public override bool Contains(T item)
    {
        this.master ??= new ObservableList<T>();

        return this.master.Contains(item) ||
               this.slaves.Any(
                   (
                       p,
                       itemL1) => p.Contains(itemL1),
                   item);
    }

    public void MasterCopyTo(
        T[] array,
        int arrayIndex)
    {
        this.master ??= new ObservableList<T>();

        this.master.CopyTo(
            array,
            arrayIndex);
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We can't avoid this here.")]
    public override void CopyTo(
        T[] array,
        int arrayIndex)
    {
        this.master ??= new ObservableList<T>();

        var totalCount = this.Count + arrayIndex;
        using IEnumerator<T> enumerator = this.GetEnumerator();
        for (var i = arrayIndex; i < totalCount; i++)
        {
            if (!enumerator.MoveNext())
            {
                break;
            }

            array[i] = enumerator.Current;
        }
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We can't avoid this here.")]
    public override IEnumerator<T> GetEnumerator()
    {
        this.master ??= new ObservableList<T>();

        foreach (T var in this.master)
        {
            yield return var;
        }

        foreach (IEnumerable<T> lst in this.slaves)
        {
            foreach (T var in lst)
            {
                yield return var;
            }
        }
    }

    public override int Remove(T item)
    {
        this.master ??= new ObservableList<T>();

        var index = this.master.IndexOf(item);

        this.master.Remove(item);

        return index;
    }

    public override void Insert(
        int index,
        T item)
    {
        this.master ??= new ObservableList<T>();

        this.master.Insert(
            index,
            item);
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We can't avoid this here.")]
    public override int IndexOf(T item)
    {
        this.master ??= new ObservableList<T>();

        var offset = 0;

        int foundIndex;
        if ((foundIndex = this.master.IndexOf(item)) != -1)
        {
            return foundIndex;
        }

        offset += this.master.Count;

        foreach (List<T> slave in this.slaves.Select(p => p.ToList()))
        {
            if ((foundIndex = slave.IndexOf(item)) != -1)
            {
                return foundIndex + offset;
            }

            offset += slave.Count;
        }

        return -1;
    }

    /// <summary>
    ///     Removes an item at a specific index.
    /// </summary>
    /// <param name="index">The index at which to remove from.</param>
    public override void RemoveAt(int index)
    {
        this.master ??= new ObservableList<T>();

        this.master.RemoveAt(index);
    }

    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP003:Dispose previous before re-assigning",
        Justification = "We do not own this instance, disposing it is not advisable.")]
    internal void SetMaster<TList>(TList masterList)
        where TList : class, IList<T>, INotifyCollectionChanged
    {
        TList newMaster = Requires.NotNull(masterList);
        IList<T>? oldMaster = this.master;

        if (oldMaster != null)
        {
            try
            {
                ((INotifyCollectionChanged)oldMaster).CollectionChanged -= this.List_CollectionChanged;
            }
            catch
            {
                // We need to do nothing here. Inability to remove the event delegate reference is of no consequence.
            }
        }

        this.master = newMaster;
        masterList.CollectionChanged += this.List_CollectionChanged;
    }

    internal void SetSlave<TList>(TList slaveList)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        this.slaves.Add(Requires.NotNull(slaveList));
        slaveList.CollectionChanged += this.List_CollectionChanged;
    }

    internal void RemoveSlave<TList>(TList slaveList)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        var localSlaveList = Requires.NotNull(
            slaveList);

        try
        {
            localSlaveList.CollectionChanged -= this.List_CollectionChanged;
        }
        catch
        {
            // We need to do nothing here. Inability to remove the event delegate reference is of no consequence.
        }

        this.slaves.Remove(localSlaveList);
    }

    private void List_CollectionChanged(
        object? sender,
        NotifyCollectionChangedEventArgs e) =>
        this.TriggerReset();

#endregion
}