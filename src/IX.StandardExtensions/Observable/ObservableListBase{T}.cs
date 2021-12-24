// <copyright file="ObservableListBase{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using IX.Guaranteed;
using IX.Observable.Adapters;
using IX.Observable.StateChanges;
using IX.StandardExtensions;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using IX.StandardExtensions.Threading;
using IX.Undoable;
using IX.Undoable.StateChanges;
using JetBrains.Annotations;

namespace IX.Observable
{
    /// <summary>
    ///     A base class for lists that are observable.
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    /// <seealso cref="IX.Observable.ObservableCollectionBase{T}" />
    /// <seealso cref="IList" />
    /// <seealso cref="IList{T}" />
    /// <seealso cref="IReadOnlyList{T}" />
    [PublicAPI]
    public abstract class ObservableListBase<T> : ObservableCollectionBase<T>,
        IList<T>,
        IReadOnlyList<T>,
        IList
    {
#region Constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableListBase{T}" /> class.
        /// </summary>
        /// <param name="internalContainer">The internal container.</param>
        protected ObservableListBase(IListAdapter<T> internalContainer)
            : base(internalContainer) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableListBase{T}" /> class.
        /// </summary>
        /// <param name="internalContainer">The internal container.</param>
        /// <param name="context">The context.</param>
        protected ObservableListBase(
            IListAdapter<T> internalContainer,
            SynchronizationContext context)
            : base(
                internalContainer,
                context) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableListBase{T}" /> class.
        /// </summary>
        /// <param name="internalContainer">The internal container.</param>
        /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
        protected ObservableListBase(
            IListAdapter<T> internalContainer,
            bool suppressUndoable)
            : base(
                internalContainer,
                suppressUndoable) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableListBase{T}" /> class.
        /// </summary>
        /// <param name="internalContainer">The internal container.</param>
        /// <param name="context">The context.</param>
        /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
        protected ObservableListBase(
            IListAdapter<T> internalContainer,
            SynchronizationContext context,
            bool suppressUndoable)
            : base(
                internalContainer,
                context,
                suppressUndoable) { }

#endregion

#region Properties and indexers

        /// <summary>
        ///     Gets a value indicating whether or not this list is of a fixed size.
        /// </summary>
        public virtual bool IsFixedSize =>
            this.InvokeIfNotDisposed(
                thisL1 => thisL1.ReadLock(
                    thisL2 => thisL2.InternalContainer.IsFixedSize,
                    thisL1),
                this);

        /// <summary>
        ///     Gets the count after an add operation. Used internally.
        /// </summary>
        /// <value>
        ///     The count after add.
        /// </value>
        protected virtual int CountAfterAdd => this.Count;

        /// <summary>
        ///     Gets the internal list container.
        /// </summary>
        /// <value>
        ///     The internal list container.
        /// </value>
        protected new ListAdapter<T> InternalContainer => (ListAdapter<T>)base.InternalContainer;

        /// <summary>
        ///     Gets the item at the specified index.
        /// </summary>
        /// <value>
        ///     The item.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The item at the specified index.</returns>
        public virtual T this[int index]
        {
            get
            {
                // PRECONDITIONS

                // Current object not disposed
                this.RequiresNotDisposed();

                // ACTION
                using (this.ReadLock())
                {
                    return this.InternalContainer[index];
                }
            }

            set
            {
                // PRECONDITIONS

                // Current object not disposed
                this.RequiresNotDisposed();

                // ACTION
                T oldValue;

                // Inside a read/write lock
                using (ReadWriteSynchronizationLocker lockContext = this.ReadWriteLock())
                {
                    // Verify if we are within bounds in a read lock
                    if (index >= this.InternalContainer.Count)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    // Upgrade to a write lock
                    lockContext.Upgrade();

                    // Get the old value
                    oldValue = this.InternalContainer[index];

                    // Two undo/redo transactions
                    using (OperationTransaction tc1 = this.CheckItemAutoCapture(value))
                    {
                        using (OperationTransaction tc2 = this.CheckItemAutoRelease(oldValue))
                        {
                            // Replace with new value
                            this.InternalContainer[index] = value;

                            // Push the undo level
                            this.PushUndoLevel(
                                new ChangeAtStateChange<T>(
                                    index,
                                    value,
                                    oldValue));

                            // Mark the second transaction as successful
                            tc2.Success();
                        }

                        // Mark the first transaction as successful
                        tc1.Success();
                    }
                }

                // NOTIFICATION

                // Collection changed
                this.RaiseCollectionChangedChanged(
                    oldValue,
                    value,
                    index);

                // Property changed
                this.RaisePropertyChanged(nameof(this.Count));

                // Contents may have changed
                this.ContentsMayHaveChanged();
            }
        }

        /// <summary>
        ///     Gets the item at the specified index.
        /// </summary>
        /// <value>
        ///     The item.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The item at the specified index.</returns>
        [SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "Unavoidable here.")]
        object? IList.this[int index]
        {
            get => this[index];
            set
            {
                if (value is not T v)
                {
                    throw new ArgumentInvalidTypeException();
                }

                this[index] = v;
            }
        }

#endregion

#region Methods

#region Interface implementations

        /// <summary>
        ///     Determines the index of a specific item, if any.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The index of the item, or <c>-1</c> if not found.</returns>
        public virtual int IndexOf(T item)
        {
            this.RequiresNotDisposed();

            using (this.ReadLock())
            {
                return this.InternalContainer.IndexOf(item);
            }
        }

        /// <summary>
        ///     Inserts an item at the specified index.
        /// </summary>
        /// <param name="index">The index at which to insert.</param>
        /// <param name="item">The item.</param>
        /// <remarks>
        ///     <para>On concurrent collections, this method is write-synchronized.</para>
        /// </remarks>
        public virtual void Insert(
            int index,
            T item)
        {
            // PRECONDITIONS

            // Current object not disposed
            this.RequiresNotDisposed();

            // ACTION

            // Inside a write lock
            using (this.WriteLock())
            {
                // Inside an undo/redo transaction
                using OperationTransaction tc = this.CheckItemAutoCapture(item);

                // Actually insert
                this.InternalContainer.Insert(
                    index,
                    item);

                // Push undo level
                this.PushUndoLevel(
                    new AddStateChange<T>(
                        item,
                        index));

                // Mark transaction as successful
                tc.Success();
            }

            // NOTIFICATION

            // Collection changed
            this.RaiseCollectionChangedAdd(
                item,
                index);

            // Property changed
            this.RaisePropertyChanged(nameof(this.Count));

            // Contents may have changed
            this.ContentsMayHaveChanged();
        }

        /// <summary>
        ///     Removes an item at the specified index.
        /// </summary>
        /// <param name="index">The index at which to remove an item from.</param>
        public virtual void RemoveAt(int index)
        {
            // PRECONDITIONS

            // Current object not disposed
            this.RequiresNotDisposed();

            // ACTION
            T item;

            // Inside a read/write lock
            using (ReadWriteSynchronizationLocker lockContext = this.ReadWriteLock())
            {
                // Check to see if we are in range
                if (index >= this.InternalContainer.Count)
                {
                    return;
                }

                // Upgrade the lock to a write lock
                lockContext.Upgrade();

                item = this.InternalContainer[index];

                // Using an undo/redo transaction
                using OperationTransaction tc = this.CheckItemAutoRelease(item);

                // Actually do the removal
                this.InternalContainer.RemoveAt(index);

                // Push an undo level
                this.PushUndoLevel(
                    new RemoveStateChange<T>(
                        index,
                        item));

                // Mark the transaction as successful
                tc.Success();
            }

            // NOTIFICATION

            // Collection changed
            this.RaiseCollectionChangedRemove(
                item,
                index);

            // Property changed
            this.RaisePropertyChanged(nameof(this.Count));

            // Contents may have changed
            this.ContentsMayHaveChanged();
        }

        /// <summary>
        ///     Adds an item to the <see cref="ObservableListBase{T}" />.
        /// </summary>
        /// <param name="value">The object to add to the <see cref="ObservableListBase{T}" />.</param>
        /// <returns>The index at which the item was added.</returns>
        int IList.Add(object? value)
        {
            T v = Requires.ArgumentOfType<T>(value);

            this.Add(v);

            return this.CountAfterAdd - 1;
        }

        /// <summary>
        ///     Determines whether the <see cref="ObservableListBase{T}" /> contains a specific value.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="ObservableListBase{T}" />.</param>
        /// <returns>
        ///     true if <paramref name="value" /> is found in the <see cref="ObservableListBase{T}" />; otherwise, false.
        /// </returns>
        bool IList.Contains(object? value)
        {
            if (value is T v)
            {
                return this.Contains(v);
            }

            return false;
        }

        /// <summary>
        ///     Determines the index of a specific item, if any.
        /// </summary>
        /// <param name="value">The item value.</param>
        /// <returns>The index of the item, or <c>-1</c> if not found.</returns>
        int IList.IndexOf(object? value)
        {
            if (value is T v)
            {
                return this.IndexOf(v);
            }

            return -1;
        }

        /// <summary>
        ///     Inserts an item at the specified index.
        /// </summary>
        /// <param name="index">The index at which to insert.</param>
        /// <param name="value">The item value.</param>
        void IList.Insert(
            int index,
            object? value)
        {
            T v = Requires.ArgumentOfType<T>(value);

            this.Insert(
                index,
                v);
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the <see cref="ObservableListBase{T}" />.
        /// </summary>
        /// <param name="value">The object value to remove from the <see cref="ObservableListBase{T}" />.</param>
        void IList.Remove(object? value)
        {
            if (value is T v)
            {
                this.Remove(v);
            }
        }

#endregion

        /// <summary>
        ///     Adds a range of items to the <see cref="ObservableCollectionBase{T}" />.
        /// </summary>
        /// <param name="items">The objects to add to the <see cref="ObservableCollectionBase{T}" />.</param>
        /// <remarks>
        ///     <para>On concurrent collections, this method is write-synchronized.</para>
        /// </remarks>
        public virtual void AddRange(IEnumerable<T> items)
        {
            // PRECONDITIONS

            // Current object not disposed
            this.RequiresNotDisposed();

            T[] itemsList = items.ToArray();

            // ACTION
            int newIndex;

            // Inside a write lock
            using (this.WriteLock())
            {
                // Use an undo/redo transaction
                using OperationTransaction tc = this.CheckItemAutoCapture(itemsList);

                // Actually add the items
                newIndex = this.InternalContainer.AddRange(itemsList);

                // Push an undo level
                this.PushUndoLevel(
                    new AddMultipleStateChange<T>(
                        itemsList,
                        newIndex));

                // Mark the transaction as successful
                tc.Success();
            }

            // NOTIFICATION

            // Collection changed
            if (newIndex == -1)
            {
                this.RaiseCollectionReset();
            }
            else
            {
                this.RaiseCollectionChangedAddMultiple(
                    itemsList,
                    newIndex);
            }

            // Property changed
            this.RaisePropertyChanged(nameof(this.Count));

            // Contents may have changed
            this.ContentsMayHaveChanged();
        }

        /// <summary>
        ///     Removes a range of items from the <see cref="ObservableCollectionBase{T}" />.
        /// </summary>
        /// <param name="startIndex">The start index of the range to remove.</param>
        /// <exception cref="ArgumentNotValidIndexException">
        ///     <paramref name="startIndex" />
        ///     must be a non-negative integer, less than the size of the collection.
        /// </exception>
        /// <remarks>
        ///     <para>On concurrent collections, this method is write-synchronized.</para>
        /// </remarks>
        public virtual void RemoveRange(int startIndex)
        {
            // PRECONDITIONS
            Requires.ValidIndex(in startIndex);

            // Current object not disposed
            this.RequiresNotDisposed();

            // ACTION
            T[] itemsList;

            // Inside a write lock
            using (this.WriteLock())
            {
                if (startIndex >= this.InternalContainer.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(startIndex));
                }

                itemsList = this.InternalContainer.Skip(startIndex)
                    .Reverse()
                    .ToArray();
                var indexesList = new int[itemsList.Length];
                for (var i = 0; i < indexesList.Length; i++)
                {
                    indexesList[i] = this.InternalContainer.Count - 1 - i;
                }

                // Use an undo/redo transaction
                using OperationTransaction tc = this.CheckItemAutoRelease(itemsList);

                // Actually remove
                for (var index = this.InternalContainer.Count - 1; index >= startIndex; index--)
                {
                    // Remove item (in reverse order)
                    this.InternalContainer.RemoveAt(index);
                }

                // Push an undo level
                this.PushUndoLevel(
                    new RemoveMultipleStateChange<T>(
                        indexesList,
                        itemsList));

                // Mark the transaction as successful
                tc.Success();
            }

            // NOTIFICATION

            // Collection changed
            this.RaiseCollectionChangedRemoveMultiple(
                itemsList,
                startIndex);

            // Property changed
            this.RaisePropertyChanged(nameof(this.Count));

            // Contents may have changed
            this.ContentsMayHaveChanged();
        }

        /// <summary>
        ///     Removes a range of items from the <see cref="ObservableCollectionBase{T}" />.
        /// </summary>
        /// <param name="startIndex">The start index of the range to remove.</param>
        /// <param name="length">The length to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="startIndex" />
        ///     must be a non-negative integer, less than the size of the collection.
        ///     AND
        ///     <paramref name="length" />
        ///     must be a non-negative integer, and, in combination with the startIndex, must not exceed the length of the
        ///     collection.
        /// </exception>
        /// <remarks>
        ///     <para>On concurrent collections, this method is write-synchronized.</para>
        /// </remarks>
        public virtual void RemoveRange(
            int startIndex,
            int length)
        {
            // PRECONDITIONS
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            // Current object not disposed
            this.RequiresNotDisposed();

            // ACTION
            T[] itemsList;

            // Inside a write lock
            using (this.WriteLock())
            {
                if (startIndex >= this.InternalContainer.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(startIndex));
                }

                if (startIndex + length > this.InternalContainer.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(length));
                }

                itemsList = this.InternalContainer.Skip(startIndex)
                    .Take(length)
                    .Reverse()
                    .ToArray();
                var indexesList = new int[itemsList.Length];
                for (var i = 0; i < indexesList.Length; i++)
                {
                    indexesList[i] = startIndex + length - 1 - i;
                }

                // Use an undo/redo transaction
                using OperationTransaction tc = this.CheckItemAutoRelease(itemsList);

                // Actually remove
                for (var index = startIndex + length - 1; index >= startIndex; index--)
                {
                    // Remove item (in reverse order)
                    this.InternalContainer.RemoveAt(index);
                }

                // Push an undo level
                this.PushUndoLevel(
                    new RemoveMultipleStateChange<T>(
                        indexesList,
                        itemsList));

                // Mark the transaction as successful
                tc.Success();
            }

            // NOTIFICATION

            // Collection changed
            this.RaiseCollectionChangedRemoveMultiple(
                itemsList,
                startIndex);

            // Property changed
            this.RaisePropertyChanged(nameof(this.Count));

            // Contents may have changed
            this.ContentsMayHaveChanged();
        }

        /// <summary>
        ///     Removes a range of items from the <see cref="ObservableCollectionBase{T}" />.
        /// </summary>
        /// <param name="items">The items to remove.</param>
        /// <remarks>
        ///     <para>On concurrent collections, this method is write-synchronized.</para>
        /// </remarks>
        [SuppressMessage(
            "ReSharper",
            "PossibleMultipleEnumeration",
            Justification = "Multiple enumeration, should it happen, is acceptable in this case.")]
        [SuppressMessage(
            "CodeQuality",
            "IDE0079:Remove unnecessary suppression",
            Justification = "Some developers use ReSharper.")]
        public virtual void RemoveRange(IEnumerable<T> items)
        {
            // PRECONDITIONS
            Requires.NotNull(
                items);

            // Current object not disposed
            this.RequiresNotDisposed();

            // ACTION
            // Inside a write lock
            using (this.WriteLock())
            {
                if (items.Any(
                    (
                        p,
                        coll) => !coll.Contains(p),
                    this.InternalContainer))
                {
                    throw new ArgumentException(
                        Resources.TheGivenCollectionToRemoveIsNotContainedInTheInitialCollection,
                        nameof(items));
                }

                var itemsToDelete = this.InternalContainer.Select(
                        (
                            p,
                            index) => new
                        {
                            Index = index,
                            Item = p
                        })
                    .Where(
                        (
                            p,
                            coll) => coll.Contains(p.Item),
                        items)
                    .OrderByDescending(p => p.Index)
                    .ToArray();

                // Use an undo/redo transaction
                using OperationTransaction tc = this.CheckItemAutoRelease(items);

                // Actually remove
                foreach (var item in itemsToDelete)
                {
                    // Remove an item
                    this.InternalContainer.RemoveAt(item.Index);
                }

                // Push undo transaction
                this.PushUndoLevel(
                    new RemoveMultipleStateChange<T>(
                        itemsToDelete.Select(p => p.Index)
                            .ToArray(),
                        itemsToDelete.Select(p => p.Item)
                            .ToArray()));

                // Mark the transaction as successful
                tc.Success();
            }

            // NOTIFICATION

            // Collection changed
            this.RaiseCollectionReset();

            // Property changed
            this.RaisePropertyChanged(nameof(this.Count));

            // Contents may have changed
            this.ContentsMayHaveChanged();
        }

        /// <summary>
        ///     Removes a range of items from the <see cref="ObservableCollectionBase{T}" />.
        /// </summary>
        /// <param name="items">The items to remove.</param>
        /// <remarks>
        ///     <para>On concurrent collections, this method is write-synchronized.</para>
        /// </remarks>
        public virtual void RemoveRange(params T[] items) => this.RemoveRange((IEnumerable<T>)items);

        /// <summary>
        ///     Inserts a range of items to the <see cref="ObservableCollectionBase{T}" /> at a pre-defined position.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="items">The objects to add to the <see cref="ObservableCollectionBase{T}" />.</param>
        /// <remarks>
        ///     <para>On concurrent collections, this method is write-synchronized.</para>
        /// </remarks>
        [SuppressMessage(
            "Performance",
            "HAA0401:Possible allocation of reference type enumerator",
            Justification = "Acceptable here.")]
        public virtual void InsertRange(
            int index,
            IEnumerable<T> items)
        {
            // PRECONDITIONS
            Requires.NonNegative(index);
            Requires.NotNull(items);

            // Current object not disposed
            this.RequiresNotDisposed();

            T[] itemsList = items.ToArray();

            // ACTION
            // Inside a write lock
            using (this.WriteLock())
            {
                if (index > this.InternalContainer.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                // Use an undo/redo transaction
                using OperationTransaction tc = this.CheckItemAutoCapture(itemsList);

                // Actually add the items
                foreach (T item in Enumerable.Reverse(itemsList))
                {
                    this.InternalContainer.Insert(
                        index,
                        item);
                }

                // Push an undo level
                this.PushUndoLevel(
                    new AddMultipleStateChange<T>(
                        itemsList,
                        index));

                // Mark the transaction as successful
                tc.Success();
            }

            // NOTIFICATION

            // Collection changed
            this.RaiseCollectionChangedAddMultiple(
                itemsList,
                index);

            // Property changed
            this.RaisePropertyChanged(nameof(this.Count));

            // Contents may have changed
            this.ContentsMayHaveChanged();
        }

        /// <summary>
        ///     Called when items are added to a collection.
        /// </summary>
        /// <param name="addedItems">The added items.</param>
        /// <param name="index">The index.</param>
        protected virtual void RaiseCollectionChangedAddMultiple(
            IEnumerable<T> addedItems,
            int index) =>
            this.RaiseCollectionAdd(
                index,
                addedItems);

        /// <summary>
        ///     Called when items are added to a collection.
        /// </summary>
        /// <param name="addedItems">The added items.</param>
        /// <param name="indexes">The indexes.</param>
        protected virtual void RaiseCollectionChangedAddMultiple(
            IEnumerable<T> addedItems,
            IEnumerable<int> indexes)
        {
            var ixs = indexes.ToArray();

            if (ixs.Length > 5)
            {
                this.RaiseCollectionReset();
            }
            else
            {
                T[] ims = addedItems.ToArray();
                for (var i = 0; i < ixs.Length; i++)
                {
                    this.RaiseCollectionAdd(
                        ixs[i],
                        ims[i]);
                }
            }
        }

        /// <summary>
        ///     Called when items are removed from a collection.
        /// </summary>
        /// <param name="removedItems">The removed items.</param>
        /// <param name="index">The index.</param>
        protected virtual void RaiseCollectionChangedRemoveMultiple(
            IEnumerable<T> removedItems,
            int index) =>
            this.RaiseCollectionRemove(
                index,
                removedItems);

        /// <summary>
        ///     Called when items are removed from a collection.
        /// </summary>
        /// <param name="removedItems">The removed items.</param>
        /// <param name="indexes">The indexes.</param>
        protected virtual void RaiseCollectionChangedRemoveMultiple(
            IEnumerable<T> removedItems,
            IEnumerable<int> indexes)
        {
            var ixs = indexes.ToArray();

            if (ixs.Length > 5)
            {
                this.RaiseCollectionReset();
            }
            else
            {
                T[] ims = removedItems.ToArray();
                for (var i = 0; i < ixs.Length; i++)
                {
                    this.RaiseCollectionRemove(
                        ixs[i],
                        ims[i]);
                }
            }
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
            this.RaiseCollectionReset();
            this.ContentsMayHaveChanged();
        }

        /// <summary>
        ///     Has the last operation undone.
        /// </summary>
        /// <param name="undoRedoLevel">A level of undo, with contents.</param>
        /// <param name="toInvokeOutsideLock">An action to invoke outside of the lock.</param>
        /// <param name="state">The state object to pass to the invocation.</param>
        /// <returns><see langword="true" /> if the undo was successful, <see langword="false" /> otherwise.</returns>
        [SuppressMessage(
            "Performance",
            "HAA0401:Possible allocation of reference type enumerator",
            Justification = "Acceptable.")]
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
                case AddStateChange<T>(var item, var index):
                {
                    this.InternalContainer.RemoveAt(index);

                    if (this.ItemsAreUndoable &&
                        this.AutomaticallyCaptureSubItems &&
                        item is IUndoableItem { IsCapturedIntoUndoContext: true } ul &&
                        ul.ParentUndoContext == this)
                    {
                        ul.ReleaseFromUndoContext();
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        (var observableListBase, T removedItem, var indexRemoved) =
                            (Tuple<ObservableListBase<T>, T, int>)innerState;

                        observableListBase.RaiseCollectionChangedRemove(
                            removedItem,
                            indexRemoved);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };

                    state = new Tuple<ObservableListBase<T>, T, int>(
                        this,
                        item,
                        index);

                    break;
                }

                case AddMultipleStateChange<T>(var addedItems, var index):
                {
                    for (var i = 0; i < addedItems.Length; i++)
                    {
                        this.InternalContainer.RemoveAt(index);
                    }

                    IEnumerable<T> items = addedItems;

                    if (this.ItemsAreUndoable && this.AutomaticallyCaptureSubItems)
                    {
                        foreach (IUndoableItem ul in items.Cast<IUndoableItem>()
                            .Where(
                                (
                                    p,
                                    thisL1) => p.IsCapturedIntoUndoContext && p.ParentUndoContext == thisL1,
                                this))
                        {
                            ul.ReleaseFromUndoContext();
                        }
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        var (observableListBase, enumerable, addedIndex) =
                            (Tuple<ObservableListBase<T>, IEnumerable<T>, int>)innerState;

                        observableListBase.RaiseCollectionChangedRemoveMultiple(
                            enumerable,
                            addedIndex);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };

                    state = new Tuple<ObservableListBase<T>, IEnumerable<T>, int>(
                        this,
                        items,
                        index);

                    break;
                }

                case RemoveStateChange<T>(var index, var item):
                {
                    this.InternalContainer.Insert(
                        index,
                        item);

                    if (this.ItemsAreUndoable &&
                        this.AutomaticallyCaptureSubItems &&
                        item is IUndoableItem { IsCapturedIntoUndoContext: false } ul)
                    {
                        ul.CaptureIntoUndoContext(this);
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        (var observableListBase, T removedItem, var removedIndex) =
                            (Tuple<ObservableListBase<T>, T, int>)innerState;

                        observableListBase.RaiseCollectionChangedAdd(
                            removedItem,
                            removedIndex);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };

                    state = new Tuple<ObservableListBase<T>, T, int>(
                        this,
                        item,
                        index);

                    break;
                }

                case RemoveMultipleStateChange<T>(var indexes, var items):
                {
                    for (var i = items.Length - 1; i >= 0; i--)
                    {
                        this.InternalContainer.Insert(
                            indexes[i],
                            items[i]);
                    }

                    if (this.ItemsAreUndoable && this.AutomaticallyCaptureSubItems)
                    {
                        foreach (IUndoableItem ul in items.Cast<IUndoableItem>()
                            .Where(p => !p.IsCapturedIntoUndoContext))
                        {
                            ul.CaptureIntoUndoContext(this);
                        }
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        var (observableListBase, enumerable, indexesInternal) =
                            (Tuple<ObservableListBase<T>, IEnumerable<T>, IEnumerable<int>>)innerState;

                        observableListBase.RaiseCollectionChangedAddMultiple(
                            enumerable,
                            indexesInternal);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };

                    state = new Tuple<ObservableListBase<T>, IEnumerable<T>, IEnumerable<int>>(
                        this,
                        items,
                        indexes);

                    break;
                }

                case ClearStateChange<T>(var originalItems):
                {
                    foreach (T t in originalItems)
                    {
                        this.InternalContainer.Add(t);
                    }

                    if (this.ItemsAreUndoable && this.AutomaticallyCaptureSubItems)
                    {
                        foreach (IUndoableItem ul in originalItems.Cast<IUndoableItem>()
                            .Where(p => !p.IsCapturedIntoUndoContext))
                        {
                            ul.CaptureIntoUndoContext(this);
                        }
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        var convertedState = (ObservableListBase<T>)innerState;

                        convertedState.RaiseCollectionReset();
                        convertedState.RaisePropertyChanged(nameof(convertedState.Count));
                        convertedState.ContentsMayHaveChanged();
                    };

                    state = this;

                    break;
                }

                case ChangeAtStateChange<T>(var index, var oldItem, var newItem):
                {
                    this.InternalContainer[index] = newItem;

                    if (this.ItemsAreUndoable && this.AutomaticallyCaptureSubItems)
                    {
                        if (newItem is IUndoableItem { IsCapturedIntoUndoContext: false } ul)
                        {
                            ul.CaptureIntoUndoContext(this);
                        }

                        if (oldItem is IUndoableItem { IsCapturedIntoUndoContext: true } ol &&
                            ol.ParentUndoContext == this)
                        {
                            ol.ReleaseFromUndoContext();
                        }
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        (var observableListBase, T oldItemInternal, T newItemInternal, var indexInternal) =
                            (Tuple<ObservableListBase<T>, T, T, int>)innerState;

                        observableListBase.RaiseCollectionChangedChanged(
                            oldItemInternal,
                            newItemInternal,
                            indexInternal);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };

                    state = new Tuple<ObservableListBase<T>, T, T, int>(
                        this,
                        oldItem,
                        newItem,
                        index);

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
        [SuppressMessage(
            "Performance",
            "HAA0401:Possible allocation of reference type enumerator",
            Justification = "Acceptable.")]
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
                case AddStateChange<T>(var addedItem, var index):
                {
                    this.InternalContainer.Insert(
                        index,
                        addedItem);

                    if (this.ItemsAreUndoable &&
                        this.AutomaticallyCaptureSubItems &&
                        addedItem is IUndoableItem { IsCapturedIntoUndoContext: false } ul)
                    {
                        ul.CaptureIntoUndoContext(this);
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        (var observableListBase, T itemInternal, var indexInternal) =
                            (Tuple<ObservableListBase<T>, T, int>)innerState;

                        observableListBase.RaiseCollectionChangedAdd(
                            itemInternal,
                            indexInternal);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };

                    state = new Tuple<ObservableListBase<T>, T, int>(
                        this,
                        addedItem,
                        index);

                    break;
                }

                case AddMultipleStateChange<T>(var addedItems, var index):
                {
                    IEnumerable<T> items = addedItems;

                    items.Reverse()
                        .ForEach(
                            (
                                p,
                                thisL1,
                                indexL1) => thisL1.InternalContainer.Insert(
                                indexL1,
                                p),
                            this,
                            index);

                    if (this.ItemsAreUndoable && this.AutomaticallyCaptureSubItems)
                    {
                        foreach (IUndoableItem ul in addedItems.Cast<IUndoableItem>()
                            .Where(p => !p.IsCapturedIntoUndoContext))
                        {
                            ul.CaptureIntoUndoContext(this);
                        }
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        var (observableListBase, enumerable, indexInternal) =
                            (Tuple<ObservableListBase<T>, IEnumerable<T>, int>)innerState;

                        observableListBase.RaiseCollectionChangedAddMultiple(
                            enumerable,
                            indexInternal);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };

                    state = new Tuple<ObservableListBase<T>, IEnumerable<T>, int>(
                        this,
                        items,
                        index);

                    break;
                }

                case RemoveStateChange<T>(var index, var removedItem):
                {
                    this.InternalContainer.RemoveAt(index);

                    if (this.ItemsAreUndoable &&
                        this.AutomaticallyCaptureSubItems &&
                        removedItem is IUndoableItem { IsCapturedIntoUndoContext: true } ul &&
                        ul.ParentUndoContext == this)
                    {
                        ul.ReleaseFromUndoContext();
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        (var observableListBase, T itemInternal, var indexInternal) =
                            (Tuple<ObservableListBase<T>, T, int>)innerState;

                        observableListBase.RaiseCollectionChangedRemove(
                            itemInternal,
                            indexInternal);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };

                    state = new Tuple<ObservableListBase<T>, T, int>(
                        this,
                        removedItem,
                        index);

                    break;
                }

                case RemoveMultipleStateChange<T>(var indexes, var removedItems):
                {
                    foreach (var t in indexes)
                    {
                        this.InternalContainer.RemoveAt(t);
                    }

                    if (this.ItemsAreUndoable && this.AutomaticallyCaptureSubItems)
                    {
                        foreach (IUndoableItem ul in removedItems.Cast<IUndoableItem>()
                            .Where(
                                (
                                    p,
                                    thisL1) => p.IsCapturedIntoUndoContext && p.ParentUndoContext == thisL1,
                                this))
                        {
                            ul.ReleaseFromUndoContext();
                        }
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        var (observableListBase, enumerable, indexesInternal) =
                            (Tuple<ObservableListBase<T>, IEnumerable<T>, IEnumerable<int>>)innerState;

                        observableListBase.RaiseCollectionChangedRemoveMultiple(
                            enumerable,
                            indexesInternal);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };

                    state = new Tuple<ObservableListBase<T>, IEnumerable<T>, IEnumerable<int>>(
                        this,
                        removedItems,
                        indexes);

                    break;
                }

                case ClearStateChange<T>(var originalItems):
                {
                    this.InternalContainer.Clear();

                    if (this.ItemsAreUndoable && this.AutomaticallyCaptureSubItems)
                    {
                        foreach (IUndoableItem ul in originalItems.Cast<IUndoableItem>()
                            .Where(
                                (
                                    p,
                                    thisL1) => p.IsCapturedIntoUndoContext && p.ParentUndoContext == thisL1,
                                this))
                        {
                            ul.ReleaseFromUndoContext();
                        }
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        var convertedState = (ObservableListBase<T>)innerState;

                        convertedState.RaiseCollectionReset();
                        convertedState.RaisePropertyChanged(nameof(convertedState.Count));
                        convertedState.ContentsMayHaveChanged();
                    };

                    state = this;

                    break;
                }

                case ChangeAtStateChange<T>(var index, var newItem, var oldItem):
                {
                    this.InternalContainer[index] = newItem;

                    if (this.ItemsAreUndoable && this.AutomaticallyCaptureSubItems)
                    {
                        if (newItem is IUndoableItem { IsCapturedIntoUndoContext: false } ul)
                        {
                            ul.CaptureIntoUndoContext(this);
                        }

                        if (oldItem is IUndoableItem { IsCapturedIntoUndoContext: true } ol &&
                            ol.ParentUndoContext == this)
                        {
                            ol.ReleaseFromUndoContext();
                        }
                    }

                    toInvokeOutsideLock = innerState =>
                    {
                        if (innerState == null)
                        {
                            return;
                        }

                        (var observableListBase, T oldItemInternal, T newItemInternal, var indexInternal) =
                            (Tuple<ObservableListBase<T>, T, T, int>)innerState;

                        observableListBase.RaiseCollectionChangedChanged(
                            oldItemInternal,
                            newItemInternal,
                            indexInternal);
                        observableListBase.RaisePropertyChanged(nameof(observableListBase.Count));
                        observableListBase.ContentsMayHaveChanged();
                    };
                    state = new Tuple<ObservableListBase<T>, T, T, int>(
                        this,
                        oldItem,
                        newItem,
                        index);

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

#endregion
    }
}