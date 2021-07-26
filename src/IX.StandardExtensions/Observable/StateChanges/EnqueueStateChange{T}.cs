// <copyright file="EnqueueStateChange{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Undoable.StateChanges;
using JetBrains.Annotations;

namespace IX.Observable.StateChanges
{
    /// <summary>
    ///     An undo step for when an item was enqueued.
    /// </summary>
    /// <typeparam name="T">The type of item.</typeparam>
    /// <seealso cref="StateChangeBase" />
    [PublicAPI]
    public record EnqueueStateChange<T>(T EnqueuedItem) : StateChangeBase;
}