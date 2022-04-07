// <copyright file="NameSwitchEventArgs.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace IX.StandardExtensions.EventModel;

/// <summary>
///     An event arguments class depicting a named switch.
/// </summary>
/// <seealso cref="EventArgs" />
[PublicAPI]
public class NameSwitchEventArgs : EventArgs
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="NameSwitchEventArgs" /> class.
    /// </summary>
    /// <param name="switchName">The switch name.</param>
    /// <param name="switchValue">The switch value.</param>
    public NameSwitchEventArgs(
        string switchName,
        bool switchValue)
    {
        this.Name = switchName;
        this.Value = switchValue;
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the name value.
    /// </summary>
    /// <value>The name value.</value>
    public string Name { get; }

    /// <summary>
    ///     Gets the value of the switch.
    /// </summary>
    /// <value>The switch value.</value>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1623:Property summary documentation should match accessors",
        Justification = "The analyzer thinks this is a switch.")]
    public bool Value { get; }

#endregion
}