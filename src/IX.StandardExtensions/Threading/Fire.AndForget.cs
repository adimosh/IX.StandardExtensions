// <copyright file="Fire.AndForget.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A class that provides methods and extensions to fire events.
    /// </summary>
    [PublicAPI]
    public static partial class Fire
    {
#pragma warning disable HAA0603 // Delegate allocation from a method group - This is acceptable
        /// <summary>
        ///     Fires a method on a separate thread, and forgets about it completely, only invoking a continuation if there was an
        ///     exception.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Obsolete("Please use the methods in class Work.")]
        public static void AndForget(
            [NotNull] Action action,
            CancellationToken cancellationToken = default) => AndForget(
            action,
            EnvironmentSettings.DefaultFireAndForgetUnhandledExceptionHandler,
            cancellationToken);

        /// <summary>
        ///     Fires a method on a separate thread, and forgets about it completely, only invoking a continuation if there was an
        ///     exception.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="exceptionHandler">The exception handler. This parameter can be null.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Obsolete("Please use the methods in class Work.")]
        public static void AndForget(
            [NotNull] Action action,
            [CanBeNull] Action<Exception>? exceptionHandler,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                action,
                nameof(action));

            Task runningTask = action.OnThreadPool(cancellationToken);

            if (exceptionHandler != null)
            {
                // No sense in running the continuation if there's nobody listening
                runningTask.ContinueWith(
                    StandardContinuation,
                    exceptionHandler,
                    continuationOptions: TaskContinuationOptions.OnlyOnFaulted,
                    scheduler: GetCurrentTaskScheduler(),
                    cancellationToken: cancellationToken);
            }
        }

        /// <summary>
        ///     Fires a method on a separate thread, and forgets about it completely, only invoking a continuation if there was an
        ///     exception.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Obsolete("Please use the methods in class Work.")]
        public static void AndForget(
            [NotNull] Action<CancellationToken> action,
            CancellationToken cancellationToken = default) => AndForget(
            action,
            EnvironmentSettings.DefaultFireAndForgetUnhandledExceptionHandler,
            cancellationToken);

        /// <summary>
        ///     Fires a method on a separate thread, and forgets about it completely, only invoking a continuation if there was an
        ///     exception.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="exceptionHandler">The exception handler. This parameter can be null.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Obsolete("Please use the methods in class Work.")]
        public static void AndForget(
            [NotNull] Action<CancellationToken> action,
            [CanBeNull] Action<Exception>? exceptionHandler,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                action,
                nameof(action));

            Task runningTask = action.OnThreadPool(cancellationToken);

            if (exceptionHandler != null)
            {
                // No sense in running the continuation if there's nobody listening
                runningTask.ContinueWith(
                    StandardContinuation,
                    exceptionHandler,
                    continuationOptions: TaskContinuationOptions.OnlyOnFaulted,
                    scheduler: GetCurrentTaskScheduler(),
                    cancellationToken: cancellationToken);
            }
        }

        /// <summary>
        ///     Fires a method on a separate thread, and forgets about it completely, only invoking a continuation if there was an
        ///     exception.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Obsolete("Please use the methods in class Work.")]
        public static void AndForget(
            [NotNull] Func<Task> action,
            CancellationToken cancellationToken = default) => AndForget(
            action,
            EnvironmentSettings.DefaultFireAndForgetUnhandledExceptionHandler,
            cancellationToken);

        /// <summary>
        ///     Fires a method on a separate thread, and forgets about it completely, only invoking a continuation if there was an
        ///     exception.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="exceptionHandler">The exception handler. This parameter can be null.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Obsolete("Please use the methods in class Work.")]
        public static void AndForget(
            [NotNull] Func<Task> action,
            [CanBeNull] Action<Exception>? exceptionHandler,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                action,
                nameof(action));

            // We invoke our task-yielding operation in a different thread, guaranteed
            Task runningTask = action.OnThreadPool(cancellationToken);

            if (exceptionHandler != null)
            {
                // No sense in running the continuation if there's nobody listening
                runningTask.ContinueWith(
                    StandardContinuation,
                    exceptionHandler,
                    continuationOptions: TaskContinuationOptions.OnlyOnFaulted,
                    scheduler: GetCurrentTaskScheduler(),
                    cancellationToken: cancellationToken);
            }
        }

        /// <summary>
        ///     Fires a method on a separate thread, and forgets about it completely, only invoking a continuation if there was an
        ///     exception.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Obsolete("Please use the methods in class Work.")]
        public static void AndForget(
            [NotNull] Func<CancellationToken, Task> action,
            CancellationToken cancellationToken = default) => AndForget(
            action,
            EnvironmentSettings.DefaultFireAndForgetUnhandledExceptionHandler,
            cancellationToken);

        /// <summary>
        ///     Fires a method on a separate thread, and forgets about it completely, only invoking a continuation if there was an
        ///     exception.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="exceptionHandler">The exception handler. This parameter can be null.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [Obsolete("Please use the methods in class Work.")]
        public static void AndForget(
            [NotNull] Func<CancellationToken, Task> action,
            [CanBeNull] Action<Exception>? exceptionHandler,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                action,
                nameof(action));

            // We invoke our task-yielding operation in a different thread, guaranteed
            Task runningTask = action.OnThreadPool(cancellationToken);

            if (exceptionHandler != null)
            {
                // No sense in running the continuation if there's nobody listening
                runningTask.ContinueWith(
                    StandardContinuation,
                    exceptionHandler,
                    continuationOptions: TaskContinuationOptions.OnlyOnFaulted,
                    scheduler: GetCurrentTaskScheduler(),
                    cancellationToken: cancellationToken);
            }
        }
#pragma warning restore HAA0603 // Delegate allocation from a method group

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [NotNull]
        private static TaskScheduler GetCurrentTaskScheduler()
        {
            try
            {
                return SynchronizationContext.Current == null
                    ? TaskScheduler.Default
                    : TaskScheduler.FromCurrentSynchronizationContext();
            }
            catch (InvalidOperationException)
            {
                return TaskScheduler.Default;
            }
        }
    }
}