// <copyright file="MulticastDictionaryUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using IX.StandardExtensions.Efficiency;
using Xunit;

namespace IX.UnitTests.StandardExtensions.Efficiency
{
    /// <summary>
    /// Tests for multicast dictionary.
    /// </summary>
    public class MulticastDictionaryUnitTests
    {
        /// <summary>
        /// Tests the multicast dictionary main function.
        /// </summary>
        [Fact]
        public void Test1()
        {
            // ARRANGE
            MulticastDictionary<int, int> d = new MulticastDictionary<int, int>();

            d.Add(0, 1);
            d.Add(0, 2);
            d.Add(0, 3);
            d.Add(1, 4);
            d.Add(1, 5);
            d.Add(1, 6);

            bool success;
            int attempts = 0;

            // ACT
            try
            {
                success = d.TryAct(
                    0,
                    (
                        k,
                        v) =>
                    {
                        if (k != 0)
                        {
                            throw new InvalidOperationException();
                        }

                        attempts++;

                        return v == 3;
                    });
            }
            catch (InvalidOperationException)
            {
                success = false;
            }

            // ASSERT
            Assert.True(success);
            Assert.Equal(3, attempts);
        }
    }
}