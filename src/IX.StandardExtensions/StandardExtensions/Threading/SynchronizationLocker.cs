// <copyright file="SynchronizationLocker.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.System.Threading;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading;

/// <summary>
///     A synchronization locker base class.
/// </summary>
/// <seealso cref="IDisposable" />
[PublicAPI]
public abstract class SynchronizationLocker : IDisposable
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="SynchronizationLocker" /> class.
    /// </summary>
    /// <param name="locker">The locker.</param>
    internal SynchronizationLocker(IReaderWriterLock? locker)
    {
        Locker = locker;
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the reader/writer lock to use. This property can be <see langword="null" /> (<see langword="Nothing" /> in
    ///     Visual Basic).
    /// </summary>
    protected IReaderWriterLock? Locker { get; }

#endregion

#region Methods

#region Interface implementations

    /// <summary>
    ///     Releases the currently-held lock.
    /// </summary>
    public abstract void Dispose();

#endregion

#endregion
}