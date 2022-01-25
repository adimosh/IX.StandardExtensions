// <copyright file="RequestForwardingEnvelope.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.IO;
using System.Linq;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using JetBrains.Annotations;
using RestSharp;

namespace IX.StandardExtensions.RestSharp.Envelopes;

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
    Method Method,
    string Resource,
    string? JsonBody,
    RequestForwardingEnvelope.RequestFileData[]? FileData,
    AdditionalHeaderEnvelope[]? AdditionalHeaders)
{
    /// <summary>
    /// Initializes a new instance of <see cref="RequestForwardingEnvelope"/> by converting from a <see cref="RestRequest"/>.
    /// </summary>
    /// <param name="request">The request to convert from.</param>
    /// <param name="jsonBodyConverter">The JSON body converter to use.</param>
    /// <returns></returns>
    public RequestForwardingEnvelope(
        RestRequest request,
        Func<object?, string> jsonBodyConverter)
        : this(
            request.Method,
            request.Resource,
            Requires.NotNull(jsonBodyConverter)(
                Requires.NotNull(request)
                    .Parameters.GetParameters(ParameterType.RequestBody)
                    .Cast<BodyParameter>()
                    .AsEnumerable()
                    .FirstOrDefault()
                    ?.Value),
            request.Files.Any()
                ? (request.Files.Select(
                    p =>
                    {
                        var contentStream = p.GetFile();
                        contentStream.Seek(
                            0,
                            SeekOrigin.Begin);
                        var buffer = new byte[contentStream.Length];
                        contentStream.Read(
                            buffer,
                            0,
                            Convert.ToInt32(contentStream.Length));

                        return new RequestFileData(
                            p.Name,
                            buffer,
                            p.FileName);
                    })).ToArray()
                : null,
            request.Parameters.GetParameters(ParameterType.HttpHeader)
                .Cast<HeaderParameter>()
                .Where(p => p.Name != null && p.Value != null)
                .Select(
                    p => new AdditionalHeaderEnvelope(
                        p.Name!,
                        p.Value!.ToString()))
                .ToArray())
    {
        if (this.AdditionalHeaders?.Length == 0)
        {
            this.AdditionalHeaders = null;
        }
    }

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
        string FileName)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestFileData"/> class by copying from a <see cref="FileParameter"/> instance.
        /// </summary>
        /// <param name="parameter"></param>
        public RequestFileData(FileParameter parameter)
            : this(Requires.NotNull(parameter).Name,
                parameter.GetFile.Chain(
                    contentStreamFunc =>
                    {
                        var contentStream = contentStreamFunc();
                        contentStream.Seek(
                            0,
                            SeekOrigin.Begin);
                        var buffer = new byte[contentStream.Length];
                        contentStream.Read(
                            buffer,
                            0,
                            Convert.ToInt32(contentStream.Length));

                        return buffer;
                    }),
                parameter.FileName)
        {
        }
    }
}