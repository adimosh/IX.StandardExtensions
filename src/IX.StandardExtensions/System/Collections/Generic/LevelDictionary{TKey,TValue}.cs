// <copyright file="LevelDictionary{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions;
using IX.StandardExtensions.ComponentModel;
using JetBrains.Annotations;

namespace IX.System.Collections.Generic;

/// <summary>
///     A dictionary that saves its objects in multiple levels.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
[PublicAPI]
public class LevelDictionary<TKey, TValue> : DisposableBase,
    IDictionary<TKey, TValue>
    where TKey : notnull
{
#region Internal state

    private readonly Dictionary<TKey, TValue> internalDictionary;
    private readonly Dictionary<int, List<TKey>> keyLevels;
    private readonly Dictionary<TKey, int> levelKeys;

#endregion

#region Constructors and destructors

#region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="LevelDictionary{TKey, TValue}" /> class.
    /// </summary>
    public LevelDictionary()
    {
        this.internalDictionary = new Dictionary<TKey, TValue>();
        this.keyLevels = new Dictionary<int, List<TKey>>();
        this.levelKeys = new Dictionary<TKey, int>();
    }

#endregion

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the count.
    /// </summary>
    /// <value>The count.</value>
    public int Count
    {
        get
        {
            this.ThrowIfCurrentObjectDisposed();

            return this.internalDictionary.Count;
        }
    }

    /// <summary>
    ///     Gets a value indicating whether this instance is read only.
    /// </summary>
    /// <value><see langword="true" /> if this instance is read only; otherwise, <see langword="false" />.</value>
    public bool IsReadOnly => false;

    /// <summary>
    ///     Gets the keys.
    /// </summary>
    /// <value>The keys.</value>
    public ICollection<TKey> Keys
    {
        get
        {
            this.ThrowIfCurrentObjectDisposed();

            return this.internalDictionary.Keys;
        }
    }

    /// <summary>
    ///     Gets the keys by level.
    /// </summary>
    /// <value>The keys by level.</value>
    public IEnumerable<KeyValuePair<int, TKey[]>> KeysByLevel
    {
        get
        {
            this.ThrowIfCurrentObjectDisposed();

            return this.keyLevels.OrderBy(p => p.Key)
                .Select(
                    p => new KeyValuePair<int, TKey[]>(
                        p.Key,
                        p.Value.ToArray()));
        }
    }

    /// <summary>
    ///     Gets the values.
    /// </summary>
    /// <value>The values.</value>
    public ICollection<TValue> Values
    {
        get
        {
            this.ThrowIfCurrentObjectDisposed();

            return this.internalDictionary.Values;
        }
    }

    /// <summary>
    ///     Gets or sets the <typeparamref name="TValue" /> with the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>TValue.</returns>
    public TValue this[TKey key]
    {
        get
        {
            this.ThrowIfCurrentObjectDisposed();

            return this.internalDictionary[key];
        }

        set
        {
            this.ThrowIfCurrentObjectDisposed();

            this.internalDictionary[key] = value;
        }
    }

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Clears the dictionary.
    /// </summary>
    public void Clear()
    {
        this.ThrowIfCurrentObjectDisposed();

        this.internalDictionary.Clear();
        this.keyLevels.Clear();
        this.levelKeys.Clear();
    }

    /// <summary>
    ///     Determines whether the dictionary contains they key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns><see langword="true" /> if the dictionary contains the key; otherwise, <see langword="false" />.</returns>
    public bool ContainsKey(TKey key)
    {
        this.ThrowIfCurrentObjectDisposed();

        return this.internalDictionary.ContainsKey(key);
    }

    /// <summary>
    ///     Tries to get a value by key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns><see langword="true" /> if the value was found, <see langword="false" /> otherwise.</returns>
    public bool TryGetValue(
        TKey key,
        out TValue value)
    {
        this.ThrowIfCurrentObjectDisposed();

        return this.internalDictionary.TryGetValue(
            key,
            out value!);
    }

    /// <summary>
    ///     Adds the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <exception cref="NotImplementedByDesignException">
    ///     This method is not implemented by design. Do not call it, as it will
    ///     always throw an exception.
    /// </exception>
    [ExcludeFromCodeCoverage]
    void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item) =>
        throw new NotImplementedByDesignException();

    /// <summary>
    ///     Determines whether the specified item is contained in the dictionary.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns><see langword="true" /> if the dictionary contains the specified item; otherwise, <see langword="false" />.</returns>
    [ExcludeFromCodeCoverage]
    bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
    {
        this.ThrowIfCurrentObjectDisposed();

        return (this.internalDictionary as ICollection<KeyValuePair<TKey, TValue>>).Contains(item);
    }

    /// <summary>
    ///     Copies the contents of the dictionary to an array.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="arrayIndex">Index of the array.</param>
    [ExcludeFromCodeCoverage]
    void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(
        KeyValuePair<TKey, TValue>[] array,
        int arrayIndex)
    {
        this.ThrowIfCurrentObjectDisposed();

        (this.internalDictionary as ICollection<KeyValuePair<TKey, TValue>>).CopyTo(
            array,
            arrayIndex);
    }

    /// <summary>
    ///     Removes the specified item from the dictionary.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns><see langword="true" /> if the removal was a success, <see langword="false" /> otherwise.</returns>
    [ExcludeFromCodeCoverage]
    bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item) => this.Remove(item.Key);

    /// <summary>
    ///     Adds the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <exception cref="NotImplementedByDesignException">
    ///     This method is not implemented by design. Do not call it, as it will
    ///     always throw an exception.
    /// </exception>
    [ExcludeFromCodeCoverage]
    void IDictionary<TKey, TValue>.Add(
        TKey key,
        TValue value) =>
        throw new NotImplementedByDesignException();

    /// <summary>
    ///     Removes the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns><see langword="true" /> if the key has been removed, <see langword="false" /> otherwise.</returns>
    [ExcludeFromCodeCoverage]
    bool IDictionary<TKey, TValue>.Remove(TKey key) => this.Remove(in key);

    /// <summary>
    ///     Gets the enumerator.
    /// </summary>
    /// <returns>IEnumerator.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Explicit interface implementation.")]
    [ExcludeFromCodeCoverage]
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    /// <summary>
    ///     Gets the enumerator.
    /// </summary>
    /// <returns>The dictionary enumerator.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Explicit interface implementation.")]
    [ExcludeFromCodeCoverage]
    IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() =>
        this.GetEnumerator();

#endregion

    /// <summary>
    ///     Removes the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns><see langword="true" /> if the key has been removed, <see langword="false" /> otherwise.</returns>
    public bool Remove(in TKey key)
    {
        this.ThrowIfCurrentObjectDisposed();

        if (!this.levelKeys.TryGetValue(
                key,
                out var level))
        {
            return false;
        }

        if (!this.internalDictionary.Remove(key))
        {
            return false;
        }

        this.keyLevels[level]
            .Remove(key);
        this.levelKeys.Remove(key);

        return true;
    }

    /// <summary>
    ///     Adds the specified key and value to a level in the dictionary.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <param name="level">The level.</param>
    /// <exception cref="InvalidOperationException">The key was already present in the dictionary.</exception>
    public void Add(
        TKey key,
        TValue value,
        int level)
    {
        if (level < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(level));
        }

        if (this.internalDictionary.ContainsKey(key))
        {
            throw new InvalidOperationException(Resources.ErrorKeyFoundInDictionary);
        }

        this.internalDictionary.Add(
            key,
            value);

        if (this.keyLevels.TryGetValue(
                level,
                out List<TKey>? list))
        {
            list.Add(key);
        }
        else
        {
            this.keyLevels.Add(
                level,
                new List<TKey>
                {
                    key
                });
        }

        this.levelKeys.Add(
            key,
            level);
    }

    /// <summary>
    ///     Gets the enumerator.
    /// </summary>
    /// <returns>The dictionary's enumerator.</returns>
    public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
    {
        this.ThrowIfCurrentObjectDisposed();

        return this.internalDictionary.GetEnumerator();
    }

    /// <summary>
    ///     Enumerates values based on key levels.
    /// </summary>
    /// <returns>A values enumerable that enumerates based on key levels.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Not necessary.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "Not necessary.")]
    [SuppressMessage(
        "CodeQuality",
        "IDE0079:Remove unnecessary suppression",
        Justification = "We use ReSharper.")]
    public IEnumerable<TValue> EnumerateValuesOnLevelKeys()
    {
        foreach (List<TKey> keyList in this.keyLevels.OrderBy(p => p.Key)
                     .Select(p => p.Value))
        {
            foreach (TKey key in keyList)
            {
                yield return this.internalDictionary[key];
            }
        }
    }

#region Disposable

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        this.internalDictionary.Clear();
        this.keyLevels.Clear();
        this.levelKeys.Clear();

        base.DisposeManagedContext();
    }

#endregion

#endregion

#region Nested types and delegates

    /// <summary>
    ///     An enumerable wrapper that holds values.
    /// </summary>
    [PublicAPI]
    public readonly struct KeyLevelEnumerable : IEnumerable<TValue>
    {
        private readonly TValue[] values;

        [SuppressMessage(
            "Performance",
            "HAA0602:Delegate on struct instance caused a boxing allocation",
            Justification = "Not a problem.")]
        internal KeyLevelEnumerable(LevelDictionary<TKey, TValue> instance)
        {
            this.values = (
                from p in instance.keyLevels.OrderBy(p => p.Key)
                    .SelectMany(p => p.Value)
                join q in instance.internalDictionary.AsEnumerable() on p equals q.Key
                select q.Value).ToArray();
        }

        /// <summary>
        ///     Gets an enumerator for this level dictionary.
        /// </summary>
        /// <returns>An enumerator that enumerates by key levels.</returns>
        public KeyLevelEnumerator GetEnumerator() => new(this.values);

        /// <summary>
        ///     Gets an enumerator for this level dictionary.
        /// </summary>
        /// <returns>An enumerator that enumerates by key levels.</returns>
        [SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "Explicit interface implementation.")]
        [ExcludeFromCodeCoverage]
        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => this.GetEnumerator();

        /// <summary>
        ///     Gets an enumerator for this level dictionary.
        /// </summary>
        /// <returns>An enumerator that enumerates by key levels.</returns>
        [SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "Explicit interface implementation.")]
        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <summary>
        ///     An enumerator for the <see cref="LevelDictionary{TKey,TValue}" />, so that it can enumerate on level keys.
        /// </summary>
        public struct KeyLevelEnumerator : IEnumerator<TValue>
        {
            private readonly TValue[] values;

            private int index;

            internal KeyLevelEnumerator(TValue[] values)
            {
                this.values = values;

                this.index = 0;
            }

            /// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
            /// <returns>The element in the collection at the current position of the enumerator.</returns>
            public TValue Current
            {
                get
                {
                    if (this.index == -1)
                    {
                        throw new ObjectDisposedException(nameof(KeyLevelEnumerator));
                    }

                    if (this.index >= this.values.Length)
                    {
                        throw new IndexOutOfRangeException(Resources.TheLevelDictionaryHasNoMoreItems);
                    }

                    return this.values[this.index];
                }
            }

            /// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
            /// <returns>The element in the collection at the current position of the enumerator.</returns>
            [SuppressMessage(
                "Performance",
                "HAA0601:Value type to reference type conversion causing boxing allocation",
                Justification = "This is how the property works, and should not be used directly anyway.")]
            object? IEnumerator.Current => this.Current;

            /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
            public void Dispose() =>
                Interlocked.Exchange(
                    ref this.index,
                    -1);

            /// <summary>Advances the enumerator to the next element of the collection.</summary>
            /// <returns>
            ///     <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" />
            ///     if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
            public bool MoveNext()
            {
                if (this.index == -1)
                {
                    throw new ObjectDisposedException(nameof(KeyLevelEnumerator));
                }

                if (this.index == this.values.Length)
                {
                    return false;
                }

                Interlocked.Increment(ref this.index);

                return true;
            }

            /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
            public void Reset()
            {
                if (this.index == -1)
                {
                    throw new ObjectDisposedException(nameof(KeyLevelEnumerator));
                }

                this.index = 0;
            }
        }
    }

#endregion
}