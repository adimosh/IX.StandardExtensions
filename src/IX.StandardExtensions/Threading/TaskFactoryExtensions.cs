// <copyright file="TaskFactoryExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A class containing extension methods for <see cref="TaskFactory" />, mostly intended for use with
    ///     <see cref="Task.Factory" />.
    /// </summary>
    [PublicAPI]
    public static partial class TaskFactoryExtensions
    {
        /// <summary>
        ///     Starts a task on a new thread.
        /// </summary>
        /// <param name="taskFactory">The task factory to extend.</param>
        /// <param name="action">The action to start on a new thread.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>A <see cref="Task" /> that represents the started task.</returns>
        [NotNull]
        public static Task StartOnDefaultTaskScheduler(
            [NotNull] this TaskFactory taskFactory,
            [NotNull] Action action,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                action,
                nameof(action));

            return StartWithStateOnDefaultTaskScheduler(
                taskFactory,
                rawState => rawState(),
                action,
                false,
                cancellationToken);
        }

        /// <summary>
        ///     Starts a long-running task on a new thread.
        /// </summary>
        /// <param name="taskFactory">The task factory to extend.</param>
        /// <param name="action">The action to start on a new thread.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>A <see cref="Task" /> that represents the started long-running task.</returns>
        [NotNull]
        public static Task StartLongRunningOnDefaultTaskScheduler(
            [NotNull] this TaskFactory taskFactory,
            [NotNull] Action action,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                action,
                nameof(action));

            return StartWithStateOnDefaultTaskScheduler(
                taskFactory,
                rawState => rawState(),
                action,
                true,
                cancellationToken);
        }

        /// <summary>
        ///     Starts a task on a new thread.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="taskFactory">The task factory to extend.</param>
        /// <param name="action">The action to start on a new thread.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>A <see cref="Task" /> that represents the started task.</returns>
        [NotNull]
        public static Task<TResult> StartOnDefaultTaskScheduler<TResult>(
            [NotNull] this TaskFactory taskFactory,
            [NotNull] Func<TResult> action,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                action,
                nameof(action));

            return StartWithStateOnDefaultTaskScheduler(
                taskFactory,
                StateAsAction<TResult>,
                action,
                false,
                cancellationToken);
        }

        /// <summary>
        ///     Starts a long-running task on a new thread.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="taskFactory">The task factory to extend.</param>
        /// <param name="action">The action to start on a new thread.</param>
        /// <param name="cancellationToken">The cancellation token for this operation.</param>
        /// <returns>A <see cref="Task" /> that represents the started long-running task.</returns>
        [NotNull]
        public static Task<TResult> StartLongRunningOnDefaultTaskScheduler<TResult>(
            [NotNull] this TaskFactory taskFactory,
            [NotNull] Func<TResult> action,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                action,
                nameof(action));

            return StartWithStateOnDefaultTaskScheduler(
                taskFactory,
                StateAsAction<TResult>,
                action,
                true,
                cancellationToken);
        }

        [NotNull]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "Unavoidable here.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Usage",
            "DE0008:API is deprecated",
            Justification = "Only after .NET 4.5.2.")]
        internal static Task StartWithStateOnDefaultTaskScheduler<TState>(
            [NotNull] TaskFactory taskFactory,
            [NotNull] Action<TState> action,
            TState state,
            bool longRunning,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                taskFactory,
                nameof(taskFactory));
            Requires.NotNull(
                action,
                nameof(action));

            TaskCreationOptions creationOptions = TaskCreationOptions.HideScheduler |
                                                  (longRunning
                                                      ? TaskCreationOptions.LongRunning
                                                      : TaskCreationOptions.PreferFairness);

            return taskFactory.StartNew(
                StartAction,
                new Tuple<Action<TState>, CultureInfo, CultureInfo, TState>(
                    action,
                    CultureInfo.CurrentCulture,
                    CultureInfo.CurrentUICulture,
                    state), cancellationToken,
                creationOptions,
                TaskScheduler.Default);

            static void StartAction(object rawState)
            {
                var innerState = (Tuple<Action<TState>, CultureInfo, CultureInfo, TState>)rawState;

#if NET452
                Thread.CurrentThread.CurrentCulture = innerState.Item2;
                Thread.CurrentThread.CurrentUICulture = innerState.Item3;
#else
                CultureInfo.CurrentCulture = innerState.Item2;
                CultureInfo.CurrentUICulture = innerState.Item3;
#endif

                innerState.Item1(innerState.Item4);
            }
        }

        [NotNull]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "Unavoidable here.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Usage",
            "DE0008:API is deprecated",
            Justification = "Only after .NET 4.5.2.")]
        internal static Task<TResult> StartWithStateOnDefaultTaskScheduler<TState, TResult>(
            TaskFactory taskFactory,
            Func<TState, TResult> action,
            TState state,
            bool longRunning,
            CancellationToken cancellationToken = default)
        {
            Requires.NotNull(
                taskFactory,
                nameof(taskFactory));
            Requires.NotNull(
                action,
                nameof(action));

            TaskCreationOptions creationOptions = TaskCreationOptions.HideScheduler |
                                                  (longRunning
                                                      ? TaskCreationOptions.LongRunning
                                                      : TaskCreationOptions.PreferFairness);

            return taskFactory.StartNew(
                StartAction,
                new Tuple<Func<TState, TResult>, CultureInfo, CultureInfo, TState>(
                    action,
                    CultureInfo.CurrentCulture,
                    CultureInfo.CurrentUICulture,
                    state), cancellationToken,
                creationOptions,
                TaskScheduler.Default);

            static TResult StartAction(object rawState)
            {
                var innerState = (Tuple<Func<TState, TResult>, CultureInfo, CultureInfo, TState>)rawState;

#if NET452
                Thread.CurrentThread.CurrentCulture = innerState.Item2;
                Thread.CurrentThread.CurrentUICulture = innerState.Item3;
#else
                CultureInfo.CurrentCulture = innerState.Item2;
                CultureInfo.CurrentUICulture = innerState.Item3;
#endif

                return innerState.Item1(innerState.Item4);
            }
        }

        private static TResult StateAsAction<TResult>(object state) => ((Func<TResult>)state)();
    }
}