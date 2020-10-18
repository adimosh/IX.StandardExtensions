// <copyright file="EmptyEnumerator{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace IX.System.Collections.Generic
{
    /// <summary>
    ///     An empty enumerator.
    /// </summary>
    /// <typeparam name="T">The type of items in the enumerator.</typeparam>
    /// <seealso cref="IEnumerator{T}" />
    /// <seealso cref="IEnumerator" />
#if NETSTANDARD2_1
    /// <seealso cref="IAsyncEnumerator{T}" />
#endif
    [PublicAPI]
    public sealed partial class EmptyEnumerator<T> : IEnumerator<T>
    {
        private static readonly EmptyEnumerator<T> EmptyInstance = new EmptyEnumerator<T>();

        /// <summary>
        /// Prevents a default instance of the <see cref="EmptyEnumerator{T}"/> class from being created.
        /// </summary>
        private EmptyEnumerator()
        {
            // Nothing to do.
        }

#region Properties and indexers

        /// <summary>
        ///     Gets a default value.
        /// </summary>
        [SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "We offer a default value, even at the risk of boxing, in order to keep up with the standards that are expected of the interface enumerator.")]
        object IEnumerator.Current => default(T)!;

        /// <summary>
        ///     Gets a default value.
        /// </summary>
        T IEnumerator<T>.Current => default!;

        #endregion

        #region Methods

        /// <summary>
        /// Gets this empty instance.
        /// </summary>
        /// <returns>The empty instance.</returns>
        [SuppressMessage(
            "Design",
            "CA1000:Do not declare static members on generic types",
            Justification = "This is intended.")]
        public static EmptyEnumerator<T> Get() => EmptyInstance;

#region Interface implementations

        /// <summary>
        ///     Does nothing.
        /// </summary>
        [SuppressMessage(
            "Design",
            "CA1063:Implement IDisposable Correctly",
            Justification = "This does nothing and is supposed to do nothing.")]
        void IDisposable.Dispose()
        {
            // Nothing to do.
        }

        /// <summary>
        ///     Does nothing.
        /// </summary>
        /// <returns>
        ///     Always returns <see langword="false" />.
        /// </returns>
        bool IEnumerator.MoveNext() => false;

        /// <summary>
        ///     Does nothing.
        /// </summary>
        void IEnumerator.Reset()
        {
            // Nothing to do.
        }

#endregion

#endregion
    }
}