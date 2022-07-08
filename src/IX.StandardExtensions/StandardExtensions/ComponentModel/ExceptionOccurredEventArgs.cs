// <copyright file="ExceptionOccurredEventArgs.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace IX.StandardExtensions.ComponentModel;

/// <summary>
///     Event arguments for an event handler detailing exceptions occurring in different threads.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public class ExceptionOccurredEventArgs : EventArgs
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ExceptionOccurredEventArgs" /> class.
    /// </summary>
    /// <param name="exception">The exception that has occurred.</param>
    public ExceptionOccurredEventArgs(Exception exception)
    {
        Exception = exception;
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the exception that has occurred.
    /// </summary>
    public Exception Exception { get; }

#endregion
}