// <copyright file="IEntityWithStartEnd.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using JetBrains.Annotations;

namespace IX.Abstractions.Entities
{
    /// <summary>
    /// A data contract for an entity that starts ar a certain point in time and, optionally, ends at another one.
    /// </summary>
    [PublicAPI]
    public interface IEntityWithStartEnd
    {
        /// <summary>
        /// Gets or sets the moment this entity is started at.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// Gets or sets the moment this entity ended at, or <c>null</c> (<c>Nothing in Visual Basic</c>).
        /// </summary>
        /// <value>
        /// The end date, if one exists.
        /// </value>
        public DateTime? EndedAt { get; set; }
    }
}