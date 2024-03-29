// <copyright file="StopRetryingException.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace IX.StandardExtensions;

/// <summary>
///     An exception that, when thrown, signals the thread it's on to stop retrying an operation.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
[PublicAPI]
[ExcludeFromCodeCoverage]
public class StopRetryingException : Exception
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="StopRetryingException" /> class.
    /// </summary>
    public StopRetryingException()
        : base(Resources.ErrorStopRetrying) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="StopRetryingException" /> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public StopRetryingException(string message)
        : base(message) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="StopRetryingException" /> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    ///     The exception that is the cause of the current exception, or a null reference (
    ///     <see langword="Nothing" /> in Visual Basic) if no inner exception is specified.
    /// </param>
    public StopRetryingException(
        string message,
        Exception innerException)
        : base(
            message,
            innerException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="StopRetryingException" /> class.
    /// </summary>
    /// <param name="info">
    ///     The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being
    ///     thrown.
    /// </param>
    /// <param name="context">
    ///     The <see cref="StreamingContext" /> that contains contextual information about the source or
    ///     destination.
    /// </param>
    protected StopRetryingException(
        SerializationInfo info,
        StreamingContext context)
        : base(
            info,
            context) { }

#endregion
}