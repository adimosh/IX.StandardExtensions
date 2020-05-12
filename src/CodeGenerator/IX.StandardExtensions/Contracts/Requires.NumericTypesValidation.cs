// <copyright file="Requires.NumericTypesValidation.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Contracts
{
    /// <summary>
    ///     Methods for approximating the works of contract-oriented programming.
    /// </summary>
    public static partial class Requires
    {
        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="byte" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "byte is a primitive type that the compiler can handle.")]
        public static void Positive(
            in byte argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="byte" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "byte is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref byte field,
            in byte argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void Positive(
            in sbyte argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="sbyte" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            in sbyte argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref sbyte field,
            in sbyte argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="sbyte" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            ref sbyte field,
            in sbyte argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void Positive(
            in short argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="short" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            in short argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref short field,
            in short argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="short" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            ref short field,
            in short argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="ushort" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ushort is a primitive type that the compiler can handle.")]
        public static void Positive(
            in ushort argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="ushort" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ushort is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref ushort field,
            in ushort argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="char" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "char is a primitive type that the compiler can handle.")]
        public static void Positive(
            in char argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="char" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "char is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref char field,
            in char argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void Positive(
            in int argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="int" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            in int argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref int field,
            in int argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="int" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            ref int field,
            in int argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="uint" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "uint is a primitive type that the compiler can handle.")]
        public static void Positive(
            in uint argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="uint" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "uint is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref uint field,
            in uint argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void Positive(
            in long argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="long" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            in long argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref long field,
            in long argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="long" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            ref long field,
            in long argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="ulong" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ulong is a primitive type that the compiler can handle.")]
        public static void Positive(
            in ulong argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="ulong" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ulong is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref ulong field,
            in ulong argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void Positive(
            in float argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="float" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            in float argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref float field,
            in float argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="float" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            ref float field,
            in float argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void Positive(
            in double argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="double" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            in double argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref double field,
            in double argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="double" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            ref double field,
            in double argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void Positive(
            in decimal argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a contract requires that a numeric argument of type <see cref="decimal" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            in decimal argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
        ///     positive (greater than zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void Positive(
            ref decimal field,
            in decimal argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }

        /// <summary>
        ///     Called when a field initialization requires that a numeric argument of type <see cref="decimal" /> is
        ///     non-negative (greater than or equal to zero).
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void NonNegative(
            ref decimal field,
            in decimal argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }

            field = argument;
        }
    }
}