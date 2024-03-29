// <copyright file="IDeepCloneable{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.StandardExtensions;

/// <summary>
///     Interface for implementing deep cloning for an object.
/// </summary>
/// <typeparam name="T">The type of object to clone.</typeparam>
[PublicAPI]
public interface IDeepCloneable<out T>
    where T : notnull
{
#region Methods

    /// <summary>
    ///     Creates a deep clone of the source object.
    /// </summary>
    /// <returns>A deep clone.</returns>
    T DeepClone();

#endregion
}