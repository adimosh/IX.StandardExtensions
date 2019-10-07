// <copyright file="Fire.ExecuteOnThreadPool.Void.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A class that provides methods and extensions to fire events.
    /// </summary>
    public partial class Fire
    {
        private static Task ExecuteOnThreadPool(
            Func<Task> action,
            CancellationToken cancellationToken = default) =>
            ExecuteOnThreadPool(
#pragma warning disable HAA0301 // Closure Allocation Source
                (
                    st,
                    ct) =>
#pragma warning restore HAA0301 // Closure Allocation Source
                {
                    Contract.RequiresNotNullPrivate(
                        in st,
                        nameof(st));
                    Contract.RequiresArgumentOfTypePrivate<Func<Task>>(
                        st,
                        nameof(st));

                    ct.ThrowIfCancellationRequested();

#pragma warning disable HAA0302 // Display class allocation to capture closure
                    var tcs = new TaskCompletionSource<int>();
#pragma warning restore HAA0302 // Display class allocation to capture closure
#pragma warning disable HAA0603 // Delegate allocation from a method group
                    ((Func<Task>)st)().ContinueWith(Continuation, TaskContinuationOptions.ExecuteSynchronously);
#pragma warning restore HAA0603 // Delegate allocation from a method group

                    void Continuation(Task completedTask)
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
                            tcs.TrySetResult(0);
                        }
                    }

                    return tcs.Task;
                }, action,
                cancellationToken);

        private static Task ExecuteOnThreadPool(
            Func<CancellationToken, Task> action,
            CancellationToken cancellationToken = default) =>
            ExecuteOnThreadPool(
#pragma warning disable HAA0301 // Closure Allocation Source
                (
                    st,
                    ct) =>
#pragma warning restore HAA0301 // Closure Allocation Source
                {
                    Contract.RequiresNotNullPrivate(
                        in st,
                        nameof(st));
                    Contract.RequiresArgumentOfTypePrivate<Func<CancellationToken, Task>>(
                        st,
                        nameof(st));

#pragma warning disable HAA0302 // Display class allocation to capture closure
                    var tcs = new TaskCompletionSource<int>();
#pragma warning restore HAA0302 // Display class allocation to capture closure
#pragma warning disable HAA0603 // Delegate allocation from a method group
                    ((Func<CancellationToken, Task>)st)(ct).ContinueWith(Continuation, TaskContinuationOptions.ExecuteSynchronously);
#pragma warning restore HAA0603 // Delegate allocation from a method group

                    void Continuation(Task completedTask)
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
                            tcs.TrySetResult(0);
                        }
                    }

                    return tcs.Task;
                }, action,
                cancellationToken);

        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            Func<Task<TResult>> action,
            CancellationToken cancellationToken = default) =>
            ExecuteOnThreadPool(
                (
                    st,
                    ct) =>
                {
                    Contract.RequiresNotNullPrivate(
                        in st,
                        nameof(st));
                    Contract.RequiresArgumentOfTypePrivate<Func<Task<TResult>>>(
                        st,
                        nameof(st));

                    ct.ThrowIfCancellationRequested();

                    return ((Func<Task<TResult>>)st)();
                }, action,
                cancellationToken);

        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            Func<CancellationToken, Task<TResult>> action,
            CancellationToken cancellationToken = default) =>
            ExecuteOnThreadPool(
                (
                    st,
                    ct) =>
                {
                    Contract.RequiresNotNullPrivate(
                        in st,
                        nameof(st));
                    Contract.RequiresArgumentOfTypePrivate<Func<CancellationToken, Task<TResult>>>(
                        st,
                        nameof(st));

                    return ((Func<CancellationToken, Task<TResult>>)st)(ct);
                }, action,
                cancellationToken);

        private static Task ExecuteOnThreadPool(
            Func<object, Task> action,
            object state,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
#pragma warning disable HAA0301 // Closure Allocation Source
            (
                st,
                ct) =>
#pragma warning restore HAA0301 // Closure Allocation Source
            {
                Contract.RequiresNotNullPrivate(
                    in st,
                    nameof(st));
                Contract.RequiresArgumentOfTypePrivate<Tuple<Func<object, Task>, object>>(
                    st,
                    nameof(st));

                var innerState = (Tuple<Func<object, Task>, object>)st;
#pragma warning disable HAA0302 // Display class allocation to capture closure
                var tcs = new TaskCompletionSource<int>();
#pragma warning restore HAA0302 // Display class allocation to capture closure
#pragma warning disable HAA0603 // Delegate allocation from a method group
                innerState.Item1(innerState.Item2).ContinueWith(Continuation, TaskContinuationOptions.ExecuteSynchronously);
#pragma warning restore HAA0603 // Delegate allocation from a method group

                void Continuation(Task completedTask)
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
                        tcs.TrySetResult(0);
                    }
                }

                return tcs.Task;
            }, new Tuple<Func<object, Task>, object>(
                action,
                state), cancellationToken);

        private static Task ExecuteOnThreadPool(
            Func<object, CancellationToken, Task> action,
            object state,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
#pragma warning disable HAA0301 // Closure Allocation Source
            (
                st,
                ct) =>
#pragma warning restore HAA0301 // Closure Allocation Source
            {
                Contract.RequiresNotNullPrivate(
                    in st,
                    nameof(st));
                Contract.RequiresArgumentOfTypePrivate<Tuple<Func<object, CancellationToken, Task>, object>>(
                    st,
                    nameof(st));

                var innerState = (Tuple<Func<object, CancellationToken, Task>, object>)st;
#pragma warning disable HAA0302 // Display class allocation to capture closure
                var tcs = new TaskCompletionSource<int>();
#pragma warning restore HAA0302 // Display class allocation to capture closure
#pragma warning disable HAA0603 // Delegate allocation from a method group
                innerState.Item1(
                    innerState.Item2,
                    ct).ContinueWith(Continuation, TaskContinuationOptions.ExecuteSynchronously);
#pragma warning restore HAA0603 // Delegate allocation from a method group

                void Continuation(Task completedTask)
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
                        tcs.TrySetResult(0);
                    }
                }

                return tcs.Task;
            }, new Tuple<Func<object, CancellationToken, Task>, object>(
                action,
                state), cancellationToken);

#pragma warning disable HAA0303 // Lambda or anonymous method in a generic method allocates a delegate instance
        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            Func<object, Task<TResult>> action,
            object state,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
            (
                st,
                ct) =>
            {
                Contract.RequiresNotNullPrivate(
                    in st,
                    nameof(st));
                Contract.RequiresArgumentOfTypePrivate<Tuple<Func<object, Task<TResult>>, object>>(
                    st,
                    nameof(st));

                ct.ThrowIfCancellationRequested();

                var innerState = (Tuple<Func<object, Task<TResult>>, object>)st;

                return innerState.Item1(innerState.Item2);
            }, new Tuple<Func<object, Task<TResult>>, object>(
                action,
                state), cancellationToken);
#pragma warning restore HAA0303 // Lambda or anonymous method in a generic method allocates a delegate instance
    }
}