// <copyright file="PooledObject{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Efficiency
{
    /// <summary>
    ///     A pooled object. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T">The type of class instance in the pool.</typeparam>
    /// <seealso cref="IDisposable" />
    [PublicAPI]
    public sealed class PooledObject<T> : IDisposable
        where T : class
    {
#region Internal state

        private readonly ObjectPool<T> pool;

        private bool abort;

#endregion

#region Constructors

        internal PooledObject(
            ObjectPool<T> pool,
            T value)
        {
            this.Value = value;
            this.pool = pool;
        }

#endregion

#region Properties and indexers

        /// <summary>
        ///     Gets the value contained.
        /// </summary>
        /// <value>The value.</value>
        public T Value
        {
            get;
        }

#endregion

#region Methods

#region Operators

        /// <summary>
        ///     Performs an implicit conversion from <see cref="PooledObject{T}" /> to <typeparamref name="T" />.
        /// </summary>
        /// <param name="source">The source pooled object.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator T(PooledObject<T> source) =>
            Requires.NotNull(
                    source)
                .Value;

#endregion

#region Interface implementations

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!this.abort)
            {
                this.pool.Release(this.Value);
            }
        }

#endregion

        /// <summary>
        ///     Aborts this pooled object, not returning its value to the pool.
        /// </summary>
        public void Abort() =>
            this.abort = true;

#endregion
    }
}