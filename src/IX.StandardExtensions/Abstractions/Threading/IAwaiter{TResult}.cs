// <copyright file="IAwaiter{TResult}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace IX.Abstractions.Threading
{
    /// <summary>
    /// An interface that can be used to create custom awaiters.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    [PublicAPI]
    public interface IAwaiter<out TResult> : INotifyCompletion
    {
        /// <summary>
        /// Gets a value indicating whether the awaiter has completed.
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// Gets the final result of the awaited operation.
        /// </summary>
        /// <returns>The result of the awaiting operation.</returns>
        TResult GetResult();

        /// <summary>
        /// Returns the current awaiter.
        /// </summary>
        /// <returns>The current awaiter.</returns>
        IAwaiter<TResult> GetAwaiter();
    }
}