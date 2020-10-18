// <copyright file="ArrayExtensions.SequenceEquals.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Efficiency;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    ///     Extensions for array types.
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        /// Determines whether two enumerable objects have all members in sequence equal to one another by using a comparer.
        /// </summary>
        /// <typeparam name="T">The type of the enumerable item.</typeparam>
        /// <param name="left">The left operand enumerable.</param>
        /// <param name="right">The right operand enumerable.</param>
        /// <param name="comparer">The comparer to use when equating items.</param>
        /// <returns><see langword="true"/> if the two enumerable objects have the same length and each element at each position
        /// in one enumerable is equal to the equivalent in the other, <see langword="false"/> otherwise.</returns>
        public static bool SequenceEquals<T>(
            this T[]? left,
            T[]? right,
            IEqualityComparer<T> comparer)
        {
            var localComparer = Requires.NotNull(
                comparer,
                nameof(comparer));

            if (left == null)
            {
                return right == null;
            }

            if (right == null)
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (var i = 0; i < left.Length; i++)
            {
                if (!localComparer.Equals(left[i], right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether two enumerable objects have all members in sequence equal to one another by using a comparer.
        /// </summary>
        /// <typeparam name="T">The type of the enumerable item.</typeparam>
        /// <param name="left">The left operand enumerable.</param>
        /// <param name="right">The right operand enumerable.</param>
        /// <param name="comparer">The comparer to use when equating items.</param>
        /// <returns><see langword="true"/> if the two enumerable objects have the same length and each element at each position
        /// in one enumerable is equal to the equivalent in the other, <see langword="false"/> otherwise.</returns>
        public static bool SequenceEquals<T>(
            this T[]? left,
            T[]? right,
            InFunc<T, T, bool> comparer)
        {
            var localComparer = Requires.NotNull(
                comparer,
                nameof(comparer));

            if (left == null)
            {
                return right == null;
            }

            if (right == null)
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (var i = 0; i < left.Length; i++)
            {
                if (!localComparer(in left[i], in right[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}