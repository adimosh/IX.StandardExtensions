// <copyright file="EnvironmentSettings.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using JetBrains.Annotations;

namespace IX.StandardExtensions
{
    /// <summary>
    ///     Environment settings for the standard extensions.
    /// </summary>
    [PublicAPI]
    public static class EnvironmentSettings
    {
#region Properties and indexers

        /// <summary>
        ///     Gets or sets a default unhandled exception handler for fire-and-forget scenarios.
        /// </summary>
        /// <value>The default unhandled exception handler.</value>
        public static Action<Exception>? DefaultFireAndForgetUnhandledExceptionHandler { get; set; }

#endregion

        /// <summary>
        /// Environment settings for pagination extensions.
        /// </summary>
        public static class Pagination
        {
            /// <summary>
            /// Gets or sets a default page size for pagination scenarios.
            /// </summary>
            public static int DefaultPageSize { get; set; } = 10;
        }
    }
}