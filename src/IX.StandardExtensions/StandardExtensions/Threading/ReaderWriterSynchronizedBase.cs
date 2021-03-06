// <copyright file="ReaderWriterSynchronizedBase.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Threading;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Contracts;
using IX.System.Threading;
using JetBrains.Annotations;
using ReaderWriterLockSlim = IX.System.Threading.ReaderWriterLockSlim;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A base class for a reader/writer synchronized class.
    /// </summary>
    /// <seealso cref="IX.StandardExtensions.ComponentModel.DisposableBase" />
    [DataContract(Namespace = Constants.DataContractNamespace)]
    [PublicAPI]
    public abstract partial class ReaderWriterSynchronizedBase : DisposableBase
    {
#region Internal state

        private readonly bool lockInherited;

        [SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP008:Don't assign member with injected and created disposables.",
            Justification = "We can't do that here, as doing exactly that is the purpose of this class.")]
        [SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP002:Dispose member.",
            Justification = "It is.")]
        [SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP006:Implement IDisposable.",
            Justification = "It is.")]
        private IReaderWriterLock locker;

        [DataMember]
        private TimeSpan lockerTimeout;

#endregion

#region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReaderWriterSynchronizedBase" /> class.
        /// </summary>
        protected ReaderWriterSynchronizedBase()
        {
            this.locker = new ReaderWriterLockSlim();
            this.lockerTimeout = EnvironmentSettings.LockAcquisitionTimeout;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReaderWriterSynchronizedBase" /> class.
        /// </summary>
        /// <param name="locker">The locker.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="locker" />
        ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
        /// </exception>
        protected ReaderWriterSynchronizedBase(IReaderWriterLock? locker)
        {
            Requires.NotNull(
                out this.locker,
                locker,
                nameof(locker));
            this.lockInherited = true;
            this.lockerTimeout = EnvironmentSettings.LockAcquisitionTimeout;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReaderWriterSynchronizedBase" /> class.
        /// </summary>
        /// <param name="timeout">The lock timeout duration.</param>
        protected ReaderWriterSynchronizedBase(TimeSpan timeout)
        {
            this.locker = new ReaderWriterLockSlim();
            this.lockerTimeout = timeout;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReaderWriterSynchronizedBase" /> class.
        /// </summary>
        /// <param name="locker">The locker.</param>
        /// <param name="timeout">The lock timeout duration.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="locker" />
        ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
        /// </exception>
        protected ReaderWriterSynchronizedBase(
            IReaderWriterLock locker,
            TimeSpan timeout)
        {
            Requires.NotNull(
                out this.locker,
                locker,
                nameof(locker));
            this.lockInherited = true;
            this.lockerTimeout = timeout;
        }

#endregion

#region Methods

        /// <summary>
        ///     Called when the object is being deserialized, in order to set the locker to a new value.
        /// </summary>
        /// <param name="context">The streaming context.</param>
        [OnDeserializing]
        [SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP003:Dispose previous before re-assigning.",
            Justification = "This method is the OnDeserializing method, so there is no instance to dispose of before reassigning.")]
        [SuppressMessage(
            "IDisposableAnalyzers.Correctness",
            "IDISP004:Don't ignore created IDisposable.",
            Justification = "We really aren't.")]
        internal void OnDeserializingMethod(StreamingContext context) =>
            Interlocked.Exchange(
                ref this.locker,
                new ReaderWriterLockSlim());

#region Disposable

        /// <summary>
        ///     Disposes in the managed context.
        /// </summary>
        protected override void DisposeManagedContext()
        {
            if (!this.lockInherited)
            {
                this.locker.Dispose();
            }

            base.DisposeManagedContext();
        }

#endregion

        /// <summary>
        ///     Produces a reader lock in concurrent collections.
        /// </summary>
        /// <returns>A disposable object representing the lock.</returns>
        protected ReadOnlySynchronizationLocker ReadLock()
        {
            this.RequiresNotDisposed();

            return new ReadOnlySynchronizationLocker(
                this.locker,
                this.lockerTimeout);
        }

        /// <summary>
        ///     Invokes using a reader lock.
        /// </summary>
        /// <param name="action">An action that is called.</param>
        protected void ReadLock(Action action)
        {
            this.RequiresNotDisposed();
            Action localAction = Requires.NotNull(
                action,
                nameof(action));

            using (new ReadOnlySynchronizationLocker(
                this.locker,
                this.lockerTimeout))
            {
                localAction();
            }
        }

        /// <summary>
        ///     Gets a result from an invoker using a reader lock.
        /// </summary>
        /// <param name="action">An action that is called to get the result.</param>
        /// <typeparam name="T">The type of the object to return.</typeparam>
        /// <returns>A disposable object representing the lock.</returns>
        protected T ReadLock<T>(Func<T> action)
        {
            this.RequiresNotDisposed();
            Func<T> localAction = Requires.NotNull(
                action,
                nameof(action));

            using (new ReadOnlySynchronizationLocker(
                this.locker,
                this.lockerTimeout))
            {
                return localAction();
            }
        }

        /// <summary>
        ///     Produces a writer lock in concurrent collections.
        /// </summary>
        /// <returns>A disposable object representing the lock.</returns>
        protected WriteOnlySynchronizationLocker WriteLock()
        {
            this.RequiresNotDisposed();

            return new WriteOnlySynchronizationLocker(
                this.locker,
                this.lockerTimeout);
        }

        /// <summary>
        ///     Invokes using a writer lock.
        /// </summary>
        /// <param name="action">An action that is called.</param>
        protected void WriteLock(Action action)
        {
            this.RequiresNotDisposed();
            Action localAction = Requires.NotNull(
                action,
                nameof(action));

            using (new WriteOnlySynchronizationLocker(
                this.locker,
                this.lockerTimeout))
            {
                localAction();
            }
        }

        /// <summary>
        ///     Invokes using a writer lock.
        /// </summary>
        /// <typeparam name="T">The type of item to return.</typeparam>
        /// <param name="action">An action that is called.</param>
        /// <returns>The generated item.</returns>
        protected T WriteLock<T>(Func<T> action)
        {
            this.RequiresNotDisposed();
            Func<T> localAction = Requires.NotNull(
                action,
                nameof(action));

            using (new WriteOnlySynchronizationLocker(
                this.locker,
                this.lockerTimeout))
            {
                return localAction();
            }
        }

        /// <summary>
        ///     Produces an upgradeable reader lock in concurrent collections.
        /// </summary>
        /// <returns>A disposable object representing the lock.</returns>
        protected ReadWriteSynchronizationLocker ReadWriteLock()
        {
            this.RequiresNotDisposed();

            return new ReadWriteSynchronizationLocker(
                this.locker,
                this.lockerTimeout);
        }

#endregion
    }
}