// <copyright file="DisposableBase.netstandard2.1.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;

namespace IX.StandardExtensions.ComponentModel
{
#if NETSTANDARD2_1
    /// <summary>
    ///     An abstract base class for correctly implementing the disposable pattern.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public abstract partial class DisposableBase : IAsyncDisposable
    {
        /// <summary>
        ///     Asynchronously performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <returns>
        ///     A value task represengint the completed dispose operation.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
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

        /// <summary>
        ///     Disposes in the managed context.
        /// </summary>
        /// <returns>
        ///     A value task represengint the completed dispose operation.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "AsyncUsage.CSharp.Naming",
            "AvoidAsyncSuffix:Avoid Async suffix",
            Justification = "The naming is correct, but the analyzer can't tell.")]
        protected virtual ValueTask DisposeManagedContextAsync()
        {
            this.DisposeManagedContext();

            return new ValueTask(Task.CompletedTask);
        }

        /// <summary>
        ///     Disposes in the general (managed and unmanaged) context.
        /// </summary>
        /// <returns>
        ///     A value task represengint the completed dispose operation.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "AsyncUsage.CSharp.Naming",
            "AvoidAsyncSuffix:Avoid Async suffix",
            Justification = "The naming is correct, but the analyzer can't tell.")]
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
    }
#endif
}