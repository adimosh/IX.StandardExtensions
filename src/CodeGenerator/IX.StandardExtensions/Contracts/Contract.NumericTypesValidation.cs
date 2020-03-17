// <copyright file="Contract.NumericTypesValidation.cs" company="Adrian Mos">
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
    public static partial class Contract
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
        public static void RequiresPositive(
            in byte argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="byte" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "byte is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresPositive(
            in sbyte argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="sbyte" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresNonNegative(
            in sbyte argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="sbyte" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "sbyte is a primitive type that the compiler can handle.")]
        public static void RequiresNonNegativePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresNonNegative(
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
        public static void RequiresPositive(
            in short argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="short" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresNonNegative(
            in short argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="short" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "short is a primitive type that the compiler can handle.")]
        public static void RequiresNonNegativePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresNonNegative(
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
        public static void RequiresPositive(
            in ushort argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="ushort" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ushort is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresPositive(
            in char argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="char" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "char is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresPositive(
            in int argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="int" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresNonNegative(
            in int argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="int" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "int is a primitive type that the compiler can handle.")]
        public static void RequiresNonNegativePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresNonNegative(
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
        public static void RequiresPositive(
            in uint argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="uint" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "uint is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresPositive(
            in long argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="long" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresNonNegative(
            in long argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="long" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "long is a primitive type that the compiler can handle.")]
        public static void RequiresNonNegativePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresNonNegative(
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
        public static void RequiresPositive(
            in ulong argument,
            [NotNull] string argumentName)
        {
            if (argument == 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="ulong" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "ulong is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresPositive(
            in float argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="float" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresNonNegative(
            in float argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="float" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "float is a primitive type that the compiler can handle.")]
        public static void RequiresNonNegativePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresNonNegative(
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
        public static void RequiresPositive(
            in double argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="double" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresNonNegative(
            in double argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="double" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "double is a primitive type that the compiler can handle.")]
        public static void RequiresNonNegativePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresNonNegative(
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
        public static void RequiresPositive(
            in decimal argument,
            [NotNull] string argumentName)
        {
            if (argument <= 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="decimal" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void RequiresPositivePrivate(
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
        public static void RequiresNonNegative(
            in decimal argument,
            [NotNull] string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentNotPositiveIntegerException(argumentName);
            }
        }

        /// <summary>
        ///     Called when a non-public contract requires that a numeric argument of type <see cref="decimal" /> is
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
        /// <remarks>
        ///     <para>Use this method for non-public contracts. The conditional symbol for non-public contracts will disable calls to it when not defined.</para>
        ///     <para>
        ///         You can use this method in your non-public code to further enforce contracts and do static analysis of your own code. You can then disable
        ///         it in release builds to improve performance.
        ///     </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Conditional(Constants.ContractsNonPublicSymbol)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "EPS02:Non-readonly struct used as in-parameter",
            Justification = "decimal is a primitive type that the compiler can handle.")]
        public static void RequiresNonNegativePrivate(
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
        public static void RequiresPositive(
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
        public static void RequiresNonNegative(
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