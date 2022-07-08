// <copyright file="BusyScope.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.ComponentModel;

/// <summary>
///     A scope of operations that can be marked as busy or idle.
/// </summary>
[PublicAPI]
public class BusyScope : SynchronizationContextInvokerBase
{
#region Internal state

    private readonly string? initialDescription;

    private int busyCount;
    private string? description;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="BusyScope" /> class.
    /// </summary>
    public BusyScope() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="BusyScope" /> class.
    /// </summary>
    /// <param name="description">The scope description.</param>
    /// <exception cref="ArgumentNullException"><paramref name="description" /> is <see langword="null" />.</exception>
    public BusyScope(string description) =>
        Requires.NotNull<string>(
            out initialDescription,
            description);

    /// <summary>
    ///     Initializes a new instance of the <see cref="BusyScope" /> class.
    /// </summary>
    /// <param name="initialBusyCount">The initial busy count.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="initialBusyCount" /> is an integer value less than 0.</exception>
    public BusyScope(int initialBusyCount) =>
        Requires.NonNegative(
            out busyCount,
            in initialBusyCount);

    /// <summary>
    ///     Initializes a new instance of the <see cref="BusyScope" /> class.
    /// </summary>
    /// <param name="initialBusyCount">The initial busy count.</param>
    /// <param name="description">The scope description.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="initialBusyCount" /> is an integer value less than 0.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="description" /> is <see langword="null" />.</exception>
    public BusyScope(
        int initialBusyCount,
        string description)
    {
        Requires.NonNegative(
            out busyCount,
            in initialBusyCount);
        Requires.NotNull<string>(
            out initialDescription,
            description);
    }

#endregion

#region Events

    /// <summary>
    ///     Occurs when the busy status of the scope has changed.
    /// </summary>
    public event EventHandler? BusyScopeChanged;

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the busy count.
    /// </summary>
    /// <value>The busy count.</value>
    public int BusyCount => busyCount;

    /// <summary>
    ///     Gets the description.
    /// </summary>
    /// <value>The description.</value>
    public string Description => description ?? initialDescription ?? string.Empty;

#endregion

#region Methods

    /// <summary>
    ///     Increments the busy scope.
    /// </summary>
    /// <param name="description">The description for the topmost busy operation.</param>
    [SuppressMessage(
        "ReSharper",
        "ParameterHidesMember",
        Justification = "We know, that's the point.")]
    public void IncrementBusyScope(string? description = null)
    {
        Interlocked.Increment(ref busyCount);
        Interlocked.Exchange(
            ref this.description,
            description);

        if (BusyScopeChanged != null)
        {
            Invoke(
                (
                    sender,
                    @event) => @event.Invoke(
                    sender,
                    EventArgs.Empty),
                this,
                BusyScopeChanged);
        }
    }

    /// <summary>
    ///     Decrements the busy scope.
    /// </summary>
    /// <exception cref="InvalidOperationException">The scope is idle.</exception>
    public void DecrementBusyScope()
    {
        if (BusyCount == 0)
        {
            throw new InvalidOperationException();
        }

        Interlocked.Decrement(ref busyCount);

        if (BusyScopeChanged != null)
        {
            Invoke(
                (
                    sender,
                    @event) => @event.Invoke(
                    sender,
                    EventArgs.Empty),
                this,
                BusyScopeChanged);
        }
    }

#endregion
}