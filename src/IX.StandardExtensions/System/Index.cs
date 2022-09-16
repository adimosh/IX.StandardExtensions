// <copyright file="IsExternalInit.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

// This file has been adapted from https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Index.cs,
// retrieved on 2022.09.08

#if !NETSTANDARD21_OR_GREATER
using IX.StandardExtensions.Contracts;

using JetBrains.Annotations;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace System;

/// <summary>Represent a type can be used to index a collection either from the start or the end.</summary>
/// <remarks>
/// Index is used by the C# compiler to support the new index syntax
/// <code>
/// int[] someArray = new int[5] { 1, 2, 3, 4, 5 } ;
/// int lastElement = someArray[^1]; // lastElement = 5
/// </code>
/// </remarks>
[PublicAPI]
public readonly struct Index : IEquatable<Index>
{
    private readonly int _value;

    /// <summary>Construct an Index using a value and indicating if the index is from the start or from the end.</summary>
    /// <param name="value">The index value. it has to be zero or positive number.</param>
    /// <param name="fromEnd">Indicating if the index is from the start or from the end.</param>
    /// <remarks>
    /// If the Index constructed from the end, index value 1 means pointing at the last element and index value 0 means pointing at beyond last element.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Index(int value, bool fromEnd = false)
    {
        Requires.NonNegative(value, nameof(value));

        _value = fromEnd ? ~value : value;
    }

    // The following private constructors mainly created for perf reason to avoid the checks
    private Index(int value) => _value = value;

    /// <summary>Create an Index pointing at first element.</summary>
    public static Index Start => new(0);

    /// <summary>Create an Index pointing at beyond last element.</summary>
    public static Index End => new(~0);

    /// <summary>Create an Index from the start at the position indicated by the value.</summary>
    /// <param name="value">The index value from the start.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index FromStart(int value)
    {
        Requires.NonNegative(value, nameof(value));

        return new(value);
    }

    /// <summary>Create an Index from the end at the position indicated by the value.</summary>
    /// <param name="value">The index value from the end.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index FromEnd(int value)
    {
        Requires.NonNegative(value, nameof(value));

        return new(~value);
    }

    /// <summary>Returns the index value.</summary>
    public int Value => _value < 0 ? ~_value : _value;

    /// <summary>Indicates whether the index is from the start or the end.</summary>
    public bool IsFromEnd => _value < 0;

    /// <summary>Calculate the offset from the start using the giving collection length.</summary>
    /// <param name="length">The length of the collection that the Index will be used with. length has to be a positive value</param>
    /// <remarks>
    /// For performance reason, we don't validate the input length parameter and the returned offset value against negative values.
    /// we don't validate either the returned offset is greater than the input length.
    /// It is expected Index will be used with collections which always have non negative length/count. If the returned offset is negative and
    /// then used to index a collection will get out of range exception which will be same affect as the validation.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetOffset(int length)
    {
        int offset = _value;
        if (IsFromEnd)
        {
            offset += length + 1;
        }
        return offset;
    }

    /// <summary>Indicates whether the current Index object is equal to another object of the same type.</summary>
    /// <param name="value">An object to compare with this object</param>
    public override bool Equals([NotNullWhen(true)] object? value) => value is Index index && _value == index._value;

    /// <summary>Indicates whether the current Index object is equal to another Index object.</summary>
    /// <param name="other">An object to compare with this object</param>
    public bool Equals(Index other) => _value == other._value;

    /// <summary>Returns the hash code for this instance.</summary>
    public override int GetHashCode() => _value;

    /// <summary>Converts integer number to an Index.</summary>
    public static implicit operator Index(int value) => FromStart(value);

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(Index left, Index right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(Index left, Index right) => !(left == right);

    /// <summary>Converts the value of the current Index object to its equivalent string representation.</summary>
    public override string ToString() => IsFromEnd ? ToStringFromEnd() : ((uint)Value).ToString();

    private string ToStringFromEnd() => '^' + ((uint)Value).ToString();
}
#endif