// <copyright file="DictionaryDebugView{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.Observable.DebugAide;

/// <summary>Debug view for an observable dictionary.</summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
[UsedImplicitly]
[ExcludeFromCodeCoverage]
public sealed class DictionaryDebugView<TKey, TValue>
    where TKey : notnull
{
#region Internal state

    private readonly ObservableDictionary<TKey, TValue> dict;

#endregion

#region Constructors and destructors

    /// <summary>Initializes a new instance of the <see cref="DictionaryDebugView{TKey, TValue}" /> class.</summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <exception cref="ArgumentNullException">dictionary is null.</exception>
    [UsedImplicitly]
    public DictionaryDebugView(ObservableDictionary<TKey, TValue> dictionary) =>
        Requires.NotNull(
            out dict,
            dictionary);

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the items, in debug view.
    /// </summary>
    /// <value>
    ///     The items.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    [UsedImplicitly]
    public Kvp<TKey, TValue>[] Items
    {
        get
        {
            var items = new KeyValuePair<TKey, TValue>[dict.InternalContainer.Count];
            dict.InternalContainer.CopyTo(
                items,
                0);

            return items.Select(
                    p => new Kvp<TKey, TValue>
                    {
                        Key = p.Key,
                        Value = p.Value
                    })
                .ToArray();
        }
    }

#endregion
}