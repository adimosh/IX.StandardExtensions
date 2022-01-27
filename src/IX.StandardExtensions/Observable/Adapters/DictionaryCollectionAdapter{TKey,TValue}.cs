// <copyright file="DictionaryCollectionAdapter{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using System.Runtime.Serialization;
using IX.StandardExtensions.Threading;

namespace IX.Observable.Adapters;

[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "DictionaryCollectionAdapterOf{1}By{0}",
    ItemName = "Item",
    KeyName = "Key",
    ValueName = "Value")]
internal class DictionaryCollectionAdapter<TKey, TValue> : CollectionAdapter<KeyValuePair<TKey, TValue>>,
    IDictionaryCollectionAdapter<TKey, TValue>
    where TKey : notnull
{
#region Internal state

    private Dictionary<TKey, TValue> dictionary;

#endregion

#region Constructors and destructors

    public DictionaryCollectionAdapter()
    {
        this.dictionary = new Dictionary<TKey, TValue>();
    }

    internal DictionaryCollectionAdapter(Dictionary<TKey, TValue> dictionary)
    {
        this.dictionary = new Dictionary<TKey, TValue>(dictionary);
    }

#endregion

#region Properties and indexers

    public override int Count => this.dictionary.Count;

    public override bool IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)this.dictionary).IsReadOnly;

    public ICollection<TKey> Keys => this.dictionary.Keys;

    public ICollection<TValue> Values => this.dictionary.Values;

    public TValue this[TKey key]
    {
        get => this.dictionary[key];
        set => this.dictionary[key] = value;
    }

#endregion

#region Methods

#region Interface implementations

    public override void Clear()
    {
        Dictionary<TKey, TValue> tempdict = this.dictionary;
        this.dictionary = new Dictionary<TKey, TValue>();

        _ = Work.OnThreadPoolAsync(
            oldDictionary => oldDictionary.Clear(),
            tempdict);
    }

    public override bool Contains(KeyValuePair<TKey, TValue> item) =>
        ((ICollection<KeyValuePair<TKey, TValue>>)this.dictionary).Contains(item);

    public override void CopyTo(
        KeyValuePair<TKey, TValue>[] array,
        int arrayIndex) =>
        ((ICollection<KeyValuePair<TKey, TValue>>)this.dictionary).CopyTo(
            array,
            arrayIndex);

    public override int Add(KeyValuePair<TKey, TValue> item)
    {
        ((ICollection<KeyValuePair<TKey, TValue>>)this.dictionary).Add(item);

        return -1;
    }

    public override int Remove(KeyValuePair<TKey, TValue> item)
    {
        ((ICollection<KeyValuePair<TKey, TValue>>)this.dictionary).Remove(item);

        return -1;
    }

    public bool ContainsKey(TKey key) => this.dictionary.ContainsKey(key);

    public bool Remove(TKey item) => this.dictionary.Remove(item);

    public bool TryGetValue(
        TKey key,
        out TValue value) =>
        this.dictionary.TryGetValue(
            key,
            out value);

    public int Add(
        TKey key,
        TValue value)
    {
        this.dictionary.Add(
            key,
            value);

        return -1;
    }

    public override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => this.dictionary.GetEnumerator();

    void IDictionary<TKey, TValue>.Add(
        TKey key,
        TValue value) =>
        this.dictionary.Add(
            key,
            value);

#endregion

#endregion
}