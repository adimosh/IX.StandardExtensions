// <copyright file="ConversionExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using IX.Remote.Envelopes;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using JetBrains.Annotations;
using RestSharp;
using RestSharp.Serializers;

namespace IX.StandardExtensions.RestSharp;

/// <summary>
/// Conversion extensions.
/// </summary>
[PublicAPI]
public static class ConversionExtensions
{
    /// <summary>
    /// Performs conversion between a <see cref="HeaderParameter"/> instance and an <see cref="AdditionalHeaderEnvelope"/> instance.
    /// </summary>
    /// <param name="source">The header parameter instance to convert from.</param>
    /// <returns>A converted instance of <see cref="AdditionalHeaderEnvelope"/>.</returns>
    public static AdditionalHeaderEnvelope ToEnvelope(this HeaderParameter source) =>
        new(
            source.Name ?? string.Empty,
            source.Value?.ToString() ?? string.Empty);

    /// <summary>
    /// Creates an array of <see cref="AdditionalHeaderEnvelope"/> instances from a collection of <see cref="HeaderParameter"/> instances.
    /// </summary>
    /// <param name="source">The collection of file parameters.</param>
    /// <returns>An array of file data instances, or <c>null</c> (<c>Nothing</c> in Visual Basic).</returns>
    /// <remarks>
    /// <para>This method will return <c>null</c> (<c>Nothing</c> in Visual Basic) in case the source is itself <c>null</c> (<c>Nothing</c> in Visual Basic), or empty.</para>
    /// </remarks>
    public static AdditionalHeaderEnvelope[]? ToEnvelopes(this ParametersCollection? source) =>
        source == null
            ? null
            : (source.GetParameters(ParameterType.HttpHeader)
                .Any()
                ? source.GetParameters(ParameterType.HttpHeader)
                    .Cast<HeaderParameter>()
                    .Where(p => p.Name != null || p.Value != null)
                    .Select(p => p.ToEnvelope())
                    .ToArray()
                : null);

    /// <summary>
    /// Creates an array of <see cref="AdditionalHeaderEnvelope"/> instances from a collection of <see cref="HeaderParameter"/> instances.
    /// </summary>
    /// <param name="source">The collection of file parameters.</param>
    /// <returns>An array of file data instances, or <c>null</c> (<c>Nothing</c> in Visual Basic).</returns>
    /// <remarks>
    /// <para>This method will return <c>null</c> (<c>Nothing</c> in Visual Basic) in case the source is itself <c>null</c> (<c>Nothing</c> in Visual Basic), or empty.</para>
    /// </remarks>
    public static AdditionalHeaderEnvelope[]? ToEnvelopes(this IReadOnlyCollection<HeaderParameter>? source) =>
        source == null
            ? null
            : (source.Any()
                ? source.Where(p => p.Name != null || p.Value != null)
                    .Select(p => p.ToEnvelope())
                    .ToArray()
                : null);

    /// <summary>
    /// Performs conversion between a <see cref="FileParameter"/> instance and a <see cref="RequestForwardingEnvelope.RequestFileData"/> instance.
    /// </summary>
    /// <param name="source">The header parameter instance to convert from.</param>
    /// <returns>A converted instance of <see cref="RequestForwardingEnvelope.RequestFileData"/>.</returns>
    public static RequestForwardingEnvelope.RequestFileData ToEnvelope(this FileParameter source) =>
        new(
            Requires.NotNull(source)
                .Name,
            source.GetFile.Chain(
                contentStreamFunc => contentStreamFunc().ReadAllBytes()),
            source.FileName);

    /// <summary>
    /// Creates an array of <see cref="RequestForwardingEnvelope.RequestFileData"/> instances from a collection of <see cref="FileParameter"/> instances.
    /// </summary>
    /// <param name="source">The collection of file parameters.</param>
    /// <returns>An array of file data instances, or <c>null</c> (<c>Nothing</c> in Visual Basic).</returns>
    /// <remarks>
    /// <para>This method will return <c>null</c> (<c>Nothing</c> in Visual Basic) in case the source is itself <c>null</c> (<c>Nothing</c> in Visual Basic), or empty.</para>
    /// </remarks>
    public static RequestForwardingEnvelope.RequestFileData[]? ToEnvelopes(this IReadOnlyCollection<FileParameter>? source) =>
        source == null ? null : (source.Any()
            ? source.Select(p => p.ToEnvelope())
                .ToArray()
            : null);

    /// <summary>
    /// Performs implicit conversion between a <see cref="RestResponse"/> instance and a <see cref="ResponseForwardingEnvelope"/> instance.
    /// </summary>
    /// <param name="response">The response instance to convert from.</param>
    /// <returns>A converted instance of <see cref="ResponseForwardingEnvelope"/>.</returns>
    public static ResponseForwardingEnvelope ToEnvelope(this RestResponse response) =>
        response switch
        {
            { ResponseStatus: not ResponseStatus.Completed } => new ResponseForwardingEnvelope(false),
            { ContentLength: > 0, ContentType: ContentType.Json } => new ResponseForwardingEnvelope(
                response.ResponseStatus == ResponseStatus.Completed,
                response.StatusCode,
                response.Content,
                AdditionalHeaders: response.Headers.ToEnvelopes()),
            { ContentLength: > 0 } => new ResponseForwardingEnvelope(
                response.ResponseStatus == ResponseStatus.Completed,
                response.StatusCode,
                RawContent: response.RawBytes,
                AdditionalHeaders: response.Headers.ToEnvelopes()),
            _ => new ResponseForwardingEnvelope(
                response.ResponseStatus == ResponseStatus.Completed,
                response.StatusCode,
                AdditionalHeaders: response.Headers.ToEnvelopes())
        };

    /// <summary>
    /// Converts between a <see cref="HttpMethod"/> and a <see cref="Method"/>.
    /// </summary>
    /// <param name="method">The <see cref="HttpMethod"/> to convert.</param>
    /// <returns>The resulting <see cref="Method"/>.</returns>
    /// <exception cref="ArgumentDoesNotMatchException">The method is completely custom and cannot be converted.</exception>
    public static Method ToRestMethod(this HttpMethod method)
    {
        if (method == HttpMethod.Get)
        {
            return Method.Get;
        }

        if (method == HttpMethod.Post)
        {
            return Method.Post;
        }

        if (method == HttpMethod.Put)
        {
            return Method.Put;
        }

        if (method == HttpMethod.Delete)
        {
            return Method.Delete;
        }

        if (method == HttpMethod.Head)
        {
            return Method.Head;
        }

        if (method == HttpMethod.Options)
        {
            return Method.Options;
        }

        if (method == HttpMethod.Trace)
        {
            return Method.Search;
        }

        throw new ArgumentDoesNotMatchException();
    }
}