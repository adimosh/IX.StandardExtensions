// <copyright file="PropertyStateChange.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

namespace IX.Undoable.StateChanges;

/// <summary>
///     A record for a state change of a property.
/// </summary>
public abstract record PropertyStateChange(string PropertyName) : StateChangeBase;