// <copyright file="ObservableQueue{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Runtime.Serialization;
using IX.Observable.Adapters;
using IX.Observable.DebugAide;
using IX.Observable.StateChanges;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using IX.System.Collections.Generic;
using IX.Undoable.StateChanges;
using JetBrains.Annotations;

namespace IX.Observable;

/// <summary>
///     A queue that broadcasts its changes.
/// </summary>
/// <typeparam name="T">The type of items in the queue.</typeparam>
[DebuggerDisplay("ObservableQueue, Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(QueueDebugView<>))]
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "Observable{0}Queue",
    ItemName = "Item")]
[PublicAPI]
public class ObservableQueue<T> : ObservableCollectionBase<T>,
    IQueue<T>
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    public ObservableQueue()
        : base(new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>())) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="collection">A collection of items to copy from.</param>
    public ObservableQueue(IEnumerable<T> collection)
        : base(new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>(collection))) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the queue.</param>
    public ObservableQueue(int capacity)
        : base(new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>(capacity))) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    public ObservableQueue(SynchronizationContext context)
        : base(
            new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>()),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="collection">A collection of items to copy from.</param>
    public ObservableQueue(
        SynchronizationContext context,
        IEnumerable<T> collection)
        : base(
            new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>(collection)),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the queue.</param>
    public ObservableQueue(
        SynchronizationContext context,
        int capacity)
        : base(
            new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>(capacity)),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableQueue(bool suppressUndoable)
        : base(
            new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>()),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="collection">A collection of items to copy from.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableQueue(
        IEnumerable<T> collection,
        bool suppressUndoable)
        : base(
            new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>(collection)),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the queue.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableQueue(
        int capacity,
        bool suppressUndoable)
        : base(
            new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>(capacity)),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableQueue(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>()),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="collection">A collection of items to copy from.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableQueue(
        SynchronizationContext context,
        IEnumerable<T> collection,
        bool suppressUndoable)
        : base(
            new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>(collection)),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableQueue{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the queue.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableQueue(
        SynchronizationContext context,
        int capacity,
        bool suppressUndoable)
        : base(
            new QueueCollectionAdapter<T>(new System.Collections.Generic.Queue<T>(capacity)),
            context,
            suppressUndoable) { }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets a value indicating whether this queue is empty.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this queue is empty; otherwise, <c>false</c>.
    /// </value>
    public bool IsEmpty => this.Count == 0;

#endregion

#region Queue-specific methods

    /// <summary>
    ///     De-queues and removes an item from the queue.
    /// </summary>
    /// <returns>The de-queued item.</returns>
    public T Dequeue()
    {
        this.RequiresNotDisposed();

        T item;

        using (this.WriteLock())
        {
            item = ((QueueCollectionAdapter<T>)this.InternalContainer).Dequeue();
            this.PushUndoLevel(new DequeueStateChange<T>(item));
        }

        this.RaisePropertyChanged(nameof(this.Count));
        this.RaisePropertyChanged(Constants.ItemsName);
        this.RaiseCollectionChangedRemove(
            item,
            0);

        return item;
    }

    /// <summary>
    ///     Attempts to de-queue an item and to remove it from queue.
    /// </summary>
    /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
    /// <returns>
    ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
    ///     queue is empty.
    /// </returns>
    public bool TryDequeue(out T item)
    {
        this.RequiresNotDisposed();

        using (ReadWriteSynchronizationLocker locker = this.ReadWriteLock())
        {
            var adapter = (QueueCollectionAdapter<T>)this.InternalContainer;

            if (adapter.Count == 0)
            {
                item = default!;

                return false;
            }

            locker.Upgrade();

            item = adapter.Dequeue();
            this.PushUndoLevel(new DequeueStateChange<T>(item));
        }

        this.RaisePropertyChanged(nameof(this.Count));
        this.RaisePropertyChanged(Constants.ItemsName);
        this.RaiseCollectionChangedRemove(
            item,
            0);

        return true;
    }

    /// <summary>
    ///     Queues an item into the queue.
    /// </summary>
    /// <param name="item">The item to queue.</param>
    public void Enqueue(T item)
    {
        this.RequiresNotDisposed();

        int newIndex;

        using (this.WriteLock())
        {
            var internalContainer = (QueueCollectionAdapter<T>)this.InternalContainer;
            internalContainer.Enqueue(item);
            newIndex = internalContainer.Count - 1;
            this.PushUndoLevel(new EnqueueStateChange<T>(item));
        }

        this.RaisePropertyChanged(nameof(this.Count));
        this.RaisePropertyChanged(Constants.ItemsName);
        this.RaiseCollectionChangedAdd(
            item,
            newIndex);
    }

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to push.</param>
    public void EnqueueRange(T[] items)
    {
        Requires.NotNull(
            items);

        foreach (T item in items)
        {
            this.Enqueue(item);
        }
    }

    /// <summary>
    ///     Queues a range of elements, adding them to the queue.
    /// </summary>
    /// <param name="items">The item range to enqueue.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="count">The number of items to enqueue.</param>
    public void EnqueueRange(
        T[] items,
        int startIndex,
        int count)
    {
        Requires.NotNull(
            items);
        Requires.ValidArrayRange(
            in startIndex,
            in count,
            items);

        var itemsSpan = new ReadOnlySpan<T>(
            items,
            startIndex,
            count);
        foreach (T item in itemsSpan)
        {
            this.Enqueue(item);
        }
    }

    /// <summary>
    ///     Peeks at the topmost item in the queue without de-queuing it.
    /// </summary>
    /// <returns>The topmost item in the queue.</returns>
    public T Peek()
    {
        this.RequiresNotDisposed();

        using (this.ReadLock())
        {
            return ((QueueCollectionAdapter<T>)this.InternalContainer).Peek();
        }
    }

    /// <summary>
    ///     Attempts to peek at the current queue and return the item that is next in line to be dequeued.
    /// </summary>
    /// <param name="item">The item, or default if unsuccessful.</param>
    /// <returns><see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.</returns>
    public bool TryPeek(out T item)
    {
        this.RequiresNotDisposed();

        using (this.ReadLock())
        {
            var ip = (QueueCollectionAdapter<T>)this.InternalContainer;
            if (ip.Count == 0)
            {
                item = default!;

                return false;
            }

            item = ip.Peek();

            return true;
        }
    }

    /// <summary>
    ///     Copies the items of the queue into a new array.
    /// </summary>
    /// <returns>An array of items that are contained in the queue.</returns>
    public T[] ToArray()
    {
        this.RequiresNotDisposed();

        using (this.ReadLock())
        {
            return ((QueueCollectionAdapter<T>)this.InternalContainer).ToArray();
        }
    }

    /// <summary>
    ///     Sets the capacity to the actual number of elements in the <see cref="ObservableQueue{T}" />, if that number is less
    ///     than 90 percent of current capacity.
    /// </summary>
    public void TrimExcess()
    {
        this.RequiresNotDisposed();

        using (this.WriteLock())
        {
            ((QueueCollectionAdapter<T>)this.InternalContainer).TrimExcess();
        }
    }

#endregion

#region Undo/Redo

    /// <summary>
    ///     Has the last operation undone.
    /// </summary>
    /// <param name="undoRedoLevel">A level of undo, with contents.</param>
    /// <param name="toInvokeOutsideLock">An action to invoke outside of the lock.</param>
    /// <param name="state">The state object to pass to the invocation.</param>
    /// <returns><see langword="true" /> if the undo was successful, <see langword="false" /> otherwise.</returns>
    protected override bool UndoInternally(
        StateChangeBase undoRedoLevel,
        out Action<object?>? toInvokeOutsideLock,
        out object? state)
    {
        if (base.UndoInternally(
                undoRedoLevel,
                out toInvokeOutsideLock,
                out state))
        {
            return true;
        }

        switch (undoRedoLevel)
        {
            case AddStateChange<T>:
            {
                var container = (QueueCollectionAdapter<T>)this.InternalContainer;
                var array = new T[container.Count];
                container.CopyTo(
                    array,
                    0);
                container.Clear();

                for (var i = 0; i < array.Length - 1; i++)
                {
                    container.Enqueue(array[i]);
                }

                var index = container.Count;
                T item = array.Last();
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableQueue, T internalItem, var internalIndex) = (Tuple<ObservableQueue<T>, T, int>)innerState;

                    observableQueue.RaisePropertyChanged(nameof(observableQueue.Count));
                    observableQueue.RaisePropertyChanged(Constants.ItemsName);
                    observableQueue.RaiseCollectionChangedRemove(
                        internalItem,
                        internalIndex);
                };

                state = new Tuple<ObservableQueue<T>, T, int>(
                    this,
                    item,
                    index);

                break;
            }

            case EnqueueStateChange<T>:
            {
                var container = (QueueCollectionAdapter<T>)this.InternalContainer;
                var array = new T[container.Count];
                container.CopyTo(
                    array,
                    0);
                container.Clear();

                for (var i = 0; i < array.Length - 1; i++)
                {
                    container.Enqueue(array[i]);
                }

                var index = container.Count;
                T item = array.Last();
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableQueue, T itemInternal, var indexInternal) = (Tuple<ObservableQueue<T>, T, int>)innerState;

                    observableQueue.RaisePropertyChanged(nameof(observableQueue.Count));
                    observableQueue.RaisePropertyChanged(Constants.ItemsName);
                    observableQueue.RaiseCollectionChangedRemove(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableQueue<T>, T, int>(
                    this,
                    item,
                    index);

                break;
            }

            case DequeueStateChange<T>(var dequeuedItem):
            {
                var container = (QueueCollectionAdapter<T>)this.InternalContainer;
                container.Enqueue(dequeuedItem);

                var index = container.Count - 1;
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableQueue, T itemInternal, var indexInternal) = (Tuple<ObservableQueue<T>, T, int>)innerState;

                    observableQueue.RaisePropertyChanged(nameof(observableQueue.Count));
                    observableQueue.RaisePropertyChanged(Constants.ItemsName);
                    observableQueue.RaiseCollectionChangedAdd(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableQueue<T>, T, int>(
                    this,
                    dequeuedItem,
                    index);

                break;
            }

            case RemoveStateChange<T>:
            {
                toInvokeOutsideLock = null;
                state = null;

                break;
            }

            case ClearStateChange<T>(var originalItems):
            {
                var container = (QueueCollectionAdapter<T>)this.InternalContainer;
                for (var i = 0; i < originalItems.Length - 1; i++)
                {
                    container.Enqueue(originalItems[i]);
                }

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    var convertedState = (ObservableQueue<T>)innerState;

                    convertedState.RaisePropertyChanged(nameof(convertedState.Count));
                    convertedState.RaisePropertyChanged(Constants.ItemsName);
                    convertedState.RaiseCollectionReset();
                };

                state = this;

                break;
            }

            default:
            {
                toInvokeOutsideLock = null;
                state = null;

                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Has the last undone operation redone.
    /// </summary>
    /// <param name="undoRedoLevel">A level of undo, with contents.</param>
    /// <param name="toInvokeOutsideLock">An action to invoke outside of the lock.</param>
    /// <param name="state">The state object to pass to the invocation.</param>
    /// <returns><see langword="true" /> if the redo was successful, <see langword="false" /> otherwise.</returns>
    protected override bool RedoInternally(
        StateChangeBase undoRedoLevel,
        out Action<object?>? toInvokeOutsideLock,
        out object? state)
    {
        if (base.RedoInternally(
                undoRedoLevel,
                out toInvokeOutsideLock,
                out state))
        {
            return true;
        }

        switch (undoRedoLevel)
        {
            case AddStateChange<T>(var addedItem, _):
            {
                var container = (QueueCollectionAdapter<T>)this.InternalContainer;

                container.Enqueue(addedItem);

                var index = container.Count - 1;
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableQueue, T itemInternal, var indexInternal) = (Tuple<ObservableQueue<T>, T, int>)innerState;

                    observableQueue.RaisePropertyChanged(nameof(observableQueue.Count));
                    observableQueue.RaisePropertyChanged(Constants.ItemsName);
                    observableQueue.RaiseCollectionChangedAdd(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableQueue<T>, T, int>(
                    this,
                    addedItem,
                    index);

                break;
            }

            case EnqueueStateChange<T>(var enqueuedItem):
            {
                var container = (QueueCollectionAdapter<T>)this.InternalContainer;

                container.Enqueue(enqueuedItem);

                var index = container.Count - 1;
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableQueue, T itemInternal, var indexInternal) = (Tuple<ObservableQueue<T>, T, int>)innerState;

                    observableQueue.RaisePropertyChanged(nameof(observableQueue.Count));
                    observableQueue.RaisePropertyChanged(Constants.ItemsName);
                    observableQueue.RaiseCollectionChangedAdd(
                        itemInternal,
                        indexInternal);
                };

                state = new Tuple<ObservableQueue<T>, T, int>(
                    this,
                    enqueuedItem,
                    index);

                break;
            }

            case DequeueStateChange<T>(var dequeuedItem):
            {
                var container = (QueueCollectionAdapter<T>)this.InternalContainer;

                container.Dequeue();

                var index = 0;
                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    (var observableQueue, T itemInternal, var itemIndex) = (Tuple<ObservableQueue<T>, T, int>)innerState;

                    observableQueue.RaisePropertyChanged(nameof(observableQueue.Count));
                    observableQueue.RaisePropertyChanged(Constants.ItemsName);
                    observableQueue.RaiseCollectionChangedRemove(
                        itemInternal,
                        itemIndex);
                };

                state = new Tuple<ObservableQueue<T>, T, int>(
                    this,
                    dequeuedItem,
                    index);

                break;
            }

            case RemoveStateChange<T>:
            {
                toInvokeOutsideLock = null;
                state = null;

                break;
            }

            case ClearStateChange<T>:
            {
                this.InternalContainer.Clear();

                toInvokeOutsideLock = innerState =>
                {
                    if (innerState == null)
                    {
                        return;
                    }

                    var convertedState = (ObservableQueue<T>)innerState;

                    convertedState.RaisePropertyChanged(nameof(convertedState.Count));
                    convertedState.RaisePropertyChanged(Constants.ItemsName);
                    convertedState.RaiseCollectionReset();
                };

                state = this;

                break;
            }

            default:
            {
                toInvokeOutsideLock = null;
                state = null;

                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Interprets the block state changes outside the write lock.
    /// </summary>
    /// <param name="actions">The actions to employ.</param>
    /// <param name="states">The state objects to send to the corresponding actions.</param>
    protected override void InterpretBlockStateChangesOutsideLock(
        Action<object?>?[] actions,
        object?[] states)
    {
        this.RaisePropertyChanged(nameof(this.Count));
        this.RaisePropertyChanged(Constants.ItemsName);
        this.RaiseCollectionReset();
    }

#endregion
}