// <copyright file="RemoveMultipleStateChange{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Undoable.StateChanges;
using JetBrains.Annotations;

namespace IX.Observable.StateChanges
{
    /// <summary>
    ///     An undo step for when some items were removed.
    /// </summary>
    /// <typeparam name="T">The type of items.</typeparam>
    /// <seealso cref="StateChangeBase" />
    [PublicAPI]
    public record RemoveMultipleStateChange<T>(
        int[] Indexes,
        T[] RemovedItems) : StateChangeBase;
}