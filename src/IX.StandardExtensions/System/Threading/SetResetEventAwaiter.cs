// <copyright file="SetResetEventAwaiter.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Abstractions.Threading;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using JetBrains.Annotations;

namespace IX.System.Threading;

/// <summary>
///     A class that is used to await on <see cref="ISetResetEvent" /> instances.
/// </summary>
public class SetResetEventAwaiter : IAwaiter
{
#region Internal state

    private readonly ISetResetEvent mre;

    private int isCompleted;

#endregion

#region Constructors and destructors

    internal SetResetEventAwaiter(ISetResetEvent mre)
    {
        Requires.NotNull(
            out this.mre,
            mre,
            nameof(mre));
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets a value indicating whether this awaiter has completed.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this awaiter has completed; otherwise, <c>false</c>.
    /// </value>
    [UsedImplicitly]
    public bool IsCompleted => this.isCompleted != 0;

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Returns the current awaiter.
    /// </summary>
    /// <returns>The current awaiter.</returns>
    public IAwaiter GetAwaiter() => this;

    /// <summary>
    ///     Gets the result.
    /// </summary>
    [UsedImplicitly]
    public void GetResult() { }

    /// <summary>Schedules the continuation action that's invoked when the instance completes.</summary>
    /// <param name="continuation">The action to invoke when the operation completes.</param>
    /// <exception cref="T:System.ArgumentNullException">
    ///     The <paramref name="continuation" /> argument is null (Nothing in
    ///     Visual Basic).
    /// </exception>
    public void OnCompleted(Action continuation) =>
        _ = Work.OnThreadPoolAsync(
            state =>
            {
                var (internalContinuation, internalThis) = state;

                internalThis.mre.WaitOne();

                internalContinuation?.Invoke();

                Interlocked.Exchange(
                    ref internalThis.isCompleted,
                    1);
            },
            (Continuation: continuation, this));

#endregion

#endregion
}