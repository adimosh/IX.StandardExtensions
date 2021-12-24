// <copyright file="CompositeStateChange.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;

namespace IX.Undoable.StateChanges;

/// <summary>
///     A record for an entire set of state changes happening all at once.
/// </summary>
public record CompositeStateChange(List<StateChangeBase> StateChanges) : StateChangeBase;