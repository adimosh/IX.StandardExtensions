// <copyright file="ArgumentsException.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions;

/// <summary>
///     An exception representing something wrong with a set of arguments as a whole, rather than just one.
/// </summary>
[Serializable]
[PublicAPI]
[ExcludeFromCodeCoverage]
public class ArgumentsException : Exception
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="argumentNames">The names of the arguments that have an invalid value.</param>
    public ArgumentsException(params string[] argumentNames)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.AnInvalidSetOfArgumentsWasSpecifiedArgumentNames,
                string.Join(
                    ", ",
                    Requires.NotNull(argumentNames))))
    {
        this.ArgumentNames = argumentNames;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="argumentNames">The names of the arguments that have an invalid value.</param>
    public ArgumentsException(
        Exception innerException,
        params string[] argumentNames)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                Resources.AnInvalidSetOfArgumentsWasSpecifiedArgumentNames,
                string.Join(
                    ", ",
                    Requires.NotNull(argumentNames))),
            innerException)
    {
        this.ArgumentNames = argumentNames;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="message">The custom exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="argumentNames">The names of the arguments that have an invalid value.</param>
    public ArgumentsException(
        string message,
        Exception innerException,
        params string[] argumentNames)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                message,
                string.Join(
                    ", ",
                    Requires.NotNull(argumentNames))),
            innerException)
    {
        this.ArgumentNames = argumentNames;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="message">The custom exception message.</param>
    /// <param name="argumentNames">The names of the arguments that have an invalid value.</param>
    protected ArgumentsException(
        string message,
        params string[] argumentNames)
        : base(
            string.Format(
                CultureInfo.CurrentCulture,
                message,
                string.Join(
                    ", ",
                    Requires.NotNull(argumentNames))))
    {
        this.ArgumentNames = argumentNames;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentsException" /> class.
    /// </summary>
    /// <param name="info">
    ///     The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being
    ///     thrown.
    /// </param>
    /// <param name="context">
    ///     The <see cref="StreamingContext" /> that contains contextual information about the source or
    ///     destination.
    /// </param>
    protected ArgumentsException(
        SerializationInfo info,
        StreamingContext context)
        : base(
            info,
            context)
    {
        this.ArgumentNames = Requires.ArgumentOfType<string[]>(
            info.GetValue(
                nameof(this.ArgumentNames),
                typeof(string[])),
            nameof(info));
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the argument names.
    /// </summary>
    public string[] ArgumentNames { get; private set; }

#endregion

#region Methods

    /// <summary>
    ///     Sets the <see cref="SerializationInfo" /> with information about the exception.
    /// </summary>
    /// <param name="info">
    ///     The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being
    ///     thrown.
    /// </param>
    /// <param name="context">
    ///     The <see cref="StreamingContext" /> that contains contextual information about the source or
    ///     destination.
    /// </param>
    public override void GetObjectData(
        SerializationInfo info,
        StreamingContext context)
    {
        base.GetObjectData(
            info,
            context);

        info.AddValue(
            nameof(this.ArgumentNames),
            this.ArgumentNames,
            typeof(string[]));
    }

#endregion
}