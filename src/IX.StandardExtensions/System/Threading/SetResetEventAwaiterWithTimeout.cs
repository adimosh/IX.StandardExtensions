// <copyright file="SetResetEventAwaiterWithTimeout.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Abstractions.Threading;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using JetBrains.Annotations;

namespace IX.System.Threading;

/// <summary>
///     A class that is used to await on <see cref="ISetResetEvent" /> instances with a specified timeout.
/// </summary>
public class SetResetEventAwaiterWithTimeout : IAwaiter<bool>
{
#region Internal state

    private readonly ISetResetEvent mre;
    private readonly TimeSpan tsTimeout;

    private int isCompleted;
    private bool result;

#endregion

#region Constructors and destructors

    internal SetResetEventAwaiterWithTimeout(
        ISetResetEvent mre,
        int timeout)
    {
        Requires.NotNull(
            out this.mre,
            mre,
            nameof(mre));

        tsTimeout = TimeSpan.FromMilliseconds(timeout);
    }

    internal SetResetEventAwaiterWithTimeout(
        ISetResetEvent mre,
        TimeSpan timeout)
    {
        Requires.NotNull(
            out this.mre,
            mre,
            nameof(mre));

        tsTimeout = timeout;
    }

    internal SetResetEventAwaiterWithTimeout(
        ISetResetEvent mre,
        double timeout)
    {
        Requires.NotNull(
            out this.mre,
            mre,
            nameof(mre));

        tsTimeout = TimeSpan.FromMilliseconds(timeout);
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
    public bool IsCompleted => isCompleted != 0;

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Returns the current awaiter.
    /// </summary>
    /// <returns>The current awaiter.</returns>
    public IAwaiter<bool> GetAwaiter() => this;

    /// <summary>
    ///     Gets the result.
    /// </summary>
    /// <returns><c>true</c> if the wait didn't outrun the timeout, <c>false</c> if it did.</returns>
    [UsedImplicitly]
    public bool GetResult() => result;

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

                internalThis.result = internalThis.mre.WaitOne(internalThis.tsTimeout);

                internalContinuation?.Invoke();

                _ = Interlocked.Exchange(
                    ref internalThis.isCompleted,
                    1);
            },
            (Continuation: continuation, this));

#endregion

#endregion
}