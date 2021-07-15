// <copyright file="IAwaiter.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace IX.Abstractions.Threading
{
    /// <summary>
    /// An interface that can be used to create custom awaiters.
    /// </summary>
    [PublicAPI]
    public interface IAwaiter : INotifyCompletion
    {
        /// <summary>
        /// Gets a value indicating whether the awaiter has completed.
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// Gets the final result of the awaited operation, returning no value.
        /// </summary>
        void GetResult();

        /// <summary>
        /// Returns the current awaiter.
        /// </summary>
        /// <returns>The current awaiter.</returns>
        IAwaiter GetAwaiter();
    }
}