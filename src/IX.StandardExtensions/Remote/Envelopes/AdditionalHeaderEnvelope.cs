// <copyright file="AdditionalHeaderEnvelope.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Remote.Envelopes;

/// <summary>
/// Additional headers that are to be forwarded in the RestSharp request.
/// </summary>
/// <param name="Name">The name of the header.</param>
/// <param name="Value">The header of the value.</param>
[PublicAPI]
public record AdditionalHeaderEnvelope(
    string Name,
    string Value);