// <copyright file="AsyncEventInvokerExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.EventModel
{
    /// <summary>
    ///     Extension methods for async events.
    /// </summary>
    [PublicAPI]
    public static class AsyncEventInvokerExtensions
    {
#region Methods

#region Static methods

        /// <summary>
        ///     Invokes an asynchronous event.
        /// </summary>
        /// <param name="handler">The event handler.</param>
        /// <param name="sender">The sender.</param>
        /// <returns>An task that can be awaited on by the invoker.</returns>
        public static Task InvokeAsync(
            this AsyncEventHandler? handler,
            object sender)
        {
            Requires.NotNull(sender);

            Delegate[]? invocationList = handler?.GetInvocationList();

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
                        .TaskList)
            };
        }

        /// <summary>
        ///     Invokes an asynchronous event.
        /// </summary>
        /// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
        /// <param name="handler">The event handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <typeparamref name="TEventArgs" /> instance containing the event data.</param>
        /// <returns>An task that can be awaited on by the invoker.</returns>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
            Justification = "Not avoidable here.")]
        public static Task InvokeAsync<TEventArgs>(
            this AsyncEventHandler<TEventArgs>? handler,
            object sender,
            TEventArgs e)
            where TEventArgs : EventArgs
        {
            Requires.NotNull(sender);
            Requires.NotNull(e);

            Delegate[]? invocationList = handler?.GetInvocationList();

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
                        .TaskList)
            };
        }

        /// <summary>
        ///     Invokes an asynchronous event.
        /// </summary>
        /// <param name="handler">The event handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// <returns>An task that can be awaited on by the invoker.</returns>
        public static Task InvokeAsync(
            this AsyncEventHandler<EventArgs>? handler,
            object sender,
            EventArgs e)
        {
            Requires.NotNull(sender);
            Requires.NotNull(e);

            Delegate[]? invocationList = handler?.GetInvocationList();

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
                        .TaskList)
            };
        }

#endregion

#endregion
    }
}