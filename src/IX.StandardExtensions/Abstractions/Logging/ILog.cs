// <copyright file="ILog.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using JetBrains.Annotations;

namespace IX.Abstractions.Logging
{
    /// <summary>
    ///     A logging interface.
    /// </summary>
    [PublicAPI]
    public interface ILog
    {
        /// <summary>
        ///     Logs a debug message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        void Debug([NotNull] string message);

        /// <summary>
        ///     Logs a debug message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        /// <param name="formatParameters">
        ///     The string format parameters.
        /// </param>
        [StringFormatMethod("message")]
        void Debug(
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs a debug message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        void Debug(
            [NotNull] Exception exception,
            [NotNull] string message);

        /// <summary>
        ///     Logs a debug message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        void Debug(
            [NotNull] Exception exception,
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs an informational message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        void Info([NotNull] string message);

        /// <summary>
        ///     Logs an informational message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        /// <param name="formatParameters">
        ///     The string format parameters.
        /// </param>
        [StringFormatMethod("message")]
        void Info(
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs an informational message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        void Info(
            [NotNull] Exception exception,
            [NotNull] string message);

        /// <summary>
        ///     Logs an informational message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        void Info(
            [NotNull] Exception exception,
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs a warning message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        void Warning([NotNull] string message);

        /// <summary>
        ///     Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        void Warning(
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs a warning message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        void Warning(
            [NotNull] Exception exception,
            [NotNull] string message);

        /// <summary>
        ///     Logs a warning message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        void Warning(
            [NotNull] Exception exception,
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs an error message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        void Error([NotNull] string message);

        /// <summary>
        ///     Logs an error message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        /// <param name="formatParameters">
        ///     The string format parameters.
        /// </param>
        [StringFormatMethod("message")]
        void Error(
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs an error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        void Error(
            [NotNull] Exception exception,
            [NotNull] string message);

        /// <summary>
        ///     Logs an error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        void Error(
            [NotNull] Exception exception,
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs a critical error message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        void Critical([NotNull] string message);

        /// <summary>
        ///     Logs a critical error message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        /// <param name="formatParameters">
        ///     The string format parameters.
        /// </param>
        [StringFormatMethod("message")]
        void Critical(
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs a critical error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        void Critical(
            [NotNull] Exception exception,
            [NotNull] string message);

        /// <summary>
        ///     Logs a critical error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        void Critical(
            [NotNull] Exception exception,
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs a fatal error message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        void Fatal([NotNull] string message);

        /// <summary>
        ///     Logs a fatal error message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        /// <param name="formatParameters">
        ///     The string format parameters.
        /// </param>
        [StringFormatMethod("message")]
        void Fatal(
            [NotNull] string message,
            params string[] formatParameters);

        /// <summary>
        ///     Logs a fatal error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        void Fatal(
            [NotNull] Exception exception,
            [NotNull] string message);

        /// <summary>
        ///     Logs a fatal error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        void Fatal(
            [NotNull] Exception exception,
            [NotNull] string message,
            params string[] formatParameters);
    }
}