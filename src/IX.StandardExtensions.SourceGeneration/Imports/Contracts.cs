// <copyright file="Contracts.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
// ReSharper disable CheckNamespace

#nullable enable
namespace IX.StandardExtensions.Contracts
{
    internal static class Requires
    {
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
                throw new ArgumentNullException(argumentName);
            }

            return argument!;
        }

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
                throw new ArgumentNullException(argumentName);
            }

            return argument!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [ContractAnnotation("argument:null => halt")]
        [AssertionMethod]
        public static T NotNull<T>(
            [CanBeNull] [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T? argument,
            [NotNull] string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }
    }
}