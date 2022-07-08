// <copyright file="DictionaryCollectionAdapter{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using IX.StandardExtensions.Threading;

namespace IX.Observable.Adapters;

/// <summary>
///     A collection adapter for a dictionary.
/// </summary>
/// <typeparam name="TKey">The type of key in the dictionary.</typeparam>
/// <typeparam name="TValue">The type of value in the dictionary.</typeparam>
/// <seealso cref="ModernCollectionAdapter{TItem, TEnumerator}" />
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "DictionaryCollectionAdapterOf{1}By{0}",
    ItemName = "Item",
    KeyName = "Key",
    ValueName = "Value")]
internal class DictionaryCollectionAdapter<TKey, TValue> : ModernCollectionAdapter<KeyValuePair<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator>,
    IDictionaryCollectionAdapter<TKey, TValue>
    where TKey : notnull
{
#region Internal state

    private Dictionary<TKey, TValue> dictionary;

#endregion

#region Constructors and destructors

    public DictionaryCollectionAdapter()
    {
        dictionary = new Dictionary<TKey, TValue>();
    }

    internal DictionaryCollectionAdapter(IDictionary<TKey, TValue> dictionary)
    {
        this.dictionary = new Dictionary<TKey, TValue>(dictionary);
    }

#endregion

#region Properties and indexers

    public override int Count => dictionary.Count;

    public override bool IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).IsReadOnly;

    public ICollection<TKey> Keys => dictionary.Keys;

    public ICollection<TValue> Values => dictionary.Values;

    public TValue this[TKey key]
    {
        get => dictionary[key];
        set => dictionary[key] = value;
    }

#endregion

#region Methods

#region Interface implementations

    public override void Clear()
    {
        Dictionary<TKey, TValue> tempDictionary = dictionary;
        dictionary = new Dictionary<TKey, TValue>();

        _ = Work.OnThreadPoolAsync(
            oldDictionary => oldDictionary.Clear(),
            tempDictionary);
    }

    public override bool Contains(KeyValuePair<TKey, TValue> item) =>
        ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).Contains(item);

    public override void CopyTo(
        KeyValuePair<TKey, TValue>[] array,
        int arrayIndex) =>
        ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).CopyTo(
            array,
            arrayIndex);

    public override int Add(KeyValuePair<TKey, TValue> item)
    {
        ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).Add(item);

        return -1;
    }

    public override int Remove(KeyValuePair<TKey, TValue> item)
    {
        ((ICollection<KeyValuePair<TKey, TValue>>)dictionary).Remove(item);

        return -1;
    }

    public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);

    public bool Remove(TKey item) => dictionary.Remove(item);

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    public bool TryGetValue(
        TKey key,
        [MaybeNullWhen(false)] out TValue value) =>
        dictionary.TryGetValue(
            key,
            out value);
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

    public int Add(
        TKey key,
        TValue value)
    {
        dictionary.Add(
            key,
            value);

        return -1;
    }

    void IDictionary<TKey, TValue>.Add(
        TKey key,
        TValue value) =>
        dictionary.Add(
            key,
            value);

#endregion

    public override Dictionary<TKey, TValue>.Enumerator GetEnumerator() => dictionary.GetEnumerator();

#endregion
}