// <copyright file="Requires.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using IX.Abstractions.Entities;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Efficiency;
using JetBrains.Annotations;
using DiagCA = System.Diagnostics.CodeAnalysis;

namespace IX.StandardExtensions.Contracts
{
    /// <summary>
    ///     Methods for approximating the works of contract-oriented programming.
    /// </summary>
    [PublicAPI]
    public static partial class Requires
    {
        #region Not null, empty or whitespace

        #region Strings

        /// <summary>
        ///     Called when a contract requires that an argument is not null.
        /// </summary>
        /// <typeparam name="T">The type of argument to validate.</typeparam>
        /// <param name="argument">
        ///     The argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The validated argument.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     The argument is <see langword="null" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static T NotNull<T>(
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T? argument,
            string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }

        /// <summary>
        ///     Called when a contract requires that an argument is not null.
        /// </summary>
        /// <typeparam name="T">The type of argument to validate.</typeparam>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The argument is <see langword="null" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static void NotNull<T>(
            out T field,
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T? argument,
            string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a string argument is not null or empty.
        /// </summary>
        /// <param name="argument">
        ///     The string argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The validated argument.
        /// </returns>
        /// <exception cref="ArgumentNullOrEmptyStringException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static string NotNullOrEmpty(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullOrEmptyStringException(argumentName);
            }

            return argument!;
        }

        /// <summary>
        ///     Called when a contract requires that a string argument is not null or empty.
        /// </summary>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The string argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullOrEmptyStringException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static void NotNullOrEmpty(
            out string field,
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullOrEmptyStringException(argumentName);
            }

            field = argument!;
        }

        /// <summary>
        ///     Called when a contract requires that a string argument is not null empty or whitespace-only.
        /// </summary>
        /// <param name="argument">
        ///     The string argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The validated argument.
        /// </returns>
        /// <exception cref="ArgumentNullOrWhiteSpaceStringException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static string NotNullOrWhiteSpace(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
            }

            return argument!;
        }

        /// <summary>
        ///     Called when a contract requires that a string argument is not null empty or whitespace-only.
        /// </summary>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The string argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullOrWhiteSpaceStringException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static void NotNullOrWhiteSpace(
            out string field,
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
            }

            field = argument!;
        }

        #endregion

        #region Arrays and collections

        /// <summary>
        ///     Called when a contract requires that a collection argument is not null or empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection.</typeparam>
        /// <typeparam name="T">
        ///     The type of item in the collection.
        /// </typeparam>
        /// <param name="argument">
        ///     The collection argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The validated argument.
        /// </returns>
        /// <exception cref="ArgumentNullOrEmptyCollectionException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static TCollection NotEmpty<TCollection, T>(
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            TCollection? argument,
            string argumentName)
            where TCollection : class, ICollection<T>
        {
            if ((argument?.Count ?? 0) == 0)
            {
                throw new ArgumentNullOrEmptyCollectionException(argumentName);
            }

            return argument!;
        }

        /// <summary>
        /// Called when a contract requires that a collection argument is not null or empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection.</typeparam>
        /// <typeparam name="T">The type of the item in the collection.</typeparam>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="argument">The collection argument.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNullOrEmptyCollectionException">The argument is <see langword="null" /> or empty.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static void NotEmpty<TCollection, T>(
            out TCollection field,
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            TCollection? argument,
            string argumentName)
            where TCollection : class, ICollection<T>
        {
            if ((argument?.Count ?? 0) == 0)
            {
                throw new ArgumentNullOrEmptyCollectionException(argumentName);
            }

            field = argument!;
        }

        /// <summary>
        ///     Called when a contract requires that an array argument is not null or empty.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the array.
        /// </typeparam>
        /// <param name="argument">
        ///     The array argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The validated argument.
        /// </returns>
        /// <exception cref="ArgumentNullOrEmptyBinaryException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static T[] NotEmpty<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? argument,
            string argumentName)
        {
            if ((argument?.Length ?? 0) == 0)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            return argument!;
        }

        /// <summary>
        ///     Called when a contract requires that an array argument is not null or empty.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the array.
        /// </typeparam>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="argument">
        ///     The array argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullOrEmptyBinaryException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static void NotEmpty<T>(
            out T[] field,
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? argument,
            string argumentName)
        {
            if ((argument?.Length ?? 0) == 0)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            field = argument!;
        }

        #endregion

        #endregion

        #region Fixed length

        /// <summary>Called when a contract requires that an array is of a specific length.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <returns>The validated argument.</returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static T[] FixedLength<T>(
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in int length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 0)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.Length != length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            return array;
        }

        /// <summary>Called when a contract requires that an array is of a specific length.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static void FixedLength<T>(
            out T[] field,
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in int length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 0)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.Length != length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            field = array;
        }

        /// <summary>Called when a contract requires that an array is of a specific length.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <returns>The validated argument.</returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static T[] FixedLength<T>(
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in long length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 0)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.LongLength != length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            return array;
        }

        /// <summary>Called when a contract requires that an array is of a specific length.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static void FixedLength<T>(
            out T[] field,
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in long length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 0)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.LongLength != length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            field = array;
        }

        #endregion

        #region Length at least

        /// <summary>Called when a contract requires that an array's length is at least a specific value.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <returns>The validated argument.</returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static T[] LengthAtLeast<T>(
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in int length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 0)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.Length < length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            return array;
        }

        /// <summary>Called when a contract requires that an array's length is at least a specific value.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static void LengthAtLeast<T>(
            out T[] field,
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in int length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 0)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.Length < length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            field = array;
        }

        /// <summary>Called when a contract requires that an array's length is at least a specific value.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <returns>The validated argument.</returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static T[] LengthAtLeast<T>(
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in long length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 0)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.LongLength < length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            return array;
        }

        /// <summary>Called when a contract requires that an array's length is at least a specific value.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static void LengthAtLeast<T>(
            out T[] field,
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in long length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 0)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.LongLength < length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            field = array;
        }

        #endregion

        #region Length at most

        /// <summary>Called when a contract requires that an array's length is at most a specific value.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <returns>The validated argument.</returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static T[] LengthAtMost<T>(
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in int length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 1)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.Length > length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            return array;
        }

        /// <summary>Called when a contract requires that an array's length is at most a specific value.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static void LengthAtMost<T>(
            out T[] field,
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in int length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length > 1)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.Length < length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            field = array;
        }

        /// <summary>Called when a contract requires that an array's length is at most a specific value.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <returns>The validated argument.</returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static T[] LengthAtMost<T>(
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in long length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length > 1)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.LongLength < length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            return array;
        }

        /// <summary>Called when a contract requires that an array's length is at most a specific value.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="length">The exact length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("array:null => halt")]
        public static void LengthAtMost<T>(
            out T[] field,
            [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? array,
            in long length,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            if (length < 1)
            {
                throw new ArgumentNotValidLengthException(nameof(length));
            }

            if (array.LongLength > length)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            field = array;
        }

        #endregion

        #region Matches

        [DiagCA.SuppressMessage(
            "StyleCop.CSharp.OrderingRules",
            "SA1201:Elements should appear in the correct order",
            Justification = "Better code readability this way.")]
        private static readonly Lazy<ConcurrentDictionary<string, Regex>> Regexes = new(() => new ConcurrentDictionary<string, Regex>());

        /// <summary>
        /// Called when a contract requires that a string matches a specific pattern.
        /// </summary>
        /// <param name="argument">The string to validate.</param>
        /// <param name="pattern">The pattern to match.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <returns>The validated argument.</returns>
        /// <exception cref="ArgumentNullOrEmptyStringException">The pattern is <c>null</c> (<c>Nothing in Visual Basic</c>) or empty.</exception>
        /// <exception cref="ArgumentNullException">The argument is <c>null</c> (<c>Nothing in Visual Basic</c>).</exception>
        /// <exception cref="ArgumentDoesNotMatchException">The argument does not match the pattern.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static string Matches(
            string? argument,
            string pattern,
            string argumentName)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentNullOrEmptyStringException(nameof(pattern));
            }

            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            var patternRegex = Regexes.Value.GetOrAdd(
                pattern,
                p => new Regex(p));

            if (!patternRegex.IsMatch(argument))
            {
                throw new ArgumentDoesNotMatchException(argumentName);
            }

            return argument;
        }

        /// <summary>
        /// Called when a contract requires that a string matches a specific pattern.
        /// </summary>
        /// <param name="field">
        ///     The field that this argument is initializing.
        /// </param>
        /// <param name="argument">The string to validate.</param>
        /// <param name="pattern">The pattern to match.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNullOrEmptyStringException">The pattern is <c>null</c> (<c>Nothing in Visual Basic</c>) or empty.</exception>
        /// <exception cref="ArgumentNullException">The argument is <c>null</c> (<c>Nothing in Visual Basic</c>).</exception>
        /// <exception cref="ArgumentDoesNotMatchException">The argument does not match the pattern.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static void Matches(
            out string field,
            string? argument,
            string pattern,
            string argumentName)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentNullOrEmptyStringException(nameof(pattern));
            }

            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            var patternRegex = Regexes.Value.GetOrAdd(
                pattern,
                p => new Regex(p));

            if (!patternRegex.IsMatch(argument))
            {
                throw new ArgumentDoesNotMatchException(argumentName);
            }

            field = argument;
        }

        #endregion

        #region Positive

        /// <summary>
        ///     Called when a contract requires that a <see cref="TimeSpan"/> argument is positive.
        /// </summary>
        /// <param name="argument">
        ///     The time span argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The validated argument.
        /// </returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan Positive(
            in TimeSpan argument,
            string argumentName)
        {
            if (argument <= TimeSpan.Zero)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            return argument;
        }

        /// <summary>
        ///     Called when a contract requires that a <see cref="TimeSpan"/> argument is positive.
        /// </summary>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="argument">
        ///     The time span argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Positive(
            out TimeSpan field,
            in TimeSpan argument,
            string argumentName)
        {
            if (argument <= TimeSpan.Zero)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }
        #endregion

        #region Non-negative

        /// <summary>
        ///     Called when a contract requires that a <see cref="TimeSpan" /> argument is not negative.
        /// </summary>
        /// <param name="argument">
        ///     The time span argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The validated argument.
        /// </returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan NonNegative(
            in TimeSpan argument,
            string argumentName)
        {
            if (argument < TimeSpan.Zero)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            return argument;
        }

        /// <summary>
        ///     Called when a contract requires that a <see cref="TimeSpan" /> argument is not negative.
        /// </summary>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="argument">
        ///     The time span argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NonNegative(
            out TimeSpan field,
            in TimeSpan argument,
            string argumentName)
        {
            if (argument < TimeSpan.Zero)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }
        #endregion

        #region Array index and range

        /// <summary>Called when a contract requires that a specific index is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the index.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayIndex<T>(
            in int argument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (argument < 0 || argument >= array.Length)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }
        }

        /// <summary>Called when a contract requires that a specific index is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the index.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayIndex<T>(
            out int field,
            in int argument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (argument < 0 || argument >= array.Length)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }

            field = argument;
        }

        /// <summary>Called when a contract requires that a specific index is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the index.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayIndex<T>(
            in long argument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (argument < 0 || argument >= array.LongLength)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }
        }

        /// <summary>Called when a contract requires that a specific index is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the index.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayIndex<T>(
            out long field,
            in long argument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (argument < 0 || argument >= array.LongLength)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }

            field = argument;
        }

        /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="indexArgument">The numeric index argument to validate.</param>
        /// <param name="lengthArgument">The numeric length argument to validate.</param>
        /// <param name="array">The array for which we are validating the range.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayRange<T>(
            in int indexArgument,
            in int lengthArgument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (indexArgument < 0 || indexArgument >= array.Length)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }

            if (lengthArgument <= 0 || indexArgument + lengthArgument > array.Length)
            {
                throw new ArgumentsNotValidRangeException(
                    nameof(indexArgument),
                    nameof(lengthArgument));
            }
        }

        /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="fieldIndex">The index field that this argument is initializing.</param>
        /// <param name="fieldLength">The length field that this argument is initializing.</param>
        /// <param name="indexArgument">The numeric index argument to validate.</param>
        /// <param name="lengthArgument">The numeric length argument to validate.</param>
        /// <param name="array">The array for which we are validating the range.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayRange<T>(
            out int fieldIndex,
            out int fieldLength,
            in int indexArgument,
            in int lengthArgument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (indexArgument < 0 || indexArgument >= array.Length)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }

            if (lengthArgument <= 0 || indexArgument + lengthArgument > array.Length)
            {
                throw new ArgumentsNotValidRangeException(
                    nameof(indexArgument),
                    nameof(lengthArgument));
            }

            fieldIndex = indexArgument;
            fieldLength = lengthArgument;
        }

        /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="indexArgument">The numeric index argument to validate.</param>
        /// <param name="lengthArgument">The numeric length argument to validate.</param>
        /// <param name="array">The array for which we are validating the range.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayRange<T>(
            in long indexArgument,
            in long lengthArgument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (indexArgument < 0 || indexArgument >= array.LongLength)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }

            if (lengthArgument <= 0 || indexArgument + lengthArgument > array.LongLength)
            {
                throw new ArgumentsNotValidRangeException(
                    nameof(indexArgument),
                    nameof(lengthArgument));
            }
        }

        /// <summary>Called when a contract requires that a specific index and length, constituting a range, is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="fieldIndex">The index field that this argument is initializing.</param>
        /// <param name="fieldLength">The length field that this argument is initializing.</param>
        /// <param name="indexArgument">The numeric index argument to validate.</param>
        /// <param name="lengthArgument">The numeric length argument to validate.</param>
        /// <param name="array">The array for which we are validating the range.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayRange<T>(
            out long fieldIndex,
            out long fieldLength,
            in long indexArgument,
            in long lengthArgument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (indexArgument < 0 || indexArgument >= array.LongLength)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }

            if (lengthArgument <= 0 || indexArgument + lengthArgument > array.LongLength)
            {
                throw new ArgumentsNotValidRangeException(
                    nameof(indexArgument),
                    nameof(lengthArgument));
            }

            fieldIndex = indexArgument;
            fieldLength = lengthArgument;
        }

        /// <summary>Called when a contract requires that a specific length is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayLength<T>(
            in int argument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (argument <= 0 || argument > array.Length)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }
        }

        /// <summary>Called when a contract requires that a specific length is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayLength<T>(
            out int field,
            in int argument,
            T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (argument <= 0 || argument > array.Length)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }

            field = argument;
        }

        /// <summary>Called when a contract requires that a specific length is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayLength<T>(
            in long argument,
            in T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (argument <= 0 || argument > array.LongLength)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }
        }

        /// <summary>Called when a contract requires that a specific length is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidArrayLength<T>(
            out long field,
            in long argument,
            in T[] array,
            string argumentName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (argument <= 0 || argument > array.LongLength)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }

            field = argument;
        }

        #endregion

        #region True and false

        /// <summary>
        ///     Called when a contract requires that a condition is true.
        /// </summary>
        /// <param name="condition">
        ///     The condition that should be evaluated.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The validated argument.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     The condition is not being met.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [AssertionMethod]
        public static bool True(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            string argumentName)
        {
            if (!condition)
            {
                throw new ArgumentException(
                    Resources.AContractConditionIsNotBeingMet,
                    argumentName);
            }

            return condition;
        }

        /// <summary>
        ///     Called when a contract requires that a condition is true.
        /// </summary>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="condition">
        ///     The condition that should be evaluated.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     The condition is not being met.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [AssertionMethod]
        public static void True(
            out bool field,
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            string argumentName)
        {
            if (!condition)
            {
                throw new ArgumentException(
                    Resources.AContractConditionIsNotBeingMet,
                    argumentName);
            }

            field = condition;
        }

        /// <summary>
        ///     Called when a contract requires that a condition is false.
        /// </summary>
        /// <param name="condition">
        ///     The condition that should be evaluated.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The validated argument.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     The condition is not being met.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [AssertionMethod]
        public static bool False(
            [AssertionCondition(AssertionConditionType.IS_FALSE)]
            bool condition,
            string argumentName)
        {
            if (condition)
            {
                throw new ArgumentException(
                    Resources.AContractConditionIsNotBeingMet,
                    argumentName);
            }

            return condition;
        }

        /// <summary>
        ///     Called when a contract requires that a condition is false.
        /// </summary>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="condition">
        ///     The condition that should be evaluated.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     The condition is not being met.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [AssertionMethod]
        public static void False(
            out bool field,
            [AssertionCondition(AssertionConditionType.IS_FALSE)]
            bool condition,
            string argumentName)
        {
            if (condition)
            {
                throw new ArgumentException(
                    Resources.AContractConditionIsNotBeingMet,
                    argumentName);
            }

            field = condition;
        }
        #endregion

        #region Argument of type

        /// <summary>
        ///     Called when a contract requires that an argument is of a specific type.
        /// </summary>
        /// <typeparam name="T">
        ///     The type to check the argument for.
        /// </typeparam>
        /// <param name="argument">
        ///     The argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <returns>
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentInvalidTypeException">
        ///     The condition is not being met.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static T ArgumentOfType<T>(
            [NoEnumeration, AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object? argument,
            string argumentName)
        {
            if (argument is not T convertedValue)
            {
                throw new ArgumentInvalidTypeException(argumentName);
            }

            return convertedValue;
        }

        /// <summary>
        ///     Called when a contract requires that an argument is of a specific type.
        /// </summary>
        /// <typeparam name="T">
        ///     The type to check the argument for.
        /// </typeparam>
        /// <param name="field">The field that this argument is initializing.</param>
        /// <param name="argument">
        ///     The argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentInvalidTypeException">
        ///     The condition is not being met.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static void ArgumentOfType<T>(
            out T field,
            [NoEnumeration, AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object? argument,
            string argumentName)
        {
            if (argument is not T convertedValue)
            {
                throw new ArgumentInvalidTypeException(argumentName);
            }

            field = convertedValue;
        }
        #endregion

        #region Not disposed

        /// <summary>
        ///     Called when a contract requires that an argument is not disposed.
        /// </summary>
        /// <param name="reference">
        ///     The object reference to check for disposed.
        /// </param>
        /// <exception cref="ObjectDisposedException">If the reference object is disposed, this exception will be thrown.</exception>
        public static void NotDisposed(DisposableBase reference) =>
            NotNull(
                    reference,
                    nameof(reference))
                .ThrowIfCurrentObjectDisposed();

        /// <summary>
        ///     Called when a contract requires that an argument is not disposed.
        /// </summary>
        /// <param name="reference">
        ///     The object reference to check for disposed.
        /// </param>
        /// <exception cref="ObjectDisposedException">If the reference object is disposed, this exception will be thrown.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RequiresNotDisposed(this DisposableBase reference) =>
            NotNull(
                    reference,
                    nameof(reference))
                .ThrowIfCurrentObjectDisposed();

        #endregion

        #region Found by ID

        /// <summary>
        ///     Called when a contract requires that an item is found by its identifier.
        /// </summary>
        /// <param name="source">The items source.</param>
        /// <param name="id">The identifier to seek.</param>
        /// <param name="sourceName">The name of the source collection to seek in.</param>
        /// <param name="idName">The name of the identifier parameter.</param>
        /// <typeparam name="TItem">The type of keyed item in the collection.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <returns>The item that was found.</returns>
        /// <exception cref="ArgumentNullException">Either the source collection or the identifier are <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="IdCorrespondsToNoItemException">There is no usable item in the source collection that can be fetched by the supplied identifier.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("source:null => halt; id:null => halt")]
        [AssertionMethod]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0301:Closure Allocation Source",
            Justification = "LINQ used, unavoidable.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
            Justification = "LINQ used, unavoidable.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0302:Display class allocation to capture closure",
            Justification = "LINQ used, unavoidable.")]
        public static TItem ItemFoundById<TItem, TKey>(
            IEnumerable<TItem> source,
            TKey id,
            string sourceName,
            string idName)
            where TItem : IKeyedEntity<TKey>
        {
            if (source == null)
            {
                throw new ArgumentNullException(sourceName);
            }

            if (id == null)
            {
                throw new ArgumentNullException(idName);
            }

            var item = source.FirstOrDefault(p => EqualityComparer<TKey>.Default.Equals(p.Id, id));

            if (item is null || EqualityComparer<TItem>.Default.Equals(item, default!))
            {
                throw new IdCorrespondsToNoItemException(idName);
            }

            return item;
        }

#endregion
    }
}