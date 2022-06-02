// <copyright file="CollectionWithBinarySwitches{TItem}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Efficiency
{
    /// <summary>
    /// A collection of items along with binary switches for each.
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    [PublicAPI]
    public class CollectionWithBinarySwitches<TItem> : DisposableBase, IEnumerable<(TItem Item, bool Switch)>
    {
        private readonly (TItem Item, bool Switch)[] switchedItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionWithBinarySwitches{TItem}"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public CollectionWithBinarySwitches(TItem[] source)
        {
            var localSource = Requires.NotNull(
                source,
                nameof(source));
            var count = localSource.Length;

            this.switchedItems = new (TItem Item, bool Switch)[count];

            for (int i = 0; i < count; i++)
            {
                this.switchedItems[i]
                    .Item = localSource[i];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionWithBinarySwitches{TItem}"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public CollectionWithBinarySwitches(List<TItem> source)
        {
            var localSource = Requires.NotNull(
                source,
                nameof(source));
            var count = localSource.Count;

            this.switchedItems = new (TItem Item, bool Switch)[count];

            for (int i = 0; i < count; i++)
            {
                this.switchedItems[i]
                    .Item = localSource[i];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionWithBinarySwitches{TItem}"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public CollectionWithBinarySwitches(IEnumerable<TItem> source)
        {
            var localSource = Requires.NotNull(
                source,
                nameof(source));
            List<(TItem Item, bool Switch)> tempList = new();

            foreach (var item in localSource)
            {
                tempList.Add((item, false));
            }

            this.switchedItems = tempList.ToArray();
        }

        /// <summary>
        /// Gets a value indicating whether all switches are on.
        /// </summary>
        /// <value>
        ///   <c>true</c> if all switches are on; otherwise, <c>false</c>.
        /// </value>
        public bool AllSwitchesOn =>
            this.switchedItems.All(p => p.Switch);

        /// <summary>
        /// Gets a value indicating whether all switches are off.
        /// </summary>
        /// <value>
        ///   <c>true</c> if all switches are off; otherwise, <c>false</c>.
        /// </value>
        public bool AllSwitchesOff =>
            this.switchedItems.All(p => !p.Switch);

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>An enumerator that enumerates through the contents of the current collection.</returns>
        public CollectionWithBinarySwitchesEnumerator GetEnumerator() =>
            new(this.switchedItems);

        /// <summary>
        /// Increments the one.
        /// </summary>
        public void IncrementOne()
        {
            for (int i = 0; i < this.switchedItems.Length; i++)
            {
                this.switchedItems[i].Switch = !this.switchedItems[i].Switch;
                if (this.switchedItems[i]
                    .Switch)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Resets the switches.
        /// </summary>
        public void ResetSwitches()
        {
            for (int i = 0; i < this.switchedItems.Length; i++)
            {
                this.switchedItems[i]
                    .Switch = false;
            }
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>A boxed instance of <see cref="CollectionWithBinarySwitchesEnumerator"/>.</returns>
        [Obsolete("Please do not use this method, as it risks unnecessarily boxing the enumerator.")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This method is marked as obsolete and should not be used anymore.")]
        IEnumerator<(TItem Item, bool Switch)> IEnumerable<(TItem Item, bool Switch)>.GetEnumerator() =>
            this.GetEnumerator();

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>A boxed instance of <see cref="CollectionWithBinarySwitchesEnumerator"/>.</returns>
        [Obsolete("Please do not use this method, as it risks unnecessarily boxing the enumerator.")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This method is marked as obsolete and should not be used anymore.")]
        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        /// <summary>
        /// An enumerator for the <see cref="CollectionWithBinarySwitches{TItem}"/> class.
        /// </summary>
        public struct CollectionWithBinarySwitchesEnumerator : IEnumerator<(TItem Item, bool Switch)>
        {
            private readonly WeakReference<(TItem Item, bool Switch)[]> items;

            private int index;

            internal CollectionWithBinarySwitchesEnumerator((TItem Item, bool Switch)[] items)
            {
                this.items = new WeakReference<(TItem Item, bool Switch)[]>(items);
                this.index = 0;
            }

            /// <summary>
            /// Gets the item at the current cursor position.
            /// </summary>
            /// <value>
            /// The item.
            /// </value>
            public readonly (TItem Item, bool Switch) Current
            {
                get
                {
                    if (!this.items.TryGetTarget(out var target))
                    {
                        throw new ObjectDisposedException(nameof(CollectionWithBinarySwitches<TItem>));
                    }

                    return target[this.index];
                }
            }

            /// <summary>
            /// Gets the item at the current index as an object.
            /// </summary>
            /// <value>
            /// The current.
            /// </value>
            [Obsolete("Please do not use this method, as it risks unnecessarily boxing items.")]
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
                "Performance",
                "HAA0601:Value type to reference type conversion causing boxing allocation",
                Justification = "This method is marked as obsolete and should not be used anymore.")]
            readonly object global::System.Collections.IEnumerator.Current =>
                this.Current;

            /// <summary>
            /// Releases unmanaged and - optionally - managed resources.
            /// </summary>
            readonly void IDisposable.Dispose()
            {
            }

            /// <summary>
            /// Moves the cursor to the next item in the enumerable.
            /// </summary>
            /// <returns><c>true</c> on success, <c>false</c> if the end of the enumerable has been reached.</returns>
            public bool MoveNext()
            {
                if (!this.items.TryGetTarget(out var target))
                {
                    throw new ObjectDisposedException(nameof(CollectionWithBinarySwitches<TItem>));
                }

                if (this.index >= target.Length - 1)
                {
                    return false;
                }

                this.index++;

                return true;
            }

            /// <summary>
            /// Resets this enumerator.
            /// </summary>
            public void Reset() => this.index = 0;
        }
    }
}