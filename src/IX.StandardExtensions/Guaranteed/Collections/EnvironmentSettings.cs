// <copyright file="EnvironmentSettings.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Guaranteed.Collections;

/// <summary>
///     Environment settings for guaranteed collections.
/// </summary>
[PublicAPI]
public static class EnvironmentSettings
{
#region Properties and indexers

    /// <summary>
    ///     Gets or sets the persisted collections lock timeout.
    /// </summary>
    /// <value>The persisted collections lock timeout.</value>
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.LayoutRules",
        "SA1513:Closing brace should be followed by blank line",
        Justification = "Initializer used here.")]
    public static TimeSpan PersistedCollectionsLockTimeout
    {
        get;
        set;
    }
        = TimeSpan.FromSeconds(1);

#endregion
}