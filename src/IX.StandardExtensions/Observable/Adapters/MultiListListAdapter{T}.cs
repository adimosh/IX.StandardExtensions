// <copyright file="MultiListListAdapter{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Extensions;

namespace IX.Observable.Adapters;
#pragma warning disable HAA0401 // Possible allocation of reference type enumerator - Unavoidable right now
internal class MultiListListAdapter<T> : ModernListAdapter<T, IEnumerator<T>>
{
#region Internal state

    private readonly List<IEnumerable<T>> lists;

#endregion

#region Constructors and destructors

    internal MultiListListAdapter()
    {
        this.lists = new List<IEnumerable<T>>();
    }

#endregion

#region Properties and indexers

    public override int Count => this.lists.Sum(p => p.Count());

    public override bool IsReadOnly => true;

    public int SlavesCount => this.lists.Count;

    public override T this[int index]
    {
        get
        {
            var idx = index;

            foreach (IEnumerable<T> list in this.lists)
            {
                var count = list.Count();
                if (count > idx)
                {
                    return list.ElementAt(idx);
                }

                idx -= count;
            }

            throw new IndexOutOfRangeException();
        }

        set => throw new InvalidOperationException();
    }

#endregion

#region Methods

    public override int Add(T item) => throw new InvalidOperationException();

    public override int AddRange(IEnumerable<T> items) => throw new InvalidOperationException();

    public override void Clear() => throw new InvalidOperationException();

    public override bool Contains(T item) =>
        this.lists.Any(
            (
                p,
                itemL1) => p.Contains(itemL1),
            item);

    public override void CopyTo(
        T[] array,
        int arrayIndex)
    {
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

    public override IEnumerator<T> GetEnumerator()
    {
        foreach (IEnumerable<T> lst in this.lists)
        {
            foreach (T var in lst)
            {
                yield return var;
            }
        }
    }

    public override int Remove(T item) => throw new InvalidOperationException();

    public override void Insert(
        int index,
        T item) =>
        throw new InvalidOperationException();

    public override int IndexOf(T item)
    {
        var offset = 0;

        foreach (List<T> list in this.lists.Select(p => p.ToList()))
        {
            int foundIndex;
            if ((foundIndex = list.IndexOf(item)) != -1)
            {
                return foundIndex + offset;
            }

            offset += list.Count;
        }

        return -1;
    }

    public override void RemoveAt(int index) => throw new InvalidOperationException();

    internal void SetList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        this.lists.Add(list ?? throw new ArgumentNullException(nameof(list)));
        list.CollectionChanged += this.List_CollectionChanged;
    }

    [SuppressMessage(
        "ReSharper",
        "EmptyGeneralCatchClause",
        Justification = "This is of no consequence.")]
    internal void RemoveList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        try
        {
            list.CollectionChanged -= this.List_CollectionChanged;
        }
        catch
        {
        }

        this.lists.Remove(list ?? throw new ArgumentNullException(nameof(list)));
    }

    private void List_CollectionChanged(
        object? sender,
        NotifyCollectionChangedEventArgs e) =>
        this.TriggerReset();

#endregion
}
#pragma warning restore HAA0401 // Possible allocation of reference type enumerator