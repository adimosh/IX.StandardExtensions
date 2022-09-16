using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace IX.StandardExtensions.Threading;

// TODO: Remove in 0.8.0

/// <summary>
///     A base class for a reader/writer synchronized class.
/// </summary>
/// <seealso cref="IX.StandardExtensions.ComponentModel.DisposableBase" />
public partial class ReaderWriterSynchronizedBase
{
    /// <summary>
    ///     Produces a reader lock in concurrent collections.
    /// </summary>
    /// <returns>A disposable object representing the lock.</returns>
    [Obsolete("This method has been marked obsolete, please use AcquireReadLock in its place.")]
    [ExcludeFromCodeCoverage]
    protected ReadOnlySynchronizationLocker ReadLock()
    {
        ThrowIfCurrentObjectDisposed();

        return new(
            _locker,
            lockerTimeout);
    }

    /// <summary>
    ///     Produces a writer lock in concurrent collections.
    /// </summary>
    /// <returns>A disposable object representing the lock.</returns>
    [Obsolete("This method has been marked obsolete, please use AcquireWriteLock in its place.")]
    [ExcludeFromCodeCoverage]
    protected WriteOnlySynchronizationLocker WriteLock()
    {
        ThrowIfCurrentObjectDisposed();

        return new(
            _locker,
            lockerTimeout);
    }

    /// <summary>
    ///     Produces an upgradeable reader lock in concurrent collections.
    /// </summary>
    /// <returns>A disposable object representing the lock.</returns>
    [Obsolete("This method has been marked obsolete, please use AcquireReadWriteLock in its place.")]
    [ExcludeFromCodeCoverage]
    protected ReadWriteSynchronizationLocker ReadWriteLock()
    {
        ThrowIfCurrentObjectDisposed();

        return new(
            _locker,
            lockerTimeout);
    }
}