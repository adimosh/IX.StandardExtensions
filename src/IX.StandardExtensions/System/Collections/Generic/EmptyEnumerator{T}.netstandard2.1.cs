// <copyright file="EmptyEnumerator{T}.netstandard2.1.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if FRAMEWORK_ADVANCED
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace IX.System.Collections.Generic
{
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1601:Partial elements should be documented",
        Justification = "Already documented.")]
    public sealed partial class EmptyEnumerator<T> : IAsyncEnumerator<T>
    {
#region Properties and indexers

        /// <summary>
        ///     Gets a default value.
        /// </summary>
        T IAsyncEnumerator<T>.Current => default!;

#endregion

#region Methods

#region Interface implementations

        /// <summary>
        ///     Does nothing.
        /// </summary>
        /// <returns>A default <see cref="ValueTask" />.</returns>
        [SuppressMessage(
            "AsyncUsage.CSharp.Naming",
            "AvoidAsyncSuffix:Avoid Async suffix",
            Justification = "This method was originally meant to actually be async.")]
        ValueTask IAsyncDisposable.DisposeAsync() => default;

        /// <summary>
        ///     Does nothing.
        /// </summary>
        /// <returns>
        ///     Always returns <see langword="false" />.
        /// </returns>
        [SuppressMessage(
            "AsyncUsage.CSharp.Naming",
            "AvoidAsyncSuffix:Avoid Async suffix",
            Justification = "This method was originally meant to actually be async.")]
        ValueTask<bool> IAsyncEnumerator<T>.MoveNextAsync() => new(false);

#endregion

#endregion
    }
}
#endif