// <copyright file="CharsetDetectionEngine.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using JetBrains.Annotations;
using UtfUnknown.Core;
using UtfUnknown.Core.Probers;

namespace IX.StandardExtensions.Globalization;

/// <summary>
/// A character set detection engine.
/// </summary>
/// <seealso cref="ICharsetDetectionEngine"/>
[PublicAPI]
public class CharsetDetectionEngine : ICharsetDetectionEngine
{
    private static readonly Dictionary<string, string> FixedToSupportCodepageName =
        new()
        {
            // CP949 is superset of ks_c_5601-1987 (see https://github.com/CharsetDetector/UTF-unknown/pull/74#issuecomment-550362133)
            { CodepageName.CP949, CodepageName.KS_C_5601_1987 },
            { CodepageName.ISO_2022_CN, CodepageName.X_CP50227 },
        };

    private static readonly Lazy<CharsetProber[]> UnicodeProbers = new(
        () => new CharsetProber[]
        {
            new MBCSGroupProber(),
            new SBCSGroupProber(),
            new Latin1Prober()
        });

    private static readonly Lazy<CharsetProber> EscapedAsciiProber = new(() => new EscCharsetProber());

    /// <summary>
    /// Gets a compatible encoding (if any is applicable) based on its short name.
    /// </summary>
    /// <param name="encodingShortName">The short name of the encoding.</param>
    /// <returns>The encoding, if one is found.</returns>
    public static Encoding? GetCompatibleEncodingByShortName(string encodingShortName)
    {
        var encodingName = FixedToSupportCodepageName.TryGetValue(
            encodingShortName,
            out var supportCodepageName)
            ? supportCodepageName
            : encodingShortName;
        try
        {
            return Encoding.GetEncoding(encodingName);
        }
        catch (ArgumentException)
        {
            #if NETSTANDARD
            try
            {
                return CodePagesEncodingProvider.Instance.GetEncoding(encodingName);
            }
            catch
            {
                return null;
            }
            #else
                return null;
            #endif
        }
    }

    /// <summary>
    /// Read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(Stream stream)
    {
        var buffer = stream.ReadAllBytes();

        return this.Interpret(
            buffer,
            0,
            buffer.LongLength);
    }

    /// <summary>
    /// Read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="limit">The limit on the number of bytes to read, if available.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(
        Stream stream,
        int limit)
    {
        byte[] buffer = new byte[limit];

        _ = stream.Read(
            buffer,
            0,
            limit);

        return this.Interpret(
            buffer,
            0,
            limit);
    }

    /// <summary>
    /// Read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="offset">The offset within the buffer to start reading from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(
        byte[] buffer,
        int offset,
        int count)
    {
        return this.Interpret(
            buffer,
            offset,
            count);
    }

    /// <summary>
    /// Read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(
        byte[] buffer,
        int count)
    {
        return this.Interpret(
            buffer,
            0,
            count);
    }

    /// <summary>
    /// Read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(
        byte[] buffer)
    {
        return this.Interpret(
            buffer,
            0,
            buffer.LongLength);
    }

    /// <summary>
    /// Asynchronously read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public async Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        Stream stream,
        CancellationToken cancellationToken = default)
    {
        var buffer = await stream.ReadAllBytesAsync(cancellationToken);

        return this.Interpret(
            buffer,
            0,
            buffer.LongLength);
    }

    /// <summary>
    /// Asynchronously read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="limit">The limit on the number of bytes to read, if available.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public async Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        Stream stream,
        int limit,
        CancellationToken cancellationToken = default)
    {
        byte[] buffer = new byte[limit];

        await stream.ReadAsync(
            buffer,
            0,
            limit);

        return this.Interpret(
            buffer,
            0,
            limit);
    }

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="offset">The offset within the buffer to start reading from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public async Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        int offset,
        int count,
        CancellationToken cancellationToken = default)
    {
        await Task.Yield();

        return this.Interpret(
            buffer,
            offset,
            count);
    }

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public async Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        int count,
        CancellationToken cancellationToken = default)
    {
        await Task.Yield();

        return this.Interpret(
            buffer,
            0,
            count);
    }

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public async Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        CancellationToken cancellationToken = default)
    {
        await Task.Yield();

        return this.Interpret(
            buffer,
            0,
            buffer.LongLength);
    }

    private (Encoding? Encoding, float Confidence) Interpret(byte[] input, long offset, long length)
    {
        Requires.ValidArrayRange(in offset, in length, input);

        #region Check for byte-order mark

        switch (input[offset])
        {
            case 0xEF:
                // UTF8 with BOM
                if (length >= 3 && input[offset + 1] == 0xBB && input[offset + 2] == 0xBF)
                {
                    // BOM recognized as UTF8
                    return (Encoding.UTF8, 1f);
                }

                break;
            case 0xFE:
                // Either UCS4 (3412) encoding, or UTF16 big-endian
                if (length >= 2 && input[offset + 1] == 0xFF)
                {
                    if (length >= 4 && input[offset + 2] == 0x00 && input[offset + 3] == 0x00)
                    {
                        // UCS4 (3412) - UNSUPPORTED YET, probably never
                        // return (Encoding.GetEncoding(CodepageName.X_ISO_10646_UCS_4_3412), 1.0f);
                        return (null, 0f);
                    }

                    // UTF-16 big-endian
                    return (Encoding.BigEndianUnicode, 1.0f);
                }

                break;

            case 0xFF:
                // UTF16 little-endian or UTF32 little-endian
                if (length >= 2 && input[offset + 1] == 0xFE)
                {
                    if (length >= 4 && input[offset + 2] == 0x00 && input[offset + 3] == 0x00)
                    {
                        // UTF32 little-endian
                        return (Encoding.UTF32, 1.0f);
                    }

                    return (Encoding.Unicode, 1.0f);
                }

                break;

            case 0x00:
                // UTF32 big-endian or UCS4 (2143)
                if (length >= 4 && input[offset + 1] == 0x00)
                {
                    if (input[offset + 2] == 0xFE && input[offset + 3] == 0xFF)
                    {
                        // UTF32 big-endian
                        return (Encoding.GetEncoding(12001), 1.0f);
                    }

                    if (input[offset + 2] == 0xFF && input[offset + 3] == 0xFE)
                    {
                        // UCS4 (2143) - UNSUPPORTED YET, probably never
                        // return (Encoding.GetEncoding(CodepageName.X_ISO_10646_UCS_4_2143), 1.0f);
                        return (null, 0f);
                    }
                }

                break;

            case 0x2B:
                // UTF7
                if (length >= 4 &&
                    input[offset + 1] == 0x2F &&
                    input[offset + 2] == 0x76 &&
                    (input[offset + 3] == 0x38 || input[offset + 3] == 0x39 || input[offset + 3] == 0x2B || input[offset + 3] == 0x2F))
                {
                    return (Encoding.UTF7, 1.0f);
                }

                break;

            case 0x84:
                // GB18030
                if (length >= 4 && input[offset + 1] == 0x31 && input[offset + 2] == 0x95 && input[offset + 3] == 0x33)
                {
                    return (Encoding.GetEncoding(54936), 1.0f);
                }

                break;
        }

        #endregion

        #region Initial probe for pure ASCII

        bool? pureAscii = true; // NULL: high-byte, false: escaped ASCII, true: pure ASCII
        byte lastByte = 0;

        for (long i = offset; i < offset + length; i++)
        {
            if ((input[i] & 0x80) != 0 && input[i] != 0xA0)
            {
                // We found a non-ASCII byte (high-byte), let's not move on
                pureAscii = null;

                break;
            }
            else
            {
                if (pureAscii == true &&
                    (input[i] == 0x1B || (input[i] == 0x7B && lastByte == 0x7E)))
                {
                    // We found escape character or HZ "~{" - Could be escaped ASCII, but we
                    // should continue probing for high bytes
                    pureAscii = false;
                }

                lastByte = input[i];
            }
        }

        if (pureAscii == true)
        {
            return (Encoding.ASCII, 1.0f);
        }

        #endregion

        #region Probe for escaped ASCII

        if (pureAscii == false)
        {
            // TODO: Change from int to long
            ProbingState state;
            lock (EscapedAsciiProber)
            {
                state = EscapedAsciiProber.Value.HandleData(
                    input,
                    (int)offset,
                    (int)length);
                EscapedAsciiProber.Value.Reset();
            }

            if (state == ProbingState.FoundIt)
            {
                return (Encoding.ASCII, 1.0f);
            }

            // TODO: Bug in EscCharsetProber, but ASCII validation has passed nonetheless - return to this when original bug is fixed.
            // https://github.com/CharsetDetector/UTF-unknown/blob/c24d58d286d1e9639611453f8055f5aa122c3c6b/src/CharsetDetector.cs#L470
            return (Encoding.ASCII, 1.0f);
        }

        #endregion

        #region Probe for more complex charsets

        Encoding? finalEncoding;
        float finalConfidence;
        lock (UnicodeProbers)
        {
            foreach (var prober in UnicodeProbers.Value)
            {
                if (prober.HandleData(
                        input,
                        (int)offset,
                        (int)length) ==
                    ProbingState.FoundIt)
                {
                    var encoding = GetCompatibleEncodingByShortName(prober.GetCharsetName());

                    if (encoding != null)
                    {
                        var confidence = prober.GetConfidence();

                        if (confidence > 0.97f)
                        {
                            confidence = 1.0f;
                        }

                        return (encoding, confidence);
                    }
                }
            }

            var mostLikelyCharset = UnicodeProbers.Value.Select(
                    p => new
                    {
                        Confidence = p.GetConfidence(),
                        Detected = p.GetCharsetName()
                    })
                .Where(p => p.Confidence > 0.2f)
                .OrderByDescending(result => result.Confidence)
                .First();

            foreach (var prober in UnicodeProbers.Value)
            {
                prober.Reset();
            }

            finalEncoding = GetCompatibleEncodingByShortName(mostLikelyCharset.Detected);
            finalConfidence = mostLikelyCharset.Confidence;
        }

        #endregion
        return finalEncoding == null ? (null, 0f) : (finalEncoding, finalConfidence);
    }
}