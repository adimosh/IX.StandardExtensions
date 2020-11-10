// <copyright file="Work.OnThreadPool.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;
using DiagCA = System.Diagnostics.CodeAnalysis;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    /// Methods and extension methods that aim to simplify working with different threads and thread pools.
    /// </summary>
    [PublicAPI]
    public static class Work
    {
        #region Func with cancellation token, returning task

        /// <summary>
        /// Executes a method accepting a cancellation token on the thread pool.
        /// </summary>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task OnThreadPoolAsync(
            [NotNull] this Func<CancellationToken, Task> methodToInvoke,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<CancellationToken, Task> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<int> tcs, CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<CancellationToken, Task>, CultureInfo,
                            CultureInfo,
                            TaskCompletionSource<int>, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func(ct)
                        .ContinueWith(
                            Continuation,
                            default,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Current);

                    void Continuation(Task completedTask)
                    {
                        if (completedTask.IsCanceled)
                        {
                            tcs.TrySetCanceled(ct);
                        }
                        else if (completedTask.IsFaulted)
                        {
                            tcs.TrySetException(
                                completedTask.Exception?.InnerExceptions ?? (IEnumerable<Exception>)Array.Empty<Exception>());
                        }
                        else
                        {
                            tcs.TrySetResult(0);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func with cancellation token, returning task with value

        /// <summary>
        /// Executes a method accepting a cancellation token on the thread pool.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task<TResult> OnThreadPoolAsync<TResult>(
            [NotNull] this Func<CancellationToken, Task<TResult>> methodToInvoke,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<CancellationToken, Task<TResult>> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs, CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<CancellationToken, Task<TResult>>, CultureInfo,
                            CultureInfo,
                            TaskCompletionSource<TResult>, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func(ct)
                        .ContinueWith(
                            Continuation,
                            default,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Current);

                    void Continuation(Task<TResult> completedTask)
                    {
                        if (completedTask.IsCanceled)
                        {
                            tcs.TrySetCanceled(ct);
                        }
                        else if (completedTask.IsFaulted)
                        {
                            tcs.TrySetException(
                                completedTask.Exception?.InnerExceptions ?? (IEnumerable<Exception>)Array.Empty<Exception>());
                        }
                        else
                        {
                            tcs.TrySetResult(completedTask.Result);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func with payload and cancellation token, returning task

        /// <summary>
        /// Executes a method accepting a cancellation token on the thread pool.
        /// </summary>
        /// <typeparam name="TState">The type of the payload.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="state">The state, or payload, of the invoked method.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task OnThreadPoolAsync<TState>(
            [NotNull] this Func<TState, CancellationToken, Task> methodToInvoke,
            [CanBeNull] TState state,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, state, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<TState, CancellationToken, Task> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<int> tcs, TState payload,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<TState, CancellationToken, Task>, CultureInfo,
                            CultureInfo,
                            TaskCompletionSource<int>, TState, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func(
                            payload,
                            ct)
                        .ContinueWith(
                            Continuation,
                            default,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Current);

                    void Continuation(Task completedTask)
                    {
                        if (completedTask.IsCanceled)
                        {
                            tcs.TrySetCanceled(ct);
                        }
                        else if (completedTask.IsFaulted)
                        {
                            tcs.TrySetException(
                                completedTask.Exception?.InnerExceptions ?? (IEnumerable<Exception>)Array.Empty<Exception>());
                        }
                        else
                        {
                            tcs.TrySetResult(0);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func with payload and cancellation token, returning task with value

        /// <summary>
        /// Executes a method accepting a cancellation token on the thread pool.
        /// </summary>
        /// <typeparam name="TState">The type of the payload.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="state">The state, or payload, of the invoked method.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task<TResult> OnThreadPoolAsync<TState, TResult>(
            [NotNull] this Func<TState, CancellationToken, Task<TResult>> methodToInvoke,
            [CanBeNull] TState state,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, state, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<TState, CancellationToken, Task<TResult>> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs, TState payload,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<TState, CancellationToken, Task<TResult>>, CultureInfo,
                            CultureInfo,
                            TaskCompletionSource<TResult>, TState, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func(
                            payload,
                            ct)
                        .ContinueWith(
                            Continuation,
                            default,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Current);

                    void Continuation(Task<TResult> completedTask)
                    {
                        if (completedTask.IsCanceled)
                        {
                            tcs.TrySetCanceled(ct);
                        }
                        else if (completedTask.IsFaulted)
                        {
                            tcs.TrySetException(
                                completedTask.Exception?.InnerExceptions ?? (IEnumerable<Exception>)Array.Empty<Exception>());
                        }
                        else
                        {
                            tcs.TrySetResult(completedTask.Result);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func with cancellation token, returning value

        /// <summary>
        /// Executes a method accepting a cancellation token on the thread pool.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task<TResult> OnThreadPoolAsync<TResult>(
            [NotNull] this Func<CancellationToken, TResult> methodToInvoke,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<CancellationToken, TResult> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<CancellationToken, TResult>, CultureInfo, CultureInfo,
                            TaskCompletionSource<TResult>, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    TResult innerResult = func(ct);

                    tcs.TrySetResult(innerResult);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func with payload and cancellation token, returning value

        /// <summary>
        /// Executes a method accepting a payload and cancellation token on the thread pool.
        /// </summary>
        /// <typeparam name="TState">The type of the payload.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="state">The state, or payload, of the invoked method.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task<TResult> OnThreadPoolAsync<TState, TResult>(
            [NotNull] this Func<TState, CancellationToken, TResult> methodToInvoke,
            [CanBeNull] TState state,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, state, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<TState, CancellationToken, TResult> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs, TState payload,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<TState, CancellationToken, TResult>, CultureInfo, CultureInfo,
                            TaskCompletionSource<TResult>, TState, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    TResult innerResult = func(
                        payload,
                        ct);

                    tcs.TrySetResult(innerResult);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func, returning task

        /// <summary>
        /// Executes a method on the thread pool.
        /// </summary>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task OnThreadPoolAsync(
            [NotNull] this Func<Task> methodToInvoke,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<Task> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<int> tcs, CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<Task>, CultureInfo,
                            CultureInfo,
                            TaskCompletionSource<int>, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func()
                        .ContinueWith(
                            Continuation,
                            default,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Current);

                    void Continuation(Task completedTask)
                    {
                        if (completedTask.IsCanceled)
                        {
                            tcs.TrySetCanceled(ct);
                        }
                        else if (completedTask.IsFaulted)
                        {
                            tcs.TrySetException(
                                completedTask.Exception?.InnerExceptions ?? (IEnumerable<Exception>)Array.Empty<Exception>());
                        }
                        else
                        {
                            tcs.TrySetResult(0);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func, returning task with value

        /// <summary>
        /// Executes a method on the thread pool.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task<TResult> OnThreadPoolAsync<TResult>(
            [NotNull] this Func<Task<TResult>> methodToInvoke,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<Task<TResult>> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs, CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<Task<TResult>>, CultureInfo,
                            CultureInfo,
                            TaskCompletionSource<TResult>, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func()
                        .ContinueWith(
                            Continuation,
                            default,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Current);

                    void Continuation(Task<TResult> completedTask)
                    {
                        if (completedTask.IsCanceled)
                        {
                            tcs.TrySetCanceled(ct);
                        }
                        else if (completedTask.IsFaulted)
                        {
                            tcs.TrySetException(
                                completedTask.Exception?.InnerExceptions ?? (IEnumerable<Exception>)Array.Empty<Exception>());
                        }
                        else
                        {
                            tcs.TrySetResult(completedTask.Result);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func with payload, returning task

        /// <summary>
        /// Executes a method accepting a payload on the thread pool.
        /// </summary>
        /// <typeparam name="TState">The type of the payload.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="state">The state, or payload, of the invoked method.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task OnThreadPoolAsync<TState>(
            [NotNull] this Func<TState, Task> methodToInvoke,
            [CanBeNull] TState state,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, state, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<TState, Task> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<int> tcs, TState payload,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<TState, Task>, CultureInfo,
                            CultureInfo,
                            TaskCompletionSource<int>, TState, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func(payload)
                        .ContinueWith(
                            Continuation,
                            default,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Current);

                    void Continuation(Task completedTask)
                    {
                        if (completedTask.IsCanceled)
                        {
                            tcs.TrySetCanceled(ct);
                        }
                        else if (completedTask.IsFaulted)
                        {
                            tcs.TrySetException(
                                completedTask.Exception?.InnerExceptions ?? (IEnumerable<Exception>)Array.Empty<Exception>());
                        }
                        else
                        {
                            tcs.TrySetResult(0);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func with payload, returning task with value

        /// <summary>
        /// Executes a method accepting a payload on the thread pool.
        /// </summary>
        /// <typeparam name="TState">The type of the payload.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="state">The state, or payload, of the invoked method.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task<TResult> OnThreadPoolAsync<TState, TResult>(
            [NotNull] this Func<TState, Task<TResult>> methodToInvoke,
            [CanBeNull] TState state,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, state, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<TState, Task<TResult>> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs, TState payload,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<TState, Task<TResult>>, CultureInfo,
                            CultureInfo,
                            TaskCompletionSource<TResult>, TState, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func(payload)
                        .ContinueWith(
                            Continuation,
                            default,
                            TaskContinuationOptions.ExecuteSynchronously,
                            TaskScheduler.Current);

                    void Continuation(Task<TResult> completedTask)
                    {
                        if (completedTask.IsCanceled)
                        {
                            tcs.TrySetCanceled(ct);
                        }
                        else if (completedTask.IsFaulted)
                        {
                            tcs.TrySetException(
                                completedTask.Exception?.InnerExceptions ?? (IEnumerable<Exception>)Array.Empty<Exception>());
                        }
                        else
                        {
                            tcs.TrySetResult(completedTask.Result);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func, returning value

        /// <summary>
        /// Executes a method on the thread pool.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task<TResult> OnThreadPoolAsync<TResult>(
            [NotNull] this Func<TResult> methodToInvoke,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<TResult> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<TResult>, CultureInfo, CultureInfo,
                            TaskCompletionSource<TResult>, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    TResult innerResult = func();

                    tcs.TrySetResult(innerResult);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Func with payload, returning value

        /// <summary>
        /// Executes a method accepting a payload on the thread pool.
        /// </summary>
        /// <typeparam name="TState">The type of the payload.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="state">The state, or payload, of the invoked method.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing the result of the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task<TResult> OnThreadPoolAsync<TState, TResult>(
            [NotNull] this Func<TState, TResult> methodToInvoke,
            [CanBeNull] TState state,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<TResult>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, state, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Func<TState, TResult> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<TResult> tcs, TState payload,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Func<TState, TResult>, CultureInfo, CultureInfo,
                            TaskCompletionSource<TResult>, TState, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    TResult innerResult = func(payload);

                    tcs.TrySetResult(innerResult);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Action with payload and cancellation token

        /// <summary>
        /// Executes a method accepting a payload and cancellation token on the thread pool.
        /// </summary>
        /// <typeparam name="TState">The type of the payload.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="state">The state, or payload, of the invoked method.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing representing the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task OnThreadPoolAsync<TState>(
            [NotNull] this Action<TState, CancellationToken> methodToInvoke,
            [CanBeNull] TState state,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, state, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Action<TState, CancellationToken> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<int> tcs, TState payload,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Action<TState, CancellationToken>, CultureInfo, CultureInfo,
                            TaskCompletionSource<int>, TState, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func(
                        payload,
                        ct);

                    tcs.TrySetResult(0);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Action with cancellation token

        /// <summary>
        /// Executes a method accepting a cancellation token on the thread pool.
        /// </summary>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing representing the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task OnThreadPoolAsync(
            [NotNull] this Action<CancellationToken> methodToInvoke,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Action<CancellationToken> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<int> tcs,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Action<CancellationToken>, CultureInfo, CultureInfo,
                            TaskCompletionSource<int>, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func(ct);

                    tcs.TrySetResult(0);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Action with payload

        /// <summary>
        /// Executes a method accepting a payload on the thread pool.
        /// </summary>
        /// <typeparam name="TState">The type of the payload.</typeparam>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="state">The state, or payload, of the invoked method.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing representing the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task OnThreadPoolAsync<TState>(
            [NotNull] this Action<TState> methodToInvoke,
            [CanBeNull] TState state,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, state, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Action<TState> func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<int> tcs, TState payload,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Action<TState>, CultureInfo, CultureInfo,
                            TaskCompletionSource<int>, TState, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func(payload);

                    tcs.TrySetResult(0);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion

        #region Action

        /// <summary>
        /// Executes a method on the thread pool.
        /// </summary>
        /// <param name="methodToInvoke">The method to invoke.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task containing representing the executed method.</returns>
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [DiagCA.SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "This is unavoidable because of thread switching.")]
        [DiagCA.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "It is OK to catch, as we're setting it in the task.")]
        [NotNull]
        public static Task OnThreadPoolAsync(
            [NotNull] this Action methodToInvoke,
            CancellationToken cancellationToken = default)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            if (cancellationToken.IsCancellationRequested)
            {
                taskCompletionSource.TrySetCanceled(cancellationToken);
                return taskCompletionSource.Task;
            }

            ThreadPool.QueueUserWorkItem(
                WorkItem,
                (methodToInvoke, CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture, taskCompletionSource, cancellationToken));

            static void WorkItem(object rawState)
            {
                (Action func, CultureInfo currentCulture,
                        CultureInfo currentUiCulture, TaskCompletionSource<int> tcs,
                        CancellationToken ct) =
                    Requires.ArgumentOfType<(Action, CultureInfo, CultureInfo,
                            TaskCompletionSource<int>, CancellationToken)>(
                            rawState,
                            nameof(rawState));

                if (ct.IsCancellationRequested)
                {
                    tcs.TrySetCanceled(ct);
                    return;
                }

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;

                try
                {
                    func();

                    tcs.TrySetResult(0);
                }
                catch (OperationCanceledException)
                {
                    tcs.TrySetCanceled(ct);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }

            return taskCompletionSource.Task;
        }

        #endregion
    }
}