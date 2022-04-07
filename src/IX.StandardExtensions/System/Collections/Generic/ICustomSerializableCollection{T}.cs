// <copyright file="ICustomSerializableCollection{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace IX.System.Collections.Generic;

/// <summary>
///     An interface that is used for hiding the public list of custom serializable collections.
/// </summary>
/// <typeparam name="T">The type of items in the list.</typeparam>
[PublicAPI]
public interface ICustomSerializableCollection<T>
{
#region Properties and indexers

    /// <summary>
    ///     Gets or sets the internal container.
    /// </summary>
    /// <value>The internal container.</value>
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Usage",
        "CA2227:Collection properties should be read only",
        Justification = "The whole point of this is so that it is not read-only.")]
    List<T> InternalContainer { get; set; }

#endregion
}