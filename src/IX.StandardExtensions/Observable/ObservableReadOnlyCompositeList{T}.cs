// <copyright file="ObservableReadOnlyCompositeList{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Specialized;
using IX.Observable.Adapters;
using JetBrains.Annotations;
using ReaderWriterLockSlim = IX.System.Threading.ReaderWriterLockSlim;

namespace IX.Observable;

/// <summary>
///     An observable, composite, thread-safe and read-only list made of multiple lists of the same rank.
/// </summary>
/// <typeparam name="T">The type of the list item.</typeparam>
/// <seealso cref="IDisposable" />
/// <seealso cref="Observable.ObservableReadOnlyCollectionBase{T}" />
[PublicAPI]
public class ObservableReadOnlyCompositeList<T> : ObservableReadOnlyCollectionBase<T>
{
#region Internal state

    private readonly Lazy<ReaderWriterLockSlim> locker;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableReadOnlyCompositeList{T}" /> class.
    /// </summary>
    public ObservableReadOnlyCompositeList()
        : base(new MultiListListAdapter<T>()) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableReadOnlyCompositeList{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    public ObservableReadOnlyCompositeList(SynchronizationContext context)
        : base(
            new MultiListListAdapter<T>(),
            context) =>
        locker = EnvironmentSettings.GenerateDefaultLocker();

#endregion

#region Methods

    /// <summary>
    ///     Sets a list.
    /// </summary>
    /// <typeparam name="TList">The type of the list.</typeparam>
    /// <param name="list">The list.</param>
    public void SetList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        using (AcquireWriteLock())
        {
            ((MultiListListAdapter<T>)InternalContainer).SetList(list);
        }

        RaiseCollectionReset();
        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
    }

    /// <summary>
    ///     Removes a list.
    /// </summary>
    /// <typeparam name="TList">The type of the list.</typeparam>
    /// <param name="list">The list.</param>
    public void RemoveList<TList>(TList list)
        where TList : class, IEnumerable<T>, INotifyCollectionChanged
    {
        using (AcquireWriteLock())
        {
            ((MultiListListAdapter<T>)InternalContainer).RemoveList(list);
        }

        RaiseCollectionReset();
        RaisePropertyChanged(nameof(Count));
        RaisePropertyChanged(Constants.ItemsName);
    }

#region Disposable

    /// <summary>
    ///     Disposes the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        if (locker.IsValueCreated)
        {
            locker.Value.Dispose();
        }

        base.DisposeManagedContext();
    }

#endregion

#endregion
}