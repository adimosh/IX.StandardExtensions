// <copyright file="AtomicEnumerator{TItem}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;
using DiagCA = System.Diagnostics.CodeAnalysis;

namespace IX.StandardExtensions.Threading;

/// <summary>
///     An atomic enumerator that can enumerate items one at a time, atomically.
/// </summary>
/// <typeparam name="TItem">The type of the items to enumerate.</typeparam>
/// <seealso cref="IEnumerator{T}" />
/// <seealso cref="AtomicEnumerator" />
[PublicAPI]
public abstract class AtomicEnumerator<TItem> : AtomicEnumerator,
    IEnumerator<TItem>
{
#region Constructors and destructors

#region Constructors

    /// <summary>
    ///     Prevents a default instance of the <see cref="AtomicEnumerator{TItem}" /> class from being created.
    /// </summary>
    protected private AtomicEnumerator() { }

#endregion

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets the element in the collection at the current position of the enumerator.
    /// </summary>
    /// <value>The current element.</value>
    public abstract TItem Current { get; }

    /// <summary>
    ///     Gets the element in the collection at the current position of the enumerator.
    /// </summary>
    /// <value>The current element.</value>
    [DiagCA.SuppressMessage(
        "Performance",
        "HAA0601:Value type to reference type conversion causing boxing allocation",
        Justification = "Unavoidable with a generic enumerator.")]
    object? IEnumerator.Current => this.Current;

#endregion

#region Methods

#region Static methods

    /// <summary>
    ///     Creates an atomic enumerator from a collection.
    /// </summary>
    /// <typeparam name="TCollection">The type of the collection.</typeparam>
    /// <param name="collection">The collection.</param>
    /// <param name="readLock">The function to acquire a read lock.</param>
    /// <returns>The created atomic enumerator.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="collection" />
    ///     or
    ///     <paramref name="readLock" />
    ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    [DiagCA.SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "We need this instance allocated.")]
    [DiagCA.SuppressMessage(
        "Design",
        "CA1000:Do not declare static members on generic types",
        Justification = "This is, honestly, a stupid rule.")]
    [DiagCA.SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Not an issue, since we're returning a class-based atomic enumerator anyway.")]
    public static AtomicEnumerator<TItem> FromCollection<TCollection>(
        TCollection collection,
        Func<ReadOnlySynchronizationLocker> readLock)
        where TCollection : class, IEnumerable<TItem>
    {
        // Validate arguments
        Requires.NotNull(collection);
        Requires.NotNull(readLock);

        Delegate initializer = ConstructionDelegates.GetOrAdd(
            typeof(TCollection),
            (
                collectionType,
                _) =>
            {
                // Get used types
                MethodInfo getEnumeratorMethodInfo = collectionType.GetMethod(
                    nameof(IEnumerable<TItem>.GetEnumerator),
                    BindingFlags.Public | BindingFlags.Instance)!;

                // ReSharper disable once PossibleNullReferenceException - We know this cannot be null, as we're interrogating the GetEnumerator method if an IEnumerable - there must be at least one
                Type enumeratorType = getEnumeratorMethodInfo.ReturnType;
                Type atomicEnumeratorType = typeof(AtomicEnumerator<,>).MakeGenericType(
                    typeof(TItem),
                    enumeratorType);
                ConstructorInfo atomicEnumeratorConstructorInfo = atomicEnumeratorType.GetConstructors()[0]!;

                // Prepare parameter expressions
                ParameterExpression parameter1 = Expression.Parameter(collectionType);
                ParameterExpression parameter2 = Expression.Parameter(typeof(Func<ReadOnlySynchronizationLocker>));

                // Prepare expression
                return Expression.Lambda(
                        Expression.New(
                            atomicEnumeratorConstructorInfo,
                            Expression.Call(
                                parameter1,
                                getEnumeratorMethodInfo),
                            parameter2),
                        parameter1,
                        parameter2)
                    .Compile();
            },
            collection);

        if (initializer is Func<TCollection, Func<ReadOnlySynchronizationLocker>, AtomicEnumerator<TItem>>
            typedInitializer)
        {
            return typedInitializer(
                collection,
                readLock);
        }

        return (AtomicEnumerator<TItem>)initializer.DynamicInvoke(
            collection,
            readLock)!;
    }

    /// <summary>
    ///     Creates an atomic enumerator from an already-existing enumerator.
    /// </summary>
    /// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
    /// <param name="enumerator">The enumerator.</param>
    /// <param name="readLock">The function to acquire a read lock.</param>
    /// <returns>The created atomic enumerator.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="enumerator" />
    ///     or
    ///     <paramref name="readLock" />
    ///     is <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    [DiagCA.SuppressMessage(
        "Design",
        "CA1000:Do not declare static members on generic types",
        Justification = "This is, honestly, a stupid rule.")]
    public static AtomicEnumerator<TItem> FromEnumerator<TEnumerator>(
        TEnumerator enumerator,
        Func<ReadOnlySynchronizationLocker> readLock)
        where TEnumerator : IEnumerator<TItem>
    {
        Requires.NotNull(enumerator);
        Requires.NotNull(readLock);

        return new AtomicEnumerator<TItem, TEnumerator>(
            enumerator,
            readLock);
    }

#endregion

#endregion
}