// <copyright file="ObservableList{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Runtime.Serialization;
using IX.Observable.Adapters;
using IX.Observable.DebugAide;
using JetBrains.Annotations;

namespace IX.Observable;

/// <summary>
///     An observable list.
/// </summary>
/// <typeparam name="T">The type of item in the list.</typeparam>
/// <seealso cref="IX.Observable.ObservableListBase{T}" />
[DebuggerDisplay("ObservableList, Count = {" + nameof(Count) + "}")]
[DebuggerTypeProxy(typeof(CollectionDebugView<>))]
[CollectionDataContract(
    Namespace = Constants.DataContractNamespace,
    Name = "Observable{0}List",
    ItemName = "Item")]
[PublicAPI]
public class ObservableList<T> : ObservableListBase<T>
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableList{T}" /> class.
    /// </summary>
    public ObservableList()
        : base(new ListListAdapter<T>()) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableList{T}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    public ObservableList(IEnumerable<T> source)
        : base(new ListListAdapter<T>(source)) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableList{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    public ObservableList(SynchronizationContext context)
        : base(
            new ListListAdapter<T>(),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableList{T}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    public ObservableList(
        IEnumerable<T> source,
        SynchronizationContext context)
        : base(
            new ListListAdapter<T>(source),
            context) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableList{T}" /> class.
    /// </summary>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableList(bool suppressUndoable)
        : base(
            new ListListAdapter<T>(),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableList{T}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableList(
        IEnumerable<T> source,
        bool suppressUndoable)
        : base(
            new ListListAdapter<T>(source),
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableList{T}" /> class.
    /// </summary>
    /// <param name="context">The synchronization context to use, if any.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableList(
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            new ListListAdapter<T>(),
            context,
            suppressUndoable) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ObservableList{T}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <param name="suppressUndoable">If set to <see langword="true" />, suppresses undoable capabilities of this collection.</param>
    public ObservableList(
        IEnumerable<T> source,
        SynchronizationContext context,
        bool suppressUndoable)
        : base(
            new ListListAdapter<T>(source),
            context,
            suppressUndoable) { }

#endregion
}