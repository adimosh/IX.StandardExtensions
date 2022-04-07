// <copyright file="NameValueEventArgs.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.StandardExtensions.EventModel;

/// <summary>
///     An event arguments class depicting a named value.
/// </summary>
/// <seealso cref="EventArgs" />
[PublicAPI]
public class NameValueEventArgs : EventArgs
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="NameValueEventArgs" /> class.
    /// </summary>
    /// <param name="nameValue">The name value.</param>
    public NameValueEventArgs(string nameValue)
    {
        this.Name = nameValue;
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the name value.
    /// </summary>
    /// <value>The name value.</value>
    public string Name { get; }

#endregion
}