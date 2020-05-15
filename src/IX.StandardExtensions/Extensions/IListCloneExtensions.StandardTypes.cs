// <copyright file="IListCloneExtensions.StandardTypes.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using IX.StandardExtensions.Contracts;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    ///     Extensions for IList.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IListCloneExtensions
    {
        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<byte> DeepClone(this List<byte> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<byte>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<sbyte> DeepClone(this List<sbyte> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<sbyte>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<short> DeepClone(this List<short> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<short>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<ushort> DeepClone(this List<ushort> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<ushort>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<char> DeepClone(this List<char> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<char>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<int> DeepClone(this List<int> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<int>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<uint> DeepClone(this List<uint> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<uint>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<long> DeepClone(this List<long> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<long>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<ulong> DeepClone(this List<ulong> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<ulong>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<float> DeepClone(this List<float> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<float>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<double> DeepClone(this List<double> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<double>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<decimal> DeepClone(this List<decimal> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<decimal>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<DateTime> DeepClone(this List<DateTime> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<DateTime>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<bool> DeepClone(this List<bool> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<bool>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<TimeSpan> DeepClone(this List<TimeSpan> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<TimeSpan>(list);
        }

        /// <summary>
        ///     Deep clones the list.
        /// </summary>
        /// <param name="list">The list to clone.</param>
        /// <returns>
        ///     A cloned list.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="list"/> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static List<string> DeepClone(this List<string> list)
        {
            Requires.NotNull(
                list,
                nameof(list));

            return new List<string>(list);
        }
    }
}