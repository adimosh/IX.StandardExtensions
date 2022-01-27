// <copyright file="PredictableDataStore{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using JetBrains.Annotations;

namespace IX.DataGeneration;

/// <summary>
///     A data store for storing items in a predictable way, such as any iteration through the store will produce the same
///     output. This class is thread-safe, and its internal items container is immutable.
/// </summary>
/// <typeparam name="T">The type of items in the store.</typeparam>
[PublicAPI]
public class PredictableDataStore<T> : ReaderWriterSynchronizedBase,
    IReadOnlyList<T>
{
#region Internal state

    private readonly T[] items;

    private int storeIndex;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="PredictableDataStore{T}" /> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    /// <param name="generator">The generator.</param>
    // TODO BREAKING: Remove this in the next breaking changes release
    [Obsolete(
        "Please use the constructor with the default parameter, as this constructor will be removed in a later version.")]
    [SuppressMessage(
        "ReSharper",
        "RedundantOverload.Global",
        Justification = "Let's leave this in for now, as we'll remove this in a future version.")]
    public PredictableDataStore(
        int capacity,
        Func<T> generator)
        : this(
            capacity,
            generator,
            false) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PredictableDataStore{T}" /> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    /// <param name="generator">The stateful generator.</param>
    /// <param name="state">The state.</param>
    // TODO BREAKING: Remove this in the next breaking changes release
    [Obsolete(
        "Please use the constructor with the default parameter, as this constructor will be removed in a later version.")]
    [SuppressMessage(
        "ReSharper",
        "RedundantOverload.Global",
        Justification = "Let's leave this in for now, as we'll remove this in a future version.")]
    public PredictableDataStore(
        int capacity,
        Func<object, T> generator,
        object state)
        : this(
            capacity,
            generator,
            state,
            false) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PredictableDataStore{T}" /> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    /// <param name="generator">The generator.</param>
    /// <param name="parallelGenerate">if set to <see langword="true" />, run generation of items in parallel.</param>
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "We will need a closure anyway for the parallel state.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "We will need a closure anyway for the parallel state.")]
    public PredictableDataStore(
        int capacity,
        Func<T> generator,
        bool parallelGenerate = false)
    {
        this.items = new T[capacity];

        if (parallelGenerate)
        {
            _ = Parallel.For(
                0,
                capacity,
                index =>
                {
                    T item = generator();

                    this.items[index] = item;
                });
        }
        else
        {
            for (var i = 0; i < capacity; i++)
            {
                this.items[i] = generator();
            }
        }
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PredictableDataStore{T}" /> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    /// <param name="generator">The generator.</param>
    /// <param name="state">The state.</param>
    /// <param name="parallelGenerate">if set to <see langword="true" />, run generation of items in parallel.</param>
    [SuppressMessage(
        "Performance",
        "HAA0301:Closure Allocation Source",
        Justification = "We will need a closure anyway for the parallel state.")]
    [SuppressMessage(
        "Performance",
        "HAA0302:Display class allocation to capture closure",
        Justification = "We will need a closure anyway for the parallel state.")]
    public PredictableDataStore(
        int capacity,
        Func<object, T> generator,
        object state,
        bool parallelGenerate = false)
    {
        Func<object, T> localGenerator = Requires.NotNull(
            generator);

        this.items = new T[capacity];

        if (parallelGenerate)
        {
            Parallel.For(
                0,
                capacity,
                index =>
                {
                    T item = localGenerator(state);

                    this.items[index] = item;
                });
        }
        else
        {
            for (var i = 0; i < capacity; i++)
            {
                this.items[i] = localGenerator(state);
            }
        }
    }

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
            using (this.ReadLock())
            {
                return this.items.Length;
            }
        }
    }

    /// <summary>Gets the element at the specified index in the read-only list.</summary>
    /// <param name="index">The zero-based index of the element to get. </param>
    /// <returns>The element at the specified index in the read-only list.</returns>
    public T this[int index]
    {
        get
        {
            using (this.ReadLock())
            {
                return this.items[index];
            }
        }
    }

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Returns an enumerator that iterates through the collection, from the point in which it currently stands, to the
    ///     end.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        while (true)
        {
            T item;
            using (ReadWriteSynchronizationLocker lck = this.ReadWriteLock())
            {
                if (this.storeIndex >= this.items.Length)
                {
                    break;
                }

                lck.Upgrade();

                item = this.items[this.storeIndex];
                this.storeIndex++;
            }

            yield return item;
        }
    }

    /// <summary>
    ///     Returns an enumerator that iterates through a collection, from the point in which it currently stands, to the end.
    /// </summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

#endregion

    /// <summary>
    ///     Takes an item from the predictable data store.
    /// </summary>
    /// <returns>T.</returns>
    public T Take()
    {
        T item;

        using (this.WriteLock())
        {
            item = this.items[this.storeIndex];
            this.storeIndex++;
        }

        return item;
    }

    /// <summary>
    ///     Resets this instance.
    /// </summary>
    public void Reset()
    {
        using (this.WriteLock())
        {
            this.storeIndex = 0;
        }
    }

#endregion
}