// <copyright file="BitArrayExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using IX.StandardExtensions.Contracts;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    /// Extensions for the <see cref="BitArray"/> class.
    /// </summary>
    public static class BitArrayExtensions
    {
        /// <summary>
        /// Adds one from the least significant byte, with carryover up to the most significant byte.
        /// </summary>
        /// <param name="source">The source bit array.</param>
        public static void AddOne(this BitArray source)
        {
            var ba = Requires.NotNull(
                source,
                nameof(source));

            for (int i = 0; i < ba.Length; i++)
            {
                if (ba[i])
                {
                    ba[i] = false;
                }
                else
                {
                    break;
                }
            }
        }
    }
}