// <copyright file="ReaderWriterLockSlim.cs" company="Adrian Mos">
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
    ///     A wrapper over <see cref="GlobalThreading.ReaderWriterLockSlim" />, compatible with
    ///     <see cref="IReaderWriterLock" />.
    /// </summary>
    /// <seealso cref="IX.System.Threading.IReaderWriterLock" />
    [PublicAPI]
    public class ReaderWriterLockSlim : DisposableBase,
        IReaderWriterLock
    {
#region Internal state

        [SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP008:Don't assign member with injected and created disposables.",
            Justification = "We're doing proper management of resources, but the analyzer can't tell.")]
        private readonly GlobalThreading.ReaderWriterLockSlim locker;

        private readonly bool lockerLocal;

#endregion

#region Constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReaderWriterLockSlim" /> class.
        /// </summary>
        public ReaderWriterLockSlim()
        {
            this.locker = new GlobalThreading.ReaderWriterLockSlim();
            this.lockerLocal = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReaderWriterLockSlim" /> class.
        /// </summary>
        /// <param name="lockRecursionPolicy">The lock recursion policy.</param>
        public ReaderWriterLockSlim(GlobalThreading.LockRecursionPolicy lockRecursionPolicy)
        {
            this.locker = new GlobalThreading.ReaderWriterLockSlim(lockRecursionPolicy);
            this.lockerLocal = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReaderWriterLockSlim" /> class.
        /// </summary>
        /// <param name="locker">The existing locker.</param>
        public ReaderWriterLockSlim(GlobalThreading.ReaderWriterLockSlim locker)
        {
            this.locker = locker;
        }

#endregion

#region Properties and indexers

        /// <summary>
        ///     Gets a value indicating whether the current thread has a read lock held.
        /// </summary>
        /// <value><see langword="true" /> if the current thread has a read lock held; otherwise, <see langword="false" />.</value>
        public bool IsReadLockHeld =>
            this.InvokeIfNotDisposed(
                lck => lck.IsReadLockHeld,
                this.locker);

        /// <summary>
        ///     Gets a value indicating whether the current thread has an upgradeable lock held.
        /// </summary>
        /// <value><see langword="true" /> if the current thread has an upgradeable lock held; otherwise, <see langword="false" />.</value>
        public bool IsUpgradeableReadLockHeld =>
            this.InvokeIfNotDisposed(
                lck => lck.IsUpgradeableReadLockHeld,
                this.locker);

        /// <summary>
        ///     Gets a value indicating whether the current thread has a write lock held.
        /// </summary>
        /// <value><see langword="true" /> if the current thread has a write lock held; otherwise, <see langword="false" />.</value>
        public bool IsWriteLockHeld =>
            this.InvokeIfNotDisposed(
                lck => lck.IsWriteLockHeld,
                this.locker);

#endregion

#region Methods

#region Operators

        /// <summary>
        ///     Performs an implicit conversion from <see cref="GlobalThreading.ReaderWriterLockSlim" /> to
        ///     <see cref="ReaderWriterLockSlim" />.
        /// </summary>
        /// <param name="lock">The locker.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ReaderWriterLockSlim(GlobalThreading.ReaderWriterLockSlim @lock) => new(@lock);

        /// <summary>
        ///     Performs an implicit conversion from <see cref="ReaderWriterLockSlim" /> to
        ///     <see cref="GlobalThreading.ReaderWriterLockSlim" />.
        /// </summary>
        /// <param name="lock">The locker.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator GlobalThreading.ReaderWriterLockSlim(ReaderWriterLockSlim @lock) =>
            Requires.NotNull(
                    @lock,
                    nameof(@lock))
                .locker;

#endregion

#region Interface implementations

        /// <summary>
        ///     Enters a read lock.
        /// </summary>
        public void EnterReadLock() =>
            this.InvokeIfNotDisposed(
                lck => lck.EnterReadLock(),
                this.locker);

        /// <summary>
        ///     Enters an upgradeable read lock.
        /// </summary>
        public void EnterUpgradeableReadLock() =>
            this.InvokeIfNotDisposed(
                lck => lck.EnterUpgradeableReadLock(),
                this.locker);

        /// <summary>
        ///     Enters the write lock.
        /// </summary>
        public void EnterWriteLock() =>
            this.InvokeIfNotDisposed(
                lck => lck.EnterWriteLock(),
                this.locker);

        /// <summary>
        ///     Exits a read lock.
        /// </summary>
        public void ExitReadLock() =>
            this.InvokeIfNotDisposed(
                lck => lck.ExitReadLock(),
                this.locker);

        /// <summary>
        ///     Exits an upgradeable read lock.
        /// </summary>
        public void ExitUpgradeableReadLock() =>
            this.InvokeIfNotDisposed(
                lck => lck.ExitUpgradeableReadLock(),
                this.locker);

        /// <summary>
        ///     Exits a write lock.
        /// </summary>
        public void ExitWriteLock() =>
            this.InvokeIfNotDisposed(
                lck => lck.ExitWriteLock(),
                this.locker);

        /// <summary>
        ///     Tries to enter a read lock.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
        /// <returns>
        ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public bool TryEnterReadLock(int millisecondsTimeout) =>
            this.InvokeIfNotDisposed(
                (
                    lck,
                    timeout) => lck.TryEnterReadLock(timeout),
                this.locker,
                millisecondsTimeout);

        /// <summary>
        ///     Tries to enter a read lock.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>
        ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public bool TryEnterReadLock(TimeSpan timeout) =>
            this.InvokeIfNotDisposed(
                (
                    lck,
                    timeoutInternal) => lck.TryEnterReadLock(timeoutInternal),
                this.locker,
                timeout);

        /// <summary>
        ///     Tries to enter an upgradeable read lock.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
        /// <returns>
        ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public bool TryEnterUpgradeableReadLock(int millisecondsTimeout) =>
            this.InvokeIfNotDisposed(
                (
                    lck,
                    timeout) => lck.TryEnterUpgradeableReadLock(timeout),
                this.locker,
                millisecondsTimeout);

        /// <summary>
        ///     Tries to enter an upgradeable read lock.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>
        ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public bool TryEnterUpgradeableReadLock(TimeSpan timeout) =>
            this.InvokeIfNotDisposed(
                (
                    lck,
                    timeoutInternal) => lck.TryEnterUpgradeableReadLock(timeoutInternal),
                this.locker,
                timeout);

        /// <summary>
        ///     Tries to enter a write lock.
        /// </summary>
        /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
        /// <returns>
        ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public bool TryEnterWriteLock(int millisecondsTimeout) =>
            this.InvokeIfNotDisposed(
                (
                    lck,
                    timeout) => lck.TryEnterWriteLock(timeout),
                this.locker,
                millisecondsTimeout);

        /// <summary>
        ///     Tries to enter a write lock.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>
        ///     <see langword="true" /> if the lock has been acquired for the calling thread, <see langword="false" />
        ///     otherwise.
        /// </returns>
        public bool TryEnterWriteLock(TimeSpan timeout) =>
            this.InvokeIfNotDisposed(
                (
                    lck,
                    timeoutInternal) => lck.TryEnterWriteLock(timeoutInternal),
                this.locker,
                timeout);

#endregion

        /// <summary>
        ///     Converts to a <see cref="GlobalThreading.ReaderWriterLockSlim" />.
        /// </summary>
        /// <returns>The <see cref="GlobalThreading.ReaderWriterLockSlim" /> that is encapsulated in this instance.</returns>
        public GlobalThreading.ReaderWriterLockSlim ToReaderWriterLockSlim() => this.locker;

#region Disposable

        /// <summary>
        ///     Disposes in the managed context.
        /// </summary>
        protected override void DisposeManagedContext()
        {
            base.DisposeManagedContext();

            if (this.lockerLocal)
            {
                this.locker.Dispose();
            }
        }

#endregion

#endregion
    }
}