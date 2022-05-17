// <copyright file="DelayedDisposerUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using Xunit;
using Xunit.Abstractions;
using EnvironmentSettings = IX.StandardExtensions.EnvironmentSettings;

namespace IX.UnitTests.StandardExtensions.Threading;

/// <summary>
/// Unit tests for <see cref="DelayedDisposer"/>.
/// </summary>
public class DelayedDisposerUnitTests
{
    private readonly ITestOutputHelper output;

    public DelayedDisposerUnitTests(ITestOutputHelper output)
    {
        Requires.NotNull(
            out this.output,
            output);

        DelayedDisposer.EnsureInitialized();
    }

    /// <summary>
    /// Tests DelayedDisposer one instance.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer one instance.", Timeout = 3000)]
    public async Task Test1()
    {
        // ARRANGE
        this.output.WriteLine("Starting timed test...");
        var dt = new DisposeTester();
        EnvironmentSettings.DelayedDisposal.DefaultDisposalDelayInMilliseconds = 300;

        // ACT
        this.output.WriteLine("Adding to safe disposer...");
        DelayedDisposer.SafelyDispose(dt);

        // ASSERT
        this.output.WriteLine("Checking negative...");
        dt.CheckNegative();

        this.output.WriteLine("Waiting for disposal...");
        await dt.WaitForDisposal();

        this.output.WriteLine("Checking positive...");
        dt.Check();
    }

    /// <summary>
    /// Tests DelayedDisposer one instance cast.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer one instance cast.", Timeout = 3000)]
    public async Task Test2()
    {
        // ARRANGE
        var dt = new DisposeTester();
        EnvironmentSettings.DelayedDisposal.DefaultDisposalDelayInMilliseconds = 300;

        // ACT
        DelayedDisposer.SafelyDispose((IDisposable)dt);

        // ASSERT
        dt.CheckNegative();

        await dt.WaitForDisposal();

        dt.Check();
    }

    /// <summary>
    /// Tests DelayedDisposer multiple instances.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer multiple instances.", Timeout = 3000)]
    public async Task Test3()
    {
        // ARRANGE
        var dt = new List<DisposeTester>
        {
            new(),
            new(),
            new()
        };
        EnvironmentSettings.DelayedDisposal.DefaultDisposalDelayInMilliseconds = 300;

        // ACT
        DelayedDisposer.SafelyDispose(dt);

        // ASSERT
        dt.ForEach(p => p.CheckNegative());

        await Task.WhenAll(dt.Select(p => p.WaitForDisposal()));

        dt.ForEach(p => p.Check());
    }

    /// <summary>
    /// Tests DelayedDisposer multiple instances cast.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer multiple instances cast.", Timeout = 3000)]
    public async Task Test4()
    {
        // ARRANGE
        var dt = new List<IDisposable>
        {
            new DisposeTester(),
            new DisposeTester(),
            new DisposeTester()
        };
        EnvironmentSettings.DelayedDisposal.DefaultDisposalDelayInMilliseconds = 300;

        // ACT
        DelayedDisposer.SafelyDispose(dt);

        // ASSERT
        dt.ForEach(p => ((DisposeTester)p).CheckNegative());

        await Task.WhenAll(dt.Select(p => ((DisposeTester)p).WaitForDisposal()));

        dt.ForEach(p => ((DisposeTester)p).Check());
    }

    /// <summary>
    /// Tests DelayedDisposer exchange.
    /// </summary>
    /// <returns>The task representing this test.</returns>
    [Fact(DisplayName = "DelayedDisposer exchange.", Timeout = 3000)]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP001:Dispose created",
        Justification = "Not observed in this case.")]
    public async Task Test5()
    {
        // ARRANGE
        var dt = new DisposeTester();
        var dt2 = new DisposeTester();
        var dtt = dt;
        EnvironmentSettings.DelayedDisposal.DefaultDisposalDelayInMilliseconds = 300;

        // ACT
        DelayedDisposer.AtomicExchange(ref dt, dt2);

        // ASSERT
        dtt.CheckNegative();
        dt2.CheckNegative();
        dt.CheckNegative();

        await dtt.WaitForDisposal();

        dtt.Check();
        dt2.CheckNegative();
        dt.CheckNegative();
        Assert.Equal(dt2, dt);
    }

    private sealed class DisposeTester : IDisposable
    {
        private readonly TaskCompletionSource<bool> tcs = new();
        private bool disposed;

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            this.disposed = true;
            this.tcs.SetResult(true);
        }

        /// <summary>
        /// Checks whether this instance has been correctly disposed.
        /// </summary>
        public void Check() => Assert.True(this.disposed, "The instance has not been disposed.");

        /// <summary>
        /// Checks whether this instance has NOT been disposed.
        /// </summary>
        public void CheckNegative() => Assert.False(this.disposed, "The instance has been disposed.");

        public Task WaitForDisposal() => this.tcs.Task;
    }
}