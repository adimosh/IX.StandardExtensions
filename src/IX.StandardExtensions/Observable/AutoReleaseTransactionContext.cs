// <copyright file="AutoReleaseTransactionContext.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Guaranteed;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using IX.Undoable;

namespace IX.Observable;

/// <summary>
///     An auto-capture-releasing class that captures in a transaction.
/// </summary>
internal class AutoReleaseTransactionContext : OperationTransaction
{
#region Internal state

    private readonly EventHandler<EditCommittedEventArgs> editableHandler;
    private readonly IUndoableItem? item;
    private readonly IUndoableItem[]? items;
    private readonly IUndoableItem parentContext;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoReleaseTransactionContext" /> class.
    /// </summary>
    public AutoReleaseTransactionContext()
    {
        editableHandler = null!;
        parentContext = null!;

        Success();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoReleaseTransactionContext" /> class.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="parentContext">The parent context.</param>
    /// <param name="editableHandler">The editable handler.</param>
    public AutoReleaseTransactionContext(
        IUndoableItem item,
        IUndoableItem parentContext,
        EventHandler<EditCommittedEventArgs> editableHandler)
    {
        // Contract validation
        Requires.NotNull(
            out this.item,
            item);
        Requires.NotNull(
            out this.parentContext,
            parentContext);
        Requires.NotNull(
            out this.editableHandler,
            editableHandler);

        // Data validation
        if (!item.IsCapturedIntoUndoContext || item.ParentUndoContext != parentContext)
        {
            throw new ItemNotCapturedIntoUndoContextException();
        }

        // State
        items = null;

        item.ReleaseFromUndoContext();

        if (item is IEditCommittableItem tei)
        {
            tei.EditCommitted -= editableHandler;
        }

        AddFailure();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutoReleaseTransactionContext" /> class.
    /// </summary>
    /// <param name="items">The items.</param>
    /// <param name="parentContext">The parent context.</param>
    /// <param name="editableHandler">The editable handler.</param>
    public AutoReleaseTransactionContext(
        IEnumerable<IUndoableItem> items,
        IUndoableItem parentContext,
        EventHandler<EditCommittedEventArgs> editableHandler)
    {
        // Contract validation
        _ = Requires.NotNull(
            items);
        Requires.NotNull(
            out this.parentContext,
            parentContext);
        Requires.NotNull(
            out this.editableHandler,
            editableHandler);

        // Data validation
        // Multiple enumeration warning: this has to be done, as there is no efficient way to do a transactional capturing otherwise
        IUndoableItem[] itemsArray = items.ToArray();
        if (itemsArray.Any(
                (
                    undoableItem,
                    pc) => !undoableItem.IsCapturedIntoUndoContext || undoableItem.ParentUndoContext != pc,
                parentContext))
        {
            throw new ItemNotCapturedIntoUndoContextException();
        }

        // State
        this.items = itemsArray;
        item = null;

        foreach (IUndoableItem undoableItem in itemsArray)
        {
            undoableItem.ReleaseFromUndoContext();

            if (undoableItem is IEditCommittableItem tei)
            {
                tei.EditCommitted -= editableHandler;
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
                var thisL1 = (AutoReleaseTransactionContext)state;

                if (thisL1.item != null)
                {
                    thisL1.item.CaptureIntoUndoContext(thisL1.parentContext);

                    if (thisL1.item is IEditCommittableItem tei)
                    {
                        tei.EditCommitted += thisL1.editableHandler;
                    }
                }

                if (thisL1.items == null)
                {
                    return;
                }

                foreach (IUndoableItem undoableItem in thisL1.items)
                {
                    undoableItem.CaptureIntoUndoContext(thisL1.parentContext);

                    if (thisL1.item is IEditCommittableItem tei)
                    {
                        tei.EditCommitted += thisL1.editableHandler;
                    }
                }
            },
            this);

#endregion
}