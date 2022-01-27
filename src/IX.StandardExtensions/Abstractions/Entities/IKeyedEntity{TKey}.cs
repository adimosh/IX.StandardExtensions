// <copyright file="IKeyedEntity{TKey}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Abstractions.Entities;

/// <summary>
///     A data contract for an entity with a simple key.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
[PublicAPI]
public interface IKeyedEntity<TKey>
{
#region Properties and indexers

    /// <summary>
    ///     Gets or sets the key for this entity.
    /// </summary>
    /// <value>
    ///     The entity key.
    /// </value>
    public TKey Id { get; set; }

#endregion
}