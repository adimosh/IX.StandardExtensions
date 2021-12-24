// <copyright file="DisposableBase.netstandard2.1.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if FRAMEWORK_ADVANCED
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace IX.StandardExtensions.ComponentModel;

/// <summary>
///     An abstract base class for correctly implementing the disposable pattern.
/// </summary>
/// <seealso cref="IDisposable" />
public abstract partial class DisposableBase : IAsyncDisposable
{
    #region Methods

    #region Interface implementations

    /// <summary>
    ///     Asynchronously performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
    ///     resources.
    /// </summary>
    /// <returns>
    ///     A value task representing the completed dispose operation.
    /// </returns>
    [SuppressMessage(
        "Usage",
        "CA1816:Dispose methods should call SuppressFinalize",
        Justification = "This is a dispose method.")]
    public async ValueTask DisposeAsync()
    {
        if (Interlocked.Exchange(
                ref this.disposeSignaled,
                1) !=
            0)
        {
            return;
        }

        GC.SuppressFinalize(this);
        await this.DisposeAsync(true)
            .ConfigureAwait(false);
    }

    #endregion

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    /// <returns>
    ///     A value task representing the completed dispose operation.
    /// </returns>
    protected virtual ValueTask DisposeManagedContextAsync()
    {
        this.DisposeManagedContext();

        return new ValueTask(Task.CompletedTask);
    }

    /// <summary>
    ///     Disposes in the general (managed and unmanaged) context.
    /// </summary>
    /// <returns>
    ///     A value task representing the completed dispose operation.
    /// </returns>
    protected virtual ValueTask DisposeGeneralContextAsync()
    {
        this.DisposeGeneralContext();

        return new ValueTask(Task.CompletedTask);
    }

    /// <summary>
    ///     Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing">
    ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
    ///     unmanaged resources.
    /// </param>
    private async ValueTask DisposeAsync(bool disposing)
    {
        try
        {
            if (disposing)
            {
                this.DisposeAutomatically();

                await this.DisposeManagedContextAsync()
                    .ConfigureAwait(false);
            }

            await this.DisposeGeneralContextAsync()
                .ConfigureAwait(false);
        }
        finally
        {
            this.Disposed = true;
        }
    }

    #endregion
}
#endif