// <copyright file="SerializationUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Runtime.Serialization;
using System.Text;
using IX.DataGeneration;
using IX.StandardExtensions.Extensions;
using IX.System.Collections.Generic;
using Xunit;

namespace IX.UnitTests.Abstractions.Collections;

/// <summary>
/// Tests for serialization.
/// </summary>
public class SerializationUnitTests
{
    /// <summary>
    /// Tests the push down stack serialization.
    /// </summary>
    [Fact(DisplayName = "Serialization tests for PushDownStack")]
    public void TestPushDownStackSerialization()
    {
        // ARRANGE
        // =======
        var item1 = DataGenerator.RandomNonNegativeInteger();
        var item2 = DataGenerator.RandomNonNegativeInteger();
        var item3 = DataGenerator.RandomNonNegativeInteger();
        var item4 = DataGenerator.RandomNonNegativeInteger();
        var item5 = DataGenerator.RandomNonNegativeInteger();

        using var l1 = new PushDownStack<int>(4);

        l1.Push(item1);
        l1.Push(item2);
        l1.Push(item3);
        l1.Push(item4);
        l1.Push(item5);

        // The serializer
        var dcs = new DataContractSerializer(typeof(PushDownStack<int>));

        // The deserialization variable
        PushDownStack<int> l2;

        // The serialization content
        string content;

        // ACT
        // ===
        using (var ms = new MemoryStream())
        {
            dcs.WriteObject(ms, l1);

            _ = ms.Seek(0, SeekOrigin.Begin);

            using (var textReader = new StreamReader(ms, Encoding.UTF8, false, 32768, true))
            {
                content = textReader.ReadToEnd();
            }

            _ = ms.Seek(0, SeekOrigin.Begin);

            l2 = dcs.ReadObject(ms) as PushDownStack<int>;
        }

        try
        {
            // ASSERT
            // ======
            const string abstractionsNs = "http://ns.ixiancorp.com/IX/IX.Abstractions.Collections";
            const string threadingNs = "http://ns.ixiancorp.com/IX/IX.StandardExtensions.Threading";
            string expectedSerializedString = @"<PushDownStackOfint xmlns=""" +
                                              abstractionsNs +
                                              @""" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><lockerTimeout xmlns=""" +
                                              threadingNs +
                                              @""">PT0.1S</lockerTimeout><Items xmlns:a=""http://schemas.microsoft.com/2003/10/Serialization/Arrays""><a:int>" +
                                              item2 +
                                              @"</a:int><a:int>" +
                                              item3 +
                                              @"</a:int><a:int>" +
                                              item4 +
                                              @"</a:int><a:int>" +
                                              item5 +
                                              @"</a:int></Items><Limit>4</Limit></PushDownStackOfint>";

            // Serialization content is OK
            Assert.False(string.IsNullOrWhiteSpace(content));
            Assert.Equal(
                expectedSerializedString,
                content);

            // Deserialized object is OK
            Assert.NotNull(l2);
            Assert.Equal(l1.Count, l2.Count);
            Assert.Equal(l1.Limit, l2.Limit);
            Assert.True(l1.SequenceEquals(l2));
        }
        finally
        {
            l2?.Dispose();
        }
    }
}