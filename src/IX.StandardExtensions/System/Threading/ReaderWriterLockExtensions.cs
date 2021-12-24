// <copyright file="ReaderWriterLockExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;
using GlobalThreading = System.Threading;

namespace IX.System.Threading;

/// <summary>
///     Extension methods for reader/writer lock classes.
/// </summary>
[PublicAPI]
public static class ReaderWriterLockExtensions
{
#region Methods

#region Static methods

    /// <summary>
    ///     Converts the source <see cref="GlobalThreading.ReaderWriterLockSlim" /> to a <see cref="IReaderWriterLock" />
    ///     abstraction.
    /// </summary>
    /// <param name="source">The source locker.</param>
    /// <returns>The abstracted version of the same event.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static IReaderWriterLock AsAbstraction(this GlobalThreading.ReaderWriterLockSlim source) =>
        new ReaderWriterLockSlim(
            Requires.NotNull(
                source,
                nameof(source)));

#endregion

#endregion
}