// <copyright file="IEntityWithAbbreviatedName.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Abstractions.Entities;

/// <summary>
///     A data contract for an entity with an abbreviated name.
/// </summary>
[PublicAPI]
public interface IEntityWithAbbreviatedName
{
#region Properties and indexers

    /// <summary>
    ///     Gets or sets the abbreviation for this entity.
    /// </summary>
    /// <value>
    ///     The entity abbreviation.
    /// </value>
    public string Abbreviation { get; set; }

#endregion
}