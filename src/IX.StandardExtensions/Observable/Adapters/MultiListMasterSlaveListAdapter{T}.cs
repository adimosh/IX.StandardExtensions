// <copyright file="MultiListMasterSlaveListAdapter{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
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

    internal MultiListMasterSlaveListAdapter() => slaves = new List<IEnumerable<T>>();

#endregion

#region Properties and indexers

    public override int Count
    {
        get
        {
            master ??= new ObservableList<T>();

            return master.Count + slaves.Sum(p => p.Count());
        }
    }

    public override bool IsReadOnly
    {
        get
        {
            master ??= new ObservableList<T>();

            return master.IsReadOnly;
        }
    }

    public int SlavesCount => slaves.Count;

    internal int MasterCount
    {
        get
        {
            master ??= new ObservableList<T>();

            return master.Count;
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
            master ??= new ObservableList<T>();

            if (index < master.Count)
            {
                return master[index];
            }

            var idx = index - master.Count;

            foreach (IEnumerable<T> slave in slaves)
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
            master ??= new ObservableList<T>();

            master[index] = value;
        }
    }

#endregion

#region Methods

    public override int Add(T item)
    {
        master ??= new ObservableList<T>();

        master.Add(item);

        return MasterCount - 1;
    }

    public override int AddRange(IEnumerable<T> items)
    {
        master ??= new ObservableList<T>();

        var index = master.Count;
        items.ForEach(
            (
                p,
                masterL1) => masterL1.Add(p),
            master);

        return index;
    }

    public override void Clear()
    {
        master ??= new ObservableList<T>();

        master.Clear();
    }

    public override bool Contains(T item)
    {
        master ??= new ObservableList<T>();

        return master.Contains(item) ||
               slaves.Any(
                   (
                       p,
                       itemL1) => p.Contains(itemL1),
                   item);
    }

    public void MasterCopyTo(
        T[] array,
        int arrayIndex)
    {
        master ??= new ObservableList<T>();

        master.CopyTo(
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
        master ??= new ObservableList<T>();

        var totalCount = Count + arrayIndex;
        using IEnumerator<T> enumerator = GetEnumerator();
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
        master ??= new ObservableList<T>();

        foreach (T var in master)
        {
            yield return var;
        }

        foreach (IEnumerable<T> lst in slaves)
        {
            foreach (T var in lst)
            {
                yield return var;
            }
        }
    }

    public override int Remove(T item)
    {
        master ??= new ObservableList<T>();

        var index = master.IndexOf(item);

        master.Remove(item);

        return index;
    }

    public override void Insert(
        int index,
        T item)
    {
        master ??= new ObservableList<T>();

        master.Insert(
            index,
            item);
    }

    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "We can't avoid this here.")]
    public override int IndexOf(T item)
    {
        master ??= new ObservableList<T>();

        var offset = 0;

        int foundIndex;
        if ((foundIndex = master.IndexOf(item)) != -1)
        {
            return foundIndex;
        }

        offset += master.Count;

        foreach (List<T> slave in slaves.Select(p => p.ToList()))
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
        master ??= new ObservableList<T>();

        master.RemoveAt(index);
    }

    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP003:Dispose previous before re-assigning",
        Justification = "We do not own this instance, disposing it is not advisable.")]
    internal void SetMaster<TList>(TList masterList)
        where TList : class, IList<T>, INotifyCollectionChanged
    {
        TList newMaster = Requires.NotNull(masterList);
        IList<T>? oldMaster = master;

        if (oldMaster != null)
        {
            try
            {
                ((INotifyCollectionChanged)oldMaster).CollectionChanged -= List_CollectionChanged;
            }
            catch
            {
                // We need to do nothing here. Inability to remove the event delegate reference is of no consequence.
            }
        }

        master = newMaster;
        masterList.CollectionChanged += List_CollectionChanged;
    }

    internal void SetSlave<TList>(TList slaveList)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        slaves.Add(Requires.NotNull(slaveList));
        slaveList.CollectionChanged += List_CollectionChanged;
    }

    internal void RemoveSlave<TList>(TList slaveList)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        var localSlaveList = Requires.NotNull(
            slaveList);

        try
        {
            localSlaveList.CollectionChanged -= List_CollectionChanged;
        }
        catch
        {
            // We need to do nothing here. Inability to remove the event delegate reference is of no consequence.
        }

        slaves.Remove(localSlaveList);
    }

    private void List_CollectionChanged(
        object? sender,
        NotifyCollectionChangedEventArgs e) =>
        TriggerReset();

#endregion
}