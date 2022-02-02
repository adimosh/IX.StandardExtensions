// <copyright file="CharsetDetectionEngine.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Text;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Extensions;
using IX.StandardExtensions.Globalization.CharsetDetectionContrib;
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
            new PureProber(),
            new EscCharsetProber(),
            new MBCSGroupProber(),
            new SBCSGroupProber(),
            new Latin1Prober()
        });

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
            limit,
            cancellationToken);

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
            count,
            cancellationToken);
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
            buffer.LongLength,
            cancellationToken);
    }

    private (Encoding? Encoding, float Confidence) Interpret(byte[] input, long offset, long length, CancellationToken cancellationToken = default)
    {
        Requires.ValidArrayRange(in offset, in length, input);

        #region Check for byte-order mark

        var checkResult = CheckBOM(
            input,
            offset,
            length,
            out var possibleEncoding);

        if (checkResult)
        {
            return (possibleEncoding, possibleEncoding == null ? 0f : 1f);
        }

        #endregion

        lock (UnicodeProbers)
        {
            try
            {
                byte[]? chunk = null;
                while (length != 0)
                {
                    long toRead = length > 1000 ? 1000 : length;

                    chunk ??= new byte[toRead];

                    Array.Copy(
                        input,
                        offset,
                        chunk,
                        0,
                        toRead);

                    if (this.CheckSmallBuffer(
                            chunk,
                            (int)toRead,
                            out var immediateResult))
                    {
                        return immediateResult;
                    }

                    offset += toRead;
                    length -= toRead;
                }

                Encoding? finalEncoding = null;
                float finalConfidence = 0f;

                var mostLikelyCharset = UnicodeProbers.Value.Where(p => p.GetState() != ProbingState.NotMe)
                    .Select(
                        p => new
                        {
                            Confidence = p.GetConfidence(),
                            Detected = p.GetCharsetName()
                        })
                    .Where(p => p.Confidence > 0.2f)
                    .OrderByDescending(result => result.Confidence)
                    .FirstOrDefault();

                if (mostLikelyCharset != null)
                {
                    finalEncoding = GetCompatibleEncodingByShortName(mostLikelyCharset.Detected ?? CodepageName.ASCII);
                    finalConfidence = mostLikelyCharset.Confidence;
                }

                return finalEncoding == null
                    ? (null, 0f)
                    : (finalEncoding, finalConfidence >= 0.99f ? 1.0f : finalConfidence);
            }
            finally
            {
                if (UnicodeProbers.IsValueCreated)
                {
                    foreach (var prober in UnicodeProbers.Value)
                    {
                        prober.Reset();
                    }
                }
            }
        }
    }

    private bool CheckSmallBuffer(
        byte[] input,
        int length,
        out (Encoding? Encoding, float Confidence) definitiveAnswerResult)
    {
        foreach (var prober in UnicodeProbers.Value.Where(p => p.GetState() != ProbingState.NotMe))
        {
            if (prober.HandleData(
                    input,
                    0,
                    length) !=
                ProbingState.FoundIt)
            {
                // Not a definitive answer yet, keep searching
                continue;
            }

            var encoding = GetCompatibleEncodingByShortName(prober.GetCharsetName());

            if (encoding == null)
            {
                // Encoding may not actually be supported, let's keep searching
                continue;
            }

            var confidence = prober.GetConfidence();

            if (confidence >= 0.99f)
            {
                confidence = 1.0f;
            }

            // We've got a definitive encoding, let's return
            definitiveAnswerResult = (encoding, confidence);

            return true;
        }

        definitiveAnswerResult = default;
        return false;
    }

    //private static (Encoding? Encoding, float Confidence) CheckEscapedAscii(byte[] input, long offset, long length)
    //{
    //    lock (EscapedAsciiProber)
    //    {
    //        try
    //        {
    //            // TODO: Change from int to long
    //            ProbingState state;
    //            state = EscapedAsciiProber.Value.HandleData(
    //                input,
    //                (int)offset,
    //                (int)length);

    //            if (state == ProbingState.FoundIt)
    //            {
    //                var encoding = GetCompatibleEncodingByShortName(EscapedAsciiProber.Value.GetCharsetName());
    //                if (encoding == null)
    //                {
    //                    return default;
    //                }

    //                return (encoding,
    //                    EscapedAsciiProber.Value.GetConfidence());
    //            }

    //            // TODO: Bug in EscCharsetProber, but ASCII validation has passed nonetheless - return to this when original bug is fixed.
    //            // https://github.com/CharsetDetector/UTF-unknown/blob/c24d58d286d1e9639611453f8055f5aa122c3c6b/src/CharsetDetector.cs#L470
    //            return (Encoding.ASCII, 1.0f);
    //        }
    //        finally
    //        {
    //            if (EscapedAsciiProber.IsValueCreated)
    //            {
    //                EscapedAsciiProber.Value.Reset();
    //            }
    //        }
    //    }
    //}

    private static bool CheckBOM(
        byte[] input,
        long offset,
        long length,
        out Encoding? encoding)
    {
        switch (input[offset])
        {
            case 0xEF:
                // UTF8 with BOM
                if (length >= 3 && input[offset + 1] == 0xBB && input[offset + 2] == 0xBF)
                {
                    // BOM recognized as UTF8
                    encoding = Encoding.UTF8;

                    return true;
                }

                break;
            case 0xFE:
                // Either UCS4 (3412) encoding, or UTF16 big-endian
                if (length >= 2 && input[offset + 1] == 0xFF)
                {
                    if (length >= 4 && input[offset + 2] == 0x00 && input[offset + 3] == 0x00)
                    {
                        // UCS4 (3412) - UNSUPPORTED YET, probably never
                        // encoding = Encoding.GetEncoding(CodepageName.X_ISO_10646_UCS_4_3412);
                        encoding = null;

                        return true;
                    }

                    // UTF-16 big-endian
                    encoding = Encoding.BigEndianUnicode;

                    return true;
                }

                break;

            case 0xFF:
                // UTF16 little-endian or UTF32 little-endian
                if (length >= 2 && input[offset + 1] == 0xFE)
                {
                    if (length >= 4 && input[offset + 2] == 0x00 && input[offset + 3] == 0x00)
                    {
                        // UTF32 little-endian
                        encoding = Encoding.UTF32;

                        return true;
                    }

                    encoding = Encoding.Unicode;

                    return true;
                }

                break;

            case 0x00:
                // UTF32 big-endian or UCS4 (2143)
                if (length >= 4 && input[offset + 1] == 0x00)
                {
                    if (input[offset + 2] == 0xFE && input[offset + 3] == 0xFF)
                    {
                        // UTF32 big-endian
                        encoding = Encoding.GetEncoding(12001);

                        return true;
                    }

                    if (input[offset + 2] == 0xFF && input[offset + 3] == 0xFE)
                    {
                        // UCS4 (2143) - UNSUPPORTED YET, probably never
                        // encoding = Encoding.GetEncoding(CodepageName.X_ISO_10646_UCS_4_2143);
                        encoding = null;

                        return true;
                    }
                }

                break;

            case 0x2B:
                // UTF7
                if (length >= 4 &&
                    input[offset + 1] == 0x2F &&
                    input[offset + 2] == 0x76 &&
                    (input[offset + 3] == 0x38 ||
                     input[offset + 3] == 0x39 ||
                     input[offset + 3] == 0x2B ||
                     input[offset + 3] == 0x2F))
                {
#pragma warning disable SYSLIB0001 // Type or member is obsolete - it is still currently in use and can be recognized
#pragma warning disable CS0618
                    encoding = Encoding.UTF7;
#pragma warning restore CS0618
#pragma warning restore SYSLIB0001 // Type or member is obsolete

                    return true;
                }

                break;

            case 0x84:
                // GB18030
                if (length >= 4 && input[offset + 1] == 0x31 && input[offset + 2] == 0x95 && input[offset + 3] == 0x33)
                {
                    encoding = Encoding.GetEncoding(54936);

                    return true;
                }

                break;
        }

        encoding = null;

        return false;
    }
}