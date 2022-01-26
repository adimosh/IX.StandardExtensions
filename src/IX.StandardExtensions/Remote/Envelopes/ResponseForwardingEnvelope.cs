// <copyright file="ResponseForwardingEnvelope.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Net;
using JetBrains.Annotations;

namespace IX.Remote.Envelopes;

/// <summary>
/// A response envelope for received responses from RestSharp requests.
/// </summary>
/// <param name="RequestSuccessful"><c>true</c> if the request completed, <c>false</c> otherwise.</param>
/// <param name="StatusCode">The status code, if a response was received.</param>
/// <param name="JsonBody">The JSON body, if one was received.</param>
/// <param name="RawContent">The raw body content, should there be one.</param>
/// <param name="AdditionalHeaders">Additional response headers.</param>
[PublicAPI]
public record ResponseForwardingEnvelope(
    bool RequestSuccessful,
    HttpStatusCode? StatusCode = null,
    string? JsonBody = null,
    byte[]? RawContent = null,
    AdditionalHeaderEnvelope[]? AdditionalHeaders = null);