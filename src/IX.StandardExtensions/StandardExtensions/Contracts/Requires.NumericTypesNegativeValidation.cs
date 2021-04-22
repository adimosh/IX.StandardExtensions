// <copyright file="Requires.NumericTypesNegativeValidation.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Runtime.CompilerServices;

namespace IX.StandardExtensions.Contracts
{
    /// <summary>
    ///     Methods for approximating the works of contract-oriented programming.
    /// </summary>
    public static partial class Requires
    {
        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="byte" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "byte is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in byte argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="byte" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "byte is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out byte field,
            in byte argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void Negative(
            in sbyte argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in sbyte argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void Negative(
            out sbyte field,
            in sbyte argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out sbyte field,
            in sbyte argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void Negative(
            in short argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in short argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void Negative(
            out short field,
            in short argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out short field,
            in short argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="ushort" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ushort is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in ushort argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="ushort" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ushort is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out ushort field,
            in ushort argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="char" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "char is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in char argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="char" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "char is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out char field,
            in char argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void Negative(
            in int argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in int argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void Negative(
            out int field,
            in int argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out int field,
            in int argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="uint" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "uint is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in uint argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="uint" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "uint is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out uint field,
            in uint argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void Negative(
            in long argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in long argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void Negative(
            out long field,
            in long argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out long field,
            in long argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="ulong" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ulong is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in ulong argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="ulong" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveIntegerException">
        ///     The argument is equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ulong is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out ulong field,
            in ulong argument,
            string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotNegativeIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void Negative(
            in float argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in float argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void Negative(
            out float field,
            in float argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out float field,
            in float argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void Negative(
            in double argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in double argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void Negative(
            out double field,
            in double argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out double field,
            in double argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void Negative(
            in decimal argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            in decimal argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
        ///     negative (less than zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than or equal to 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void Negative(
            out decimal field,
            in decimal argument,
            string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
        ///     non-positive (less than or equal to zero).
        /// </summary>
        /// <param name="field">
        ///     The field that the argument is initializing.
        /// </param>
        /// <param name="argument">
        ///     The numeric argument.
        /// </param>
        /// <param name="argumentName">
        ///     The argument name.
        /// </param>
        /// <exception cref="ArgumentNotPositiveException">
        ///     The argument is less than 0.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void NonPositive(
            out decimal field,
            in decimal argument,
            string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotNegativeException(argumentName);
            }

            field = argument;
        }
    }
}