// <copyright file="DataGenerator.Integers.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

namespace IX.DataGeneration;

/// <summary>
///     A static class that is used for generating random data for testing.
/// </summary>
public static partial class DataGenerator
{
#region Methods

#region Static methods

    /// <summary>
    ///     Returns a random integer.
    /// </summary>
    /// <returns>An random integer.</returns>
    public static int RandomInteger()
    {
        bool negative;
        int item;

        lock (R)
        {
            negative = R.Next(2) == 1;
            item = R.Next();
        }

        return negative ? 0 - item : item;
    }

    /// <summary>
    ///     Returns a random integer whose absolute value is less than the specified maximum value.
    /// </summary>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>An random integer.</returns>
    public static int RandomInteger(int maxValue)
    {
        bool negative;
        int item;

        lock (R)
        {
            negative = R.Next(2) == 1;
            item = R.Next(maxValue);
        }

        return negative ? 0 - item : item;
    }

    /// <summary>
    ///     Returns a random integer.
    /// </summary>
    /// <param name="minValue">The minimum value, inclusive.</param>
    /// <param name="maxValue">The maximum value, exclusive.</param>
    /// <returns>An random integer.</returns>
    public static int RandomInteger(
        int minValue,
        int maxValue)
    {
        lock (R)
        {
            return R.Next(
                minValue,
                maxValue);
        }
    }

    /// <summary>
    ///     Returns a random non-negative integer.
    /// </summary>
    /// <returns>An random integer.</returns>
    public static int RandomNonNegativeInteger()
    {
        int generated;

        lock (R)
        {
            generated = R.Next();
        }

        return generated < 0 ? -generated : generated;
    }

    /// <summary>
    ///     Returns a random non-negative integer less than the specified maximum value.
    /// </summary>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>An random integer.</returns>
    public static int RandomNonNegativeInteger(int maxValue)
    {
        lock (R)
        {
            return R.Next(maxValue);
        }
    }

#endregion

#endregion
}