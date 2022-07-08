// <copyright file="ConcurrentObservableQueue{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Runtime.Serialization;
using IX.Observable.DebugAide;
using IX.System.Threading;
using JetBrains.Annotations;

namespace IX.Observable;

/// <summary>
///     A queue that broadcasts its changes.
/// </summary>
/// <typeparam name="T">The type of items in the queue.</typeparam>
[DebuggerDisplay("ConcurrentObservableQueue, Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(QueueDebugView<>))]
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "ConcurrentObservable{0}Queue",
    ItemName = "Item")]
[PublicAPI]
public class ConcurrentObservableQueue<T> : ObservableQueue<T>
{
#region Internal state

    private Lazy<System.Threading.ReaderWriterLockSlim> locker;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    public ConcurrentObservableQueue() => locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="collection">A collection of items to copy from.</param>
    public ConcurrentObservableQueue(IEnumerable<T> collection)
        : base(collection) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the queue.</param>
    public ConcurrentObservableQueue(int capacity)
        : base(capacity) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    public ConcurrentObservableQueue(SynchronizationContext context)
        : base(context) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="collection">A collection of items to copy from.</param>
    public ConcurrentObservableQueue(
        SynchronizationContext context,
        IEnumerable<T> collection)
        : base(
            context,
            collection) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the queue.</param>
    public ConcurrentObservableQueue(
        SynchronizationContext context,
        int capacity)
        : base(
            context,
            capacity) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableQueue(bool suppressUndoable)
        : base(suppressUndoable) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="collection">A collection of items to copy from.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableQueue(
        IEnumerable<T> collection,
        bool suppressUndoable)
        : base(
            collection,
            suppressUndoable) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the queue.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableQueue(
        int capacity,
        bool suppressUndoable)
        : base(
            capacity,
            suppressUndoable) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableQueue(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            context,
            suppressUndoable) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="collection">A collection of items to copy from.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableQueue(
        SynchronizationContext context,
        IEnumerable<T> collection,
        bool suppressUndoable)
        : base(
            context,
            collection,
            suppressUndoable) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the queue.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableQueue(
        SynchronizationContext context,
        int capacity,
        bool suppressUndoable)
        : base(
            context,
            capacity,
            suppressUndoable) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets a synchronization lock item to be used when trying to synchronize read/write operations between threads.
    /// </summary>
    protected override IReaderWriterLock SynchronizationLock => locker.Value;

#endregion

#region Methods

    /// <summary>
    ///     Called when the object is being deserialized, in order to set the locker to a new value.
    /// </summary>
    /// <param name="context">The streaming context.</param>
    [OnDeserializing]
    internal void OnDeserializingMethod(StreamingContext context) =>
        Interlocked.Exchange(
            ref locker,
            EnvironmentSettings.GenerateDefaultLocker());

#region Disposable

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        Lazy<System.Threading.ReaderWriterLockSlim> l = Interlocked.Exchange(
            ref locker,
            null!);
        if (l?.IsValueCreated ?? false)
        {
            l.Value.Dispose();
        }

        base.DisposeManagedContext();
    }

    /// <summary>
    ///     Disposes the general context.
    /// </summary>
    protected override void DisposeGeneralContext()
    {
        _ = Interlocked.Exchange(
            ref locker,
            null!);

        base.DisposeGeneralContext();
    }

#endregion

#endregion
}