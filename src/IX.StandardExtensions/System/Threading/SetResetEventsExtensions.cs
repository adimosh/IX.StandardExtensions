// <copyright file="SetResetEventsExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;
using GlobalThreading = System.Threading;

namespace IX.System.Threading;

/// <summary>
///     Extension methods for set/reset event classes.
/// </summary>
[PublicAPI]
public static class SetResetEventsExtensions
{
#region Methods

#region Static methods

    /// <summary>
    ///     Converts the source <see cref="GlobalThreading.AutoResetEvent" /> to a <see cref="ISetResetEvent" /> abstraction.
    /// </summary>
    /// <param name="source">The source event.</param>
    /// <returns>The abstracted version of the same event.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static ISetResetEvent AsAbstraction(this GlobalThreading.AutoResetEvent source) =>
        new AutoResetEvent(
            Requires.NotNull(
                source,
                nameof(source)));

    /// <summary>
    ///     Converts the source <see cref="GlobalThreading.ManualResetEvent" /> to a <see cref="ISetResetEvent" /> abstraction.
    /// </summary>
    /// <param name="source">The source event.</param>
    /// <returns>The abstracted version of the same event.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static ISetResetEvent AsAbstraction(this GlobalThreading.ManualResetEvent source) =>
        new ManualResetEvent(
            Requires.NotNull(
                source,
                nameof(source)));

    /// <summary>
    ///     Converts the source <see cref="GlobalThreading.ManualResetEventSlim" /> to a <see cref="ISetResetEvent" />
    ///     abstraction.
    /// </summary>
    /// <param name="source">The source event.</param>
    /// <returns>The abstracted version of the same event.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public static ISetResetEvent AsAbstraction(this GlobalThreading.ManualResetEventSlim source) =>
        new ManualResetEventSlim(
            Requires.NotNull(
                source,
                nameof(source)));

#endregion

#endregion
}