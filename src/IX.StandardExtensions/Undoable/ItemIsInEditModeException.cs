// <copyright file="ItemIsInEditModeException.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace IX.Undoable;

/// <summary>
///     An exception thrown when the item is in edit mode and it shouldn't be.
/// </summary>
/// <seealso cref="InvalidOperationException" />
/// <seealso cref="ITransactionEditableItem" />
[Serializable]
[PublicAPI]
[ExcludeFromCodeCoverage]
public class ItemIsInEditModeException : InvalidOperationException
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemIsInEditModeException" /> class.
    /// </summary>
    public ItemIsInEditModeException()
        : base(Resources.ItemIsInEditModeExceptionDefaultMessage) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemIsInEditModeException" /> class.
    /// </summary>
    /// <param name="message">The custom message to display.</param>
    public ItemIsInEditModeException(string message)
        : base(message) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemIsInEditModeException" /> class.
    /// </summary>
    /// <param name="innerException">The inner exception that caused this exception.</param>
    public ItemIsInEditModeException(Exception innerException)
        : base(
            Resources.ItemIsInEditModeExceptionDefaultMessage,
            innerException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemIsInEditModeException" /> class.
    /// </summary>
    /// <param name="message">The custom message to display.</param>
    /// <param name="innerException">The inner exception that caused this exception.</param>
    public ItemIsInEditModeException(
        string message,
        Exception innerException)
        : base(
            message,
            innerException) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemIsInEditModeException" /> class.
    /// </summary>
    /// <param name="info">
    ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
    ///     data about the exception being thrown.
    /// </param>
    /// <param name="context">
    ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
    ///     information about the source or destination.
    /// </param>
    protected ItemIsInEditModeException(
        SerializationInfo info,
        StreamingContext context)
        : base(
            info,
            context) { }

#endregion
}