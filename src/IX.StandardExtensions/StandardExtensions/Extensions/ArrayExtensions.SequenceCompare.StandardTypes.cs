// <copyright file="ArrayExtensions.SequenceCompare.StandardTypes.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

namespace IX.StandardExtensions.Extensions;

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
        this byte[]? left,
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
        this sbyte[]? left,
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
        this short[]? left,
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
        this ushort[]? left,
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
        this char[]? left,
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
        this int[]? left,
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
        this uint[]? left,
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
        this long[]? left,
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
        this ulong[]? left,
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
        this float[]? left,
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
        this double[]? left,
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
        this decimal[]? left,
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
        this DateTime[]? left,
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
        this bool[]? left,
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
        this TimeSpan[]? left,
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
        this string[]? left,
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