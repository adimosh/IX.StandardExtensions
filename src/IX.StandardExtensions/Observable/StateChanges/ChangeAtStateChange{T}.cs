// <copyright file="ChangeAtStateChange{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Undoable.StateChanges;
using JetBrains.Annotations;

namespace IX.Observable.StateChanges
{
    /// <summary>
    ///     A change at a specified index.
    /// </summary>
    /// <typeparam name="T">The type of the item changed.</typeparam>
    /// <seealso cref="StateChangeBase" />
    [PublicAPI]
    public record ChangeAtStateChange<T>(
        int Index,
        T NewValue,
        T OldValue) : StateChangeBase;
}