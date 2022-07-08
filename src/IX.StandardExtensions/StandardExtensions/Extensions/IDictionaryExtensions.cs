// <copyright file="IDictionaryExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions;

/// <summary>
///     Extensions for IDictionary.
/// </summary>
[PublicAPI]
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "We're just doing IDictionary extensions.")]
public static partial class IDictionaryExtensions
{
#region Methods

#region Static methods

    /// <summary>
    ///     Creates a clone of a dictionary, with shallow clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A cloned dictionary with shallow clones.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static Dictionary<TKey, TValue> CopyWithShallowClones<TKey, TValue>(this Dictionary<TKey, TValue> source)
        where TKey : notnull
        where TValue : IShallowCloneable<TValue>
    {
        _ = Requires.NotNull(source);

        var destination = new Dictionary<TKey, TValue>();

        foreach (KeyValuePair<TKey, TValue> p in source)
        {
            destination.Add(
                p.Key,
                p.Value.ShallowClone());
        }

        return destination;
    }

    /// <summary>
    ///     Creates a deep clone of a dictionary, with deep clones of its values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="source">The source.</param>
    /// <returns>A deeply-cloned dictionary.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static Dictionary<TKey, TValue> DeepClone<TKey, TValue>(this Dictionary<TKey, TValue> source)
        where TKey : notnull
        where TValue : IDeepCloneable<TValue>
    {
        _ = Requires.NotNull(source);

        var destination = new Dictionary<TKey, TValue>();

        foreach (KeyValuePair<TKey, TValue> p in source)
        {
            destination.Add(
                p.Key,
                p.Value.DeepClone());
        }

        return destination;
    }

#endregion

#endregion
}