// <copyright file="ArrayExtensions.SequenceEquals.StandardTypes.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    ///     Extensions for array types.
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this byte[]? left,
            [CanBeNull]
            byte[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this sbyte[]? left,
            [CanBeNull]
            sbyte[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this short[]? left,
            [CanBeNull]
            short[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this ushort[]? left,
            [CanBeNull]
            ushort[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this char[]? left,
            [CanBeNull]
            char[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this int[]? left,
            [CanBeNull]
            int[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this uint[]? left,
            [CanBeNull]
            uint[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this long[]? left,
            [CanBeNull]
            long[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this ulong[]? left,
            [CanBeNull]
            ulong[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        [SuppressMessage(
            "ReSharper",
            "CompareOfFloatsByEqualityOperator",
            Justification = "This is raw comparison and equation, we're not interested in the results of possible tolerance.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this float[]? left,
            [CanBeNull]
            float[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <param name="tolerance">The tolerance under which to consider values equal.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is within tolerance to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this float[]? left,
            [CanBeNull]
            float[]? right,
            float tolerance)
        {
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

            tolerance = Math.Abs(tolerance);

            for (var i = 0; i < left.Length; i++)
            {
                if (Math.Abs(left[i] - right[i]) > tolerance)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        [SuppressMessage(
            "ReSharper",
            "CompareOfFloatsByEqualityOperator",
            Justification = "This is raw comparison and equation, we're not interested in the results of possible tolerance.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this double[]? left,
            [CanBeNull]
            double[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <param name="tolerance">The tolerance under which to consider values equal.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is within tolerance to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this double[]? left,
            [CanBeNull]
            double[]? right,
            double tolerance)
        {
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

            tolerance = Math.Abs(tolerance);

            for (var i = 0; i < left.Length; i++)
            {
                if (Math.Abs(left[i] - right[i]) > tolerance)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this decimal[]? left,
            [CanBeNull]
            decimal[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this DateTime[]? left,
            [CanBeNull]
            DateTime[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this bool[]? left,
            [CanBeNull]
            bool[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this TimeSpan[]? left,
            [CanBeNull]
            TimeSpan[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Determines whether two arrays have all members in sequence equal to one another.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     <see langword="true"/> if the two arrays have the same length and each element at each position
        ///     in one array is equal to the equivalent in the other, <see langword="false"/> otherwise.
        /// </returns>
        [SuppressMessage(
            "ReSharper",
            "LoopCanBeConvertedToQuery",
            Justification = "We don't want this. Instead, we want maximum performance out of the array.")]
        public static bool SequenceEquals(
            [CanBeNull]
            this string[]? left,
            [CanBeNull]
            string[]? right)
        {
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
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}