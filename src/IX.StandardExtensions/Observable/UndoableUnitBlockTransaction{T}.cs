// <copyright file="UndoableUnitBlockTransaction{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using IX.Guaranteed;
using IX.StandardExtensions.Contracts;
using IX.Undoable;

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
            Requires.NotNull(
                collectionBase,
                nameof(collectionBase));

            this.collectionBase = collectionBase;

            this.AddRevertStep(
                state => { ((ObservableCollectionBase<T>)state).FailExplicitUndoBlockTransaction(); },
                collectionBase);

            this.StateChanges = new BlockStateChange
            {
                StateChanges = new List<StateChange>()
            };
        }

#endregion

#region Properties and indexers

        internal BlockStateChange StateChanges { get; }

#endregion

#region Methods

        protected override void WhenSuccessful() => this.collectionBase.FinishExplicitUndoBlockTransaction();

#endregion
    }
}