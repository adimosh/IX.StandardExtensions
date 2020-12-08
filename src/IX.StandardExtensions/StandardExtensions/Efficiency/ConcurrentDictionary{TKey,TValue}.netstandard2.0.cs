// <copyright file="ConcurrentDictionary{TKey,TValue}.netstandard2.0.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;

namespace IX.StandardExtensions.Efficiency
{
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1601:Partial elements should be documented",
        Justification = "This conflicts with how XML documentation works.")]
    public partial class ConcurrentDictionary<TKey, TValue>
    {
#if !FRAMEWORK_ADVANCED && !FRAMEWORK_GT_471
        [ThreadStatic]
        [SuppressMessage("ReSharper", "StaticMemberInGenericType", Justification = "This field is used exclusively under lock, so this is safe.")]
        private static object? threadStaticAddFactory;

        private static TValue AddInternal<TState>(TKey key)
        {
            var innerState = (TState)threadStaticMethods!;
            var innerAdd = (Func<TKey, TState, TValue>)threadStaticAddFactory!;

            return innerAdd(
                key,
                innerState);
        }

        /// <summary>
        ///     Uses the specified functions to add a key/value pair to the <see cref="ConcurrentDictionary{TKey,TValue}" /> if the
        ///     key does not already exist, or to update a key/value pair in the <see cref="ConcurrentDictionary{TKey,TValue}" />
        ///     if the key already exists.
        /// </summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="key">The key to be added or whose value should be updated.</param>
        /// <param name="addValueFactory">The function used to generate a value for an absent key.</param>
        /// <param name="updateValueFactory">
        ///     The function used to generate a new value for an existing key based on the key's
        ///     existing value.
        /// </param>
        /// <param name="state">The state object.</param>
        /// <returns>
        ///     The new value for the key. This will be either be the result of addValueFactory (if the key was absent) or the
        ///     result of updateValueFactory (if the key was present).
        /// </returns>
        public TValue AddOrUpdate<TState>(
            TKey key,
            Func<TKey, TState, TValue> addValueFactory,
            Func<TKey, TValue, TState, TValue> updateValueFactory,
            TState state)
        {
            threadStaticMethods = state;
            threadStaticAddFactory = addValueFactory;
            threadStaticUpdateFactory = updateValueFactory;

            try
            {
                return this.AddOrUpdate(
                    key,
                    AddInternal<TState>,
                    UpdateInternal<TState>);
            }
            finally
            {
                threadStaticMethods = null;
                threadStaticAddFactory = null;
                threadStaticUpdateFactory = null;
            }
        }

        /// <summary>
        ///     Adds a key/value pair to the <see cref="ConcurrentDictionary{TKey,TValue}" /> by using the specified function, if
        ///     the key does not already exist.
        /// </summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <param name="state">The state object.</param>
        /// <returns>
        ///     The value for the key. This will be either the existing value for the key if the key is already in the
        ///     dictionary, or the new value for the key as returned by valueFactory if the key was not in the dictionary.
        /// </returns>
        public TValue GetOrAdd<TState>(
            TKey key,
            Func<TKey, TState, TValue> valueFactory,
            TState state)
        {
            threadStaticMethods = state;
            threadStaticAddFactory = valueFactory;

            try
            {
                return this.GetOrAdd(
                    key,
                    AddInternal<TState>);
            }
            finally
            {
                threadStaticMethods = null;
                threadStaticAddFactory = null;
                threadStaticUpdateFactory = null;
            }
        }
#endif
    }
}