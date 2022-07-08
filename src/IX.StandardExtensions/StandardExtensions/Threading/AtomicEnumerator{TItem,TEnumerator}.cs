// <copyright file="AtomicEnumerator{TItem,TEnumerator}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading;

/// <summary>
///     An atomic enumerator that can enumerate items one at a time, atomically.
/// </summary>
/// <typeparam name="TItem">The type of the items to enumerate.</typeparam>
/// <typeparam name="TEnumerator">The type of the enumerator from which this atomic enumerator is derived.</typeparam>
/// <seealso cref="AtomicEnumerator{TItem}" />
[PublicAPI]
internal sealed class AtomicEnumerator<TItem, TEnumerator> : AtomicEnumerator<TItem>
    where TEnumerator : IEnumerator<TItem>
{
#region Internal state

    private readonly Func<ReadOnlySynchronizationLocker> readLock;
    private TItem current;
    private TEnumerator existingEnumerator;
    private bool movedNext;

#endregion

#region Constructors and destructors

#region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="AtomicEnumerator{TItem, TEnumerator}" /> class.
    /// </summary>
    /// <param name="existingEnumerator">The existing enumerator. This argument is passed by reference.</param>
    /// <param name="readLock">The read lock.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="existingEnumerator" />
    ///     or
    ///     <paramref name="readLock" />
    ///     is <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public AtomicEnumerator(
        TEnumerator existingEnumerator,
        Func<ReadOnlySynchronizationLocker> readLock)
    {
        Requires.NotNull(existingEnumerator);

        this.existingEnumerator = existingEnumerator;
        current = default!; /* We forgive this possible null reference, as it should not be possible to
                                      * access it before reading something from the enumerator
                                      */

        Requires.NotNull(
            out this.readLock,
            readLock);
    }

#endregion

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the element in the collection at the current position of the enumerator.
    /// </summary>
    /// <value>The current element.</value>
    public override TItem Current
    {
        get
        {
            if (!movedNext)
            {
                throw new InvalidOperationException(Resources.MoveNextNotInvoked);
            }

            ThrowIfCurrentObjectDisposed();

            return current;
        }
    }

#endregion

#region Methods

    /// <summary>
    ///     Advances the enumerator to the next element of the collection.
    /// </summary>
    /// <returns>
    ///     <see langword="true" /> if the enumerator was successfully advanced to the next element;
    ///     <see langword="false" /> if the enumerator has passed the end of the collection.
    /// </returns>
    public override bool MoveNext()
    {
        ThrowIfCurrentObjectDisposed();

        bool result;
        using (readLock())
        {
            ref TEnumerator localEnumerator = ref existingEnumerator;
            result = localEnumerator.MoveNext();

            movedNext = true;

            if (result)
            {
                current = localEnumerator.Current;
            }
        }

        return result;
    }

    /// <summary>
    ///     Sets the enumerator to its initial position, which is before the first element in the collection.
    /// </summary>
    public override void Reset()
    {
        // DO NOT CHANGE the order of these operations!
        movedNext = false;

        ThrowIfCurrentObjectDisposed();

        existingEnumerator.Reset();
        current = default!;
    }

#region Disposable

    /// <summary>
    ///     Disposes in the managed context.
    /// </summary>
    [SuppressMessage(
        "IDisposableAnalyzers.Correctness",
        "IDISP007:Don't dispose injected.",
        Justification = "The atomic enumerator requires ownership of the source enumerator.")]
    protected override void DisposeManagedContext()
    {
        base.DisposeManagedContext();

        existingEnumerator.Dispose();
    }

#endregion

#endregion
}