// <copyright file="ModernCollectionAdapter.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

namespace IX.Observable.Adapters;

internal abstract class ModernCollectionAdapter
{
#region Events

    /// <summary>
    ///     Occurs when the owner of this list adapter must reset.
    /// </summary>
    public event EventHandler? MustReset;

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the number of items.
    /// </summary>
    /// <value>
    ///     The number of items.
    /// </value>
    public abstract int Count { get; }

    /// <summary>
    ///     Gets a value indicating whether this instance is read only.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if this instance is read only; otherwise, <see langword="false" />.
    /// </value>
    public abstract bool IsReadOnly { get; }

#endregion

#region Methods

    /// <summary>
    ///     Clears this instance.
    /// </summary>
    public abstract void Clear();

    /// <summary>
    ///     Triggers the reset.
    /// </summary>
    protected void TriggerReset() =>
        this.MustReset?.Invoke(
            this,
            EventArgs.Empty);

#endregion
}