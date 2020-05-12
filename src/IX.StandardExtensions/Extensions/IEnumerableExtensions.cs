// <copyright file="IEnumerableExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    /// Extensions for IEnumerable.
    /// </summary>
    [PublicAPI]
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "These are extensions for IEnumerable, so we must allow this.")]
    [SuppressMessage(
        "ReSharper",
        "InconsistentNaming",
        Justification = "These are extensions for IEnumerable, so we must allow this.")]
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Executes an action for each one of the elements of an enumerable.
        /// </summary>
        /// <typeparam name="T">The enumerable type.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Requires.NotNull(
                source,
                nameof(source));
            Requires.NotNull(
                action,
                nameof(action));

            foreach (T item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// Executes an action for each one of the elements of an enumerable.
        /// </summary>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static void ForEach(this IEnumerable source, Action<object> action)
        {
            Requires.NotNull(
                source,
                nameof(source));
            Requires.NotNull(
                action,
                nameof(action));

            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// Executes an independent action for each one of the elements of an enumerable, in parallel.
        /// </summary>
        /// <typeparam name="T">The enumerable type.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static void ParallelForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Requires.NotNull(
                source,
                nameof(source));
            Requires.NotNull(
                action,
                nameof(action));

            Parallel.ForEach(source, action);
        }

        /// <summary>
        /// Executes an action in sequence with an iterator.
        /// </summary>
        /// <typeparam name="T">The enumerable type.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static void For<T>(this IEnumerable<T> source, Action<int, T> action)
        {
            Requires.NotNull(
                source,
                nameof(source));
            Requires.NotNull(
                action,
                nameof(action));

            var i = 0;
            foreach (T item in source)
            {
                action(i, item);
                i++;
            }
        }

        /// <summary>
        /// Executes an action in sequence with an iterator.
        /// </summary>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        public static void For(this IEnumerable source, Action<int, object> action)
        {
            Requires.NotNull(
                source,
                nameof(source));
            Requires.NotNull(
                action,
                nameof(action));

            var i = 0;
            foreach (var item in source)
            {
                action(i, item);
                i++;
            }
        }

        /// <summary>
        /// Executes an independent action in parallel, with an iterator that respects the original sequence.
        /// </summary>
        /// <typeparam name="T">The enumerable type.</typeparam>
        /// <param name="source">The enumerable source.</param>
        /// <param name="action">The action to execute.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source" /> or <paramref name="action" /> is <see langword="null"/> (<see langword="Nothing"/> in Visual Basic).</exception>
        [SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is acceptable.")]
        public static void ParallelFor<T>(this IEnumerable<T> source, Action<int, T> action)
        {
            Requires.NotNull(
                source,
                nameof(source));
            Requires.NotNull(
                action,
                nameof(action));

            Parallel.ForEach(EnumerateWithIndex(source, action), PerformParallelAction);

            static IEnumerable<Tuple<int, T, Action<int, T>>> EnumerateWithIndex(IEnumerable<T> sourceEnumerable, Action<int, T> actionToPerform)
            {
                var i = 0;
                foreach (T item in sourceEnumerable)
                {
                    yield return new Tuple<int, T, Action<int, T>>(i, item, actionToPerform);
                    i++;
                }
            }

            static void PerformParallelAction(Tuple<int, T, Action<int, T>> state) => state.Item3(state.Item1, state.Item2);
        }
    }
}