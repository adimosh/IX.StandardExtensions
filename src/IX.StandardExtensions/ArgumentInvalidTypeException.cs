// <copyright file="ArgumentInvalidTypeException.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Globalization;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace IX.StandardExtensions
{
    /// <summary>
    ///     An argument exception representing a boxed or polymorphic argument being passed as the wrong type.
    /// </summary>
    /// <seealso cref="System.ArgumentException" />
    [Serializable]
    [PublicAPI]
    public class ArgumentInvalidTypeException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidTypeException" /> class.
        /// </summary>
        public ArgumentInvalidTypeException()
            : base(Resources.ErrorWrongArgumentType)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidTypeException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentInvalidTypeException(string argumentName)
            : base(
                Resources.ErrorWrongArgumentType,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidTypeException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentInvalidTypeException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidTypeException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentInvalidTypeException(Exception internalException)
            : base(
                Resources.ErrorWrongArgumentType,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidTypeException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentInvalidTypeException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorWrongArgumentType,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidTypeException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentInvalidTypeException(
            string message,
            string argumentName,
            Exception internalException)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture,
                    message,
                    argumentName),
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidTypeException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentInvalidTypeException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}