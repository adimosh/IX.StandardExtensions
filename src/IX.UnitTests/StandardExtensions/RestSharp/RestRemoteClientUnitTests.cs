// <copyright file="RestRemoteClientUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !NET46
using System.Net.Http;
using System.Threading.Tasks;
using IX.Remote.Envelopes;
using IX.StandardExtensions.RestSharp;
using Xunit;

namespace IX.UnitTests.StandardExtensions.RestSharp
{
    public class RestRemoteClientUnitTests
    {
        [Fact]
        public async Task TestGet()
        {
            // ARRANGE
            RestRemoteClient client = new RestRemoteClient("https://adrianmos.eu");
            RequestForwardingEnvelope requestEnvelope = new RequestForwardingEnvelope(
                HttpMethod.Get,
                "/");

            // ACT
            var responseEnvelope = await client.ExecuteForwardedRequest(
                requestEnvelope);

            // ASSERT
            Assert.True(responseEnvelope.RequestSuccessful);
        }
    }
}
#endif