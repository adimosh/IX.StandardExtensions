// <copyright file="WaitHandleExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions;

/// <summary>
///     Extensions for <see cref="WaitHandle" />.
/// </summary>
[PublicAPI]
public static class WaitHandleExtensions
{
#region Methods

#region Static methods

    /// <summary>
    ///     Asynchronously waits for the wait handle.
    /// </summary>
    /// <param name="handle">The handle.</param>
    /// <param name="timeout">The timeout.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns><c>true</c> if the timeout has not been reached, <c>false</c> otherwise.</returns>
    public static async ValueTask<bool> WaitOneAsync(
        this WaitHandle handle,
        TimeSpan timeout,
        CancellationToken cancellationToken)
    {
        RegisteredWaitHandle? registeredHandle = null;
        CancellationTokenRegistration tokenRegistration = default;

        try
        {
            var tcs = new TaskCompletionSource<bool>();

            registeredHandle = ThreadPool.RegisterWaitForSingleObject(
                handle,
                (
                    state,
                    timedOut) => ((TaskCompletionSource<bool>)state!).TrySetResult(!timedOut),
                tcs,
                timeout,
                true);

            tokenRegistration = cancellationToken.Register(
                state => state.TrySetCanceled(),
                tcs);

            return await tcs.Task;
        }
        finally
        {
            registeredHandle?.Unregister(null);

            #if NETSTANDARD21_OR_GREATER
                await tokenRegistration.DisposeAsync();
            #else
            tokenRegistration.Dispose();
            #endif
        }
    }

    /// <summary>
    ///     Asynchronously waits for the wait handle.
    /// </summary>
    /// <param name="handle">The handle.</param>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns><c>true</c> if the timeout has not been reached, <c>false</c> otherwise.</returns>
    public static ValueTask<bool> WaitOneAsync(
        this WaitHandle handle,
        int millisecondsTimeout,
        CancellationToken cancellationToken) =>
        handle.WaitOneAsync(
            TimeSpan.FromMilliseconds(millisecondsTimeout),
            cancellationToken);

    /// <summary>
    ///     Asynchronously waits for the wait handle.
    /// </summary>
    /// <param name="handle">The handle.</param>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns><c>true</c> if the timeout has not been reached, <c>false</c> otherwise.</returns>
    public static ValueTask<bool> WaitOneAsync(
        this WaitHandle handle,
        double millisecondsTimeout,
        CancellationToken cancellationToken) =>
        handle.WaitOneAsync(
            TimeSpan.FromMilliseconds(millisecondsTimeout),
            cancellationToken);

#endregion

#endregion
}