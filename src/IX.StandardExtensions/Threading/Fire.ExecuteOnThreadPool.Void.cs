// <copyright file="Fire.ExecuteOnThreadPool.Void.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
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
        [NotNull]
        private static Task ExecuteOnThreadPool(
            [NotNull] Func<CancellationToken, Task> action,
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

        [NotNull]
        private static Task ExecuteOnThreadPool(
            [NotNull] Func<object, CancellationToken, Task> action,
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
    }
}