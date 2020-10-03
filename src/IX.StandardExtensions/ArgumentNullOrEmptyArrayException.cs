// <copyright file="ArgumentNullOrEmptyArrayException.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Globalization;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace IX.StandardExtensions
{
    /// <summary>
    ///     An argument exception representing an array argument being <c>null</c> (<c>Nothing</c> in Visual Basic) or empty.
    /// </summary>
    /// <seealso cref="System.ArgumentException" />
    [Serializable]
    [PublicAPI]
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "CA1032:Implement standard exception constructors",
        Justification = "Standard exception constructors make little sense for this exception.")]
    public class ArgumentNullOrEmptyArrayException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyArrayException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrEmptyArrayException(string argumentName)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.ErrorArgumentNullOrEmptyArray,
                    argumentName), argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyArrayException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyArrayException(
            string argumentName,
            Exception internalException)
            : base(
                string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.ErrorArgumentNullOrEmptyArray,
                    argumentName), argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyArrayException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being
        ///     thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual information about the source or
        ///     destination.
        /// </param>
        protected ArgumentNullOrEmptyArrayException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}