// <copyright file="IEnumerableExtensions.ForEachRefActions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using IX.StandardExtensions.Efficiency;

namespace IX.StandardExtensions.Extensions;

/// <summary>
///     Extensions for IEnumerable.
/// </summary>
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "These are extensions for IEnumerable, so we must allow this.")]
public static partial class IEnumerableExtensions
{
    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1>(
        this IEnumerable<TItem> source,
        RefIteratorAction<TItem, TParam1> action,
        ref TParam1 param1)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        RefIteratorAction1<TItem, TParam1, TParam2> action,
        ref TParam1 param1,
        TParam2 param2)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, param2);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2>(
        this IEnumerable<TItem> source,
        RefIteratorAction<TItem, TParam1, TParam2> action,
        ref TParam1 param1,
        ref TParam2 param2)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        RefIteratorAction2<TItem, TParam1, TParam2, TParam3> action,
        ref TParam1 param1,
        TParam2 param2,
        TParam3 param3)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, param2, param3);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        RefIteratorAction1<TItem, TParam1, TParam2, TParam3> action,
        ref TParam1 param1,
        ref TParam2 param2,
        TParam3 param3)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, param3);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3>(
        this IEnumerable<TItem> source,
        RefIteratorAction<TItem, TParam1, TParam2, TParam3> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        RefIteratorAction3<TItem, TParam1, TParam2, TParam3, TParam4> action,
        ref TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, param2, param3, param4);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        RefIteratorAction2<TItem, TParam1, TParam2, TParam3, TParam4> action,
        ref TParam1 param1,
        ref TParam2 param2,
        TParam3 param3,
        TParam4 param4)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, param3, param4);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        RefIteratorAction1<TItem, TParam1, TParam2, TParam3, TParam4> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        TParam4 param4)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, param4);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4>(
        this IEnumerable<TItem> source,
        RefIteratorAction<TItem, TParam1, TParam2, TParam3, TParam4> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        RefIteratorAction4<TItem, TParam1, TParam2, TParam3, TParam4, TParam5> action,
        ref TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, param2, param3, param4, param5);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        RefIteratorAction3<TItem, TParam1, TParam2, TParam3, TParam4, TParam5> action,
        ref TParam1 param1,
        ref TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, param3, param4, param5);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        RefIteratorAction2<TItem, TParam1, TParam2, TParam3, TParam4, TParam5> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, param4, param5);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        RefIteratorAction1<TItem, TParam1, TParam2, TParam3, TParam4, TParam5> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        TParam5 param5)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, param5);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5>(
        this IEnumerable<TItem> source,
        RefIteratorAction<TItem, TParam1, TParam2, TParam3, TParam4, TParam5> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        RefIteratorAction5<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> action,
        ref TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, param2, param3, param4, param5, param6);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        RefIteratorAction4<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> action,
        ref TParam1 param1,
        ref TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, param3, param4, param5, param6);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        RefIteratorAction3<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, param4, param5, param6);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        RefIteratorAction2<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, param5, param6);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        RefIteratorAction1<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5,
        TParam6 param6)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5, param6);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5. This parameter is passed by reference.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        this IEnumerable<TItem> source,
        RefIteratorAction<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5,
        ref TParam6 param6)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5, ref param6);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        RefIteratorAction6<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
        ref TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, param2, param3, param4, param5, param6, param7);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        RefIteratorAction5<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
        ref TParam1 param1,
        ref TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, param3, param4, param5, param6, param7);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        RefIteratorAction4<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, param4, param5, param6, param7);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        RefIteratorAction3<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, param5, param6, param7);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        RefIteratorAction2<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5, param6, param7);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5. This parameter is passed by reference.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        RefIteratorAction1<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5,
        ref TParam6 param6,
        TParam7 param7)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5, ref param6, param7);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5. This parameter is passed by reference.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6. This parameter is passed by reference.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        this IEnumerable<TItem> source,
        RefIteratorAction<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5,
        ref TParam6 param6,
        ref TParam7 param7)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5, ref param6, ref param7);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
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
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        RefIteratorAction7<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
        ref TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, param2, param3, param4, param5, param6, param7, param8);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
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
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        RefIteratorAction6<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
        ref TParam1 param1,
        ref TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, param3, param4, param5, param6, param7, param8);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
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
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        RefIteratorAction5<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, param4, param5, param6, param7, param8);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
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
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        RefIteratorAction4<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, param5, param6, param7, param8);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
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
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        RefIteratorAction3<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5, param6, param7, param8);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
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
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5. This parameter is passed by reference.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        RefIteratorAction2<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5,
        ref TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5, ref param6, param7, param8);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
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
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5. This parameter is passed by reference.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6. This parameter is passed by reference.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        RefIteratorAction1<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5,
        ref TParam6 param6,
        ref TParam7 param7,
        TParam8 param8)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5, ref param6, ref param7, param8);
        }
    }

    /// <summary>
    ///     Executes an action for each one of the elements of an enumerable.
    /// </summary>
    /// <typeparam name="TItem">The enumerable item type.</typeparam>
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
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0. This parameter is passed by reference.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1. This parameter is passed by reference.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2. This parameter is passed by reference.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3. This parameter is passed by reference.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4. This parameter is passed by reference.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5. This parameter is passed by reference.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6. This parameter is passed by reference.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7. This parameter is passed by reference.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
    public static void ForEach<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        this IEnumerable<TItem> source,
        RefIteratorAction<TItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
        ref TParam1 param1,
        ref TParam2 param2,
        ref TParam3 param3,
        ref TParam4 param4,
        ref TParam5 param5,
        ref TParam6 param6,
        ref TParam7 param7,
        ref TParam8 param8)
    {
        _ = Requires.NotNull(source);
        _ = Requires.NotNull(action);

        foreach (TItem item in source)
        {
            action(item, ref param1, ref param2, ref param3, ref param4, ref param5, ref param6, ref param7, ref param8);
        }
    }
}