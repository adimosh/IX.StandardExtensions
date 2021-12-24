// <copyright file="PropertyStateChange{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

namespace IX.Undoable.StateChanges;

/// <summary>
///     A record for an undoable property change.
/// </summary>
/// <typeparam name="T">The type of value the property has.</typeparam>
public record PropertyStateChange<T>(
    string PropertyName,
    T OldValue,
    T NewValue) : PropertyStateChange(PropertyName);