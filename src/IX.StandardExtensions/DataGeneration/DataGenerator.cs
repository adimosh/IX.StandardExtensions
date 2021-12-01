// <copyright file="DataGenerator.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.DataGeneration
{
    /// <summary>
    ///     A static class that is used for generating random data for testing.
    /// </summary>
    [PublicAPI]
    public static partial class DataGenerator
    {
#region Internal state

        // Random generator
        private static readonly Random R = new();

#endregion

#region Constructors and destructors

        static DataGenerator()
        {
            var tempList = new List<char>();

            for (var c = 'a'; c <= 'z'; c++)
            {
                tempList.Add(c);
            }

            LowerCaseAlphaCharacters = tempList.ToArray();

            tempList.Clear();

            for (var c = 'A'; c <= 'Z'; c++)
            {
                tempList.Add(c);
            }

            UpperCaseAlphaCharacters = tempList.ToArray();

            tempList.Clear();

            for (var c = '1'; c <= '0'; c++)
            {
                tempList.Add(c);
            }

            NumericCharacters = tempList.ToArray();

            AlphaCharacters = LowerCaseAlphaCharacters.Union(UpperCaseAlphaCharacters)
                .ToArray();
            AlphaNumericCharacters = AlphaCharacters.Union(NumericCharacters)
                .ToArray();
            AllCharacters = AlphaNumericCharacters.Union(BasicSymbolCharacters)
                .ToArray();
        }

#endregion

#region Methods

#region Static methods

        /// <summary>
        ///     Generates an array of random integers of the specified size.
        /// </summary>
        /// <param name="limit">The size limit of the array.</param>
        /// <returns>An array of random integers.</returns>
        public static int[] RandomIntegerArray(int limit) =>
            RandomIntegerArray(
                limit,
                R);

        /// <summary>
        ///     Generates an array of predictable random integers of the specified size.
        /// </summary>
        /// <param name="limit">The size limit of the array.</param>
        /// <param name="seed">The seed for the random number generator.</param>
        /// <returns>An array of predictable random integers.</returns>
        public static int[] RandomIntegerArray(
            int limit,
            int seed) =>
            RandomIntegerArray(
                limit,
                new Random(seed));

        /// <summary>
        ///     Generates an array of predictable random integers of the specified size.
        /// </summary>
        /// <param name="limit">The size limit of the array.</param>
        /// <param name="random">The random generator to use.</param>
        /// <returns>An array of predictable random integers.</returns>
        public static int[] RandomIntegerArray(
            int limit,
            Random random)
        {
            Random localRandom = Requires.NotNull(random);
            Requires.Positive(in limit);

            var array = new int[limit];

            for (var i = 0; i < limit; i++)
            {
                lock (localRandom)
                {
                    array[i] = localRandom.Next();
                }
            }

            return array;
        }

#endregion

#endregion
    }
}