// <copyright file="DelayedDisposer.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using IX.Abstractions.Logging;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading;

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
    /// Explicitly ensures that the delayed disposer is initialized and running.
    /// </summary>
    /// <remarks>
    /// <para>The delayed disposer will initialize automatically whenever an object is disposed, so the call to this method is not necessary.</para>
    /// <para>However, due to the fact that spin-up might take a while, as well as allocations, for mission-critical code where it is necessary that things work
    /// as fast as possible, you may use this method to ensure that everything is spun up before being needed.</para>
    /// </remarks>
    public static void EnsureInitialized() => EnsureProcessingThreadStarted();

    /// <summary>
    ///     Atomically exchanges an old disposable reference with a new one, and adds the old one to the delayed disposer.
    /// </summary>
    /// <typeparam name="T">The type of item to exchange.</typeparam>
    /// <param name="oldReference">The old reference, that will be disposed and replaced.</param>
    /// <param name="newReference">The new reference, which will atomically take the old reference's place.</param>
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
    /// <param name="objectsToDispose">A collection containing the objects to dispose.</param>
    public static void SafelyDispose(IEnumerable<IDisposable?>? objectsToDispose)
    {
        if (objectsToDispose == null)
        {
            return;
        }

        lock (DisposablesGeneration1)
        {
            DisposablesGeneration1.AddRange(
                objectsToDispose.Where(p => p is not null)
                    .Select(p => p!));
        }

        EnsureProcessingThreadStarted();
    }

    /// <summary>
    ///     Adds a disposable object to the delayed disposer, to dispose them after the allotted timeout.
    /// </summary>
    /// <typeparam name="T">The type of item to add.</typeparam>
    /// <param name="objectsToDispose">A collection containing the objects to dispose.</param>
    [SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "Not possible.")]
    public static void SafelyDispose<T>(IEnumerable<T?>? objectsToDispose)
        where T : class, IDisposable
    {
        if (objectsToDispose == null)
        {
            return;
        }

        lock (DisposablesGeneration1)
        {
            DisposablesGeneration1.AddRange(
                objectsToDispose.Where(p => p is not null)
                    .Select(p => p!));
        }

        EnsureProcessingThreadStarted();
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

    /// <summary>
    ///     Adds a disposable object to the delayed disposer, to dispose them after the allotted timeout.
    /// </summary>
    /// <typeparam name="T">The type of item to add.</typeparam>
    /// <param name="objectToDispose">The object to dispose.</param>
    public static void SafelyDispose<T>(T? objectToDispose)
        where T : class, IDisposable
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
        await Task.Yield();

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
                            StandardExtensions.EnvironmentSettings.DelayedDisposal.DefaultDisposalDelayInMilliseconds);

                        foreach (IDisposable disposable in disposablesGen2L1)
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

    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Required.")]
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