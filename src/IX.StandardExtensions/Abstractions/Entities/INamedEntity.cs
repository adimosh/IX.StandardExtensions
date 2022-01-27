// <copyright file="INamedEntity.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Abstractions.Entities;

/// <summary>
///     A data contract for a named entity.
/// </summary>
[PublicAPI]
public interface INamedEntity
{
#region Properties and indexers

    /// <summary>
    ///     Gets or sets a name for this entity.
    /// </summary>
    /// <value>
    ///     The entity name.
    /// </value>
    public string Name { get; set; }

#endregion
}