// <copyright file="ManualResetEventSlim.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;
using GlobalThreading = System.Threading;

namespace IX.System.Threading
{
    /// <summary>
    ///     A set/reset event class that implements methods to block and unblock threads based on manual signal interaction.
    /// </summary>
    /// <seealso cref="IX.System.Threading.ISetResetEvent" />
    [PublicAPI]
    public class ManualResetEventSlim : DisposableBase, ISetResetEvent
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
        private readonly GlobalThreading.ManualResetEventSlim sre;

#endregion

#region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManualResetEventSlim" /> class.
        /// </summary>
        public ManualResetEventSlim()
        {
            this.sre = new GlobalThreading.ManualResetEventSlim();
            this.eventLocal = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManualResetEventSlim" /> class.
        /// </summary>
        /// <param name="initialState">The initial signal state.</param>
        public ManualResetEventSlim(bool initialState)
        {
            this.sre = new GlobalThreading.ManualResetEventSlim(initialState);
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
                ref this.sre,
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
                .sre;

        /// <summary>
        ///     Performs an implicit conversion from <see cref="ManualResetEventSlim" /> to
        ///     <see cref="GlobalThreading.ManualResetEventSlim" />.
        /// </summary>
        /// <param name="manualResetEvent">The manual reset event.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ManualResetEventSlim(GlobalThreading.ManualResetEventSlim manualResetEvent) =>
            new ManualResetEventSlim(manualResetEvent);

#endregion

#region Interface implementations

        /// <summary>
        ///     Sets the state of this event instance to non-signaled. Any thread entering a wait from this point will block.
        /// </summary>
        /// <returns><see langword="true" /> if the signal has been reset, <see langword="false" /> otherwise.</returns>
        public bool Reset()
        {
            this.sre.Reset();
            return true;
        }

        /// <summary>
        ///     Sets the state of this event instance to signaled. Any waiting thread will unblock.
        /// </summary>
        /// <returns><see langword="true" /> if the signal has been set, <see langword="false" /> otherwise.</returns>
        public bool Set()
        {
            this.sre.Set();
            return true;
        }

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        public void WaitOne() => this.sre.Wait();

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(int millisecondsTimeout) => this.sre.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(double millisecondsTimeout) =>
            this.sre.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="timeout">The timeout period.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(TimeSpan timeout) => this.sre.Wait(timeout);

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
            this.sre.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

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
            this.sre.Wait(TimeSpan.FromMilliseconds(millisecondsTimeout));

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
            this.sre.Wait(timeout);

#endregion

        /// <summary>
        ///     Converts to a <see cref="GlobalThreading.ManualResetEventSlim" />.
        /// </summary>
        /// <returns>The <see cref="GlobalThreading.ManualResetEventSlim" /> that is encapsulated in this instance.</returns>
        public GlobalThreading.ManualResetEventSlim ToManualResetEventSlim() => this.sre;

#region Disposable

        /// <summary>
        ///     Disposes in the managed context.
        /// </summary>
        protected override void DisposeManagedContext()
        {
            base.DisposeManagedContext();

            if (this.eventLocal)
            {
                this.sre.Dispose();
            }
        }

#endregion

#endregion
    }
}