// <copyright file="IQueryableExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions;

/// <summary>
///     Extensions for <see cref="IQueryable" />.
/// </summary>
[PublicAPI]
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "We are not bothered by this.")]
[SuppressMessage(
    "CodeQuality",
    "IDE0079:Remove unnecessary suppression",
    Justification = "Some team members use ReSharper.")]
public static class IQueryableExtensions
{
#region Methods

#region Static methods

    /// <summary>
    ///     Paginates a query with either page number and size semantics, or skip/take semantics.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity in the queried collection.</typeparam>
    /// <param name="query">The query object.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="skip">The number of items to skip.</param>
    /// <param name="take">The number of items to take.</param>
    /// <returns>A query that is paginated or has skip/take semantics, or the original query if no semantics are defined.</returns>
    /// <remarks>
    ///     <para>The skip/take semantics take precedence over the page number and size semantics.</para>
    ///     <para>
    ///         The page size uses a default value expressed at <see cref="EnvironmentSettings.Pagination.DefaultPageSize" />
    ///         .
    ///     </para>
    ///     <para>If no pagination is specified, the query is returned as-is.</para>
    /// </remarks>
    public static IQueryable<TEntity> Paginate<TEntity>(
        this IQueryable<TEntity> query,
        int? pageNumber = default,
        int? pageSize = default,
        int? skip = default,
        int? take = default)
    {
        Requires.NotNull(query);

        if (skip != null)
        {
            // Skip/take semantics
            return take == null
                ? query.Skip(skip.Value)
                : query.Skip(skip.Value)
                    .Take(take.Value);
        }

        if (take != null)
        {
            return query.Take(take.Value);
        }

        if (pageNumber == null)
        {
            // No skip/take, no page number and size
            return query;
        }

        // Paginated semantics
        var skip2 = (pageNumber.Value - 1) * (pageSize ?? EnvironmentSettings.Pagination.DefaultPageSize);
        var take2 = pageSize ?? EnvironmentSettings.Pagination.DefaultPageSize;

        return query.Skip(skip2)
            .Take(take2);
    }

#endregion

#endregion
}