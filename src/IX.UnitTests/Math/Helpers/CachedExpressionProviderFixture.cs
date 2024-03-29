// <copyright file="CachedExpressionProviderFixture.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Math;
using JetBrains.Annotations;

namespace IX.UnitTests.Math.Helpers;

/// <summary>
///     A fixture for a cached expression provider test suite.
/// </summary>
/// <seealso cref="IDisposable" />
public sealed class CachedExpressionProviderFixture : IDisposable
{
    private int firstRun;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CachedExpressionProviderFixture" /> class.
    /// </summary>
    [UsedImplicitly]
    public CachedExpressionProviderFixture()
    {
        CachedService = new();
        Service = new();
    }

    /// <summary>
    ///     Gets the cached service.
    /// </summary>
    /// <value>The cached service.</value>
    public CachedExpressionParsingService CachedService { get; }

    /// <summary>
    ///     Gets the service.
    /// </summary>
    /// <value>The service.</value>
    public ExpressionParsingService Service { get; }

    /// <summary>
    /// Invokes an action at first run only.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    public void AtFirstRun(Action action)
    {
        if (Interlocked.Exchange(
                ref firstRun,
                1) ==
            0)
        {
            action();
        }
    }

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        CachedService.Dispose();
        Service.Dispose();
    }
}