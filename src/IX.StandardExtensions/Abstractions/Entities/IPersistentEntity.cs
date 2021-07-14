// <copyright file="IPersistentEntity.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Abstractions.Entities
{
    /// <summary>
    ///     A data contract for an entity that needs to remain in the database, or to be recoverable.
    /// </summary>
    [PublicAPI]
    public interface IPersistentEntity
    {
#region Properties and indexers

        /// <summary>
        ///     Gets or sets a value indicating whether this entity is deleted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if deleted and should not appear in queries; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }

#endregion
    }
}