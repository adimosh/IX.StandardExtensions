using IX.StandardExtensions.Threading;

namespace IX.Observable;

public partial class ObservableBase
{
    /// <summary>
    ///     Produces a reader lock in concurrent collections.
    /// </summary>
    /// <returns>A disposable object representing the lock.</returns>
    [Obsolete("To remove in next breaking changes iteration")]
    protected ReadOnlySynchronizationLocker ReadLock() => new(SynchronizationLock);

    /// <summary>
    ///     Produces a writer lock in concurrent collections.
    /// </summary>
    /// <returns>A disposable object representing the lock.</returns>
    [Obsolete("To remove in next breaking changes iteration")]
    protected WriteOnlySynchronizationLocker WriteLock() => new(SynchronizationLock);

    /// <summary>
    ///     Produces an upgradeable reader lock in concurrent collections.
    /// </summary>
    /// <returns>A disposable object representing the lock.</returns>
    [Obsolete("To remove in next breaking changes iteration")]
    protected ReadWriteSynchronizationLocker ReadWriteLock() => new(SynchronizationLock);
}