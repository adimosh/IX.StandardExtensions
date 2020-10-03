// <copyright file="ArgumentNotValidIndexException.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Globalization;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace IX.StandardExtensions
{
    /// <summary>
    ///     An argument exception representing a value given that cannot be used as an index.
    /// </summary>
    /// <seealso cref="System.ArgumentException" />
    [Serializable]
    [PublicAPI]
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "CA1032:Implement standard exception constructors",
        Justification = "Standard exception constructors make little sense for this exception.")]
    public class ArgumentNotValidIndexException : ArgumentOutOfRangeException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidIndexException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNotValidIndexException(string argumentName)
            : base(
                argumentName,
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.ErrorArgumentNotValidIndex,
                    argumentName))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidIndexException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotValidIndexException(
            string argumentName,
            Exception internalException)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.ErrorArgumentNotValidIndex,
                    argumentName),
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidIndexException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentNotValidIndexException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}