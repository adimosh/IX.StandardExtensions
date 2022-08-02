// <copyright file="ObservableListBase{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using IX.Observable.Adapters;

// ReSharper disable once CheckNamespace
namespace IX.Observable;

// TODO: Remove in 0.8.0

#pragma warning disable SA1601 // Partial elements should be documented
public abstract partial class ObservableListBase<T>
{
    /// <summary>
    ///     Gets the internal list container.
    /// </summary>
    /// <value>
    ///     The internal list container.
    /// </value>
    [Obsolete("This property is no longer used anywhere, and will not have this form anymore. Please use a private or local direct cast of the InternalContainer of the ObservableCollectionBase class, or the InternalListContainer property.")]
    [ExcludeFromCodeCoverage]
    protected new ListAdapter<T> InternalContainer => (ListAdapter<T>)base.InternalContainer;
}
#pragma warning restore SA1601 // Partial elements should be documented