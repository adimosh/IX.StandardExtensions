// <copyright file="DisposableBase.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Runtime.Serialization;
using System.Threading;
using IX.CodeGeneration;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;
using DiagCA = System.Diagnostics.CodeAnalysis;

namespace IX.StandardExtensions.ComponentModel
{
    /// <summary>
    ///     An abstract base class for correctly implementing the disposable pattern.
    /// </summary>
    /// <seealso cref="IDisposable" />
    [DataContract(Namespace = Constants.DataContractNamespace)]
    [PublicAPI]
    [DiagCA.SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP025:Class with no virtual dispose method should be sealed.",
        Justification = "The pattern is not followed here, because, instead of overriding Dispose, one can and should override the two (managed and general) methods.")]
    public abstract partial class DisposableBase : IDisposable
    {
        /// <summary>
        ///     The thread-safe dispose signal.
        /// </summary>
        private volatile int disposeSignaled;

        /// <summary>
        ///     Finalizes an instance of the <see cref="DisposableBase" /> class.
        /// </summary>
        ~DisposableBase()
        {
            this.Dispose(false);
        }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="DisposableBase" /> is disposed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if disposed; otherwise, <c>false</c>.
        /// </value>
        internal bool Disposed { get; private set; }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (Interlocked.Exchange(
                ref this.disposeSignaled,
                1) != 0)
            {
                return;
            }

            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        /// <summary>
        ///     Throws if the current object is disposed.
        /// </summary>
        /// <exception cref="ObjectDisposedException">If the current object is disposed, this exception will be thrown.</exception>
        protected internal void ThrowIfCurrentObjectDisposed()
        {
            if (this.Disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }

        /// <summary>
        /// Used to automatically dispose objects marked with the <see cref="AutoDisposableMemberAttribute" /> by code generation.
        /// This method should not be overridden by user code.
        /// </summary>
        protected virtual void DisposeAutomatically()
        {
        }

        /// <summary>
        ///     Invokes an action if the current instance is not disposed.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="action" /> is <see langword="null" /> (
        ///     <see langword="Nothing" /> in Visual Basic).
        /// </exception>
        protected void InvokeIfNotDisposed(Action action)
        {
            this.RequiresNotDisposed();

            Requires.NotNull(action, nameof(action))();
        }

        /// <summary>
        ///     Invokes an action if the current instance is not disposed.
        /// </summary>
        /// <typeparam name="TReturn">The return type.</typeparam>
        /// <param name="func">The function to invoke.</param>
        /// <returns>The object returned by the action.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="func" /> is <see langword="null" /> (
        ///     <see langword="Nothing" /> in Visual Basic).
        /// </exception>
        protected TReturn InvokeIfNotDisposed<TReturn>(Func<TReturn> func)
        {
            this.ThrowIfCurrentObjectDisposed();

            return Requires.NotNull(func, nameof(func))();
        }

        /// <summary>
        ///     Disposes in the managed context.
        /// </summary>
        protected virtual void DisposeManagedContext()
        {
        }

        /// <summary>
        ///     Disposes in the general (managed and unmanaged) context.
        /// </summary>
        protected virtual void DisposeGeneralContext()
        {
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        [DiagCA.SuppressMessage(
            "Design",
            "CA1063:Implement IDisposable Correctly",
            Justification = "The analyzer can't really tell what we're doing here.")]
        [DiagCA.SuppressMessage(
            "ReSharper",
            "FlagArgument",
            Justification = "This method signature is the standard for the disposable pattern.")]
        [DiagCA.SuppressMessage(
            "CodeQuality",
            "IDE0079:Remove unnecessary suppression",
            Justification = "Suppressions are justified for ReSharper. This was added for those that don't have it.")]
        private void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    this.DisposeAutomatically();

                    this.DisposeManagedContext();
                }

                this.DisposeGeneralContext();
            }
            finally
            {
                this.Disposed = true;
            }
        }
    }
}