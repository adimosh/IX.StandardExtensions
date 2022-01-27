// <copyright file="DictionaryChangeStateChange{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Undoable.StateChanges;
using JetBrains.Annotations;

namespace IX.Observable.StateChanges;

/// <summary>
///     An undo level for changing something in a dictionary.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
/// <seealso cref="StateChangeBase" />
[PublicAPI]
public record DictionaryChangeStateChange<TKey, TValue>(
    TKey Key,
    TValue NewValue,
    TValue OldValue) : StateChangeBase;