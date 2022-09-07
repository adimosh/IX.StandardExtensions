// <copyright file="SynchronizationContextInvokerBase.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Threading;
using JetBrains.Annotations;

namespace IX.StandardExtensions.ComponentModel;

/// <summary>
///     An abstract base class for a synchronization context invoker.
/// </summary>
/// <seealso cref="DisposableBase" />
[PublicAPI]
public abstract partial class SynchronizationContextInvokerBase : DisposableBase,
    INotifyThreadException
{
#region Internal state

    private SynchronizationContext? synchronizationContext;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="SynchronizationContextInvokerBase" /> class.
    /// </summary>
    protected SynchronizationContextInvokerBase()
        : this(null) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="SynchronizationContextInvokerBase" /> class.
    /// </summary>
    /// <param name="synchronizationContext">The specific synchronization context to use.</param>
    protected SynchronizationContextInvokerBase(SynchronizationContext? synchronizationContext) => this.synchronizationContext = synchronizationContext;

#endregion

#region Events

    /// <summary>
    ///     Triggered when an exception has occurred on a different thread.
    /// </summary>
    public event EventHandler<ExceptionOccurredEventArgs>? ExceptionOccurredOnSeparateThread;

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the synchronization context used by this object, if any.
    /// </summary>
    /// <value>The synchronization context.</value>
    public SynchronizationContext? SynchronizationContext => synchronizationContext;

#endregion

#region Methods

#region Disposable

    /// <summary>
    ///     Disposes in the general (managed and unmanaged) context.
    /// </summary>
    protected override void DisposeGeneralContext()
    {
        _ = Interlocked.Exchange(
            ref synchronizationContext,
            null);

        base.DisposeGeneralContext();
    }

#endregion

    /// <summary>
    ///     Invokes the specified action using the synchronization context, or on either this thread or a separate thread if
    ///     there is no synchronization context available.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    protected void Invoke(Action action) =>
        Invoke(
            p => p(),
            action);

    /// <summary>
    ///     Invokes the specified action using the synchronization context, or on either this thread or a separate thread if
    ///     there is no synchronization context available.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    /// <param name="state">The state object to pass on to the action.</param>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Appears to be unavoidable at this time.")]
    protected void Invoke(
        Action<object> action,
        object state)
    {
        ThrowIfCurrentObjectDisposed();

        _ = Requires.NotNull(
            action);

        SynchronizationContext? currentSynchronizationContext =
            synchronizationContext ?? EnvironmentSettings.GetUsableSynchronizationContext();

        if (currentSynchronizationContext == null)
        {
            if (EnvironmentSettings.InvokeAsynchronously)
            {
                _ = action.OnThreadPoolAsync(state);
            }
            else
            {
                action(state);
            }
        }
        else
        {
            var outerState = new Tuple<Action<object>, object>(
                action,
                state);
            if (EnvironmentSettings.InvokeAsynchronously)
            {
                currentSynchronizationContext.Post(
                    SendOrPost,
                    outerState);
            }
            else
            {
                currentSynchronizationContext.Send(
                    SendOrPost,
                    outerState);
            }
        }
    }

    /// <summary>
    ///     Invokes the specified action by posting on the synchronization context, or on a separate thread if
    ///     there is no synchronization context available.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    protected void InvokePost(Action action) =>
        InvokePost(
            p => p(),
            action);

    /// <summary>
    ///     Invokes the specified action by posting on the synchronization context, or on a separate thread if
    ///     there is no synchronization context available.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    /// <param name="state">The state object to pass on to the action.</param>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Appears to be unavoidable at this time.")]
    protected void InvokePost(
        Action<object> action,
        object state)
    {
        ThrowIfCurrentObjectDisposed();

        _ = Requires.NotNull(
            action);

        SynchronizationContext? currentSynchronizationContext =
            synchronizationContext ?? EnvironmentSettings.GetUsableSynchronizationContext();

        if (currentSynchronizationContext == null)
        {
            _ = action.OnThreadPoolAsync(state);
        }
        else
        {
            var outerState = new Tuple<Action<object>, object>(
                action,
                state);

            currentSynchronizationContext.Post(
                SendOrPost,
                outerState);
        }
    }

    /// <summary>
    ///     Invokes the specified action synchronously using the synchronization context, or on this thread if
    ///     there is no synchronization context available.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    protected void InvokeSend(Action action) =>
        InvokeSend(
            p => p(),
            action);

    /// <summary>
    ///     Invokes the specified action synchronously using the synchronization context, or on this thread if
    ///     there is no synchronization context available.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    /// <param name="state">The state object to pass on to the action.</param>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Appears to be unavoidable at this time.")]
    protected void InvokeSend(
        Action<object> action,
        object state)
    {
        ThrowIfCurrentObjectDisposed();

        _ = Requires.NotNull(
            action);

        SynchronizationContext? currentSynchronizationContext =
            synchronizationContext ?? EnvironmentSettings.GetUsableSynchronizationContext();

        if (currentSynchronizationContext == null)
        {
            action(state);
        }
        else
        {
            var outerState = new Tuple<Action<object>, object>(
                action,
                state);

            currentSynchronizationContext.Send(
                SendOrPost,
                outerState);
        }
    }

    /// <summary>
    ///     Invokes the <see cref="ExceptionOccurredOnSeparateThread" /> event in a safe manner, while ignoring any processing
    ///     exceptions.
    /// </summary>
    /// <param name="ex">The ex.</param>
    protected void InvokeExceptionOccurredOnSeparateThread(Exception ex) =>
        ExceptionOccurredOnSeparateThread?.Invoke(
            this,
            new ExceptionOccurredEventArgs(ex));

    [SuppressMessage(
        "Design",
        "CA1031:Do not catch general exception types",
        Justification = "We specifically do not want to do that.")]
    private void SendOrPost(object? innerState)
    {
        (Action<object> action, var state) = Requires.ArgumentOfType<Tuple<Action<object>, object>>(innerState);

        try
        {
            action(state);
        }
        catch (Exception ex)
        {
            InvokeExceptionOccurredOnSeparateThread(ex);
        }
    }

#endregion
}