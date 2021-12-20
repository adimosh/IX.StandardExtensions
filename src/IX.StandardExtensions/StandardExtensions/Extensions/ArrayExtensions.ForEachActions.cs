// <copyright file="ArrayExtensions.ForEachActions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    ///     Extensions for array types.
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     Executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        public static void ForEach<TItem, TParam1>(
            this TItem[] source,
            Action<TItem, TParam1> action,
            TParam1 param1)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            for (var i = 0; i < source.Length; i++)
            {
                action(source[i], param1);
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1>(
            this TItem[] source,
            Func<TItem, TParam1, Task> action,
            TParam1 param1,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1>(
            this TItem[] source,
            Func<TItem, TParam1, ValueTask> action,
            TParam1 param1,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1>(
            this TItem[] source,
            Func<TItem, TParam1, CancellationToken, Task> action,
            TParam1 param1,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1>(
            this TItem[] source,
            Func<TItem, TParam1, CancellationToken, ValueTask> action,
            TParam1 param1,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        public static void ForEach<TItem, TParam1, TParam2>(
            this TItem[] source,
            Action<TItem, TParam1, TParam2> action,
            TParam1 param1,
            TParam2 param2)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            for (var i = 0; i < source.Length; i++)
            {
                action(source[i], param1, param2);
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, Task> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, CancellationToken, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        public static void ForEach<TItem, TParam1, TParam2, TParam3>(
            this TItem[] source,
            Action<TItem, TParam1, TParam2, TParam3> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            for (var i = 0; i < source.Length; i++)
            {
                action(source[i], param1, param2, param3);
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, CancellationToken, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4>(
            this TItem[] source,
            Action<TItem, TParam1, TParam2, TParam3, TParam4> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            for (var i = 0; i < source.Length; i++)
            {
                action(source[i], param1, param2, param3, param4);
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, CancellationToken, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
            this TItem[] source,
            Action<TItem, TParam1, TParam2, TParam3, TParam4, TParam5> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            for (var i = 0; i < source.Length; i++)
            {
                action(source[i], param1, param2, param3, param4, param5);
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, CancellationToken, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            this TItem[] source,
            Action<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            for (var i = 0; i < source.Length; i++)
            {
                action(source[i], param1, param2, param3, param4, param5, param6);
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, CancellationToken, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
            this TItem[] source,
            Action<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            for (var i = 0; i < source.Length; i++)
            {
                action(source[i], param1, param2, param3, param4, param5, param6, param7);
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, param7);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, param7);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, param7, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, CancellationToken, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, param7, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
            this TItem[] source,
            Action<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            for (var i = 0; i < source.Length; i++)
            {
                action(source[i], param1, param2, param3, param4, param5, param6, param7, param8);
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, param7, param8);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, param7, param8);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, Task> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        ///     Asynchronously executes an action for each one of the elements of an array.
        /// </summary>
        /// <typeparam name="TItem">The array type.</typeparam>
        /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
        /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
        /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
        /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
        /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
        /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
        /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
        /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
        /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
        /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
        /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
        /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
        /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
        /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
        /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="source" /> or <paramref name="action" /> is
        ///     <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).
        /// </exception>
        /// <remarks>
        ///     <para>This method, due to multiple awaits, is considered to be very slow compared to its synchronous version.</para>
        ///     <para>Please make sure to only use this where asynchronicity is required.</para>
        ///     <para>In CPU-intensive operations, only its synchronous counterpart should be used.</para>
        /// </remarks>
        public static async ValueTask ForEachAsync<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
            this TItem[] source,
            Func<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, CancellationToken, ValueTask> action,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(source);
            Requires.NotNull(action);

            if (cancellationToken.IsCancellationRequested) return;

            for (var i = 0; i < source.Length; i++)
            {
                await action(source[i], param1, param2, param3, param4, param5, param6, param7, param8, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}