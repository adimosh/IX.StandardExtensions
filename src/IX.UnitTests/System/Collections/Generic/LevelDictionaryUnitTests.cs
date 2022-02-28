// <copyright file="LevelDictionaryUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.System.Collections.Generic;
using Xunit;

namespace IX.UnitTests.System.Collections.Generic;

/// <summary>
/// Unit tests for <see cref="LevelDictionary{TKey,TValue}"/>.
/// </summary>
public class LevelDictionaryUnitTests
{
    /// <summary>
    /// LevelDictionary enumerator-by-level test.
    /// </summary>
    [Fact(DisplayName = "LevelDictionary enumerator-by-level")]
    public void Test1()
    {
        // ARRANGE
        LevelDictionary<string, int> dict = new LevelDictionary<string, int>
        {
            { "key1", 1, 5 },
            { "key2", 7, 4 },
            { "key3", 2, 1 },
            { "key4", 8, 2 },
            { "key5", 5, 7 },
            { "key6", 3, 3 },
            { "key7", 6, 1 }
        };

        int[] orderForValues =
        {
            2,
            6,
            8,
            3,
            7,
            1,
            5
        };

        int index = 0;

        // ACT
        foreach (var val in dict.EnumerateValuesOnLevelKeys())
        {
            // ASSERT
            Assert.Equal(
                orderForValues[index++],
                val);
        }
    }
}