// <copyright file="BinarySwitchEnumerableExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Efficiency
{
    /// <summary>
    /// Extensions for enumerable collections with a set of binary switches.
    /// </summary>
    [PublicAPI]
    public static class BinarySwitchEnumerableExtensions
    {
        /// <summary>
        /// Enumerates the collection with switches.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="sourceCollection">The source collection.</param>
        /// <returns>An enumerator of the original collection, with switches.</returns>
        public static EnumerableBinarySwitchEnumerator<TItem> EnumerateWithSwitches<TItem>(
            this IEnumerable<TItem> sourceCollection) =>
            new EnumerableBinarySwitchEnumerator<TItem>(new CollectionWithBinarySwitches<TItem>(sourceCollection));

        /// <summary>
        /// An enumerator type.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        public readonly struct EnumerableBinarySwitchEnumerator<TItem> : IEnumerator<IEnumerable<(TItem Item, bool Switch)>>
        {
            private readonly CollectionWithBinarySwitches<TItem> sourceCollection;

            internal EnumerableBinarySwitchEnumerator(CollectionWithBinarySwitches<TItem> sourceCollection)
            {
                this.sourceCollection = sourceCollection;
            }

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>
            /// The current.
            /// </value>
            public IEnumerable<(TItem Item, bool Switch)> Current =>
                this.sourceCollection;

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>
            /// The current.
            /// </value>
            object IEnumerator.Current =>
                this.Current;

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
                "IDisposableAnalyzers.Correctness",
                "IDISP007:Don't dispose injected.",
                Justification = "This is safe, as the only injection is what we already control.")]
            public void Dispose() => this.sourceCollection.Dispose();

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            ///   <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.
            /// </returns>
            public bool MoveNext()
            {
                if (this.sourceCollection.AllSwitchesOn)
                {
                    return false;
                }

                this.sourceCollection.IncrementOne();

                return true;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset() => this.sourceCollection.ResetSwitches();
        }
    }
}