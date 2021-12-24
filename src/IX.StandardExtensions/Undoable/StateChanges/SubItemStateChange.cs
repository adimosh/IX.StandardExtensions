// <copyright file="SubItemStateChange.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

namespace IX.Undoable.StateChanges;

/// <summary>
///     A record for a set of state changes in sub-items.
/// </summary>
public record SubItemStateChange(
    IUndoableItem SubItem,
    StateChangeBase StateChange) : StateChangeBase;