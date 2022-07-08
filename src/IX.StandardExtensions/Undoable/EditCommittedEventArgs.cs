// <copyright file="EditCommittedEventArgs.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Undoable.StateChanges;
using JetBrains.Annotations;

namespace IX.Undoable;

/// <summary>
///     Event arguments for edit committed.
/// </summary>
[PublicAPI]
public class EditCommittedEventArgs : EventArgs
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="EditCommittedEventArgs" /> class.
    /// </summary>
    /// <param name="stateChanges">The state changes that have been committed.</param>
    public EditCommittedEventArgs(StateChangeBase stateChanges) => StateChanges = stateChanges;

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the state changes that have been committed.
    /// </summary>
    public StateChangeBase StateChanges { get; }

#endregion
}