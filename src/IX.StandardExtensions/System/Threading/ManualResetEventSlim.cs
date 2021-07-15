// <copyright file="ManualResetEventSlim.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using IX.StandardExtensions.Threading;
using JetBrains.Annotations;
using GlobalThreading = System.Threading;

namespace IX.System.Threading
{
    /// <summary>
    ///     A set/reset event class that implements methods to block and unblock threads based on manual signal interaction.
    /// </summary>
    /// <seealso cref="IX.System.Threading.ISetResetEvent" />
    [PublicAPI]
    public class ManualResetEventSlim : DisposableBase,
        ISetResetEvent
    {
#region Internal state

        private readonly bool eventLocal;

        /// <summary>
        ///     The manual reset event.
        /// </summary>
        [SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP006:Implement IDisposable.",
            Justification = "This is properly disposed, but the analyzer can't tell.")]
        private readonly GlobalThreading.ManualResetEventSlim internalResetEvent;

#endregion

#region Constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManualResetEventSlim" /> class.
        /// </summary>
        public ManualResetEventSlim()
        {
            this.internalResetEvent = new GlobalThreading.ManualResetEventSlim();
            this.eventLocal = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManualResetEventSlim" /> class.
        /// </summary>
        /// <param name="initialState">The initial signal state.</param>
        public ManualResetEventSlim(bool initialState)
        {
            this.internalResetEvent = new GlobalThreading.ManualResetEventSlim(initialState);
            this.eventLocal = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManualResetEventSlim" /> class.
        /// </summary>
        /// <param name="manualResetEvent">The manual reset event.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="manualResetEvent" />
        ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
        /// </exception>
        public ManualResetEventSlim(GlobalThreading.ManualResetEventSlim manualResetEvent)
        {
            Requires.NotNull(
                out this.internalResetEvent,
                manualResetEvent,
                nameof(manualResetEvent));
        }

#endregion

#region Methods

#region Operators

        /// <summary>
        ///     Performs an implicit conversion from <see cref="ManualResetEventSlim" /> to
        ///     <see cref="GlobalThreading.ManualResetEventSlim" />.
        /// </summary>
        /// <param name="manualResetEvent">The manual reset event.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator GlobalThreading.ManualResetEventSlim(ManualResetEventSlim manualResetEvent) =>
            Requires.NotNull(
                    manualResetEvent,
                    nameof(manualResetEvent))
                .internalResetEvent;

        /// <summary>
        ///     Performs an implicit conversion from <see cref="ManualResetEventSlim" /> to
        ///     <see cref="GlobalThreading.ManualResetEventSlim" />.
        /// </summary>
        /// <param name="manualResetEvent">The manual reset event.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ManualResetEventSlim(GlobalThreading.ManualResetEventSlim manualResetEvent) =>
            new(manualResetEvent);

#endregion

#region Interface implementations

        /// <summary>
        ///     Sets the state of this event instance to non-signaled. Any thread entering a wait from this point will block.
        /// </summary>
        /// <returns><see langword="true" /> if the signal has been reset, <see langword="false" /> otherwise.</returns>
        public bool Reset()
        {
            this.internalResetEvent.Reset();

            return true;
        }

        /// <summary>
        ///     Sets the state of this event instance to signaled. Any waiting thread will unblock.
        /// </summary>
        /// <returns><see langword="true" /> if the signal has been set, <see langword="false" /> otherwise.</returns>
        public bool Set()
        {
            this.internalResetEvent.Set();

            return true;
        }

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        public void WaitOne() => this.internalResetEvent.Wait();

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(int millisecondsTimeout) =>
            this.internalResetEvent.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(double millisecondsTimeout) =>
            this.internalResetEvent.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="timeout">The timeout period.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(TimeSpan timeout) => this.internalResetEvent.Wait(timeout);

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <param name="exitSynchronizationDomain">
        ///     If set to <see langword="true" />, the synchronization domain is exited before
        ///     the call.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(
            int millisecondsTimeout,
            bool exitSynchronizationDomain) =>
            this.internalResetEvent.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <param name="exitSynchronizationDomain">
        ///     If set to <see langword="true" />, the synchronization domain is exited before
        ///     the call.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(
            double millisecondsTimeout,
            bool exitSynchronizationDomain) =>
            this.internalResetEvent.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="timeout">The timeout period.</param>
        /// <param name="exitSynchronizationDomain">
        ///     If set to <see langword="true" />, the synchronization domain is exited before
        ///     the call.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(
            TimeSpan timeout,
            bool exitSynchronizationDomain) =>
            this.internalResetEvent.Wait(timeout);

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>
        ///     A potentially awaitable value task.
        /// </returns>
        public async ValueTask WaitOneAsync(GlobalThreading.CancellationToken cancellationToken = default) =>
            _ = await this.internalResetEvent.WaitHandle.WaitOneAsync(
                GlobalThreading.Timeout.InfiniteTimeSpan,
                cancellationToken);

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public ValueTask<bool> WaitOneAsync(
            int millisecondsTimeout,
            GlobalThreading.CancellationToken cancellationToken = default) =>
            this.internalResetEvent.WaitHandle.WaitOneAsync(
                millisecondsTimeout,
                cancellationToken);

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public ValueTask<bool> WaitOneAsync(
            double millisecondsTimeout,
            GlobalThreading.CancellationToken cancellationToken = default) =>
            this.internalResetEvent.WaitHandle.WaitOneAsync(
                millisecondsTimeout,
                cancellationToken);

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="timeout">The timeout period.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public ValueTask<bool> WaitOneAsync(
            TimeSpan timeout,
            GlobalThreading.CancellationToken cancellationToken = default) =>
            this.internalResetEvent.WaitHandle.WaitOneAsync(
                timeout,
                cancellationToken);

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <param name="exitSynchronizationDomain">
        ///     If set to <see langword="true" />, the synchronization domain is exited before
        ///     the call.
        /// </param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public ValueTask<bool> WaitOneAsync(
            int millisecondsTimeout,
            bool exitSynchronizationDomain,
            GlobalThreading.CancellationToken cancellationToken = default) =>
            this.internalResetEvent.WaitHandle.WaitOneAsync(
                millisecondsTimeout,
                cancellationToken);

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <param name="exitSynchronizationDomain">
        ///     If set to <see langword="true" />, the synchronization domain is exited before
        ///     the call.
        /// </param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public ValueTask<bool> WaitOneAsync(
            double millisecondsTimeout,
            bool exitSynchronizationDomain,
            GlobalThreading.CancellationToken cancellationToken = default) =>
            this.internalResetEvent.WaitHandle.WaitOneAsync(
                millisecondsTimeout,
                cancellationToken);

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="timeout">The timeout period.</param>
        /// <param name="exitSynchronizationDomain">
        ///     If set to <see langword="true" />, the synchronization domain is exited before
        ///     the call.
        /// </param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public ValueTask<bool> WaitOneAsync(
            TimeSpan timeout,
            bool exitSynchronizationDomain,
            GlobalThreading.CancellationToken cancellationToken = default) =>
            this.internalResetEvent.WaitHandle.WaitOneAsync(
                timeout,
                cancellationToken);

#endregion

        /// <summary>
        ///     Converts to a <see cref="GlobalThreading.ManualResetEventSlim" />.
        /// </summary>
        /// <returns>The <see cref="GlobalThreading.ManualResetEventSlim" /> that is encapsulated in this instance.</returns>
        public GlobalThreading.ManualResetEventSlim ToManualResetEventSlim() => this.internalResetEvent;

        /// <summary>
        /// Gets the awaiter for this event, so that it can be awaited on using &quot;await mre;&quot;.
        /// </summary>
        /// <returns>An awaiter that works the same as <see cref="WaitOne()"/>, continuing on a different thread.</returns>
        public SetResetEventAwaiter GetAwaiter() => new(this);

        /// <summary>
        /// Gets the awaiter for this event, with a timeout.
        /// </summary>
        /// <param name="timeout">The timeout to wait until expiring.</param>
        /// <returns>An awaiter that works the same as <see cref="WaitOne(TimeSpan)"/>, continuing on a different thread.</returns>
        public SetResetEventAwaiterWithTimeout WithTimeout(TimeSpan timeout) => new(this, timeout);

        /// <summary>
        /// Gets the awaiter for this event, with a timeout.
        /// </summary>
        /// <param name="timeout">The timeout to wait until expiring.</param>
        /// <returns>An awaiter that works the same as <see cref="WaitOne(double)"/>, continuing on a different thread.</returns>
        public SetResetEventAwaiterWithTimeout WithTimeout(double timeout) => new(this, timeout);

        /// <summary>
        /// Gets the awaiter for this event, with a timeout.
        /// </summary>
        /// <param name="timeout">The timeout to wait until expiring.</param>
        /// <returns>An awaiter that works the same as <see cref="WaitOne(int)"/>, continuing on a different thread.</returns>
        public SetResetEventAwaiterWithTimeout WithTimeout(int timeout) => new(this, timeout);

#region Disposable

        /// <summary>
        ///     Disposes in the managed context.
        /// </summary>
        protected override void DisposeManagedContext()
        {
            base.DisposeManagedContext();

            if (this.eventLocal)
            {
                this.internalResetEvent.Dispose();
            }
        }

#endregion

#endregion
    }
}