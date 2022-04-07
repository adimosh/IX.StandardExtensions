// <copyright file="ConcurrentDictionary{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using IX.StandardExtensions.Debugging;
using JetBrains.Annotations;
using ConcurrentCollections = System.Collections.Concurrent;

namespace IX.StandardExtensions.Efficiency;

/// <summary>
///     An efficient version of the concurrent dictionary.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
/// <seealso cref="ConcurrentCollections.ConcurrentDictionary{TKey, TValue}" />
[ComVisible(false)]
[DebuggerDisplay("Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(DictionaryDebugView<,>))]
[DefaultMember("Item")]
[PublicAPI]
public partial class ConcurrentDictionary<TKey, TValue> :
    ConcurrentCollections.ConcurrentDictionary<TKey, TValue>
    where TKey : notnull
{
#region Internal state

    [ThreadStatic]
    [SuppressMessage(
        "ReSharper",
        "StaticMemberInGenericType",
        Justification = "This field is used exclusively under lock, so this is safe.")]
    private static object? threadStaticMethods;

    [ThreadStatic]
    [SuppressMessage(
        "ReSharper",
        "StaticMemberInGenericType",
        Justification = "This field is used exclusively under lock, so this is safe.")]
    private static object? threadStaticUpdateFactory;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentDictionary{TKey, TValue}" /> class.
    /// </summary>
    public ConcurrentDictionary() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="collection">
    ///     The <see cref="IEnumerable{T}" /> whose elements are copied to the new
    ///     <see cref="ConcurrentDictionary{TKey, TValue}" />.
    /// </param>
    public ConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
        : base(collection) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="collection">
    ///     The <see cref="IEnumerable{T}" /> whose elements are copied to the new
    ///     <see cref="ConcurrentDictionary{TKey, TValue}" />.
    /// </param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing keys.</param>
    public ConcurrentDictionary(
        IEnumerable<KeyValuePair<TKey, TValue>> collection,
        IEqualityComparer<TKey> comparer)
        : base(
            collection,
            comparer) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="comparer">The equality comparison implementation to use when comparing keys.</param>
    public ConcurrentDictionary(IEqualityComparer<TKey> comparer)
        : base(comparer) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="concurrencyLevel">
    ///     The estimated number of threads that will update the
    ///     <see cref="ConcurrentDictionary{TKey, TValue}" /> concurrently.
    /// </param>
    /// <param name="collection">
    ///     The <see cref="IEnumerable{T}" /> whose elements are copied to the new
    ///     <see cref="ConcurrentDictionary{TKey, TValue}" />.
    /// </param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing keys.</param>
    public ConcurrentDictionary(
        int concurrencyLevel,
        IEnumerable<KeyValuePair<TKey, TValue>> collection,
        IEqualityComparer<TKey> comparer)
        : base(
            concurrencyLevel,
            collection,
            comparer) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="concurrencyLevel">
    ///     The estimated number of threads that will update the
    ///     <see cref="ConcurrentDictionary{TKey, TValue}" /> concurrently.
    /// </param>
    /// <param name="capacity">
    ///     The initial number of elements that the <see cref="ConcurrentDictionary{TKey, TValue}" /> can
    ///     contain.
    /// </param>
    public ConcurrentDictionary(
        int concurrencyLevel,
        int capacity)
        : base(
            concurrencyLevel,
            capacity) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="concurrencyLevel">
    ///     The estimated number of threads that will update the
    ///     <see cref="ConcurrentDictionary{TKey, TValue}" /> concurrently.
    /// </param>
    /// <param name="capacity">
    ///     The initial number of elements that the <see cref="ConcurrentDictionary{TKey, TValue}" /> can
    ///     contain.
    /// </param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing keys.</param>
    public ConcurrentDictionary(
        int concurrencyLevel,
        int capacity,
        IEqualityComparer<TKey> comparer)
        : base(
            concurrencyLevel,
            capacity,
            comparer) { }

#endregion

#region Methods

#region Static methods

    private static TValue UpdateInternal<TState>(
        TKey key,
        TValue oldValue)
    {
        var innerState = (TState)threadStaticMethods!;
        var innerUpdate = (Func<TKey, TValue, TState, TValue>)threadStaticUpdateFactory!;

        return innerUpdate(
            key,
            oldValue,
            innerState);
    }

#endregion

    /// <summary>
    ///     Adds a key/value pair to the <see cref="ConcurrentDictionary{TKey,TValue}" /> if the key does not already exist, or
    ///     updates a key/value pair in the <see cref="ConcurrentDictionary{TKey,TValue}" /> by using the specified function if
    ///     the key already exists.
    /// </summary>
    /// <typeparam name="TState">The type of the state.</typeparam>
    /// <param name="key">The key to be added or whose value should be updated.</param>
    /// <param name="addValue">The value to be added for an absent key.</param>
    /// <param name="updateValueFactory">
    ///     The function used to generate a new value for an existing key based on the key's
    ///     existing value.
    /// </param>
    /// <param name="state">The state object.</param>
    /// <returns>
    ///     The new value for the key. This will be either be addValue (if the key was absent) or the result of
    ///     updateValueFactory (if the key was present).
    /// </returns>
    public TValue AddOrUpdate<TState>(
        TKey key,
        TValue addValue,
        Func<TKey, TValue, TState, TValue> updateValueFactory,
        TState state)
    {
        threadStaticMethods = state;
        threadStaticUpdateFactory = updateValueFactory;

        try
        {
            return this.AddOrUpdate(
                key,
                addValue,
                UpdateInternal<TState>);
        }
        finally
        {
            threadStaticMethods = null;
            #if !FRAMEWORK_ADVANCED && !FRAMEWORK_GT_471
            threadStaticAddFactory = null;
            #endif
            threadStaticUpdateFactory = null;
        }
    }

    /// <summary>
    ///     Clears the contents of the concurrent dictionary into an array.
    /// </summary>
    /// <returns>The array of current items.</returns>
    public KeyValuePair<TKey, TValue>[] ClearToArray()
    {
        KeyValuePair<TKey, TValue>[] arr = this.ToArray();
        this.Clear();

        return arr;
    }

#endregion
}