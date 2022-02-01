// <copyright file="ConcurrentObservableDictionary{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Runtime.Serialization;
using IX.Observable.DebugAide;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using IX.System.Threading;
using JetBrains.Annotations;

namespace IX.Observable;

/// <summary>
///     A dictionary that broadcasts its changes.
/// </summary>
/// <typeparam name="TKey">The data key type.</typeparam>
/// <typeparam name="TValue">The data value type.</typeparam>
[DebuggerDisplay("ConcurrentObservableDictionary, Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(DictionaryDebugView<,>))]
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "ConcurrentObservable{1}DictionaryBy{0}",
    ItemName = "Entry",
    KeyName = "Key",
    ValueName = "Value")]
[PublicAPI]
public partial class ConcurrentObservableDictionary<TKey, TValue> : ObservableDictionary<TKey, TValue>
    where TKey : notnull
{
#region Internal state

    private Lazy<System.Threading.ReaderWriterLockSlim> locker;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    public ConcurrentObservableDictionary()
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    public ConcurrentObservableDictionary(int capacity)
        : base(capacity)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    public ConcurrentObservableDictionary(IEqualityComparer<TKey> equalityComparer)
        : base(equalityComparer)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    public ConcurrentObservableDictionary(
        int capacity,
        IEqualityComparer<TKey> equalityComparer)
        : base(
            capacity,
            equalityComparer)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    public ConcurrentObservableDictionary(IDictionary<TKey, TValue> dictionary)
        : base(dictionary)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="comparer">A comparer object to use for equality comparison.</param>
    public ConcurrentObservableDictionary(
        IDictionary<TKey, TValue> dictionary,
        IEqualityComparer<TKey> comparer)
        : base(
            dictionary,
            comparer)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    public ConcurrentObservableDictionary(SynchronizationContext context)
        : base(context)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        int capacity)
        : base(
            context,
            capacity)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        IEqualityComparer<TKey> equalityComparer)
        : base(
            context,
            equalityComparer)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        int capacity,
        IEqualityComparer<TKey> equalityComparer)
        : base(
            context,
            capacity,
            equalityComparer)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        IDictionary<TKey, TValue> dictionary)
        : base(
            context,
            dictionary)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="comparer">A comparer object to use for equality comparison.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        IDictionary<TKey, TValue> dictionary,
        IEqualityComparer<TKey> comparer)
        : base(
            context,
            dictionary,
            comparer)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(bool suppressUndoable)
        : base(suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        int capacity,
        bool suppressUndoable)
        : base(
            capacity,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        IEqualityComparer<TKey> equalityComparer,
        bool suppressUndoable)
        : base(
            equalityComparer,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        int capacity,
        IEqualityComparer<TKey> equalityComparer,
        bool suppressUndoable)
        : base(
            capacity,
            equalityComparer,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        IDictionary<TKey, TValue> dictionary,
        bool suppressUndoable)
        : base(
            dictionary,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="comparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        IDictionary<TKey, TValue> dictionary,
        IEqualityComparer<TKey> comparer,
        bool suppressUndoable)
        : base(
            dictionary,
            comparer,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            context,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        int capacity,
        bool suppressUndoable)
        : base(
            context,
            capacity,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        IEqualityComparer<TKey> equalityComparer,
        bool suppressUndoable)
        : base(
            context,
            equalityComparer,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="capacity">The initial capacity of the dictionary.</param>
    /// <param name="equalityComparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        int capacity,
        IEqualityComparer<TKey> equalityComparer,
        bool suppressUndoable)
        : base(
            context,
            capacity,
            equalityComparer,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        IDictionary<TKey, TValue> dictionary,
        bool suppressUndoable)
        : base(
            context,
            dictionary,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ConcurrentObservableDictionary{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context top use when posting observable messages.</param>
    /// <param name="dictionary">A dictionary of items to copy from.</param>
    /// <param name="comparer">A comparer object to use for equality comparison.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ConcurrentObservableDictionary(
        SynchronizationContext context,
        IDictionary<TKey, TValue> dictionary,
        IEqualityComparer<TKey> comparer,
        bool suppressUndoable)
        : base(
            context,
            dictionary,
            comparer,
            suppressUndoable)
    {
        this.locker = EnvironmentSettings.GenerateDefaultLocker();
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets a synchronization lock item to be used when trying to synchronize read/write operations between threads.
    /// </summary>
    protected override IReaderWriterLock SynchronizationLock => this.locker.Value;

#endregion

#region Methods

    /// <summary>
    ///     Gets a value from the dictionary, optionally generating one if the key is not found.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="valueGenerator">The value generator.</param>
    /// <returns>The value corresponding to the key, that is guaranteed to exist in the dictionary after this method.</returns>
    /// <remarks>
    ///     <para>The <paramref name="valueGenerator" /> method is guaranteed to not be invoked if the key exists.</para>
    ///     <para>
    ///         When the <paramref name="valueGenerator" /> method is invoked, it will be invoked within the write lock.
    ///         Please ensure that no member of the dictionary is called within it.
    ///     </para>
    /// </remarks>
    public TValue GetOrAdd(
        TKey key,
        Func<TValue> valueGenerator)
    {
        // PRECONDITIONS

        // Current object not disposed
        this.RequiresNotDisposed();

        // ACTION
        int newIndex;
        TValue? value;

        // Under read/write lock
        using (ReadWriteSynchronizationLocker rwl = this.ReadWriteLock())
        {
            if (this.InternalContainer.TryGetValue(
                    key,
                    out value))
            {
                // Within read lock, if the key is found, return the value.
                return value;
            }

            rwl.Upgrade();

            if (this.InternalContainer.TryGetValue(
                    key,
                    out value))
            {
                // Re-check within a write lock, to ensure that something else hasn't already added it.
                return value;
            }

            // Generate the value
            value = valueGenerator();

            // Add the item
            newIndex = this.InternalContainer.Add(
                key,
                value);
        }

        // NOTIFICATIONS

        // Collection changed
        if (newIndex == -1)
        {
            // If no index could be found for an item (Dictionary add)
            this.RaiseCollectionReset();
        }
        else
        {
            // If index was added at a specific index
            this.RaiseCollectionChangedAdd(
                new KeyValuePair<TKey, TValue>(
                    key,
                    value),
                newIndex);
        }

        // Property changed
        this.RaisePropertyChanged(nameof(this.Count));

        // Contents may have changed
        this.ContentsMayHaveChanged();

        return value;
    }

    /// <summary>
    ///     Creates an item or changes its state, if one exists.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="valueGenerator">The value generator.</param>
    /// <param name="valueAction">The value action.</param>
    /// <returns>The created or state-changed item.</returns>
    public TValue CreateOrChangeState(
        TKey key,
        Func<TValue> valueGenerator,
        Action<TValue> valueAction)
    {
        // PRECONDITIONS

        // Current object not disposed
        this.RequiresNotDisposed();

        // ACTION
        int newIndex;
        TValue? value;

        // Under read/write lock
        using (ReadWriteSynchronizationLocker rwl = this.ReadWriteLock())
        {
            if (this.InternalContainer.TryGetValue(
                    key,
                    out value))
            {
                // Within read lock, if the key is found, return the value.
                valueAction(value);

                return value;
            }

            rwl.Upgrade();

            if (this.InternalContainer.TryGetValue(
                    key,
                    out value))
            {
                // Re-check within a write lock, to ensure that something else hasn't already added it.
                valueAction(value);

                return value;
            }

            // Generate the value
            value = valueGenerator();

            // Add the item
            newIndex = this.InternalContainer.Add(
                key,
                value);
        }

        // NOTIFICATIONS

        // Collection changed
        if (newIndex == -1)
        {
            // If no index could be found for an item (Dictionary add)
            this.RaiseCollectionReset();
        }
        else
        {
            // If index was added at a specific index
            this.RaiseCollectionChangedAdd(
                new KeyValuePair<TKey, TValue>(
                    key,
                    value),
                newIndex);
        }

        // Property changed
        this.RaisePropertyChanged(nameof(this.Count));

        // Contents may have changed
        this.ContentsMayHaveChanged();

        return value;
    }

    /// <summary>
    ///     Removes a key from the dictionary, then acts on its resulting value.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="action">The action.</param>
    /// <returns><see langword="true" /> if the variable was successfully removed, <see langword="false" /> otherwise.</returns>
    public bool RemoveThenAct(
        TKey key,
        Action<TValue> action)
    {
        // PRECONDITIONS

        // Current object not disposed
        this.RequiresNotDisposed();

        // ACTION
        int oldIndex;
        TValue? value;

        // Under read/write lock
        using (ReadWriteSynchronizationLocker rwl = this.ReadWriteLock())
        {
            if (this.InternalContainer.TryGetValue(
                    key,
                    out value))
            {
                rwl.Upgrade();

                if (this.InternalContainer.TryGetValue(
                        key,
                        out value))
                {
                    // Re-check within a write lock, to ensure that something else hasn't already removed it.
                    oldIndex = this.InternalContainer.Remove(
                        new KeyValuePair<TKey, TValue>(
                            key,
                            value));

                    action(value);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // NOTIFICATIONS

        // Collection changed
        if (oldIndex == -1)
        {
            // If no index could be found for an item (Dictionary remove)
            this.RaiseCollectionReset();
        }
        else
        {
            // If index was added at a specific index
            this.RaiseCollectionChangedRemove(
                new KeyValuePair<TKey, TValue>(
                    key,
                    value),
                oldIndex);
        }

        // Property changed
        this.RaisePropertyChanged(nameof(this.Count));

        // Contents may have changed
        this.ContentsMayHaveChanged();

        return true;
    }

    /// <summary>
    ///     Called when the object is being deserialized, in order to set the locker to a new value.
    /// </summary>
    /// <param name="context">The streaming context.</param>
    [OnDeserializing]
    internal void OnDeserializingMethod(StreamingContext context) =>
        Interlocked.Exchange(
            ref this.locker,
            EnvironmentSettings.GenerateDefaultLocker());

#region Disposable

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        Lazy<System.Threading.ReaderWriterLockSlim>? l = Interlocked.Exchange(
            ref this.locker!,
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
        Interlocked.Exchange(
            ref this.locker!,
            null!);

        base.DisposeGeneralContext();
    }

#endregion

#endregion
}