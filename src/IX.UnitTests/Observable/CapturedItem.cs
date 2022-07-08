// <copyright file="CapturedItem.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using IX.Undoable;
using IX.Undoable.StateChanges;

namespace IX.UnitTests.Observable;

/// <summary>
///     A test fixture for testing undo/redo stuff.
/// </summary>
/// <seealso cref="EditableItemBase" />
public class CapturedItem : EditableItemBase
{
    private string testProperty;

    /// <summary>
    ///     Gets or sets the test property.
    /// </summary>
    /// <value>The test property.</value>
    public string TestProperty
    {
        get => testProperty;

        set
        {
            if (testProperty == value)
            {
                return;
            }

            AdvertisePropertyChange(
                nameof(TestProperty),
                testProperty,
                value);

            testProperty = value;

            RaisePropertyChanged(nameof(TestProperty));
        }
    }

    /// <summary>
    ///     Called when a list of state changes must be executed.
    /// </summary>
    /// <param name="stateChange">The state changes to execute.</param>
    /// <exception cref="InvalidOperationException">
    ///     Undo/Redo advertised a state change that is not for the only property, some state is leaking.
    ///     or
    ///     Undo/Redo advertised a state change that is of a different type than property, some state is leaking.
    /// </exception>
    protected override void DoChanges(StateChangeBase stateChange)
    {
        if (stateChange is PropertyStateChange<string> psts)
        {
            if (psts.PropertyName != nameof(TestProperty))
            {
                throw new InvalidOperationException(
                    "Undo/Redo advertised a state change that is not for the only property, some state is leaking.");
            }

            testProperty = psts.NewValue;

            RaisePropertyChanged(nameof(TestProperty));
        }
        else
        {
            throw new InvalidOperationException(
                "Undo/Redo advertised a state change that is of a different type than property, some state is leaking.");
        }
    }

    /// <summary>
    ///     Called when a list of state changes are canceled and must be reverted.
    /// </summary>
    /// <param name="stateChange">The state changes to revert.</param>
    /// <exception cref="InvalidOperationException">
    ///     Undo/Redo advertised a state change that is not for the only property, some state is leaking.
    ///     or
    ///     Undo/Redo advertised a state change that is of a different type than property, some state is leaking.
    /// </exception>
    protected override void RevertChanges(StateChangeBase stateChange)
    {
        if (stateChange is PropertyStateChange<string> psts)
        {
            if (psts.PropertyName != nameof(TestProperty))
            {
                throw new InvalidOperationException(
                    "Undo/Redo advertised a state change that is not for the only property, some state is leaking.");
            }

            testProperty = psts.OldValue;

            RaisePropertyChanged(nameof(TestProperty));
        }
        else
        {
            throw new InvalidOperationException(
                "Undo/Redo advertised a state change that is of a different type than property, some state is leaking.");
        }
    }
}