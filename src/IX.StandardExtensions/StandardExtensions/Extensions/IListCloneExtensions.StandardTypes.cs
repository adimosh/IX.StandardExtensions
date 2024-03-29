// <copyright file="IListCloneExtensions.StandardTypes.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;

namespace IX.StandardExtensions.Extensions;

/// <summary>
///     Extensions for IList.
/// </summary>
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "These are extensions for IList, so we must allow this.")]
public static partial class IListCloneExtensions
{
    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<byte> DeepClone(this List<byte> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<sbyte> DeepClone(this List<sbyte> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<short> DeepClone(this List<short> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<ushort> DeepClone(this List<ushort> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<char> DeepClone(this List<char> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<int> DeepClone(this List<int> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<uint> DeepClone(this List<uint> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<long> DeepClone(this List<long> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<ulong> DeepClone(this List<ulong> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<float> DeepClone(this List<float> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<double> DeepClone(this List<double> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<decimal> DeepClone(this List<decimal> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<DateTime> DeepClone(this List<DateTime> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<bool> DeepClone(this List<bool> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<TimeSpan> DeepClone(this List<TimeSpan> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static List<string> DeepClone(this List<string> list)
    {
        var localList = Requires.NotNull(list);

        return new(localList);
    }
}