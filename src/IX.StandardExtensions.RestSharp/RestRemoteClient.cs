// <copyright file="RestRemoteClient.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IX.Remote.Envelopes;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;
using RestSharp;
using RestSharp.Authenticators;

namespace IX.StandardExtensions.RestSharp;

/// <summary>
/// A REST client based on RestSharp's <see cref="RestClient"/> that receives remote request envelopes and runs them, returning a response envelope.
/// </summary>
[PublicAPI]
public class RestRemoteClient : DisposableBase
{
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP006:Implement IDisposable",
        Justification = "IDisposable is correctly implemented through DisposableBase, but the analyzer can't tell.")]
    private readonly RestClient client;

    /// <summary>
    /// Initializes a new instance of the <see cref="RestRemoteClient"/> class.
    /// </summary>
    /// <param name="baseUrl">The base URL for his client.</param>
    public RestRemoteClient(string baseUrl) => client = new(Requires.NotNullOrWhiteSpace(baseUrl));

    /// <summary>
    /// Initializes a new instance of the <see cref="RestRemoteClient"/> class.
    /// </summary>
    /// <param name="options">The client options.</param>
    public RestRemoteClient(RestClientOptions options) => client = new(Requires.NotNull(options));

    /// <summary>
    /// Initializes a new instance of the <see cref="RestRemoteClient"/> class.
    /// </summary>
    /// <param name="baseUrl">The base URL for his client.</param>
    /// <param name="authenticator">The authenticator to use when making requests.</param>
    public RestRemoteClient(
        string baseUrl,
        IAuthenticator authenticator) =>
        client = new(Requires.NotNullOrWhiteSpace(baseUrl))
        {
            Authenticator = Requires.NotNull(authenticator)
        };

    /// <summary>
    /// Initializes a new instance of the <see cref="RestRemoteClient"/> class.
    /// </summary>
    /// <param name="options">The client options.</param>
    /// <param name="authenticator">The authenticator to use when making requests.</param>
    public RestRemoteClient(
        RestClientOptions options,
        IAuthenticator authenticator) =>
        client = new(Requires.NotNull(options))
        {
            Authenticator = Requires.NotNull(authenticator)
        };

    /// <summary>
    /// Executes a forwarded request from an envelope.
    /// </summary>
    /// <param name="envelope">The envelope containing the request to execute.</param>
    /// <param name="cancellationToken">The cancellation token for this action.</param>
    /// <returns>A response forwarding envelope containing the basic form of the response.</returns>
    public async ValueTask<ResponseForwardingEnvelope> ExecuteForwardedRequest(
        RequestForwardingEnvelope envelope,
        CancellationToken cancellationToken = default)
    {
        // Validation
        _ = Requires.NotNull(envelope);
        _ = Requires.NotNullOrWhiteSpace(envelope.Resource);

        if (!string.IsNullOrWhiteSpace(envelope.JsonBody) && envelope.FileData is not null or { Length: 0 })
        {
            // Both body and files
            throw new InvalidOperationException(Resources.YourRequestCannotContainBothARESTBodyAndFiles);
        }

        if ((envelope.Method == HttpMethod.Get || envelope.Method == HttpMethod.Head || envelope.Method == HttpMethod.Options) &&
            (envelope.JsonBody is not null || envelope.FileData is not null or { Length: 0 }))
        {
            // Methods incompatible with body or files
            throw new InvalidOperationException(Resources.YourRequestHasAMethodThatCannotContainABodyOrFiles);
        }

        RestRequest request = new RestRequest(
            envelope.Resource,
            envelope.Method.ToRestMethod());

        if (!string.IsNullOrWhiteSpace(envelope.JsonBody))
        {
            _ = request.AddStringBody(
                envelope.JsonBody!,
                DataFormat.Json);
        }

        if (envelope.FileData is not null or { Length: 0 })
        {
            foreach (var (name, bytes, fileName) in envelope.FileData)
            {
                _ = request.AddFile(
                    name,
                    bytes,
                    fileName);
            }
        }

        if (envelope.AdditionalHeaders is not null or { Length: 0 })
        {
            foreach (var (name, value) in envelope.AdditionalHeaders)
            {
                _ = request.AddHeader(
                    name,
                    value);
            }
        }

        return (await client.ExecuteAsync(
            request,
            cancellationToken)).ToEnvelope();
    }

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        client.Dispose();
    }
}