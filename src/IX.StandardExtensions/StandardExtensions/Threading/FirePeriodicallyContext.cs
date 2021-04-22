// <copyright file="FirePeriodicallyContext.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Threading;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A ticker delegate.
    /// </summary>
    /// <param name="tick">The tick index.</param>
    /// <param name="interruptor">
    ///     The interruptor object, should the periodical firing mechanism be requested to be
    ///     interrupted.
    /// </param>
    /// <param name="state">The state.</param>
    [PublicAPI]
    public delegate void FirePeriodicallyTicker(
        int tick,
        IInterruptible interruptor,
        object? state);

    internal sealed class FirePeriodicallyContext : DisposableBase, IInterruptible
    {
        private readonly object? state;
        private readonly TimeSpan timeSpan;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP002:Dispose member.",
            Justification = "It is disposed.")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP006:Implement IDisposable.",
            Justification = "It is implemented, the analyzer cannot figure it out automatically.")]
        private readonly Timer timer;

        private int iteration;

        internal FirePeriodicallyContext(
            FirePeriodicallyTicker tickerDelegate,
            object? state,
            int milliseconds)
            : this(
                tickerDelegate,
                state,
                TimeSpan.FromMilliseconds(milliseconds))
        {
        }

        internal FirePeriodicallyContext(
            FirePeriodicallyTicker tickerDelegate,
            object? state,
            TimeSpan timeSpan)
            : this(
                tickerDelegate,
                state,
                TimeSpan.Zero,
                timeSpan)
        {
        }

        internal FirePeriodicallyContext(
            FirePeriodicallyTicker tickerDelegate,
            object? state,
            TimeSpan initialDelay,
            TimeSpan timeSpan)
        {
            this.state = state;
            this.timeSpan = timeSpan;
            this.timer = new Timer(
                this.TimerTick,
                Requires.NotNull(tickerDelegate, nameof(tickerDelegate)),
                initialDelay,
                timeSpan);
        }

        /// <summary>
        ///     Interrupts this instance.
        /// </summary>
        public void Interrupt() => this.timer.Change(
            Timeout.Infinite,
            Timeout.Infinite);

        /// <summary>
        ///     Resumes this instance.
        /// </summary>
        public void Resume() => this.timer.Change(
            TimeSpan.Zero,
            this.timeSpan);

        /// <summary>
        ///     Disposes in the general (managed and unmanaged) context.
        /// </summary>
        protected override void DisposeGeneralContext()
        {
            base.DisposeGeneralContext();

            this.timer.Dispose();
        }

        private void TimerTick(object stateObject)
        {
            var ticker = (FirePeriodicallyTicker)stateObject;

            Interlocked.Increment(ref this.iteration);

            ticker(
                this.iteration,
                this,
                this.state);
        }
    }
}