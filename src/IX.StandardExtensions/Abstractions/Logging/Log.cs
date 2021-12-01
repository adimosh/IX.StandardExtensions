// <copyright file="Log.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics;
using System.Threading;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.Abstractions.Logging
{
    /// <summary>
    ///     Logging engine.
    /// </summary>
    [PublicAPI]
    public static class Log
    {
#region Internal state

        private static readonly AsyncLocal<ILog?> CurrentContext = new();

#endregion

#region Properties and indexers

        /// <summary>
        ///     Gets the default logger.
        /// </summary>
        public static ILog? Default { get; }

        /// <summary>
        ///     Gets the currently-used logger.
        /// </summary>
        public static ILog? Current => CurrentContext.Value ?? Default;

#endregion

#region Methods

#region Static methods

        /// <summary>
        ///     Logs a critical error message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolCritical)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Critical(string message) => Current?.Critical(message);

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
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolCritical)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Critical(
            string message,
            params string[] formatParameters) =>
            Current?.Critical(
                message,
                formatParameters);

        /// <summary>
        ///     Logs a critical error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolCritical)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Critical(
            Exception exception,
            string message) =>
            Current?.Critical(
                exception,
                message);

        /// <summary>
        ///     Logs a critical error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolCritical)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Critical(
            Exception exception,
            string message,
            params string[] formatParameters) =>
            Current?.Critical(
                exception,
                message,
                formatParameters);

        /// <summary>
        ///     Logs a debug message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Debug(string message) => Current?.Debug(message);

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
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Debug(
            string message,
            params string[] formatParameters) =>
            Current?.Debug(
                message,
                formatParameters);

        /// <summary>
        ///     Logs a debug message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Debug(
            Exception exception,
            string message) =>
            Current?.Debug(
                exception,
                message);

        /// <summary>
        ///     Logs a debug message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Debug(
            Exception exception,
            string message,
            params string[] formatParameters) =>
            Current?.Debug(
                exception,
                message,
                formatParameters);

        /// <summary>
        ///     Logs an error message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Error(string message) => Current?.Error(message);

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
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Error(
            string message,
            params string[] formatParameters) =>
            Current?.Error(
                message,
                formatParameters);

        /// <summary>
        ///     Logs an error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Error(
            Exception exception,
            string message) =>
            Current?.Error(
                exception,
                message);

        /// <summary>
        ///     Logs an error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Error(
            Exception exception,
            string message,
            params string[] formatParameters) =>
            Current?.Error(
                exception,
                message,
                formatParameters);

        /// <summary>
        ///     Logs a fatal error message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolCritical)]
        [Conditional(Constants.LoggingSymbolFatal)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Fatal(string message) => Current?.Fatal(message);

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
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolCritical)]
        [Conditional(Constants.LoggingSymbolFatal)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Fatal(
            string message,
            params string[] formatParameters) =>
            Current?.Fatal(
                message,
                formatParameters);

        /// <summary>
        ///     Logs a fatal error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolCritical)]
        [Conditional(Constants.LoggingSymbolFatal)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Fatal(
            Exception exception,
            string message) =>
            Current?.Fatal(
                exception,
                message);

        /// <summary>
        ///     Logs a fatal error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolError)]
        [Conditional(Constants.LoggingSymbolCritical)]
        [Conditional(Constants.LoggingSymbolFatal)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Fatal(
            Exception exception,
            string message,
            params string[] formatParameters) =>
            Current?.Fatal(
                exception,
                message,
                formatParameters);

        /// <summary>
        ///     Logs an informational message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Info(string message) => Current?.Info(message);

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
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Info(
            string message,
            params string[] formatParameters) =>
            Current?.Info(
                message,
                formatParameters);

        /// <summary>
        ///     Logs an informational message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Info(
            Exception exception,
            string message) =>
            Current?.Info(
                exception,
                message);

        /// <summary>
        ///     Logs an informational message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Info(
            Exception exception,
            string message,
            params string[] formatParameters) =>
            Current?.Info(
                exception,
                message,
                formatParameters);

        /// <summary>
        ///     Uses a special logger in a context.
        /// </summary>
        /// <param name="customLogger">The custom logger to use.</param>
        /// <returns>A disposable context for this logger, that resets it upon disposal.</returns>
        /// <exception cref="InvalidOperationException">There already is a special logging context.</exception>
        public static IDisposable UseSpecialLogger(ILog customLogger)
        {
            if (CurrentContext.Value != null)
            {
                throw new InvalidOperationException();
            }

            CurrentContext.Value = Requires.NotNull(customLogger);

            return new SpecialLoggerContext();
        }

        /// <summary>
        ///     Logs a warning message.
        /// </summary>
        /// <param name="message">
        ///     The message to log.
        /// </param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Warning(string message) => Current?.Warning(message);

        /// <summary>
        ///     Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Warning(
            string message,
            params string[] formatParameters) =>
            Current?.Warning(
                message,
                formatParameters);

        /// <summary>
        ///     Logs a warning message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Warning(
            Exception exception,
            string message) =>
            Current?.Warning(
                exception,
                message);

        /// <summary>
        ///     Logs a warning message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="formatParameters">The string format parameters.</param>
        [StringFormatMethod("message")]
        [Conditional(Constants.LoggingSymbolDebug)]
        [Conditional(Constants.LoggingSymbolInfo)]
        [Conditional(Constants.LoggingSymbolWarning)]
        [Conditional(Constants.LoggingSymbolAll)]
        public static void Warning(
            Exception exception,
            string message,
            params string[] formatParameters) =>
            Current?.Warning(
                exception,
                message,
                formatParameters);

#endregion

#endregion

#region Nested types and delegates

        private sealed class SpecialLoggerContext : IDisposable
        {
#region Methods

#region Interface implementations

            public void Dispose() => CurrentContext.Value = null;

#endregion

#endregion
        }

#endregion
    }
}