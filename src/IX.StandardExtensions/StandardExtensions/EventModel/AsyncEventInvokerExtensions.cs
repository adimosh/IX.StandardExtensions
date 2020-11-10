// <copyright file="AsyncEventInvokerExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;

namespace IX.StandardExtensions.EventModel
{
    /// <summary>
    /// Extension methods for async events.
    /// </summary>
    [JetBrains.Annotations.PublicAPI]
    public static class AsyncEventInvokerExtensions
    {

        /// <summary>
        /// Invokes an asynchronous event.
        /// </summary>
        /// <param name="handler">The event handler.</param>
        /// <param name="sender">The sender.</param>
        /// <returns>An task that can be awaited on by the invoker.</returns>
        public static Task InvokeAsync(
            this AsyncEventHandler? handler,
            object sender)
        {
            Requires.NotNull(sender, nameof(sender));

            var invocationList = handler?.GetInvocationList();

            return (invocationList?.Length ?? 0) switch
            {
                0 => Task.CompletedTask,
                1 => handler!.Invoke(
                    sender,
                    EventArgs.Empty),
                _ => Task.WhenAll(
                    invocationList!.Cast<AsyncEventHandler>()
                        .Aggregate(
                            (Sender: sender, TaskList: new List<Task>()),
                            (
                                tuple,
                                eventHandler) =>
                            {
                                tuple.TaskList.Add(
                                    eventHandler.Invoke(
                                        tuple.Sender,
                                        EventArgs.Empty));
                                return tuple;
                            })
                        .TaskList),
            };
        }

        /// <summary>
        /// Invokes an asynchronous event.
        /// </summary>
        /// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
        /// <param name="handler">The event handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <typeparamref name="TEventArgs"/> instance containing the event data.</param>
        /// <returns>An task that can be awaited on by the invoker.</returns>
        public static Task InvokeAsync<TEventArgs>(
            this AsyncEventHandler<TEventArgs>? handler,
            object sender,
            TEventArgs e)
            where TEventArgs : EventArgs
        {
            Requires.NotNull(sender, nameof(sender));
            Requires.NotNull(e, nameof(e));

            var invocationList = handler?.GetInvocationList();

            return (invocationList?.Length ?? 0) switch
            {
                0 => Task.CompletedTask,
                1 => handler!.Invoke(
                    sender,
                    e),
                _ => Task.WhenAll(
                    invocationList!.Cast<AsyncEventHandler<TEventArgs>>()
                        .Aggregate(
                            (Sender: sender, EventArgs: e, TaskList: new List<Task>()),
                            (
                                tuple,
                                eventHandler) =>
                            {
                                tuple.TaskList.Add(
                                    eventHandler.Invoke(
                                        tuple.Sender,
                                        tuple.EventArgs));
                                return tuple;
                            })
                        .TaskList),
            };
        }

        /// <summary>
        /// Invokes an asynchronous event.
        /// </summary>
        /// <param name="handler">The event handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <returns>An task that can be awaited on by the invoker.</returns>
        public static Task InvokeAsync(
            [JetBrains.Annotations.CanBeNull] this AsyncEventHandler<EventArgs>? handler,
            [JetBrains.Annotations.NotNull] object sender,
            [JetBrains.Annotations.NotNull] EventArgs e)
        {
            Requires.NotNull(sender, nameof(sender));
            Requires.NotNull(e, nameof(e));

            var invocationList = handler?.GetInvocationList();

            return (invocationList?.Length ?? 0) switch
            {
                0 => Task.CompletedTask,
                1 => handler!.Invoke(
                    sender,
                    e),
                _ => Task.WhenAll(
                    invocationList!.Cast<AsyncEventHandler>()
                        .Aggregate(
                            (Sender: sender, EventArgs: e, TaskList: new List<Task>()),
                            (
                                tuple,
                                eventHandler) =>
                            {
                                tuple.TaskList.Add(
                                    eventHandler.Invoke(
                                        tuple.Sender,
                                        tuple.EventArgs));
                                return tuple;
                            })
                        .TaskList),
            };
        }
    }
}