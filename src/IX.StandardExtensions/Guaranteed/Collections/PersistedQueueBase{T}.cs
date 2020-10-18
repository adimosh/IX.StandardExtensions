// <copyright file="PersistedQueueBase{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using IX.System.Collections.Generic;
using IX.System.IO;
using JetBrains.Annotations;

namespace IX.Guaranteed.Collections
{
    /// <summary>
    ///     A base class for persisted queues.
    /// </summary>
    /// <typeparam name="T">The type of object in the queue.</typeparam>
    /// <seealso cref="StandardExtensions.ComponentModel.DisposableBase" />
    /// <seealso cref="System.Collections.Generic.IQueue{T}" />
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "CA1010:Generic interface should also be implemented",
        Justification = "This is not necessary.")]
    public abstract class PersistedQueueBase<T> : ReaderWriterSynchronizedBase, IQueue<T>
    {
        private readonly IDirectory directoryShim;
        private readonly IFile fileShim;
        private readonly IPath pathShim;

        /// <summary>
        ///     The poisoned non-removable files list.
        /// </summary>
        private readonly List<string> poisonedUnremovableFiles;

        private readonly DataContractSerializer serializer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PersistedQueueBase{T}" /> class.
        /// </summary>
        /// <param name="persistenceFolderPath">
        ///     The persistence folder path.
        /// </param>
        /// <param name="fileShim">
        ///     The file shim.
        /// </param>
        /// <param name="directoryShim">
        ///     The directory shim.
        /// </param>
        /// <param name="pathShim">
        ///     The path shim.
        /// </param>
        /// <param name="serializer">
        ///     The serializer.
        /// </param>
        /// <param name="timeout">
        ///     The timeout.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="persistenceFolderPath" />
        ///     or
        ///     <paramref name="fileShim" />
        ///     or
        ///     <paramref name="directoryShim" />
        ///     or
        ///     <paramref name="pathShim" />
        ///     or
        ///     <paramref name="serializer" />
        ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
        /// </exception>
        /// <exception cref="ArgumentInvalidPathException">
        ///     The folder at <paramref name="persistenceFolderPath" /> does not exist, or is not accessible.
        /// </exception>
        protected PersistedQueueBase(
            string persistenceFolderPath,
            IFile fileShim,
            IDirectory directoryShim,
            IPath pathShim,
            DataContractSerializer serializer,
            TimeSpan timeout)
            : base(timeout)
        {
            // Dependency validation
            Requires.NotNull(
                out this.fileShim,
                fileShim,
                nameof(fileShim));
            Requires.NotNull(
                out this.pathShim,
                pathShim,
                nameof(pathShim));
            Requires.NotNull(
                out this.directoryShim,
                directoryShim,
                nameof(directoryShim));
            Requires.NotNull(
                out this.serializer,
                serializer,
                nameof(serializer));

            // Parameter validation
            Requires.NotNullOrWhiteSpace(
                persistenceFolderPath,
                nameof(persistenceFolderPath));

            if (!directoryShim.Exists(persistenceFolderPath))
            {
                throw new ArgumentInvalidPathException(nameof(persistenceFolderPath));
            }

            // Internal state
            this.poisonedUnremovableFiles = new List<string>();

            // Persistence folder paths
            var dataFolderPath = pathShim.Combine(
                persistenceFolderPath,
                "Data");
            this.DataFolderPath = dataFolderPath;
            var poisonFolderPath = pathShim.Combine(
                persistenceFolderPath,
                "Poison");
            this.PoisonFolderPath = poisonFolderPath;

            // Initialize folder paths
            if (!directoryShim.Exists(dataFolderPath))
            {
                directoryShim.CreateDirectory(dataFolderPath);
            }

            if (!directoryShim.Exists(poisonFolderPath))
            {
                directoryShim.CreateDirectory(poisonFolderPath);
            }
        }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="PersistedQueueBase{T}" />.
        /// </summary>
        /// <value>The count.</value>
        public abstract int Count { get; }

        /// <summary>
        /// Gets a value indicating whether this queue is empty.
        /// </summary>
        /// <value>
        /// <c>true</c> if this queue is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => this.Count == 0;

        /// <summary>
        ///     Gets an object that can be used to synchronize access to the <see cref="PersistedQueueBase{T}" />.
        /// </summary>
        /// <value>The synchronize root.</value>
        object ICollection.SyncRoot { get; } = new object();

        /// <summary>
        ///     Gets a value indicating whether access to the <see cref="PersistedQueueBase{T}" /> is synchronized (thread safe).
        /// </summary>
        /// <value>The is synchronized.</value>
        bool ICollection.IsSynchronized => true;

        /// <summary>
        ///     Gets the data folder path.
        /// </summary>
        /// <value>The data folder path.</value>
        protected string DataFolderPath { get; }

        /// <summary>
        ///     Gets the folder shim.
        /// </summary>
        /// <value>The folder shim.</value>
        protected IDirectory DirectoryShim => this.directoryShim;

        /// <summary>
        ///     Gets the file shim.
        /// </summary>
        /// <value>The file shim.</value>
        protected IFile FileShim => this.fileShim;

        /// <summary>
        ///     Gets the path shim.
        /// </summary>
        /// <value>The path shim.</value>
        protected IPath PathShim => this.pathShim;

        /// <summary>
        ///     Gets the poison folder path.
        /// </summary>
        /// <value>The poison folder path.</value>
        protected string PoisonFolderPath { get; }

        /// <summary>
        ///     Gets the serializer.
        /// </summary>
        /// <value>The serializer.</value>
        protected DataContractSerializer Serializer => this.serializer;

        /// <summary>
        ///     Clears the queue of all elements.
        /// </summary>
        public abstract void Clear();

        /// <summary>
        ///     Verifies whether or not an item is contained in the queue.
        /// </summary>
        /// <param name="item">The item to verify.</param>
        /// <returns><see langword="true" /> if the item is queued, <see langword="false" /> otherwise.</returns>
        public abstract bool Contains(T item);

        /// <summary>
        ///     Copies the elements of the <see cref="PersistedQueueBase{T}" /> to an <see cref="Array" />, starting at a
        ///     particular <see cref="Array" /> index.
        /// </summary>
        /// <param name="array">
        ///     The one-dimensional <see cref="Array" /> that is the destination of the elements copied
        ///     from <see cref="PersistedQueueBase{T}" />. The <see cref="Array" /> must have zero-based indexing.
        /// </param>
        /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        public abstract void CopyTo(
            Array array,
            int index);

        /// <summary>
        ///     De-queues an item and removes it from the queue.
        /// </summary>
        /// <returns>The item that has been de-queued.</returns>
        public abstract T Dequeue();

        /// <summary>
        ///     Attempts to de-queue an item and to remove it from queue.
        /// </summary>
        /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
        /// <returns>
        ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
        ///     queue is empty.
        /// </returns>
        public abstract bool TryDequeue(out T item);

        /// <summary>
        ///     Queues an item, adding it to the queue.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        public abstract void Enqueue(T item);

        /// <summary>
        /// Attempts to peek at the current queue and return the item that is next in line to be dequeued.
        /// </summary>
        /// <param name="item">The item, or default if unsuccessful.</param>
        /// <returns>
        ///   <see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.
        /// </returns>
        public abstract bool TryPeek(out T item);

        /// <summary>
        /// Queues a range of elements, adding them to the queue.
        /// </summary>
        /// <param name="items">The item range to push.</param>
        public void EnqueueRange(T[] items)
        {
            Requires.NotNull(items, nameof(items));

            foreach (var item in items)
            {
                this.Enqueue(item);
            }
        }

        /// <summary>
        /// Queues a range of elements, adding them to the queue.
        /// </summary>
        /// <param name="items">The item range to enqueue.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to enqueue.</param>
        public void EnqueueRange(T[] items, int startIndex, int count)
        {
            Requires.NotNull(items, nameof(items));
            Requires.ValidArrayRange(in startIndex, in count, items, nameof(items));

            ReadOnlySpan<T> itemsRange = new ReadOnlySpan<T>(items, startIndex, count);
            foreach (var item in itemsRange)
            {
                this.Enqueue(item);
            }
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the queue.</returns>
        public abstract IEnumerator<T> GetEnumerator();

        /// <summary>
        ///     Peeks at the topmost element in the queue, without removing it.
        /// </summary>
        /// <returns>The item peeked at, if any.</returns>
        public abstract T Peek();

        /// <summary>
        ///     Copies all elements of the queue into a new array.
        /// </summary>
        /// <returns>The created array with all element of the queue.</returns>
        public abstract T[] ToArray();

        /// <summary>
        ///     Trims the excess free space from within the queue, reducing the capacity to the actual number of elements.
        /// </summary>
        public virtual void TrimExcess()
        {
        }
#pragma warning disable HAA0401 // Possible allocation of reference type enumerator - Yeah, we know
        /// <summary>
        ///     Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the queue.</returns>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
#pragma warning restore HAA0401 // Possible allocation of reference type enumerator

        /// <summary>
        ///     Loads the topmost item from the folder, ensuring its deletion afterwards.
        /// </summary>
        /// <returns>An item, if one exists and can be loaded, a default value otherwise.</returns>
        /// <exception cref="InvalidOperationException">There are no more valid items in the folder.</exception>
        protected T LoadTopmostItem()
        {
            this.RequiresNotDisposed();

            using (this.WriteLock())
            {
                string[] files = this.GetPossibleDataFiles();
                var i = 0;
                string possibleFilePath;
                T obj;

                while (true)
                {
                    if (i >= files.Length)
                    {
                        throw new InvalidOperationException();
                    }

                    possibleFilePath = files[i];

                    try
                    {
                        using Stream stream = this.FileShim.OpenRead(possibleFilePath);
                        obj = (T)this.Serializer.ReadObject(stream);

                        break;
                    }
                    catch (IOException)
                    {
                        this.HandleFileLoadProblem(possibleFilePath);
                        i++;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        this.HandleFileLoadProblem(possibleFilePath);
                        i++;
                    }
                    catch (SerializationException)
                    {
                        this.HandleFileLoadProblem(possibleFilePath);
                        i++;
                    }
                }

                try
                {
                    this.FileShim.Delete(possibleFilePath);
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }

                return obj;
            }
        }

        /// <summary>
        ///     Tries the load topmost item and execute an action on it, deleting the topmost object data if the operation is
        ///     successful.
        /// </summary>
        /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
        /// <param name="actionToInvoke">The action to invoke.</param>
        /// <param name="state">The state object to pass to the invoked action.</param>
        /// <returns><see langword="true" /> if de-queuing and executing is successful, <see langword="false" /> otherwise.</returns>
        protected bool TryLoadTopmostItemWithAction<TState>(
            Action<TState, T> actionToInvoke,
            TState state)
        {
            Requires.NotNull(
                actionToInvoke,
                nameof(actionToInvoke));

            this.RequiresNotDisposed();

            using ReadWriteSynchronizationLocker locker = this.ReadWriteLock();

            string[] files = this.GetPossibleDataFiles();
            var i = 0;

            T obj;
            string possibleFilePath;

            while (true)
            {
                if (i >= files.Length)
                {
                    return false;
                }

                possibleFilePath = files[i];

                try
                {
                    using Stream stream = this.FileShim.OpenRead(possibleFilePath);

                    obj = (T)this.Serializer.ReadObject(stream);

                    break;
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
            }

            try
            {
                actionToInvoke(
                    state,
                    obj);
            }
            catch (Exception)
            {
#pragma warning disable ERP022 // Catching everything considered harmful. - We will mitigate shortly
                return false;
#pragma warning restore ERP022 // Catching everything considered harmful.
            }

            locker.Upgrade();

            try
            {
                this.FileShim.Delete(possibleFilePath);
            }
            catch (IOException)
            {
                this.HandleFileLoadProblem(possibleFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                this.HandleFileLoadProblem(possibleFilePath);
            }
            catch (SerializationException)
            {
                this.HandleFileLoadProblem(possibleFilePath);
            }

            return true;
        }

        /// <summary>
        ///     Asynchronously tries the load topmost item and execute an action on it, deleting the topmost object data if the
        ///     operation is successful.
        /// </summary>
        /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
        /// <param name="actionToInvoke">The action to invoke.</param>
        /// <param name="state">The state object to pass to the invoked action.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns><see langword="true" /> if de-queuing and executing is successful, <see langword="false" /> otherwise.</returns>
        protected async Task<bool> TryLoadTopmostItemWithActionAsync<TState>(
            Func<TState, T, Task> actionToInvoke,
            TState state,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                actionToInvoke,
                nameof(actionToInvoke));

            this.RequiresNotDisposed();

            using ReadWriteSynchronizationLocker locker = this.ReadWriteLock();

            string[] files = this.GetPossibleDataFiles();
            var i = 0;

            T obj;
            string possibleFilePath;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (i >= files.Length)
                {
                    return false;
                }

                possibleFilePath = files[i];

                try
                {
                    using Stream stream = this.FileShim.OpenRead(possibleFilePath);

                    obj = (T)this.Serializer.ReadObject(stream);

                    break;
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
            }

            try
            {
                await actionToInvoke(
                    state,
                    obj).ConfigureAwait(false);
            }
            catch (Exception)
            {
#pragma warning disable ERP022 // Catching everything considered harmful. - We will mitigate shortly
                return false;
#pragma warning restore ERP022 // Catching everything considered harmful.
            }

            locker.Upgrade();

            try
            {
                this.FileShim.Delete(possibleFilePath);
            }
            catch (IOException)
            {
                this.HandleFileLoadProblem(possibleFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                this.HandleFileLoadProblem(possibleFilePath);
            }
            catch (SerializationException)
            {
                this.HandleFileLoadProblem(possibleFilePath);
            }

            return true;
        }

        /// <summary>
        ///     Tries to load the topmost item and execute an action on it, deleting the topmost object data if the operation is
        ///     successful.
        /// </summary>
        /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="actionToInvoke">The action to invoke.</param>
        /// <param name="state">The state object to pass to the invoked action.</param>
        /// <returns>The number of items that have been de-queued.</returns>
        /// <remarks>
        ///     <para>
        ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
        ///         <paramref name="predicate" /> method
        ///         filters out items in a way that limits the amount of data passing through.
        ///     </para>
        /// </remarks>
        protected int TryLoadWhilePredicateWithAction<TState>(
            Func<TState, T, bool> predicate,
            Action<TState, IEnumerable<T>> actionToInvoke,
            TState state)
        {
            Requires.NotNull(
                predicate,
                nameof(predicate));
            Requires.NotNull(
                actionToInvoke,
                nameof(actionToInvoke));

            this.RequiresNotDisposed();

            using ReadWriteSynchronizationLocker locker = this.ReadWriteLock();

            string[] files = this.GetPossibleDataFiles();
            var i = 0;

            var accumulatedObjects = new List<T>();
            var accumulatedPaths = new List<string>();

            while (i < files.Length)
            {
                var possibleFilePath = files[i];

                try
                {
                    T obj;

                    using (Stream stream = this.FileShim.OpenRead(possibleFilePath))
                    {
                        obj = (T)this.Serializer.ReadObject(stream);
                    }

                    if (!predicate(
                        state,
                        obj))
                    {
                        break;
                    }

                    accumulatedObjects.Add(obj);
                    accumulatedPaths.Add(possibleFilePath);

                    i++;
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
            }

            if (accumulatedObjects.Count <= 0)
            {
                return accumulatedPaths.Count;
            }

            try
            {
                actionToInvoke(
                    state,
                    accumulatedObjects);
            }
            catch (Exception)
            {
#pragma warning disable ERP022 // Catching everything considered harmful. - We will mitigate shortly
                return 0;
#pragma warning restore ERP022 // Catching everything considered harmful.
            }

            locker.Upgrade();

            foreach (var possibleFilePath in accumulatedPaths)
            {
                try
                {
                    this.FileShim.Delete(possibleFilePath);
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
            }

            return accumulatedPaths.Count;
        }

        /// <summary>
        ///     Asynchronouly tries to load the topmost item and execute an action on it, deleting the topmost object data if the
        ///     operation is successful.
        /// </summary>
        /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="actionToInvoke">The action to invoke.</param>
        /// <param name="state">The state object to pass to the invoked action.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>The number of items that have been de-queued.</returns>
        /// <remarks>
        ///     <para>
        ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
        ///         <paramref name="predicate" /> method
        ///         filters out items in a way that limits the amount of data passing through.
        ///     </para>
        /// </remarks>
        protected async Task<int> TryLoadWhilePredicateWithActionAsync<TState>(
            Func<TState, T, Task<bool>> predicate,
            Action<TState, IEnumerable<T>> actionToInvoke,
            TState state,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                predicate,
                nameof(predicate));
            Requires.NotNull(
                actionToInvoke,
                nameof(actionToInvoke));

            this.RequiresNotDisposed();

            using ReadWriteSynchronizationLocker locker = this.ReadWriteLock();

            string[] files = this.GetPossibleDataFiles();
            var i = 0;

            var accumulatedObjects = new List<T>();
            var accumulatedPaths = new List<string>();

            while (i < files.Length)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                var possibleFilePath = files[i];

                try
                {
                    T obj;

                    using (Stream stream = this.FileShim.OpenRead(possibleFilePath))
                    {
                        obj = (T)this.Serializer.ReadObject(stream);
                    }

                    if (!await predicate(
                        state,
                        obj).ConfigureAwait(false))
                    {
                        break;
                    }

                    accumulatedObjects.Add(obj);
                    accumulatedPaths.Add(possibleFilePath);

                    i++;
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
            }

            if (accumulatedObjects.Count <= 0)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return accumulatedPaths.Count;
            }

            try
            {
                actionToInvoke(
                    state,
                    accumulatedObjects);
            }
            catch (Exception)
            {
                cancellationToken.ThrowIfCancellationRequested();
#pragma warning disable ERP022 // Catching everything considered harmful. - We will mitigate shortly
                return 0;
#pragma warning restore ERP022 // Catching everything considered harmful.
            }

            locker.Upgrade();

            foreach (var possibleFilePath in accumulatedPaths)
            {
                try
                {
                    this.FileShim.Delete(possibleFilePath);
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
            }

            cancellationToken.ThrowIfCancellationRequested();
            return accumulatedPaths.Count;
        }

        /// <summary>
        ///     Asynchronously tries to load the topmost item and execute an action on it, deleting the topmost object data if the
        ///     operation is successful.
        /// </summary>
        /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="actionToInvoke">The action to invoke.</param>
        /// <param name="state">The state object to pass to the invoked action.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>The number of items that have been de-queued.</returns>
        /// <remarks>
        ///     <para>
        ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
        ///         <paramref name="predicate" /> method
        ///         filters out items in a way that limits the amount of data passing through.
        ///     </para>
        /// </remarks>
        protected async Task<int> TryLoadWhilePredicateWithActionAsync<TState>(
            Func<TState, T, bool> predicate,
            Func<TState, IEnumerable<T>, Task> actionToInvoke,
            TState state,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                predicate,
                nameof(predicate));
            Requires.NotNull(
                actionToInvoke,
                nameof(actionToInvoke));

            this.RequiresNotDisposed();

            using ReadWriteSynchronizationLocker locker = this.ReadWriteLock();

            string[] files = this.GetPossibleDataFiles();
            var i = 0;

            var accumulatedObjects = new List<T>();
            var accumulatedPaths = new List<string>();

            while (i < files.Length)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                var possibleFilePath = files[i];

                try
                {
                    T obj;

                    using (Stream stream = this.FileShim.OpenRead(possibleFilePath))
                    {
                        obj = (T)this.Serializer.ReadObject(stream);
                    }

                    if (!predicate(
                        state,
                        obj))
                    {
                        break;
                    }

                    accumulatedObjects.Add(obj);
                    accumulatedPaths.Add(possibleFilePath);

                    i++;
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
            }

            if (accumulatedObjects.Count <= 0)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return accumulatedPaths.Count;
            }

            try
            {
                await actionToInvoke(
                    state,
                    accumulatedObjects).ConfigureAwait(false);
            }
            catch (Exception)
            {
                cancellationToken.ThrowIfCancellationRequested();
#pragma warning disable ERP022 // Catching everything considered harmful. - We will mitigate shortly
                return 0;
#pragma warning restore ERP022 // Catching everything considered harmful.
            }

            locker.Upgrade();

            foreach (var possibleFilePath in accumulatedPaths)
            {
                try
                {
                    this.FileShim.Delete(possibleFilePath);
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
            }

            cancellationToken.ThrowIfCancellationRequested();
            return accumulatedPaths.Count;
        }

        /// <summary>
        ///     Asynchronously tries to load the topmost item and execute an action on it, deleting the topmost object data if the
        ///     operation is successful.
        /// </summary>
        /// <typeparam name="TState">The type of the state object to send to the action.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="actionToInvoke">The action to invoke.</param>
        /// <param name="state">The state object to pass to the invoked action.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>The number of items that have been de-queued.</returns>
        /// <remarks>
        ///     <para>
        ///         Warning! This method has the potential of overrunning its read/write lock timeouts. Please ensure that the
        ///         <paramref name="predicate" /> method
        ///         filters out items in a way that limits the amount of data passing through.
        ///     </para>
        /// </remarks>
        protected async Task<int> TryLoadWhilePredicateWithActionAsync<TState>(
            Func<TState, T, Task<bool>> predicate,
            Func<TState, IEnumerable<T>, Task> actionToInvoke,
            TState state,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                predicate,
                nameof(predicate));
            Requires.NotNull(
                actionToInvoke,
                nameof(actionToInvoke));

            this.RequiresNotDisposed();

            using ReadWriteSynchronizationLocker locker = this.ReadWriteLock();

            string[] files = this.GetPossibleDataFiles();
            var i = 0;

            var accumulatedObjects = new List<T>();
            var accumulatedPaths = new List<string>();

            while (i < files.Length)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                var possibleFilePath = files[i];

                try
                {
                    T obj;

                    using (Stream stream = this.FileShim.OpenRead(possibleFilePath))
                    {
                        obj = (T)this.Serializer.ReadObject(stream);
                    }

                    if (!await predicate(
                        state,
                        obj).ConfigureAwait(false))
                    {
                        break;
                    }

                    accumulatedObjects.Add(obj);
                    accumulatedPaths.Add(possibleFilePath);

                    i++;
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    i++;
                }
            }

            if (accumulatedObjects.Count <= 0)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return accumulatedPaths.Count;
            }

            try
            {
                await actionToInvoke(
                    state,
                    accumulatedObjects).ConfigureAwait(false);
            }
            catch (Exception)
            {
                cancellationToken.ThrowIfCancellationRequested();
#pragma warning disable ERP022 // Catching everything considered harmful. - We will mitigate shortly
                return 0;
#pragma warning restore ERP022 // Catching everything considered harmful.
            }

            locker.Upgrade();

            foreach (var possibleFilePath in accumulatedPaths)
            {
                try
                {
                    this.FileShim.Delete(possibleFilePath);
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                }
            }

            cancellationToken.ThrowIfCancellationRequested();
            return accumulatedPaths.Count;
        }

        /// <summary>
        ///     Peeks at the topmost item in the folder.
        /// </summary>
        /// <returns>An item, if one exists and can be loaded, or an exception otherwise.</returns>
        /// <exception cref="InvalidOperationException">There are no more valid items in the folder.</exception>
        protected T PeekTopmostItem()
        {
            if (!this.TryPeekTopmostItem(out var item))
            {
                throw new InvalidOperationException();
            }

            return item;
        }

        /// <summary>
        /// Peeks at the topmost item in the folder.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <see langword="true" /> if an item is found, <see langword="false" /> otherwise, or if the queue is empty.
        /// </returns>
        protected bool TryPeekTopmostItem(out T item)
        {
            this.RequiresNotDisposed();

            using (this.ReadLock())
            {
                string[] files = this.GetPossibleDataFiles();
                var i = 0;

                while (true)
                {
                    if (i >= files.Length)
                    {
                        item = default!;
                        return false;
                    }

                    var possibleFilePath = files[i];

                    try
                    {
                        using Stream stream = this.FileShim.OpenRead(possibleFilePath);
                        item = (T)this.Serializer.ReadObject(stream);
                        return true;
                    }
                    catch (IOException)
                    {
                        this.HandleFileLoadProblem(possibleFilePath);
                        i++;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        this.HandleFileLoadProblem(possibleFilePath);
                        i++;
                    }
                    catch (SerializationException)
                    {
                        this.HandleFileLoadProblem(possibleFilePath);
                        i++;
                    }
                }
            }
        }

        /// <summary>
        ///     Loads the items from the folder.
        /// </summary>
        /// <returns>An item, if one exists and can be loaded, a default value otherwise.</returns>
        /// <remarks>
        ///     <para>Warning! Not synchronized.</para>
        ///     <para>
        ///         This method is not synchronized between threads. Please ensure that you only use this method in a guaranteed
        ///         one-time-access manner (such as a constructor).
        ///     </para>
        /// </remarks>
        /// <exception cref="InvalidOperationException">There are no more valid items in the folder.</exception>
        [NotNull]
        protected IEnumerable<Tuple<T, string>> LoadValidItemObjectHandles()
        {
            foreach (var possibleFilePath in this.GetPossibleDataFiles())
            {
                T obj;
                try
                {
                    using Stream stream = this.FileShim.OpenRead(possibleFilePath);
                    obj = (T)this.Serializer.ReadObject(stream);
                }
                catch (IOException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    continue;
                }
                catch (UnauthorizedAccessException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    continue;
                }
                catch (SerializationException)
                {
                    this.HandleFileLoadProblem(possibleFilePath);
                    continue;
                }

                yield return new Tuple<T, string>(
                    obj,
                    possibleFilePath);
            }
        }

        /// <summary>
        ///     Saves the new item to the disk.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>The path of the newly-saved file.</returns>
        /// <exception cref="InvalidOperationException">
        ///     We have reached the maximum number of items saved in the same femtosecond.
        ///     This is theoretically not possible.
        /// </exception>
        [NotNull]
        protected string SaveNewItem(T item)
        {
            this.RequiresNotDisposed();

            using (this.WriteLock())
            {
                var i = 1;
                string filePath;

                DateTime now = DateTime.UtcNow;

                do
                {
#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation - This is a false positive
                    filePath = this.PathShim.Combine(
                        this.DataFolderPath,
                        $"{now:yyyy.MM.dd.HH.mm.ss.fffffff}.{i}.dat");
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
                    i++;

                    if (i == int.MaxValue)
                    {
                        throw new InvalidOperationException();
                    }
                }
                while (this.FileShim.Exists(filePath));

                using (Stream stream = this.FileShim.Create(filePath))
                {
#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation - This is unavoidable
                    this.Serializer.WriteObject(
                        stream,
                        item);
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
                }

                return filePath;
            }
        }

        /// <summary>
        ///     Clears the data.
        /// </summary>
        protected void ClearData()
        {
            this.RequiresNotDisposed();

            using (this.WriteLock())
            {
                foreach (var possibleFilePath in this.DirectoryShim.EnumerateFiles(
                    this.DataFolderPath,
                    "*.dat").ToArray())
                {
                    this.HandleImpossibleMoveToPoison(possibleFilePath);
                }
            }

            this.FixUnmovableReferences();
        }

        /// <summary>
        ///     Gets the possible data files.
        /// </summary>
        /// <returns>An array of data file names.</returns>
        [NotNull]
        protected string[] GetPossibleDataFiles() => this.DirectoryShim.EnumerateFiles(
            this.DataFolderPath,
            "*.dat").Except(this.poisonedUnremovableFiles).ToArray();

        /// <summary>
        ///     Handles the file load problem.
        /// </summary>
        /// <param name="possibleFilePath">The possible file path.</param>
        private void HandleFileLoadProblem(string possibleFilePath)
        {
            var newFilePath = this.PathShim.Combine(
                this.PoisonFolderPath,
                this.PathShim.GetFileName(possibleFilePath));

            // Seemingly-redundant catch code below will be replaced at a later time with an opt-in-based logging solution
            // and a more try/finally general approach

            // If an item by the same name exists in the poison queue, delete it
            try
            {
                if (this.FileShim.Exists(newFilePath))
                {
                    this.FileShim.Delete(newFilePath);
                }
            }
            catch (IOException)
            {
                this.HandleImpossibleMoveToPoison(possibleFilePath);
                return;
            }
            catch (UnauthorizedAccessException)
            {
                this.HandleImpossibleMoveToPoison(possibleFilePath);
                return;
            }

            try
            {
                // Move to poison queue
                this.FileShim.Move(
                    possibleFilePath,
                    newFilePath);
            }
            catch (IOException)
            {
                this.HandleImpossibleMoveToPoison(possibleFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                this.HandleImpossibleMoveToPoison(possibleFilePath);
            }
        }

        /// <summary>
        ///     Handles the situation where it is impossible to move a file to poison.
        /// </summary>
        /// <param name="possibleFilePath">The possible file path.</param>
        private void HandleImpossibleMoveToPoison(string possibleFilePath)
        {
            try
            {
                // If deletion was not possible, delete the offending item
                this.FileShim.Delete(possibleFilePath);
            }
            catch (IOException)
            {
                this.poisonedUnremovableFiles.Add(possibleFilePath);
            }
            catch (UnauthorizedAccessException)
            {
                this.poisonedUnremovableFiles.Add(possibleFilePath);
            }
        }

        /// <summary>
        ///     Fixes the unmovable references.
        /// </summary>
        private void FixUnmovableReferences()
        {
            foreach (var file in this.poisonedUnremovableFiles.ToArray())
            {
                try
                {
                    if (!this.FileShim.Exists(file))
                    {
                        this.poisonedUnremovableFiles.Remove(file);
                    }
                }
                catch (IOException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
        }
    }
}