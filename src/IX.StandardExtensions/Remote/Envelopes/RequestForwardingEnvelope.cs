// <copyright file="RequestForwardingEnvelope.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Remote.Envelopes;

/// <summary>
/// An envelope containing supported data to forward to RestSharp.
/// </summary>
/// <param name="Method">The HTTP method to invoke.</param>
/// <param name="Resource">The resource URL.</param>
/// <param name="JsonBody">The body, as an optional JSON string.</param>
/// <param name="FileData">The file data, as an optional parameter.</param>
/// <param name="AdditionalHeaders">The additional headers to send in the request.</param>
[PublicAPI]
public record RequestForwardingEnvelope(
    HttpMethod Method,
    string Resource,
    string? JsonBody = null,
    RequestForwardingEnvelope.RequestFileData[]? FileData = null,
    AdditionalHeaderEnvelope[]? AdditionalHeaders = null)
{
    /// <summary>
    /// File data that is included in the request for RestSharp.
    /// </summary>
    /// <param name="Name">The name of the file.</param>
    /// <param name="Data">The data contained in the file.</param>
    /// <param name="FileName">The file name for the provided file.</param>
    [PublicAPI]
    public record RequestFileData(
        string Name,
        byte[] Data,
        string FileName);
}