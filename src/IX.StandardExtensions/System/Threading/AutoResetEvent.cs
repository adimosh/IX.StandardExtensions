// <copyright file="AutoResetEvent.cs" company="Adrian Mos">
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
    ///     A set/reset event class that implements methods to block threads and unblock automatically.
    /// </summary>
    /// <seealso cref="IX.System.Threading.ISetResetEvent" />
    [PublicAPI]
    public class AutoResetEvent : DisposableBase, ISetResetEvent
    {
#region Internal state

        private readonly bool eventLocal;

        /// <summary>
        ///     The manual reset event.
        /// </summary>
        [SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP006:Implement IDisposable.",
            Justification = "IDisposable is correctly implemented in base class.")]
        private readonly GlobalThreading.AutoResetEvent sre;

#endregion

#region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AutoResetEvent" /> class.
        /// </summary>
        public AutoResetEvent()
            : this(false)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AutoResetEvent" /> class.
        /// </summary>
        /// <param name="initialState">The initial signal state.</param>
        public AutoResetEvent(bool initialState)
        {
            this.sre = new GlobalThreading.AutoResetEvent(initialState);
            this.eventLocal = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AutoResetEvent" /> class.
        /// </summary>
        /// <param name="autoResetEvent">The automatic reset event to wrap around.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="autoResetEvent" /> is <see langword="null" /> (
        ///     <see langword="Nothing" /> in Visual Basic).
        /// </exception>
        [SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP003:Dispose previous before re-assigning.",
            Justification = "This is a constructor, the analyzer is thrown off.")]
        public AutoResetEvent(GlobalThreading.AutoResetEvent autoResetEvent)
        {
            Requires.NotNull(
                out this.sre,
                autoResetEvent,
                nameof(autoResetEvent));
        }

#endregion

#region Methods

#region Operators

        /// <summary>
        ///     Performs an implicit conversion from <see cref="GlobalThreading.AutoResetEvent" /> to
        ///     <see cref="AutoResetEvent" />.
        /// </summary>
        /// <param name="autoResetEvent">The automatic reset event.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator AutoResetEvent(GlobalThreading.AutoResetEvent autoResetEvent) =>
            new AutoResetEvent(autoResetEvent);

        /// <summary>
        ///     Performs an implicit conversion from <see cref="AutoResetEvent" /> to
        ///     <see cref="GlobalThreading.AutoResetEvent" />.
        /// </summary>
        /// <param name="autoResetEvent">The automatic reset event.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator GlobalThreading.AutoResetEvent(AutoResetEvent autoResetEvent) =>
            Requires.NotNull(
                    autoResetEvent,
                    nameof(autoResetEvent))
                .sre;

#endregion

#region Interface implementations

        /// <summary>
        ///     Sets the state of this event instance to non-signaled. Any thread entering a wait from this point will block.
        /// </summary>
        /// <returns><see langword="true" /> if the signal has been reset, <see langword="false" /> otherwise.</returns>
        public bool Reset() => this.sre.Reset();

        /// <summary>
        ///     Sets the state of this event instance to signaled. Any waiting thread will unblock.
        /// </summary>
        /// <returns><see langword="true" /> if the signal has been set, <see langword="false" /> otherwise.</returns>
        public bool Set() => this.sre.Set();

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        public void WaitOne() => this.sre.WaitOne();

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(int millisecondsTimeout) =>
            this.sre.WaitOne(TimeSpan.FromMilliseconds(millisecondsTimeout));

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout period, in milliseconds.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(double millisecondsTimeout) =>
            this.sre.WaitOne(TimeSpan.FromMilliseconds(millisecondsTimeout));

        /// <summary>
        ///     Enters a wait period and, should there be no signal set, blocks the thread calling.
        /// </summary>
        /// <param name="timeout">The timeout period.</param>
        /// <returns>
        ///     <see langword="true" /> if the event is set within the timeout period, <see langword="false" /> if the timeout
        ///     is reached.
        /// </returns>
        public bool WaitOne(TimeSpan timeout) => this.sre.WaitOne(timeout);

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
            this.sre.WaitOne(
                TimeSpan.FromMilliseconds(millisecondsTimeout),
                exitSynchronizationDomain);

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
            this.sre.WaitOne(
                TimeSpan.FromMilliseconds(millisecondsTimeout),
                exitSynchronizationDomain);

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
            this.sre.WaitOne(
                timeout,
                exitSynchronizationDomain);

#endregion

        /// <summary>
        ///     Converts to a <see cref="GlobalThreading.ManualResetEvent" />.
        /// </summary>
        /// <returns>The <see cref="GlobalThreading.ManualResetEvent" /> that is encapsulated in this instance.</returns>
        public GlobalThreading.AutoResetEvent ToAutoResetEvent() => this.sre;

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