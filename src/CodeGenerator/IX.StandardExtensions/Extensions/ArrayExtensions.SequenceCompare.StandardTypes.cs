// <copyright file="ArrayExtensions.SequenceCompare.StandardTypes.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    ///     Extensions for array types.
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this byte[]? left,
            [CanBeNull]
            byte[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this sbyte[]? left,
            [CanBeNull]
            sbyte[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this short[]? left,
            [CanBeNull]
            short[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this ushort[]? left,
            [CanBeNull]
            ushort[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this char[]? left,
            [CanBeNull]
            char[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this int[]? left,
            [CanBeNull]
            int[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this uint[]? left,
            [CanBeNull]
            uint[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this long[]? left,
            [CanBeNull]
            long[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this ulong[]? left,
            [CanBeNull]
            ulong[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this float[]? left,
            [CanBeNull]
            float[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this double[]? left,
            [CanBeNull]
            double[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this decimal[]? left,
            [CanBeNull]
            decimal[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this DateTime[]? left,
            [CanBeNull]
            DateTime[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this bool[]? left,
            [CanBeNull]
            bool[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this TimeSpan[]? left,
            [CanBeNull]
            TimeSpan[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = c1.CompareTo(c2);
                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }

        /// <summary>
        ///     Compares two arrays to one another sequentially.
        /// </summary>
        /// <param name="left">The left operand array.</param>
        /// <param name="right">The right operand array.</param>
        /// <returns>
        ///     The result of the comparison.
        /// </returns>
        public static int SequenceCompare(
            [CanBeNull]
            this string[]? left,
            [CanBeNull]
            string[]? right)
        {
            if (left == null)
            {
                // Left is null, we return based on whether or not right is null as well
                return right == null ? 0 : int.MinValue;
            }

            if (right == null)
            {
                // Right is null, but not left
                return int.MaxValue;
            }

            var i = 0;
            while (true)
            {
                var b1 = i < left.Length;
                var b2 = i < right.Length;

                if (!b1 && !b2)
                {
                    return 0;
                }

                var c1 = b1 ? left[i] : default;
                var c2 = b2 ? right[i] : default;

                var cr = string.Compare(c1, c2, StringComparison.CurrentCulture);

                if (cr != 0)
                {
                    return cr;
                }

                i++;
            }
        }
    }
}