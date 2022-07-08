// <copyright file="UndoableInnerContext.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.StandardExtensions.ComponentModel;
using IX.System.Collections.Generic;
using IX.Undoable.StateChanges;
using JetBrains.Annotations;

namespace IX.Undoable;

/// <summary>
///     The inner context of an undoable object. This class should not normally be used, instead, use
///     <see cref="EditableItemBase" />.
/// </summary>
[PublicAPI]
public class UndoableInnerContext : NotifyPropertyChangedBase
{
#region Internal state

    private int historyLevels;
    private Lazy<PushDownStack<StateChangeBase>>? redoStack;
    private Lazy<PushDownStack<StateChangeBase>>? undoStack;

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets a value indicating whether or not the redo stack has data.
    /// </summary>
    public bool RedoStackHasData => (redoStack?.IsValueCreated ?? false) && redoStack.Value.Count > 0;

    /// <summary>
    ///     Gets a value indicating whether or not the undo stack has data.
    /// </summary>
    public bool UndoStackHasData => (undoStack?.IsValueCreated ?? false) && undoStack.Value.Count > 0;

    /// <summary>
    ///     Gets or sets the number of levels to keep undo or redo information.
    /// </summary>
    /// <value>The history levels.</value>
    /// <remarks>
    ///     <para>
    ///         If this value is set, for example, to 7, then the implementing object should allow undo methods
    ///         to be called 7 times to change the state of the object. Upon calling it an 8th time, there should be no change
    ///         in the
    ///         state of the object.
    ///     </para>
    ///     <para>
    ///         Any call beyond the limit imposed here should not fail, but it should also not change the state of the
    ///         object.
    ///     </para>
    /// </remarks>
    public int HistoryLevels
    {
        get => historyLevels;
        set
        {
            if (value < 0)
            {
                value = 0;
            }

            lock (this)
            {
                // This lock is here to ensure that no multiple threads can set different history levels, no mater what.
                // It is a write-only lock, so no need for expensive lockers
                if (historyLevels == value)
                {
                    return;
                }

                historyLevels = value;

                ProcessHistoryLevelsChange();
            }

            RaisePropertyChanged(nameof(HistoryLevels));
        }
    }

#endregion

#region Methods

    /// <summary>
    ///     Clears the redo stack.
    /// </summary>
    public void ClearRedoStack()
    {
        if (redoStack?.IsValueCreated ?? false)
        {
            redoStack.Value.Clear();
        }
    }

    /// <summary>
    ///     Clears the undo stack.
    /// </summary>
    public void ClearUndoStack()
    {
        if (undoStack?.IsValueCreated ?? false)
        {
            undoStack.Value.Clear();
        }
    }

    /// <summary>
    ///     Pushes one state change on the redo stack.
    /// </summary>
    /// <returns>A state change.</returns>
    public StateChangeBase PopRedo() =>
        (redoStack?.Value ?? throw new InvalidOperationException(Resources.NoHistoryLevelsException)).Pop();

    /// <summary>
    ///     Pushes one state change on the undo stack.
    /// </summary>
    /// <returns>A state change.</returns>
    public StateChangeBase PopUndo() =>
        (undoStack?.Value ?? throw new InvalidOperationException(Resources.NoHistoryLevelsException)).Pop();

    /// <summary>
    ///     Pushes one state change on the redo stack.
    /// </summary>
    /// <param name="stateChange">A state change to push.</param>
    public void PushRedo(StateChangeBase stateChange) =>
        (redoStack?.Value ?? throw new InvalidOperationException(Resources.NoHistoryLevelsException)).Push(
            stateChange);

    /// <summary>
    ///     Pushes one state change on the undo stack.
    /// </summary>
    /// <param name="stateChange">A state change to push.</param>
    public void PushUndo(StateChangeBase stateChange) =>
        (undoStack?.Value ?? throw new InvalidOperationException(Resources.NoHistoryLevelsException)).Push(
            stateChange);

#region Disposable

    /// <summary>Disposes in the managed context.</summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        // Setting history levels to 0 will automatically dispose the undo/redo stacks
        HistoryLevels = 0;
    }

#endregion

    private void ProcessHistoryLevelsChange()
    {
        // WARNING !!! Always execute this method within a lock
        if (historyLevels == 0)
        {
            // Undo stack
            Lazy<PushDownStack<StateChangeBase>>? stack = undoStack;

            if (stack != null)
            {
                undoStack = null;

                if (stack.IsValueCreated)
                {
                    stack.Value.Clear();
                    stack.Value.Dispose();
                }
            }

            // Redo stack
            stack = redoStack;
            if (stack != null)
            {
                redoStack = null;

                if (stack.IsValueCreated)
                {
                    stack.Value.Clear();
                    stack.Value.Dispose();
                }
            }
        }
        else
        {
            if (undoStack != null && redoStack != null)
            {
                // Both stacks are not null at this point
                // If any of them is initialized, we should change its size limit
                if (undoStack.IsValueCreated)
                {
                    undoStack.Value.Limit = historyLevels;
                }

                if (redoStack.IsValueCreated)
                {
                    redoStack.Value.Limit = historyLevels;
                }
            }
            else
            {
                // Both stacks are null at this point, or need to be otherwise reinitialized

                // Let's check for whether or not stacks need to be disposed
                if (undoStack?.IsValueCreated ?? false)
                {
                    undoStack.Value.Dispose();
                }

                if (redoStack?.IsValueCreated ?? false)
                {
                    redoStack.Value.Dispose();
                }

                // Do proper stack initialization
                undoStack = new Lazy<PushDownStack<StateChangeBase>>(GenerateStack);
                redoStack = new Lazy<PushDownStack<StateChangeBase>>(GenerateStack);
            }
        }
    }

    private PushDownStack<StateChangeBase> GenerateStack()
    {
        if (historyLevels == 0)
        {
            throw new InvalidOperationException(Resources.NoHistoryLevelsException);
        }

        return new PushDownStack<StateChangeBase>(historyLevels);
    }

#endregion
}