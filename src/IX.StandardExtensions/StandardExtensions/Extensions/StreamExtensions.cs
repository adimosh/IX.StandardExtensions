// <copyright file="StreamExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.IO;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions;

/// <summary>
/// Extensions for the <see cref="Stream"/> class.
/// </summary>
[PublicAPI]
public static class StreamExtensions
{
    /// <summary>
    /// Reads all data from a stream, as a byte array.
    /// </summary>
    /// <param name="stream">The source stream.</param>
    /// <returns>An array of bytes.</returns>
    /// <exception cref="InvalidOperationException">The input stream cannot seek, and, therefore, will not be able to read all bytes.</exception>
    /// <remarks>
    /// <para>This method will attempt to read all data from a stream into memory, regardless of the size of said data.</para>
    /// <para>When using this method, always make sure that you are reading streams small enough to fit into your memory.</para>
    /// <para>Using this method on large file streams is HIGHLY DISCOURAGED!!! Please mind your data.</para>
    /// </remarks>
    public static byte[] ReadAllBytes(this Stream stream)
    {
        if (!stream.CanSeek)
        {
            throw new InvalidOperationException("The input stream cannot seek, and, therefore, will not be able to read all bytes.");
        }

        stream.Seek(
            0,
            SeekOrigin.Begin);

        if (stream.Length == 0)
        {
            return Array.Empty<byte>();
        }

        var streamLength = stream.Length;
        var resultBuffer = new byte[streamLength];
        long readData = 0;
        int readSize = streamLength > 1000 ? 1000 : Convert.ToInt32(streamLength);
        var buffer = new byte[readSize];
        do
        {
            var actualRead = stream.Read(
                buffer,
                0,
                readSize);

            if (actualRead == 0)
            {
                continue;
            }

            Array.Copy(buffer, 0L, resultBuffer, readData, actualRead);
            readData += actualRead;
        }
        while (readData < streamLength);

        return resultBuffer;
    }
}