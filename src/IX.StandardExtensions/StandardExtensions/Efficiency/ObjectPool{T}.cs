// <copyright file="ObjectPool{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Efficiency
{
    /// <summary>
    ///     A pool of on-demand objects that keeps growing based on demand.
    /// </summary>
    /// <typeparam name="T">The class type to hold in the pool.</typeparam>
    [PublicAPI]
    public class ObjectPool<T>
        where T : class
    {
#region Internal state

        // Pool collections
        private readonly Queue<T> availableObjects;

        // Interlocker
        private readonly object locker;

        // Object factory
        private readonly Func<T> objectFactory;

#endregion

#region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectPool{T}" /> class.
        /// </summary>
        /// <param name="objectFactory">An object factory for when objects need to be created.</param>
        /// <exception cref="ArgumentNullException">
        ///     The <paramref name="objectFactory" /> is <see langword="null" /> (
        ///     <see langword="Nothing" /> in Visual Basic).
        /// </exception>
        public ObjectPool(Func<T> objectFactory)
        {
            Requires.NotNull(
                out this.objectFactory,
                objectFactory,
                nameof(objectFactory));

            this.locker = new object();
            this.availableObjects = new Queue<T>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectPool{T}" /> class.
        /// </summary>
        /// <param name="objectFactory">An object factory for when objects need to be created.</param>
        /// <param name="initialNumberOfObjects">The number of objects to populate the pool with upon creation.</param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="initialNumberOfObjects"/> is not a positive
        ///     integer.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     The <paramref name="objectFactory" /> is <see langword="null" /> (
        ///     <see langword="Nothing" /> in Visual Basic).
        /// </exception>
        public ObjectPool(Func<T> objectFactory, int initialNumberOfObjects)
        {
            Requires.Positive(
                in initialNumberOfObjects,
                nameof(initialNumberOfObjects));
            Requires.NotNull(
                out this.objectFactory,
                objectFactory,
                nameof(objectFactory));

            this.locker = new object();
            this.availableObjects = new Queue<T>();

            for (int i = 0; i < initialNumberOfObjects; i++)
            {
                this.availableObjects.Enqueue(objectFactory());
            }
        }

#endregion

#region Properties and indexers

        /// <summary>
        ///     Gets the count of unused objects in the pool.
        /// </summary>
        /// <value>The currently-unused object count.</value>
        /// <remarks>
        ///     <para>
        ///         If this property returns 0, there are no more unused objects in the pool. If one is requested, a new one will
        ///         most likely be created.
        ///     </para>
        /// </remarks>
        public int Count
        {
            get
            {
                lock (this.locker)
                {
                    return this.availableObjects.Count;
                }
            }
        }

#endregion

#region Methods

        /// <summary>
        ///     Gets an object from the pool.
        /// </summary>
        /// <returns>A pooled object, either new, or unused.</returns>
        public PooledObject<T> Get()
        {
            T @object;

            lock (this.locker)
            {
                @object = this.availableObjects.Count > 0 ? this.availableObjects.Dequeue() : this.objectFactory();
            }

            return new PooledObject<T>(
                this,
                @object);
        }

        internal void Release(T @object)
        {
            lock (this.locker)
            {
                this.availableObjects.Enqueue(@object);
            }
        }

#endregion
    }
}