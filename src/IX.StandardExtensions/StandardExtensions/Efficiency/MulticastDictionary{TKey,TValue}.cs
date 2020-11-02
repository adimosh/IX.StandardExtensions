// <copyright file="MulticastDictionary{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Efficiency
{
    /// <summary>
    /// A multicast dictionary that attempts to hold multiple values for the same key, and take them one
    /// at a time if the previous one did not yield the correct actionable result.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <seealso cref="IX.StandardExtensions.ComponentModel.DisposableBase" />
    [PublicAPI]
    public class MulticastDictionary<TKey, TValue> : DisposableBase
        where TKey : notnull
    {
        private readonly ConcurrentDictionary<TKey, List<TValue>> innerDictionary = new ConcurrentDictionary<TKey, List<TValue>>();

        /// <summary>
        /// Adds the specified key and value pair to the dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(
            TKey key,
            TValue value) =>
            _ = this.innerDictionary.AddOrUpdate(
                key,
                _ => new List<TValue>
                {
                    value
                },
                (
                    _,
                    v) =>
                {
                    v.Add(value);

                    return v;
                });

        /// <summary>
        /// Removes a specified key entirely from the multicast dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(TKey key) =>
            _ = this.innerDictionary.TryRemove(
                key,
                out _);

        /// <summary>
        /// Removes a value pertaining to a specified key from the multicast dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Remove(
            TKey key,
            TValue value)
        {
            if (!this.innerDictionary.TryGetValue(
                key,
                out var list))
            {
                return;
            }

            list.Remove(value);

            if (list.Count == 0)
            {
                this.Remove(key);
            }
        }

        /// <summary>
        /// Clears all keys from the multicast dictionary.
        /// </summary>
        public void Clear() => this.innerDictionary.Clear();

        /// <summary>
        /// Tries to act on a specified key, based on its multiple values.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="action">The action to attempt.</param>
        /// <returns>Whether or not any action, if one was found, was successful.</returns>
        public bool TryAct(
            TKey key,
            Func<KeyValuePair<TKey, TValue>, bool> action)
        {
            Requires.NotNull(
                action,
                nameof(action));

            if (!this.innerDictionary.TryGetValue(
                    key,
                    out var list) ||
                list.Count == 0)
            {
                return false;
            }

            foreach (var value in list)
            {
                KeyValuePair<TKey, TValue> mac = new KeyValuePair<TKey, TValue>(key, value);
                if (action(mac))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tries to act on a specified key, based on its multiple values.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="action">The action to attempt.</param>
        /// <returns>Whether or not any action, if one was found, was successful.</returns>
        public bool TryAct(
            TKey key,
            Func<TKey, TValue, bool> action)
        {
            Requires.NotNull(
                action,
                nameof(action));

            if (!this.innerDictionary.TryGetValue(
                    key,
                    out var list) ||
                list.Count == 0)
            {
                return false;
            }

            foreach (var value in list)
            {
                if (action(key, value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tries to act asynchronously on a specified key, based on its multiple values.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="action">The action to attempt.</param>
        /// <returns>Whether or not any action, if one was found, was successful.</returns>
        public async Task<bool> TryActAsync(
            TKey key,
            Func<KeyValuePair<TKey, TValue>, Task<bool>> action)
        {
            Requires.NotNull(
                action,
                nameof(action));

            if (!this.innerDictionary.TryGetValue(
                    key,
                    out var list) ||
                list.Count == 0)
            {
                return false;
            }

            foreach (var value in list)
            {
                KeyValuePair<TKey, TValue> mac = new KeyValuePair<TKey, TValue>(key, value);
                if (await action(mac).ConfigureAwait(false))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tries to act asynchronously on a specified key, based on its multiple values.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="action">The action to attempt.</param>
        /// <returns>Whether or not any action, if one was found, was successful.</returns>
        public async Task<bool> TryActAsync(
            TKey key,
            Func<TKey, TValue, Task<bool>> action)
        {
            Requires.NotNull(
                action,
                nameof(action));

            if (!this.innerDictionary.TryGetValue(
                    key,
                    out var list) ||
                list.Count == 0)
            {
                return false;
            }

            foreach (var value in list)
            {
                if (await action(key, value).ConfigureAwait(false))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>Disposes in the managed context.</summary>
        protected override void DisposeManagedContext()
        {
            var currentKeys = this.innerDictionary.Keys.ToArray();
            foreach (var key in currentKeys)
            {
                if (this.innerDictionary.TryRemove(key, out var list))
                {
                    list.Clear();
                }
            }

            this.innerDictionary.Clear();
            base.DisposeManagedContext();
        }
    }
}