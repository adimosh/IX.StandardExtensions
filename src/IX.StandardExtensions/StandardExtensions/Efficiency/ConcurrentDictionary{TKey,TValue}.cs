// <copyright file="ConcurrentDictionary{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using IX.StandardExtensions.Debugging;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Efficiency
{
    /// <summary>
    ///     An efficientized version of the concurrent dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <seealso cref="global::System.Collections.Concurrent.ConcurrentDictionary{TKey, TValue}" />
    [ComVisible(false)]
    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    [DebuggerTypeProxy(typeof(DictionaryDebugView<,>))]
    [DefaultMember("Item")]
    [PublicAPI]
    public partial class ConcurrentDictionary<TKey, TValue> : global::System.Collections.Concurrent.ConcurrentDictionary<TKey, TValue>
    {
        [ThreadStatic]
        [SuppressMessage("ReSharper", "StaticMemberInGenericType", Justification = "This field is used exclusively under lock, so this is safe.")]
        private static object? threadStaticMethods;

        [ThreadStatic]
        [SuppressMessage("ReSharper", "StaticMemberInGenericType", Justification = "This field is used exclusively under lock, so this is safe.")]
        private static object? threadStaticUpdateFactory;

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
    }
}