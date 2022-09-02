// <copyright file="DeconstructExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !FRAMEWORK_ADVANCED
using System.Diagnostics.CodeAnalysis;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    /// Extensions for deconstructing types.
    /// </summary>
    public static class DeconstructExtensions
    {
        /// <summary>
        /// Deconstructs the specified key-value pair into its components.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="keyValuePair">The key value pair.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        [SuppressMessage(
            "ReSharper",
            "UseDeconstructionOnParameter",
            Justification = "The point of this is to deconstruct the KeyValuePair")]
        [SuppressMessage(
            "CodeQuality",
            "IDE0079:Remove unnecessary suppression",
            Justification = "ReSharper is used in this project")]
        public static void Deconstruct<TKey, TValue>(
            this KeyValuePair<TKey, TValue> keyValuePair,
            out TKey key,
            out TValue value)
        {
            key = keyValuePair.Key;
            value = keyValuePair.Value;
        }
    }
}
#endif