using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IX.Abstractions.Logging;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A class that allows delayed safe disposal of <see cref="IDisposable" /> objects.
    /// </summary>
    [PublicAPI]
    public static class DelayedDisposer
    {
#region Internal state

        private static readonly List<IDisposable> DisposablesGeneration1 = new();
        private static readonly object Locker = new();

        private static bool currentlyRunning;

#endregion

#region Methods

#region Static methods

        /// <summary>
        ///     Atomically exchanges an old disposable reference with a new one, and adds the old one to the delayed disposer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldReference"></param>
        /// <param name="newReference"></param>
        public static void AtomicExchange<T>(
            ref T oldReference,
            T newReference)
            where T : class, IDisposable
        {
            T oldRef = Interlocked.Exchange(
                ref oldReference,
                newReference);

            SafelyDispose(oldRef);
        }

        /// <summary>
        ///     Adds a disposable object to the delayed disposer, to dispose them after the allotted timeout.
        /// </summary>
        /// <param name="objectToDispose">The object to dispose.</param>
        public static void SafelyDispose(IDisposable? objectToDispose)
        {
            if (objectToDispose == null)
            {
                return;
            }

            lock (DisposablesGeneration1)
            {
                DisposablesGeneration1.Add(objectToDispose);
            }

            EnsureProcessingThreadStarted();
        }

        private static async Task DisposableThread()
        {
            lock (Locker)
            {
                currentlyRunning = true;
            }

            try
            {
                while (DisposablesGeneration1.Count != 0)
                {
                    await Task.Delay(
                        StandardExtensions.EnvironmentSettings.DelayedDisposal.DefaultDisposalDelayInMilliseconds);

                    IDisposable[] disposablesGen2;
                    lock (DisposablesGeneration1)
                    {
                        disposablesGen2 = DisposablesGeneration1.ToArray();
                        DisposablesGeneration1.Clear();
                    }

                    _ = Work.OnThreadPoolAsync(
                        async disposablesGen2L1 =>
                        {
                            await Task.Delay(
                                StandardExtensions.EnvironmentSettings.DelayedDisposal
                                    .DefaultDisposalDelayInMilliseconds);

                            foreach (var disposable in disposablesGen2L1)
                            {
                                try
                                {
                                    disposable.Dispose();
                                }
                                catch (Exception e)
                                {
                                    (Log.Current ?? Log.Default)?.Error(
                                        e,
                                        "Exception while disposing object.");

                                    // We don't do anything with the exception here, since this is a safe-disposer.
                                }
                            }
                        },
                        disposablesGen2);
                }
            }
            finally
            {
                lock (Locker)
                {
                    currentlyRunning = false;
                }
            }
        }

        private static void EnsureProcessingThreadStarted()
        {
            lock (Locker)
            {
                if (currentlyRunning)
                {
                    return;
                }

                _ = Work.OnThreadPoolAsync(DisposableThread);
            }
        }

#endregion

#endregion
    }
}