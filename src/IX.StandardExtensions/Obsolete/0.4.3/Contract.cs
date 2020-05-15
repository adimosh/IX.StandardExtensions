// <copyright file="Contract.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using IX.StandardExtensions.ComponentModel;
using JetBrains.Annotations;
using Req = IX.StandardExtensions.Contracts.Requires;

// ReSharper disable once CheckNamespace
namespace IX.StandardExtensions.Contracts
{
#pragma warning disable CS0618 // Type or member is obsolete
    /// <summary>
    ///     Methods for approximating the works of contract-oriented programming.
    /// </summary>
    [PublicAPI]
    public static partial class Contract
    {
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
        /// <exception cref="ArgumentNullException">
        ///     The argument is <see langword="null" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNull<T>(
            [CanBeNull] [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            in T? argument,
            [NotNull] string argumentName)
            where T : class =>
            Req.NotNull(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that an argument is not null. Use this method for non-public contracts.
        /// </summary>
        /// <typeparam name="T">The type of argument to validate.</typeparam>
        /// <param name="argument">
        ///     The argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The argument is <see langword="null" />.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNullPrivate<T>(
            [CanBeNull] [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            in T? argument,
            [NotNull] string argumentName)
            where T : class =>
            Req.NotNull(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a string argument is not null or empty.
        /// </summary>
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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNullOrEmpty(
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            [NotNull] string argumentName) =>
            Req.NotNullOrEmpty(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a string argument is not null or empty. Use this method for non-public
        ///     contracts.
        /// </summary>
        /// <param name="argument">
        ///     The string argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullOrEmptyException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNullOrEmptyPrivate(
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            [NotNull] string argumentName) =>
            Req.NotNullOrEmpty(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a string argument is not null or empty.
        /// </summary>
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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNullOrWhitespace(
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            [NotNull] string argumentName) =>
            Req.NotNullOrWhiteSpace(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a string argument is not null or empty. Use this method for non-public
        ///     contracts.
        /// </summary>
        /// <param name="argument">
        ///     The string argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullOrWhitespaceException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNullOrWhitespacePrivate(
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string? argument,
            [NotNull] string argumentName) =>
            Req.NotNullOrWhiteSpace(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a collection argument is not null or empty.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the collection.
        /// </typeparam>
        /// <param name="argument">
        ///     The collection argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullOrEmptyCollectionException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNullOrEmpty<T>(
            [CanBeNull] [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            ICollection<T>? argument,
            [NotNull] string argumentName)
        {
            if ((argument?.Count ?? 0) == 0)
            {
                throw new ArgumentNullOrEmptyCollectionException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a collection argument is not null or empty. Use this method for non-public
        ///     contracts.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the collection.
        /// </typeparam>
        /// <param name="argument">
        ///     The collection argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullOrEmptyCollectionException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNullOrEmptyPrivate<T>(
            [CanBeNull] [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            ICollection<T>? argument,
            [NotNull] string argumentName)
        {
            if ((argument?.Count ?? 0) == 0)
            {
                throw new ArgumentNullOrEmptyCollectionException(argumentName);
            }
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
        /// <exception cref="ArgumentNullOrEmptyBinaryException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNullOrEmpty<T>(
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? argument,
            [NotNull] string argumentName) =>
            Req.NotEmpty(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that an array argument is not null or empty. Use this method for non-public
        ///     contracts.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the array.
        /// </typeparam>
        /// <param name="argument">
        ///     The byte array argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNullOrEmptyBinaryException">
        ///     The argument is <see langword="null" /> or empty.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotNullOrEmptyPrivate<T>(
            [CanBeNull] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T[]? argument,
            [NotNull] string argumentName) =>
            Req.NotEmpty(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a numeric argument is positive.
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresPositive(
            in TimeSpan argument,
            [NotNull] string argumentName) =>
            Req.Positive(
                in argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a numeric argument is positive. Use this method for non-public contracts.
        /// </summary>
        /// <param name="argument">
        ///     The byte array argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresPositivePrivate(
            in TimeSpan argument,
            [NotNull] string argumentName) =>
            Req.Positive(
                in argument,
                argumentName);

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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayIndex<T>(
            in int argument,
            in T[] array,
            [NotNull] string argumentName)
        {
            if (argument < 0 || argument >= array.Length)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that aspecific index is valid for an array. Use this method for non-public
        ///     contracts.
        /// </summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the index.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayIndexPrivate<T>(
            in int argument,
            in T[] array,
            [NotNull] string argumentName)
        {
            if (argument < 0 || argument >= array.Length)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }
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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayIndex<T>(
            in long argument,
            in T[] array,
            [NotNull] string argumentName)
        {
            if (argument < 0 || argument >= array.LongLength)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that aspecific index is valid for an array. Use this method for non-public
        ///     contracts.
        /// </summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the index.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayIndexPrivate<T>(
            in long argument,
            in T[] array,
            [NotNull] string argumentName)
        {
            if (argument < 0 || argument >= array.LongLength)
            {
                throw new ArgumentNotValidIndexException(argumentName);
            }
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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayRange<T>(
            in int indexArgument,
            in int lengthArgument,
            in T[] array,
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

        /// <summary>
        ///     Called when a contract requires that aspecific index and length, constituting a range, is valid for an array.
        ///     Use this method for non-public contracts.
        /// </summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="indexArgument">The numeric index argument to validate.</param>
        /// <param name="lengthArgument">The numeric length argument to validate.</param>
        /// <param name="array">The array for which we are validating the range.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayRangePrivate<T>(
            in int indexArgument,
            in int lengthArgument,
            in T[] array,
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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayRange<T>(
            in long indexArgument,
            in long lengthArgument,
            in T[] array,
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

        /// <summary>
        ///     Called when a contract requires that aspecific index and length, constituting a range, is valid for an array.
        ///     Use this method for non-public contracts.
        /// </summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="indexArgument">The numeric index argument to validate.</param>
        /// <param name="lengthArgument">The numeric length argument to validate.</param>
        /// <param name="array">The array for which we are validating the range.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayRangePrivate<T>(
            in long indexArgument,
            in long lengthArgument,
            in T[] array,
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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayLength<T>(
            in int argument,
            in T[] array,
            [NotNull] string argumentName)
        {
            if (argument <= 0 || argument > array.Length)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that aspecific length is valid for an array. Use this method for non-public
        ///     contracts.
        /// </summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayLengthPrivate<T>(
            in int argument,
            in T[] array,
            [NotNull] string argumentName)
        {
            if (argument <= 0 || argument > array.Length)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }
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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayLength<T>(
            in long argument,
            in T[] array,
            [NotNull] string argumentName)
        {
            if (argument <= 0 || argument > array.LongLength)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that aspecific length is valid for an array. Use this method for non-public
        ///     contracts.
        /// </summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="argument">The numeric argument to validate.</param>
        /// <param name="array">The array for which we are validating the length.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is either negative or exceeds the bounds of the
        ///     array.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "This is a primitive type that the compiler can handle.")]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresValidArrayLengthPrivate<T>(
            in long argument,
            in T[] array,
            [NotNull] string argumentName)
        {
            if (argument <= 0 || argument > array.LongLength)
            {
                throw new ArgumentNotValidLengthException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument is not negative.
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNonNegative(
            in TimeSpan argument,
            [NotNull] string argumentName) =>
            Req.NonNegative(
                in argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a numeric argument is not negative. Use this method for non-public contracts.
        /// </summary>
        /// <param name="argument">
        ///     The byte array argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is 0.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNonNegativePrivate(
            in TimeSpan argument,
            [NotNull] string argumentName) =>
            Req.NonNegative(
                in argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a numeric argument is not negative.
        /// </summary>
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
        public static void Requires(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            [NotNull] string argumentName) =>
            Req.True(
                condition,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that a numeric argument is not negative. Use this method for non-public contracts.
        /// </summary>
        /// <param name="condition">
        ///     The condition that should be evaluated.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     The condition is not being met.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [AssertionMethod]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresPrivate(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            [NotNull] string argumentName) =>
            Req.True(
                condition,
                argumentName);

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
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static T RequiresArgumentOfType<T>(
            [CanBeNull, NoEnumeration, AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object argument,
            [NotNull] string argumentName) =>
            Req.ArgumentOfType<T>(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that an argument is of a specific type. Use this method for non-public contracts.
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
        /// <exception cref="ArgumentInvalidTypeException">
        ///     The condition is not being met.
        /// </exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresArgumentOfTypePrivate<T>(
            [CanBeNull] object argument,
            [NotNull] string argumentName) =>
            Req.ArgumentOfType<T>(
                argument,
                argumentName);

        /// <summary>
        ///     Called when a contract requires that an argument is not disposed.
        /// </summary>
        /// <param name="reference">
        ///     The object reference to check for disposed.
        /// </param>
        /// <exception cref="ObjectDisposedException">If the reference object is disposed, this exception will be thrown.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotDisposed([NotNull] DisposableBase reference) =>
            reference.ThrowIfCurrentObjectDisposed();

        /// <summary>
        ///     Called when a contract requires that an argument is not disposed. Use this method for non-public contracts.
        /// </summary>
        /// <param name="reference">
        ///     The object reference to check for disposed.
        /// </param>
        /// <exception cref="ObjectDisposedException">If the reference object is disposed, this exception will be thrown.</exception>
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Obsolete("Please use the methods provided by the Requires class instead of this.")]
        public static void RequiresNotDisposedPrivate([NotNull] DisposableBase reference) =>
            reference.ThrowIfCurrentObjectDisposed();
    }
#pragma warning restore CS0618 // Type or member is obsolete
}