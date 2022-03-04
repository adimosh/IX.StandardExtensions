// <copyright file="PredictableDataStore{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace IX.DataGeneration;

[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1601:Partial elements should be documented", Justification = "No.")]
public partial class PredictableDataStore<T>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PredictableDataStore{T}" /> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    /// <param name="generator">The generator.</param>
    [Obsolete(
        "Please use the constructor with the default parameter, as this constructor will be removed in a later version.")]
    [SuppressMessage(
        "ReSharper",
        "RedundantOverload.Global",
        Justification = "Let's leave this in for now, as we'll remove this in a future version.")]
    [ExcludeFromCodeCoverage]
    public PredictableDataStore(
        int capacity,
        Func<T> generator)
        : this(
            capacity,
            generator,
            false) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PredictableDataStore{T}" /> class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    /// <param name="generator">The stateful generator.</param>
    /// <param name="state">The state.</param>
    [Obsolete(
        "Please use the constructor with the default parameter, as this constructor will be removed in a later version.")]
    [SuppressMessage(
        "ReSharper",
        "RedundantOverload.Global",
        Justification = "Let's leave this in for now, as we'll remove this in a future version.")]
    [ExcludeFromCodeCoverage]
    public PredictableDataStore(
        int capacity,
        Func<object, T> generator,
        object state)
        : this(
            capacity,
            generator,
            state,
            false) { }
}