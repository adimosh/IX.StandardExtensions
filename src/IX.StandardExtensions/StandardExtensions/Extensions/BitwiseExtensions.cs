// <copyright file="BitwiseExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions;

/// <summary>
///     Extension methods for bitwise operations regarding bitwise operations.
/// </summary>
[PublicAPI]
public static class BitwiseExtensions
{
#region Methods

#region Static methods

    /// <summary>
    ///     Shifts all the bits in the bit array to the left.
    /// </summary>
    /// <param name="data">The original data.</param>
    /// <param name="howManyBits">How many bits to shift by.</param>
    /// <returns>The shifted bit array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="data" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="howManyBits" /> is less than zero.
    /// </exception>
    public static BitArray LeftShift(
        this BitArray data,
        int howManyBits)
    {
        BitArray localData = Requires.NotNull(data);

        BitArray? result = Shift(
            localData,
            howManyBits);

        if (result != null)
        {
            return result;
        }

        result = new(data);

        for (var i = 0; i < result.Length - howManyBits; i++)
        {
            result[i] = result[i + howManyBits];
        }

        for (var i = result.Length - howManyBits; i < result.Length; i++)
        {
            result[i] = false;
        }

        return result;
    }

    /// <summary>
    ///     Shifts all the bits in the byte array to the left.
    /// </summary>
    /// <param name="data">The original data.</param>
    /// <param name="howManyBits">How many bits to shift by.</param>
    /// <returns>The shifted byte array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="data" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="howManyBits" /> is less than zero.
    /// </exception>
    public static byte[] LeftShift(
        this byte[] data,
        int howManyBits)
    {
        var ba = new BitArray(Requires.NotNull(data));

        ba = LeftShift(
            ba,
            howManyBits);

        var result = new byte[data.Length];
        ba.CopyTo(
            result,
            0);

        return result;
    }

    /// <summary>
    ///     Shifts all the bits in the bit array to the right.
    /// </summary>
    /// <param name="data">The original data.</param>
    /// <param name="howManyBits">How many bits to shift by.</param>
    /// <returns>The shifted bit array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="data" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="howManyBits" /> is less than zero.
    /// </exception>
    public static BitArray RightShift(
        this BitArray data,
        int howManyBits)
    {
        BitArray localData = Requires.NotNull(data);

        BitArray? result = Shift(
            localData,
            howManyBits);

        if (result != null)
        {
            return result;
        }

        result = new(data);

        for (var i = result.Length - 1; i >= howManyBits; i--)
        {
            result[i] = result[i - howManyBits];
        }

        for (var i = 0; i < howManyBits; i++)
        {
            result[i] = false;
        }

        return result;
    }

    /// <summary>
    ///     Shifts all the bits in the byte array to the right.
    /// </summary>
    /// <param name="data">The original data.</param>
    /// <param name="howManyBits">How many bits to shift by.</param>
    /// <returns>The shifted byte array.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="data" /> is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="howManyBits" /> is less than zero.
    /// </exception>
    public static byte[] RightShift(
        this byte[] data,
        int howManyBits)
    {
        var ba = new BitArray(Requires.NotNull(data));

        ba = RightShift(
            ba,
            howManyBits);

        var result = new byte[data.Length];
        ba.CopyTo(
            result,
            0);

        return result;
    }

    private static BitArray? Shift(
        BitArray data,
        int howManyBits)
    {
        Requires.NonNegative(
            in howManyBits,
            nameof(howManyBits));

        if (howManyBits == 0)
        {
            return new(data);
        }

        return howManyBits >= data.Length ? new BitArray(data.Length) : null;
    }

#endregion

#endregion
}