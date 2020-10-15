// <copyright file="StandardExceptions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Globalization;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace IX.StandardExtensions
{
    /// <summary>
    ///     An argument exception representing a path argument that is invalid.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentInvalidPathException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidPathException" /> class.
        /// </summary>
        public ArgumentInvalidPathException()
            : base(Resources.ErrorArgumentInvalidPath)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidPathException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentInvalidPathException(string argumentName)
            : base(
                Resources.ErrorArgumentInvalidPath,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidPathException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentInvalidPathException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidPathException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentInvalidPathException(Exception internalException)
            : base(
                Resources.ErrorArgumentInvalidPath,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidPathException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentInvalidPathException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorArgumentInvalidPath,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidPathException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentInvalidPathException(
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
        ///     Initializes a new instance of the <see cref="ArgumentInvalidPathException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentInvalidPathException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }

    /// <summary>
    ///     An argument exception representing a string argument not matching a specific pattern or expected input.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentDoesNotMatchException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentDoesNotMatchException" /> class.
        /// </summary>
        public ArgumentDoesNotMatchException()
            : base(Resources.ErrorArgumentDoesNotMatch)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentDoesNotMatchException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentDoesNotMatchException(string argumentName)
            : base(
                Resources.ErrorArgumentDoesNotMatch,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentDoesNotMatchException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentDoesNotMatchException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentDoesNotMatchException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentDoesNotMatchException(Exception internalException)
            : base(
                Resources.ErrorArgumentDoesNotMatch,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentDoesNotMatchException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentDoesNotMatchException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorArgumentDoesNotMatch,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentDoesNotMatchException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentDoesNotMatchException(
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
        ///     Initializes a new instance of the <see cref="ArgumentDoesNotMatchException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentDoesNotMatchException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }

    /// <summary>
    ///     An argument exception representing a boxed or polymorphic argument being passed as the wrong type.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentInvalidTypeException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidTypeException" /> class.
        /// </summary>
        public ArgumentInvalidTypeException()
            : base(Resources.ErrorArgumentInvalidType)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentInvalidTypeException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentInvalidTypeException(string argumentName)
            : base(
                Resources.ErrorArgumentInvalidType,
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
                Resources.ErrorArgumentInvalidType,
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
                Resources.ErrorArgumentInvalidType,
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

    /// <summary>
    ///     An argument exception representing an argument not being positive.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentNotPositiveException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveException" /> class.
        /// </summary>
        public ArgumentNotPositiveException()
            : base(Resources.ErrorArgumentNotPositive)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNotPositiveException(string argumentName)
            : base(
                Resources.ErrorArgumentNotPositive,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNotPositiveException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotPositiveException(Exception internalException)
            : base(
                Resources.ErrorArgumentNotPositive,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotPositiveException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorArgumentNotPositive,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotPositiveException(
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
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentNotPositiveException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }

    /// <summary>
    ///     An argument exception representing an argument not being a positive integer (like a capacity or a count).
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentNotPositiveIntegerException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveIntegerException" /> class.
        /// </summary>
        public ArgumentNotPositiveIntegerException()
            : base(Resources.ErrorArgumentNotPositiveInteger)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveIntegerException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNotPositiveIntegerException(string argumentName)
            : base(
                Resources.ErrorArgumentNotPositiveInteger,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveIntegerException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNotPositiveIntegerException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveIntegerException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotPositiveIntegerException(Exception internalException)
            : base(
                Resources.ErrorArgumentNotPositiveInteger,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveIntegerException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotPositiveIntegerException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorArgumentNotPositiveInteger,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveIntegerException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotPositiveIntegerException(
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
        ///     Initializes a new instance of the <see cref="ArgumentNotPositiveIntegerException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentNotPositiveIntegerException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }

    /// <summary>
    ///     An argument exception representing a value given that cannot be used as an index.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentNotValidIndexException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidIndexException" /> class.
        /// </summary>
        public ArgumentNotValidIndexException()
            : base(Resources.ErrorArgumentNotValidIndex)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidIndexException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNotValidIndexException(string argumentName)
            : base(
                Resources.ErrorArgumentNotValidIndex,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidIndexException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNotValidIndexException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidIndexException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotValidIndexException(Exception internalException)
            : base(
                Resources.ErrorArgumentNotValidIndex,
                internalException)
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
                Resources.ErrorArgumentNotValidIndex,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidIndexException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotValidIndexException(
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

    /// <summary>
    ///     n argument exception representing a value given that cannot be used as an array or collection length.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentNotValidLengthException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidLengthException" /> class.
        /// </summary>
        public ArgumentNotValidLengthException()
            : base(Resources.ErrorArgumentNotValidLength)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidLengthException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNotValidLengthException(string argumentName)
            : base(
                Resources.ErrorArgumentNotValidLength,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidLengthException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNotValidLengthException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidLengthException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotValidLengthException(Exception internalException)
            : base(
                Resources.ErrorArgumentNotValidLength,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidLengthException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotValidLengthException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorArgumentNotValidLength,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNotValidLengthException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNotValidLengthException(
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
        ///     Initializes a new instance of the <see cref="ArgumentNotValidLengthException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentNotValidLengthException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }

    /// <summary>
    ///     An argument exception representing an array argument being <c>null</c> (<c>Nothing</c> in Visual Basic) or empty.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentNullOrEmptyArrayException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyArrayException" /> class.
        /// </summary>
        public ArgumentNullOrEmptyArrayException()
            : base(Resources.ErrorArgumentNullOrEmptyArray)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyArrayException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrEmptyArrayException(string argumentName)
            : base(
                Resources.ErrorArgumentNullOrEmptyArray,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyArrayException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrEmptyArrayException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyArrayException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyArrayException(Exception internalException)
            : base(
                Resources.ErrorArgumentNullOrEmptyArray,
                internalException)
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
                Resources.ErrorArgumentNullOrEmptyArray,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyArrayException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyArrayException(
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
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyArrayException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
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

    /// <summary>
    ///     An argument exception representing a binary argument being <c>null</c> (<c>Nothing</c> in Visual Basic) or empty.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentNullOrEmptyBinaryException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyBinaryException" /> class.
        /// </summary>
        public ArgumentNullOrEmptyBinaryException()
            : base(Resources.ErrorArgumentNullOrEmptyBinary)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyBinaryException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrEmptyBinaryException(string argumentName)
            : base(
                Resources.ErrorArgumentNullOrEmptyBinary,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyBinaryException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrEmptyBinaryException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyBinaryException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyBinaryException(Exception internalException)
            : base(
                Resources.ErrorArgumentNullOrEmptyBinary,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyBinaryException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyBinaryException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorArgumentNullOrEmptyBinary,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyBinaryException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyBinaryException(
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
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyBinaryException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentNullOrEmptyBinaryException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }

    /// <summary>
    ///     An argument exception representing a collection argument being <c>null</c> (<c>Nothing</c> in Visual Basic) or empty.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentNullOrEmptyCollectionException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyCollectionException" /> class.
        /// </summary>
        public ArgumentNullOrEmptyCollectionException()
            : base(Resources.ErrorArgumentNullOrEmptyCollection)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyCollectionException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrEmptyCollectionException(string argumentName)
            : base(
                Resources.ErrorArgumentNullOrEmptyCollection,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyCollectionException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrEmptyCollectionException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyCollectionException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyCollectionException(Exception internalException)
            : base(
                Resources.ErrorArgumentNullOrEmptyCollection,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyCollectionException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyCollectionException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorArgumentNullOrEmptyCollection,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyCollectionException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyCollectionException(
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
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyCollectionException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentNullOrEmptyCollectionException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }

    /// <summary>
    ///     An argument exception representing a string argument being <c>null</c> (<c>Nothing</c> in Visual Basic) or empty.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentNullOrEmptyStringException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyStringException" /> class.
        /// </summary>
        public ArgumentNullOrEmptyStringException()
            : base(Resources.ErrorArgumentNullOrEmptyString)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyStringException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrEmptyStringException(string argumentName)
            : base(
                Resources.ErrorArgumentNullOrEmptyString,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyStringException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrEmptyStringException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyStringException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyStringException(Exception internalException)
            : base(
                Resources.ErrorArgumentNullOrEmptyString,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyStringException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyStringException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorArgumentNullOrEmptyString,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyStringException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrEmptyStringException(
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
        ///     Initializes a new instance of the <see cref="ArgumentNullOrEmptyStringException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentNullOrEmptyStringException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }

    /// <summary>
    ///     An argument exception representing a string argument being <c>null</c> (<c>Nothing</c> in Visual Basic), empty or
    ///     whitespace-only.
    /// </summary>
    /// <seealso cref="ArgumentException" />
    [Serializable]
    [PublicAPI]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name should match first type name",
        Justification = "Auto-generated file.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1402:File may only contain a single type",
        Justification = "Auto-generated file.")]
    public class ArgumentNullOrWhiteSpaceStringException : ArgumentException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrWhiteSpaceStringException" /> class.
        /// </summary>
        public ArgumentNullOrWhiteSpaceStringException()
            : base(Resources.ErrorArgumentNullOrWhiteSpaceString)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrWhiteSpaceStringException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrWhiteSpaceStringException(string argumentName)
            : base(
                Resources.ErrorArgumentNullOrWhiteSpaceString,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrWhiteSpaceStringException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public ArgumentNullOrWhiteSpaceStringException(
            string message,
            string argumentName)
            : base(
                message,
                argumentName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrWhiteSpaceStringException" /> class.
        /// </summary>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrWhiteSpaceStringException(Exception internalException)
            : base(
                Resources.ErrorArgumentNullOrWhiteSpaceString,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrWhiteSpaceStringException" /> class.
        /// </summary>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrWhiteSpaceStringException(
            string argumentName,
            Exception internalException)
            : base(
                Resources.ErrorArgumentNullOrWhiteSpaceString,
                argumentName,
                internalException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArgumentNullOrWhiteSpaceStringException" /> class.
        /// </summary>
        /// <param name="message">A custom message for the thrown exception.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="internalException">The internal exception, if any.</param>
        public ArgumentNullOrWhiteSpaceStringException(
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
        ///     Initializes a new instance of the <see cref="ArgumentNullOrWhiteSpaceStringException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ArgumentNullOrWhiteSpaceStringException(
            SerializationInfo info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}