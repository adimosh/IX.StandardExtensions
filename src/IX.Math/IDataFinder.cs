// <copyright file="IDataFinder.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.Math;

/// <summary>
///     A contract for an external service that fetches data based on data keys.
/// </summary>
[PublicAPI]
public interface IDataFinder
{
#region Methods

    /// <summary>
    ///     Gets data based on a data key.
    /// </summary>
    /// <param name="dataKey">The data key to search data for.</param>
    /// <param name="data">The data output, if found.</param>
    /// <returns><see langword="true" /> if data was found, <see langword="false" /> otherwise.</returns>
    bool TryGetData(
        string dataKey,
        out object data);

#endregion
}