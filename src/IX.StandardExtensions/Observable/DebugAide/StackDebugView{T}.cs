// <copyright file="StackDebugView{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.Observable.DebugAide;

/// <summary>
///     A debug view class for an observable stack.
/// </summary>
/// <typeparam name="T">The type of object in the stack.</typeparam>
[UsedImplicitly]
[ExcludeFromCodeCoverage]
public sealed class StackDebugView<T>
{
#region Internal state

    private readonly ObservableStack<T> stack;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="StackDebugView{T}" /> class.
    /// </summary>
    /// <param name="stack">The stack.</param>
    /// <exception cref="ArgumentNullException">stack is null.</exception>
    [UsedImplicitly]
    public StackDebugView(ObservableStack<T> stack) => Requires.NotNull(out this.stack, stack);

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the items.
    /// </summary>
    /// <value>
    ///     The items.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    [UsedImplicitly]
    public T[] Items
    {
        get
        {
            var items = new T[stack.InternalContainer.Count];
            stack.InternalContainer.CopyTo(
                items,
                0);

            return items;
        }
    }

#endregion
}