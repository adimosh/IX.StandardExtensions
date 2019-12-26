// <copyright file="Fire.ExecuteOnThreadPool.BaseFunctions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A class that provides methods and extensions to fire events.
    /// </summary>
    public partial class Fire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [NotNull]
        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            [NotNull] Func<object?, CancellationToken, Task<TResult>> action,
            [CanBeNull] object? state,
            CancellationToken cancellationToken = default)
        {
            Contract.RequiresNotNullPrivate(
                in action,
                nameof(action));

            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
                return taskCompletionSource.Task;
            }

            var outerState =
                new Tuple<Func<object?, CancellationToken, Task<TResult>>, CultureInfo, CultureInfo,
                    TaskCompletionSource<TResult>, object?, CancellationToken>(
                    action,
                    CultureInfo.CurrentCulture,
                    CultureInfo.CurrentUICulture,
                    taskCompletionSource,
                    state,
                    cancellationToken);

#if !NETSTANDARD2_1
            ThreadPool.QueueUserWorkItem(
                WorkItem,
                outerState);
#else
            ThreadPool.QueueUserWorkItem(
                WorkItem,
                outerState,
                false);
#endif

#if !NETSTANDARD2_1
            void WorkItem(object rawState)
            {
                Contract
                    .RequiresArgumentOfTypePrivate<
                        Tuple<Func<object?, CancellationToken, Task<TResult>>, CultureInfo, CultureInfo,
                            TaskCompletionSource<TResult>, object?, CancellationToken>>(
                        rawState,
                        nameof(rawState));

                var (func, currentCulture, currentUiCulture, tcs, payload, ct) = (Tuple<Func<object?, CancellationToken, Task<TResult>>, CultureInfo, CultureInfo,
                    TaskCompletionSource<TResult>, object?, CancellationToken>)rawState;
#else
            void WorkItem(Tuple<Func<object?, CancellationToken, Task<TResult>>, CultureInfo, CultureInfo,
                TaskCompletionSource<TResult>, object?, CancellationToken> rawState)
            {
                (Func<object?, CancellationToken, Task<TResult>> func, CultureInfo currentCulture,
                    CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs, object? payload,
                    CancellationToken ct) = rawState;
#endif

                Contract.RequiresNotNullPrivate(
                    in rawState,
                    nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled();
                    return;
                }

#if NET452
#pragma warning disable DE0008 // API is deprecated - This is an acceptable use, since we're writing on what's guaranteed to be the current thread
                Thread.CurrentThread.CurrentCulture = currentCulture;
                Thread.CurrentThread.CurrentUICulture = currentUiCulture;
#pragma warning restore DE0008 // API is deprecated
#else
                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;
#endif

                try
                {
                    func(
                        payload,
                        ct).ContinueWith(Continuation, TaskContinuationOptions.ExecuteSynchronously);

                    void Continuation(Task<TResult> completedTask)
                    {
                        if (completedTask.IsCanceled)
                        {
                            tcs.TrySetCanceled();
                        }
                        else if (completedTask.IsFaulted)
                        {
                            tcs.TrySetException(completedTask.Exception?.InnerExceptions ?? (IEnumerable<Exception>)new Exception[0]);
                        }
                        else
                        {
                            tcs.TrySetResult(completedTask.Result);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled();
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [NotNull]
        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            [NotNull] Func<object?, CancellationToken, TResult> action,
            [CanBeNull] object? state,
            CancellationToken cancellationToken = default)
        {
            Contract.RequiresNotNullPrivate(
                in action,
                nameof(action));

            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled();
                return taskCompletionSource.Task;
            }

            var outerState =
                new Tuple<Func<object?, CancellationToken, TResult>, CultureInfo, CultureInfo,
                    TaskCompletionSource<TResult>, object?, CancellationToken>(
                    action,
                    CultureInfo.CurrentCulture,
                    CultureInfo.CurrentUICulture,
                    taskCompletionSource,
                    state,
                    cancellationToken);

#if !NETSTANDARD2_1
            ThreadPool.QueueUserWorkItem(
                WorkItem,
                outerState);
#else
            ThreadPool.QueueUserWorkItem(
                WorkItem,
                outerState,
                false);
#endif

#if !NETSTANDARD2_1
            static void WorkItem(object rawState)
            {
                Contract
                    .RequiresArgumentOfTypePrivate<
                        Tuple<Func<object?, CancellationToken, TResult>, CultureInfo, CultureInfo,
                            TaskCompletionSource<TResult>, object?, CancellationToken>>(
                        rawState,
                        nameof(rawState));
                Contract.RequiresNotNullPrivate(
                    in rawState,
                    nameof(rawState));

                var (func, currentCulture, currentUiCulture, tcs, payload, ct) =
                    (Tuple<Func<object?, CancellationToken, TResult>, CultureInfo, CultureInfo,
                        TaskCompletionSource<TResult>, object?, CancellationToken>)rawState;
#else
            static void WorkItem(Tuple<Func<object?, CancellationToken, TResult>, CultureInfo, CultureInfo,
                TaskCompletionSource<TResult>, object?, CancellationToken> rawState)
            {
                Contract.RequiresNotNullPrivate(
                    in rawState,
                    nameof(rawState));

                (Func<object?, CancellationToken, TResult> func, CultureInfo currentCulture,
                    CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs, object? payload,
                    CancellationToken ct) = rawState;
#endif

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled();
                    return;
                }

#if NET452
#pragma warning disable DE0008 // API is deprecated - This is an acceptable use, since we're writing on what's guaranteed to be the current thread
                Thread.CurrentThread.CurrentCulture = currentCulture;
                Thread.CurrentThread.CurrentUICulture = currentUiCulture;
#pragma warning restore DE0008 // API is deprecated
#else
                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;
#endif

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled();
                    return;
                }

                try
                {
                    TResult innerResult = func(
                        payload,
                        ct);

                    tcs.TrySetResult(innerResult);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled();
                }
            }

            return taskCompletionSource.Task;
        }
    }
}