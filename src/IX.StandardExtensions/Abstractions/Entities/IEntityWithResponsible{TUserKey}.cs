// <copyright file="IEntityWithResponsible{TUserKey}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Abstractions.Entities
{
    /// <summary>
    ///     A data contract for an entity with an attached responsible person.
    /// </summary>
    /// <typeparam name="TUserKey">The type of the user key.</typeparam>
    [PublicAPI]
    public interface IEntityWithResponsible<TUserKey>
    {
#region Properties and indexers

        /// <summary>
        ///     Gets or sets the identifier of the user responsible for this entity.
        /// </summary>
        /// <value>
        ///     The responsible user identifier.
        /// </value>
        public TUserKey ResponsibleId { get; set; }

#endregion
    }
}