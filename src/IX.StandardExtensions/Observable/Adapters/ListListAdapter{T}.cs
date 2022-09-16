// <copyright file="ListListAdapter{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Runtime.Serialization;

namespace IX.Observable.Adapters;

[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "ListAdapterOf{0}",
    ItemName = "Item")]
internal class ListListAdapter<T> : ModernListAdapter<T, List<T>.Enumerator>
{
#region Internal state

    private readonly List<T> list;

#endregion

#region Constructors and destructors

    public ListListAdapter() => list = new();

    public ListListAdapter(IEnumerable<T> source) => list = new(source);

#endregion

#region Properties and indexers

    public override int Count => list.Count;

    public override bool IsReadOnly => false;

    public override T this[int index]
    {
        get => list[index];
        set => list[index] = value;
    }

#endregion

#region Methods

    public override int Add(T item)
    {
        list.Add(item);

        return list.Count - 1;
    }

    public override int AddRange(IEnumerable<T> items)
    {
        var index = list.Count;
        list.AddRange(items);

        return index;
    }

    public override void Clear() => list.Clear();

    public override bool Contains(T item) => list.Contains(item);

    public override void CopyTo(
        T[] array,
        int arrayIndex) =>
        list.CopyTo(
            array,
            arrayIndex);

    public override List<T>.Enumerator GetEnumerator() => list.GetEnumerator();

    public override int IndexOf(T item) => list.IndexOf(item);

    public override void Insert(
        int index,
        T item) =>
        list.Insert(
            index,
            item);

    public override int Remove(T item)
    {
        var index = list.IndexOf(item);
        _ = list.Remove(item);

        return index;
    }

    public override void RemoveAt(int index) => list.RemoveAt(index);

#endregion
}