// <copyright file="UndoableUnitBlockTransaction{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using IX.Guaranteed;
using IX.StandardExtensions.Contracts;
using IX.Undoable.StateChanges;

namespace IX.Observable
{
    internal class UndoableUnitBlockTransaction<T> : OperationTransaction
    {
#region Internal state

        private readonly ObservableCollectionBase<T> collectionBase;

#endregion

#region Constructors and destructors

        internal UndoableUnitBlockTransaction(ObservableCollectionBase<T> collectionBase)
        {
            Requires.NotNull(collectionBase);

            this.collectionBase = collectionBase;

            this.AddRevertStep(
                state => { ((ObservableCollectionBase<T>)state).FailExplicitUndoBlockTransaction(); },
                collectionBase);

            this.StateChanges = new CompositeStateChange(new List<StateChangeBase>());
        }

#endregion

#region Properties and indexers

        internal CompositeStateChange StateChanges { get; }

#endregion

#region Methods

        protected override void WhenSuccessful() => this.collectionBase.FinishExplicitUndoBlockTransaction();

#endregion
    }
}