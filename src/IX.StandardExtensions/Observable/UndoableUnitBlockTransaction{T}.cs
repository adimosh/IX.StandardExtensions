// <copyright file="UndoableUnitBlockTransaction{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Guaranteed;
using IX.StandardExtensions.Contracts;
using IX.Undoable.StateChanges;

namespace IX.Observable;

internal class UndoableUnitBlockTransaction<T> : OperationTransaction
{
#region Internal state

    private readonly ObservableCollectionBase<T> collectionBase;

#endregion

#region Constructors and destructors

    internal UndoableUnitBlockTransaction(ObservableCollectionBase<T> collectionBase)
    {
        _ = Requires.NotNull(collectionBase);

        this.collectionBase = collectionBase;

        AddRevertStep(
            state => { ((ObservableCollectionBase<T>)state).FailExplicitUndoBlockTransaction(); },
            collectionBase);

        StateChanges = new CompositeStateChange(new List<StateChangeBase>());
    }

#endregion

#region Properties and indexers

    internal CompositeStateChange StateChanges { get; }

#endregion

#region Methods

    protected override void WhenSuccessful() => collectionBase.FinishExplicitUndoBlockTransaction();

#endregion
}