// <copyright file="ReaderWriterSynchronizedBase.SimpleLocks.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

namespace IX.StandardExtensions.Threading;

/// <summary>
///     A base class for a reader/writer synchronized class.
/// </summary>
/// <seealso cref="IX.StandardExtensions.ComponentModel.DisposableBase" />
public abstract partial class ReaderWriterSynchronizedBase
{
#region Methods

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterReadLock()
    {
        this.locker.TryEnterReadLock(EnvironmentSettings.LockAcquisitionTimeout);

        return true;
    }

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterReadLock(int millisecondsTimeout)
    {
        this.locker.TryEnterReadLock(millisecondsTimeout);

        return true;
    }

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <param name="timeout">The timeout.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterReadLock(TimeSpan timeout)
    {
        this.locker.TryEnterReadLock(timeout);

        return true;
    }

    /// <summary>
    ///     Exits a read lock.
    /// </summary>
    protected void ExitReadLock() => this.locker.ExitReadLock();

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterWriteLock()
    {
        this.locker.TryEnterWriteLock(EnvironmentSettings.LockAcquisitionTimeout);

        return true;
    }

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterWriteLock(int millisecondsTimeout)
    {
        this.locker.TryEnterWriteLock(millisecondsTimeout);

        return true;
    }

    /// <summary>
    ///     Enters a read lock.
    /// </summary>
    /// <param name="timeout">The timeout.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterWriteLock(TimeSpan timeout)
    {
        this.locker.TryEnterWriteLock(timeout);

        return true;
    }

    /// <summary>
    ///     Exits a write lock.
    /// </summary>
    protected void ExitWriteLock() => this.locker.ExitWriteLock();

    /// <summary>
    ///     Enters an upgradeable read lock.
    /// </summary>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterUpgradeableReadLock()
    {
        this.locker.TryEnterUpgradeableReadLock(EnvironmentSettings.LockAcquisitionTimeout);

        return true;
    }

    /// <summary>
    ///     Enters an upgradeable read lock.
    /// </summary>
    /// <param name="millisecondsTimeout">The timeout, in milliseconds.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterUpgradeableReadLock(int millisecondsTimeout)
    {
        this.locker.TryEnterUpgradeableReadLock(millisecondsTimeout);

        return true;
    }

    /// <summary>
    ///     Enters an upgradeable read lock.
    /// </summary>
    /// <param name="timeout">The timeout.</param>
    /// <returns><see langword="true" /> if the lock is entered, <see langword="false" /> otherwise.</returns>
    protected bool EnterUpgradeableReadLock(TimeSpan timeout)
    {
        this.locker.TryEnterUpgradeableReadLock(timeout);

        return true;
    }

    /// <summary>
    ///     Exits an upgradeable read lock.
    /// </summary>
    protected void ExitUpgradeableReadLock() => this.locker.ExitUpgradeableReadLock();

#endregion
}