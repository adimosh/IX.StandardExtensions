// <copyright file="WriteOnlySynchronizationLocker.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.System.Threading;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading;

/// <summary>
///     A write-only synchronization locker.
/// </summary>
/// <seealso cref="IX.StandardExtensions.Threading.SynchronizationLocker" />
[PublicAPI]
[Obsolete("This class has been deemed obsolete in favor of the value-type lockers.")]
public class WriteOnlySynchronizationLocker : SynchronizationLocker
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="WriteOnlySynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public WriteOnlySynchronizationLocker(IReaderWriterLock? locker)
        : this(
            locker,
            EnvironmentSettings.LockAcquisitionTimeout) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="WriteOnlySynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="lockAcquisitionTimeout">The express lock acquisition timeout.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public WriteOnlySynchronizationLocker(
        IReaderWriterLock? locker,
        int lockAcquisitionTimeout)
        : this(
            locker,
            TimeSpan.FromMilliseconds(lockAcquisitionTimeout)) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="WriteOnlySynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="lockAcquisitionTimeoutMilliseconds">The express lock acquisition timeout.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public WriteOnlySynchronizationLocker(
        IReaderWriterLock? locker,
        double lockAcquisitionTimeoutMilliseconds)
        : this(
            locker,
            TimeSpan.FromMilliseconds(lockAcquisitionTimeoutMilliseconds)) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="WriteOnlySynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    /// <param name="lockAcquisitionTimespan">The lock acquisition timespan.</param>
    /// <exception cref="TimeoutException">The lock could not be acquired in time.</exception>
    public WriteOnlySynchronizationLocker(
        IReaderWriterLock? locker,
        TimeSpan lockAcquisitionTimespan)
        : base(locker)
    {
        if (!locker?.TryEnterWriteLock(lockAcquisitionTimespan) ?? false)
        {
            throw new TimeoutException();
        }
    }

#endregion

#region Methods

    /// <summary>
    ///     Releases the currently-held lock.
    /// </summary>
    public override void Dispose()
    {
        if (Locker == null)
        {
            return;
        }

        if (Locker.IsWriteLockHeld)
        {
            Locker.ExitWriteLock();
        }

        GC.SuppressFinalize(this);
    }

#endregion
}