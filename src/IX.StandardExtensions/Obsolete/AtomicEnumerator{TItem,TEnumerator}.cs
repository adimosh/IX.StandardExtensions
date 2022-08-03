using System.Diagnostics.CodeAnalysis;

using IX.StandardExtensions.Contracts;

// ReSharper disable once CheckNamespace
namespace IX.StandardExtensions.Threading;

internal sealed partial class AtomicEnumerator<TItem, TEnumerator>
{
#pragma warning disable CS0618 // Type or member is obsolete
    private readonly Func<ReadOnlySynchronizationLocker>? _readLockObsolete;
#pragma warning restore CS0618 // Type or member is obsolete
    /// <summary>
    ///     Initializes a new instance of the <see cref="AtomicEnumerator{TItem, TEnumerator}" /> class.
    /// </summary>
    /// <param name="existingEnumerator">The existing enumerator. This argument is passed by reference.</param>
    /// <param name="readLock">The read lock.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="existingEnumerator" />
    ///     or
    ///     <paramref name="readLock" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    [Obsolete("To remove in next breaking changes iteration")]
    [ExcludeFromCodeCoverage]
    public AtomicEnumerator(
        TEnumerator existingEnumerator,
        Func<ReadOnlySynchronizationLocker> readLock)
    {
        _ = Requires.NotNull(existingEnumerator);

        this._existingEnumerator = existingEnumerator;
        _current = default!; /* We forgive this possible null reference, as it should not be possible to
                                      * access it before reading something from the enumerator
                                      */

        Requires.NotNull(
            out this._readLockObsolete,
            readLock);
    }
}