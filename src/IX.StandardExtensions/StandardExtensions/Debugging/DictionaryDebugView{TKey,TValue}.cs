// <copyright file="DictionaryDebugView{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Debugging;

/// <summary>
///     A debug view for dictionaries. This class cannot be inherited.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
[ComVisible(false)]
[PublicAPI]
public sealed class DictionaryDebugView<TKey, TValue>
{
#region Internal state

    private readonly IDictionary<TKey, TValue> dict;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="DictionaryDebugView{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="dictionary" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public DictionaryDebugView(IDictionary<TKey, TValue> dictionary)
    {
        Requires.NotNull(
            out dict,
            dictionary,
            nameof(dictionary));
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the items.
    /// </summary>
    /// <value>The items.</value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    [SuppressMessage(
        "Performance",
        "CA1819:Properties should not return arrays",
        Justification = "This is supposed to be like this.")]
    public KyeValuePairDebugView<TKey, TValue>[] Items
    {
        get
        {
            var items = new KeyValuePair<TKey, TValue>[dict.Count];
            dict.CopyTo(
                items,
                0);

            return items.Select(
                    p => new KyeValuePairDebugView<TKey, TValue>
                    {
                        Key = p.Key,
                        Value = p.Value
                    })
                .ToArray();
        }
    }

#endregion
}