// <copyright file="Requires.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using IX.StandardExtensions.ComponentModel;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Contracts
{
    /// <summary>
    ///     Methods for approximating the works of contract-oriented programming.
    /// </summary>
    [PublicAPI]
    public static partial class Requires
    {
        #region Not null, empty or whitespace

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
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     The argument is <see langword="null" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static T NotNull<T>(
            [CanBeNull] [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T? argument,
            [NotNull] string argumentName)
            where T : class
        {
            if (argument == null)
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
            ref T field,
            [CanBeNull] [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T? argument,
            [NotNull] string argumentName)
            where T : class => field = argument ?? throw new ArgumentNullException(argumentName);

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
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentNullOrEmptyException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static string NotNullOrEmpty(
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            [NotNull] string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullOrEmptyException(argumentName);
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
        /// <exception cref="ArgumentNullOrEmptyException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static void NotNullOrEmpty(
            ref string field,
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            [NotNull] string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullOrEmptyException(argumentName);
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
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentNullOrWhitespaceException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static string NotNullOrWhiteSpace(
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            [NotNull] string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullOrWhitespaceException(argumentName);
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
        /// <exception cref="ArgumentNullOrWhitespaceException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static void NotNullOrWhiteSpace(
            ref string field,
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            [NotNull] string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullOrWhitespaceException(argumentName);
            }

            field = argument!;
        }

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
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentNullOrEmptyCollectionException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static TCollection NotEmpty<TCollection, T>(
            [CanBeNull] [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            TCollection? argument,
            [NotNull] string argumentName)
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
            ref TCollection field,
            [CanBeNull] [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            TCollection? argument,
            [NotNull] string argumentName)
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
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentNullOrEmptyBinaryException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static T[] NotEmpty<T>(
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? argument,
            [NotNull] string argumentName)
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
            ref T[] field,
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? argument,
            [NotNull] string argumentName)
        {
            if ((argument?.Length ?? 0) == 0)
            {
                throw new ArgumentNullOrEmptyArrayException(argumentName);
            }

            field = argument!;
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
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan Positive(
            in TimeSpan argument,
            [NotNull] string argumentName)
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
            ref TimeSpan field,
            in TimeSpan argument,
            [NotNull] string argumentName)
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
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan NonNegative(
            in TimeSpan argument,
            [NotNull] string argumentName)
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
            ref TimeSpan field,
            in TimeSpan argument,
            [NotNull] string argumentName)
        {
            if (argument < TimeSpan.Zero)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }
        #endregion

        #region Array index and range

        /// <summary>Called when a contract requires that aspecific index is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the index.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayIndex<T>(
            in int argument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
            if (argument < 0 || argument >= array.Length)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }
        }

        /// <summary>Called when a contract requires that aspecific index is valid for an array.</summary>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayIndex<T>(
            ref int field,
            in int argument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
            if (argument < 0 || argument >= array.Length)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }

            field = argument;
        }

        /// <summary>Called when a contract requires that aspecific index is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the index.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayIndex<T>(
            in long argument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
            if (argument < 0 || argument >= array.LongLength)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }
        }

        /// <summary>Called when a contract requires that aspecific index is valid for an array.</summary>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayIndex<T>(
            ref long field,
            in long argument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
            if (argument < 0 || argument >= array.LongLength)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }

            field = argument;
        }

        /// <summary>Called when a contract requires that aspecific index and length, constituting a range, is valid for an array.</summary>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayRange<T>(
            in int indexArgument,
            in int lengthArgument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
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

        /// <summary>Called when a contract requires that aspecific index and length, constituting a range, is valid for an array.</summary>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayRange<T>(
            ref int fieldIndex,
            ref int fieldLength,
            in int indexArgument,
            in int lengthArgument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
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

        /// <summary>Called when a contract requires that aspecific index and length, constituting a range, is valid for an array.</summary>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayRange<T>(
            in long indexArgument,
            in long lengthArgument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
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

        /// <summary>Called when a contract requires that aspecific index and length, constituting a range, is valid for an array.</summary>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayRange<T>(
            ref long fieldIndex,
            ref long fieldLength,
            in long indexArgument,
            in long lengthArgument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
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

        /// <summary>Called when a contract requires that aspecific length is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayLength<T>(
            in int argument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
            if (argument <= 0 || argument > array.Length)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }
        }

        /// <summary>Called when a contract requires that aspecific length is valid for an array.</summary>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayLength<T>(
            ref int field,
            in int argument,
            [NotNull] T[] array,
            [NotNull] string argumentName)
        {
            if (argument <= 0 || argument > array.Length)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }

            field = argument;
        }

        /// <summary>Called when a contract requires that aspecific length is valid for an array.</summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayLength<T>(
            in long argument,
            in T[] array,
            [NotNull] string argumentName)
        {
            if (argument <= 0 || argument > array.LongLength)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }
        }

        /// <summary>Called when a contract requires that aspecific length is valid for an array.</summary>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void ValidArrayLength<T>(
            ref long field,
            in long argument,
            in T[] array,
            [NotNull] string argumentName)
        {
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
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     The condition is not being met.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static bool True(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            [NotNull] string argumentName)
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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void True(
            ref bool field,
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            [NotNull] string argumentName)
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
        ///     The converted argument.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     The condition is not being met.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [AssertionMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static bool False(
            [AssertionCondition(AssertionConditionType.IS_FALSE)]
            bool condition,
            [NotNull] string argumentName)
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        public static void False(
            ref bool field,
            [AssertionCondition(AssertionConditionType.IS_FALSE)]
            bool condition,
            [NotNull] string argumentName)
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
            [CanBeNull, NoEnumeration, AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object argument,
            [NotNull] string argumentName)
        {
            if (!(argument is T convertedValue))
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
            ref T field,
            [CanBeNull, NoEnumeration, AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object argument,
            [NotNull] string argumentName)
        {
            if (!(argument is T convertedValue))
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RequiresNotDisposed([NotNull] this DisposableBase reference) =>
            reference.ThrowIfCurrentObjectDisposed();
        #endregion
    }
}