// <copyright file="ObjectPoolQueue{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.ComponentModel;
using IX.StandardExtensions.Threading;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Efficiency
{
    /// <summary>
    ///     A pool queue of objects that are waiting for an action to invoke for each, on a separate thread.
    /// </summary>
    /// <typeparam name="T">The type of object in the pool queue.</typeparam>
    [PublicAPI]
    public class ObjectPoolQueue<T> : INotifyThreadException
    {
#region Internal state

        private readonly CancellationToken cancellationToken;
        private readonly Queue<T> objects;
        private readonly Func<IEnumerable<T>, int, Task<bool>> queueAction;

#endregion

#region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObjectPoolQueue{T}" /> class.
        /// </summary>
        /// <param name="queueAction">The queue action.</param>
        /// <param name="objectLimit">The object limit.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        ///     <para>
        ///         The <paramref name="queueAction" /> will take two parameters: an enumerable of objects from the pool queue,
        ///         and the retry count.
        ///     </para>
        ///     <para>Every time there is an exception, the action is re-invoked, and the retry count is increased.</para>
        ///     <para>In order to stop retrying, a <see cref="StopRetryingException" /> should be thrown.</para>
        /// </remarks>
        [SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is of little consequence here, and is required for operation.")]
        public ObjectPoolQueue(
            Func<IEnumerable<T>, int, Task<bool>> queueAction,
            int objectLimit = 1000,
            CancellationToken cancellationToken = default)
        {
            this.objects = new Queue<T>();
            this.cancellationToken = cancellationToken;
            this.ObjectLimit = objectLimit;
            this.queueAction = queueAction;

            _ = Work.OnThreadPoolAsync(
                this.RunAsync,
                this.cancellationToken);
        }

#endregion

#region Events

        /// <summary>
        ///     Triggered when an exception has occurred on a different thread.
        /// </summary>
        public event EventHandler<ExceptionOccurredEventArgs>? ExceptionOccurredOnSeparateThread;

#endregion

#region Properties and indexers

        /// <summary>
        ///     Gets or sets the object limit.
        /// </summary>
        /// <value>The object limit.</value>
        public int ObjectLimit
        {
            get;
            set;
        }

#endregion

#region Methods

        /// <summary>
        ///     Enqueues the specified object in the pool queue.
        /// </summary>
        /// <param name="object">The object to enqueue.</param>
        [SuppressMessage(
            "Naming",
            "CA1720:Identifier contains type name",
            Justification = "We don't really care.")]
        public void Enqueue(T @object) =>
            this.objects.Enqueue(@object);

        [SuppressMessage(
            "Performance",
            "HAA0601:Value type to reference type conversion causing boxing allocation",
            Justification = "We don't really know what boxing occurs here.")]
        [SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "Not really avoidable.")]
        [SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "This is expected in this situation.")]
        private async Task RunAsync()
        {
            Thread.CurrentThread.Name = $"Object pool queue {Thread.CurrentThread.ManagedThreadId}";

            while (!this.cancellationToken.IsCancellationRequested)
            {
                if (this.objects.Count == 0)
                {
                    try
                    {
                        await Task.Delay(
                                1000,
                                this.cancellationToken)
                            .ConfigureAwait(false);
                    }
                    catch (TaskCanceledException)
                    {
                        return;
                    }
                }
                else
                {
                    var objectLimit = this.ObjectLimit;
                    var initialSize = objectLimit < this.objects.Count ? objectLimit : this.objects.Count;

                    var listProcess = new List<T>(initialSize);

                    for (var i = 0; i < initialSize; i++)
                    {
                        listProcess.Add(this.objects.Dequeue());
                    }

                    var retryCounter = 0;
                    var shouldRetry = true;

                    while (shouldRetry && !this.cancellationToken.IsCancellationRequested)
                    {
                        try
                        {
                            shouldRetry = !await this.queueAction(
                                    listProcess,
                                    retryCounter++)
                                .ConfigureAwait(false);
                        }
                        catch (StopRetryingException)
                        {
                            shouldRetry = false;
                        }
                        catch (Exception ex)
                        {
                            this.ExceptionOccurredOnSeparateThread?.Invoke(
                                this,
                                new ExceptionOccurredEventArgs(ex));
                        }
                    }
                }
            }
        }

#endregion
    }
}