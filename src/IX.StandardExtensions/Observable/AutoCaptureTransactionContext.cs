// <copyright file="AutoCaptureTransactionContext.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Guaranteed;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using IX.Undoable;

namespace IX.Observable;

/// <summary>
///     An auto-capturing class that captures in a transaction.
/// </summary>
/// <seealso cref="IX.Guaranteed.OperationTransaction" />
internal class AutoCaptureTransactionContext : OperationTransaction
{
#region Internal state

    private readonly EventHandler<EditCommittedEventArgs>? editableHandler;
    private readonly IUndoableItem? item;
    private readonly IUndoableItem[]? items;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoCaptureTransactionContext" /> class.
    /// </summary>
    public AutoCaptureTransactionContext() => Success();

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoCaptureTransactionContext" /> class.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="parentContext">The parent context.</param>
    /// <param name="editableHandler">The editable handler.</param>
    public AutoCaptureTransactionContext(
        IUndoableItem item,
        IUndoableItem parentContext,
        EventHandler<EditCommittedEventArgs> editableHandler)
    {
        // Contract validation
        Requires.NotNull(
            out this.item,
            item);
        _ = Requires.NotNull(
            parentContext);
        Requires.NotNull(
            out this.editableHandler,
            editableHandler);

        // Data validation
        if (item.IsCapturedIntoUndoContext && item.ParentUndoContext != parentContext)
        {
            throw new ItemAlreadyCapturedIntoUndoContextException();
        }

        // State
        items = null;

        item.CaptureIntoUndoContext(parentContext);

        if (item is IEditCommittableItem tei)
        {
            tei.EditCommitted += editableHandler;
        }

        AddFailure();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoCaptureTransactionContext" /> class.
    /// </summary>
    /// <param name="items">The items.</param>
    /// <param name="parentContext">The parent context.</param>
    /// <param name="editableHandler">The editable handler.</param>
    public AutoCaptureTransactionContext(
        IEnumerable<IUndoableItem> items,
        IUndoableItem parentContext,
        EventHandler<EditCommittedEventArgs> editableHandler)
    {
        // Contract validation
        _ = Requires.NotNull(
            items);
        _ = Requires.NotNull(
            parentContext);
        Requires.NotNull(
            out this.editableHandler,
            editableHandler);

        // Data validation
        // Multiple enumeration warning: this has to be done, as there is no efficient way to do a transactional capturing otherwise
        IUndoableItem[] itemsArray = items.ToArray();
        if (itemsArray.Any(
                (
                    internalItem,
                    pc) => internalItem.IsCapturedIntoUndoContext && internalItem.ParentUndoContext != pc,
                parentContext))
        {
            throw new ItemAlreadyCapturedIntoUndoContextException();
        }

        // State
        this.items = itemsArray;
        item = null;

        foreach (IUndoableItem undoableItem in itemsArray)
        {
            undoableItem.CaptureIntoUndoContext(parentContext);

            if (undoableItem is IEditCommittableItem tei)
            {
                tei.EditCommitted += editableHandler;
            }
        }

        AddFailure();
    }

#endregion

#region Methods

    /// <summary>
    ///     Gets invoked when the transaction commits and is successful.
    /// </summary>
    protected override void WhenSuccessful() { }

    private void AddFailure() =>
        AddRevertStep(
            state =>
            {
                var thisL1 = (AutoCaptureTransactionContext)state;
                if (thisL1.item != null)
                {
                    thisL1.item.ReleaseFromUndoContext();

                    if (thisL1.item is IEditCommittableItem tei)
                    {
                        tei.EditCommitted -= thisL1.editableHandler;
                    }
                }

                if (thisL1.items == null)
                {
                    return;
                }

                foreach (IUndoableItem undoableItem in thisL1.items)
                {
                    undoableItem.ReleaseFromUndoContext();

                    if (thisL1.item is IEditCommittableItem tei)
                    {
                        tei.EditCommitted -= thisL1.editableHandler;
                    }
                }
            },
            this);

#endregion
}