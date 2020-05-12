// <copyright file="Fire.OnThreadPool.Parameters.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;

using IX.StandardExtensions.Contracts;

using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A class that provides methods and extensions to fire events.
    /// </summary>
    public static partial class Fire
    {
#pragma warning disable SA1117 // Parameters should be on same line or separate lines - This is auto-generated code, so we don't really care
#pragma warning disable HAA0303 // Lambda or anonymous method in a generic method allocates a delegate instance - The lambdas themselves rely on generics
        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        /// <remarks><para>On .NET Standard 1.2, due to the way the task scheduler works, it is not a guarantee that the method will run on a separate thread.</para></remarks>
        [NotNull]
        public static Task OnThreadPool<TParam1>(
            [NotNull] Action<TParam1> action,
            TParam1 param1,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1>, Tuple<TParam1>>>(st, nameof(st));

                    (Action<TParam1> actionL1, Tuple<TParam1> unpackedParameters) = (Tuple<Action<TParam1>, Tuple<TParam1>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1);
                },
                new Tuple<Action<TParam1>, Tuple<TParam1>>(action, new Tuple<TParam1>(param1)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1>(
            [NotNull] Action<TParam1, CancellationToken> action,
            TParam1 param1,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, CancellationToken>, Tuple<TParam1>>>(st, nameof(st));

                    (Action<TParam1, CancellationToken> actionL1, Tuple<TParam1> unpackedParameters) = (Tuple<Action<TParam1, CancellationToken>, Tuple<TParam1>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, ct);
                },
                new Tuple<Action<TParam1, CancellationToken>, Tuple<TParam1>>(action, new Tuple<TParam1>(param1)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1>(
            [NotNull] Func<TParam1, Task> action,
            TParam1 param1,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, Task>, Tuple<TParam1>>>(st, nameof(st));

                    (Func<TParam1, Task> actionL1, Tuple<TParam1> unpackedParameters) = (Tuple<Func<TParam1, Task>, Tuple<TParam1>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1);
                },
                new Tuple<Func<TParam1, Task>, Tuple<TParam1>>(action, new Tuple<TParam1>(param1)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1>(
            [NotNull] Func<TParam1, CancellationToken, Task> action,
            TParam1 param1,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, CancellationToken, Task>, Tuple<TParam1>>>(st, nameof(st));

                    (Func<TParam1, CancellationToken, Task> actionL1, Tuple<TParam1> unpackedParameters) = (Tuple<Func<TParam1, CancellationToken, Task>, Tuple<TParam1>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, ct);
                },
                new Tuple<Func<TParam1, CancellationToken, Task>, Tuple<TParam1>>(action, new Tuple<TParam1>(param1)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TResult>(
            [NotNull] Func<TParam1, TResult> action,
            TParam1 param1,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TResult>, Tuple<TParam1>>>(st, nameof(st));

                    (Func<TParam1, TResult> actionL1, Tuple<TParam1> unpackedParameters) = (Tuple<Func<TParam1, TResult>, Tuple<TParam1>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1);
                },
                new Tuple<Func<TParam1, TResult>, Tuple<TParam1>>(action, new Tuple<TParam1>(param1)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TResult>(
            [NotNull] Func<TParam1, CancellationToken, TResult> action,
            TParam1 param1,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, CancellationToken, TResult>, Tuple<TParam1>>>(st, nameof(st));

                    (Func<TParam1, CancellationToken, TResult> actionL1, Tuple<TParam1> unpackedParameters) = (Tuple<Func<TParam1, CancellationToken, TResult>, Tuple<TParam1>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, ct);
                },
                new Tuple<Func<TParam1, CancellationToken, TResult>, Tuple<TParam1>>(action, new Tuple<TParam1>(param1)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TResult>(
            [NotNull] Func<TParam1, Task<TResult>> action,
            TParam1 param1,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, Task<TResult>>, Tuple<TParam1>>>(st, nameof(st));

                    (Func<TParam1, Task<TResult>> actionL1, Tuple<TParam1> unpackedParameters) = (Tuple<Func<TParam1, Task<TResult>>, Tuple<TParam1>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1);
                },
                new Tuple<Func<TParam1, Task<TResult>>, Tuple<TParam1>>(action, new Tuple<TParam1>(param1)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TResult>(
            [NotNull] Func<TParam1, CancellationToken, Task<TResult>> action,
            TParam1 param1,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, CancellationToken, Task<TResult>>, Tuple<TParam1>>>(st, nameof(st));

                    (Func<TParam1, CancellationToken, Task<TResult>> actionL1, Tuple<TParam1> unpackedParameters) = (Tuple<Func<TParam1, CancellationToken, Task<TResult>>, Tuple<TParam1>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, ct);
                },
                new Tuple<Func<TParam1, CancellationToken, Task<TResult>>, Tuple<TParam1>>(action, new Tuple<TParam1>(param1)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        /// <remarks><para>On .NET Standard 1.2, due to the way the task scheduler works, it is not a guarantee that the method will run on a separate thread.</para></remarks>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2>(
            [NotNull] Action<TParam1, TParam2> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2>, Tuple<TParam1, TParam2>>>(st, nameof(st));

                    (Action<TParam1, TParam2> actionL1, Tuple<TParam1, TParam2> unpackedParameters) = (Tuple<Action<TParam1, TParam2>, Tuple<TParam1, TParam2>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2);
                },
                new Tuple<Action<TParam1, TParam2>, Tuple<TParam1, TParam2>>(action, new Tuple<TParam1, TParam2>(param1, param2)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2>(
            [NotNull] Action<TParam1, TParam2, CancellationToken> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, CancellationToken>, Tuple<TParam1, TParam2>>>(st, nameof(st));

                    (Action<TParam1, TParam2, CancellationToken> actionL1, Tuple<TParam1, TParam2> unpackedParameters) = (Tuple<Action<TParam1, TParam2, CancellationToken>, Tuple<TParam1, TParam2>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, ct);
                },
                new Tuple<Action<TParam1, TParam2, CancellationToken>, Tuple<TParam1, TParam2>>(action, new Tuple<TParam1, TParam2>(param1, param2)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2>(
            [NotNull] Func<TParam1, TParam2, Task> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, Task>, Tuple<TParam1, TParam2>>>(st, nameof(st));

                    (Func<TParam1, TParam2, Task> actionL1, Tuple<TParam1, TParam2> unpackedParameters) = (Tuple<Func<TParam1, TParam2, Task>, Tuple<TParam1, TParam2>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2);
                },
                new Tuple<Func<TParam1, TParam2, Task>, Tuple<TParam1, TParam2>>(action, new Tuple<TParam1, TParam2>(param1, param2)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2>(
            [NotNull] Func<TParam1, TParam2, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, CancellationToken, Task>, Tuple<TParam1, TParam2>>>(st, nameof(st));

                    (Func<TParam1, TParam2, CancellationToken, Task> actionL1, Tuple<TParam1, TParam2> unpackedParameters) = (Tuple<Func<TParam1, TParam2, CancellationToken, Task>, Tuple<TParam1, TParam2>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, ct);
                },
                new Tuple<Func<TParam1, TParam2, CancellationToken, Task>, Tuple<TParam1, TParam2>>(action, new Tuple<TParam1, TParam2>(param1, param2)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TResult>(
            [NotNull] Func<TParam1, TParam2, TResult> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TResult>, Tuple<TParam1, TParam2>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TResult> actionL1, Tuple<TParam1, TParam2> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TResult>, Tuple<TParam1, TParam2>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2);
                },
                new Tuple<Func<TParam1, TParam2, TResult>, Tuple<TParam1, TParam2>>(action, new Tuple<TParam1, TParam2>(param1, param2)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TResult>(
            [NotNull] Func<TParam1, TParam2, CancellationToken, TResult> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, CancellationToken, TResult>, Tuple<TParam1, TParam2>>>(st, nameof(st));

                    (Func<TParam1, TParam2, CancellationToken, TResult> actionL1, Tuple<TParam1, TParam2> unpackedParameters) = (Tuple<Func<TParam1, TParam2, CancellationToken, TResult>, Tuple<TParam1, TParam2>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, ct);
                },
                new Tuple<Func<TParam1, TParam2, CancellationToken, TResult>, Tuple<TParam1, TParam2>>(action, new Tuple<TParam1, TParam2>(param1, param2)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TResult>(
            [NotNull] Func<TParam1, TParam2, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, Task<TResult>>, Tuple<TParam1, TParam2>>>(st, nameof(st));

                    (Func<TParam1, TParam2, Task<TResult>> actionL1, Tuple<TParam1, TParam2> unpackedParameters) = (Tuple<Func<TParam1, TParam2, Task<TResult>>, Tuple<TParam1, TParam2>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2);
                },
                new Tuple<Func<TParam1, TParam2, Task<TResult>>, Tuple<TParam1, TParam2>>(action, new Tuple<TParam1, TParam2>(param1, param2)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TResult>(
            [NotNull] Func<TParam1, TParam2, CancellationToken, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2>>>(st, nameof(st));

                    (Func<TParam1, TParam2, CancellationToken, Task<TResult>> actionL1, Tuple<TParam1, TParam2> unpackedParameters) = (Tuple<Func<TParam1, TParam2, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, ct);
                },
                new Tuple<Func<TParam1, TParam2, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2>>(action, new Tuple<TParam1, TParam2>(param1, param2)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        /// <remarks><para>On .NET Standard 1.2, due to the way the task scheduler works, it is not a guarantee that the method will run on a separate thread.</para></remarks>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3>(
            [NotNull] Action<TParam1, TParam2, TParam3> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3>, Tuple<TParam1, TParam2, TParam3>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3> actionL1, Tuple<TParam1, TParam2, TParam3> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3>, Tuple<TParam1, TParam2, TParam3>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3);
                },
                new Tuple<Action<TParam1, TParam2, TParam3>, Tuple<TParam1, TParam2, TParam3>>(action, new Tuple<TParam1, TParam2, TParam3>(param1, param2, param3)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3>(
            [NotNull] Action<TParam1, TParam2, TParam3, CancellationToken> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, CancellationToken>, Tuple<TParam1, TParam2, TParam3>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, CancellationToken> actionL1, Tuple<TParam1, TParam2, TParam3> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, CancellationToken>, Tuple<TParam1, TParam2, TParam3>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, ct);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, CancellationToken>, Tuple<TParam1, TParam2, TParam3>>(action, new Tuple<TParam1, TParam2, TParam3>(param1, param2, param3)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3>(
            [NotNull] Func<TParam1, TParam2, TParam3, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, Task>, Tuple<TParam1, TParam2, TParam3>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, Task> actionL1, Tuple<TParam1, TParam2, TParam3> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, Task>, Tuple<TParam1, TParam2, TParam3>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, Task>, Tuple<TParam1, TParam2, TParam3>>(action, new Tuple<TParam1, TParam2, TParam3>(param1, param2, param3)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3>(
            [NotNull] Func<TParam1, TParam2, TParam3, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, CancellationToken, Task> actionL1, Tuple<TParam1, TParam2, TParam3> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3>>(action, new Tuple<TParam1, TParam2, TParam3>(param1, param2, param3)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TResult>, Tuple<TParam1, TParam2, TParam3>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TResult> actionL1, Tuple<TParam1, TParam2, TParam3> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TResult>, Tuple<TParam1, TParam2, TParam3>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TResult>, Tuple<TParam1, TParam2, TParam3>>(action, new Tuple<TParam1, TParam2, TParam3>(param1, param2, param3)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, CancellationToken, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, CancellationToken, TResult> actionL1, Tuple<TParam1, TParam2, TParam3> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3>>(action, new Tuple<TParam1, TParam2, TParam3>(param1, param2, param3)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, Task<TResult>>, Tuple<TParam1, TParam2, TParam3>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, Task<TResult>>, Tuple<TParam1, TParam2, TParam3>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, Task<TResult>>, Tuple<TParam1, TParam2, TParam3>>(action, new Tuple<TParam1, TParam2, TParam3>(param1, param2, param3)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, CancellationToken, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, CancellationToken, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3>>(action, new Tuple<TParam1, TParam2, TParam3>(param1, param2, param3)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        /// <remarks><para>On .NET Standard 1.2, due to the way the task scheduler works, it is not a guarantee that the method will run on a separate thread.</para></remarks>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4>, Tuple<TParam1, TParam2, TParam3, TParam4>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4>, Tuple<TParam1, TParam2, TParam3, TParam4>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4>, Tuple<TParam1, TParam2, TParam3, TParam4>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4>(param1, param2, param3, param4)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4, CancellationToken> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4, CancellationToken> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, ct);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4>(param1, param2, param3, param4)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, Task>, Tuple<TParam1, TParam2, TParam3, TParam4>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, Task>, Tuple<TParam1, TParam2, TParam3, TParam4>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, Task>, Tuple<TParam1, TParam2, TParam3, TParam4>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4>(param1, param2, param3, param4)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4>(param1, param2, param3, param4)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4>(param1, param2, param3, param4)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4>(param1, param2, param3, param4)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4>(param1, param2, param3, param4)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4>(param1, param2, param3, param4)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        /// <remarks><para>On .NET Standard 1.2, due to the way the task scheduler works, it is not a guarantee that the method will run on a separate thread.</para></remarks>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4, TParam5> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4, TParam5> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>(param1, param2, param3, param4, param5)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, ct);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>(param1, param2, param3, param4, param5)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>(param1, param2, param3, param4, param5)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>(param1, param2, param3, param4, param5)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>(param1, param2, param3, param4, param5)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>(param1, param2, param3, param4, param5)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>(param1, param2, param3, param4, param5)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5>(param1, param2, param3, param4, param5)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        /// <remarks><para>On .NET Standard 1.2, due to the way the task scheduler works, it is not a guarantee that the method will run on a separate thread.</para></remarks>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(param1, param2, param3, param4, param5, param6)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, ct);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(param1, param2, param3, param4, param5, param6)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(param1, param2, param3, param4, param5, param6)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(param1, param2, param3, param4, param5, param6)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(param1, param2, param3, param4, param5, param6)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(param1, param2, param3, param4, param5, param6)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(param1, param2, param3, param4, param5, param6)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(param1, param2, param3, param4, param5, param6)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        /// <remarks><para>On .NET Standard 1.2, due to the way the task scheduler works, it is not a guarantee that the method will run on a separate thread.</para></remarks>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(param1, param2, param3, param4, param5, param6, param7)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, ct);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(param1, param2, param3, param4, param5, param6, param7)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(param1, param2, param3, param4, param5, param6, param7)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(param1, param2, param3, param4, param5, param6, param7)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(param1, param2, param3, param4, param5, param6, param7)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(param1, param2, param3, param4, param5, param6, param7)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(param1, param2, param3, param4, param5, param6, param7)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(param1, param2, param3, param4, param5, param6, param7)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        /// <remarks><para>On .NET Standard 1.2, due to the way the task scheduler works, it is not a guarantee that the method will run on a separate thread.</para></remarks>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, unpackedParameters.Rest);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(param1, param2, param3, param4, param5, param6, param7, param8)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
            [NotNull] Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>>(st, nameof(st));

                    (Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> unpackedParameters) = (Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>)st;

                    ct.ThrowIfCancellationRequested();

                    actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, unpackedParameters.Rest, ct);
                },
                new Tuple<Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(param1, param2, param3, param4, param5, param6, param7, param8)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, unpackedParameters.Rest);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(param1, param2, param3, param4, param5, param6, param7, param8)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, unpackedParameters.Rest, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(param1, param2, param3, param4, param5, param6, param7, param8)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, unpackedParameters.Rest);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(param1, param2, param3, param4, param5, param6, param7, param8)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, TResult> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, TResult> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, unpackedParameters.Rest, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, TResult>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(param1, param2, param3, param4, param5, param6, param7, param8)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, unpackedParameters.Rest);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(param1, param2, param3, param4, param5, param6, param7, param8)),
                cancellationToken);

        /// <summary>
        ///     Starts an action on a thread in the thread pool.
        /// </summary>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The optional cancellation token for the operation.</param>
        /// <returns>The task representing the current asynchronous operation.</returns>
        [NotNull]
        public static Task<TResult> OnThreadPool<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>(
            [NotNull] Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<TResult>> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
                (st, ct) =>
                {
                    Requires.NotNull(st, nameof(st));
                    Requires.ArgumentOfType<Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>>(st, nameof(st));

                    (Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<TResult>> actionL1, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> unpackedParameters) = (Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>)st;

                    ct.ThrowIfCancellationRequested();

                    return actionL1(unpackedParameters.Item1, unpackedParameters.Item2, unpackedParameters.Item3, unpackedParameters.Item4, unpackedParameters.Item5, unpackedParameters.Item6, unpackedParameters.Item7, unpackedParameters.Rest, ct);
                },
                new Tuple<Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task<TResult>>, Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>>(action, new Tuple<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(param1, param2, param3, param4, param5, param6, param7, param8)),
                cancellationToken);
#pragma warning restore HAA0303 // Lambda or anonymous method in a generic method allocates a delegate instance
#pragma warning restore SA1117 // Parameters should be on same line or separate lines

    }
}