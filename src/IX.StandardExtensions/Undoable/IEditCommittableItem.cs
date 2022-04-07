// <copyright file="IEditCommittableItem.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Undoable;

/// <summary>
///     Service contract for an object that supports advertising a commit of an edited set of changes.
/// </summary>
[PublicAPI]
public interface IEditCommittableItem
{
#region Events

    /// <summary>
    ///     Occurs when an edit on this item is committed.
    /// </summary>
    event EventHandler<EditCommittedEventArgs> EditCommitted;

#endregion
}