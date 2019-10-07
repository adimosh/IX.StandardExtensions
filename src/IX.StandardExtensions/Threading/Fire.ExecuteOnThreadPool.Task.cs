// <copyright file="Fire.ExecuteOnThreadPool.Task.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A class that provides methods and extensions to fire events.
    /// </summary>
    public partial class Fire
    {
        private static Task ExecuteOnThreadPool(
            Action action,
            CancellationToken cancellationToken = default) =>
            ExecuteOnThreadPool(
                (
                    st,
                    ct) =>
                {
                    Contract.RequiresNotNullPrivate(
                        in st,
                        nameof(st));
                    Contract.RequiresArgumentOfTypePrivate<Action>(
                        st,
                        nameof(st));

                    ct.ThrowIfCancellationRequested();

                    ((Action)st)();

                    return 0;
                }, action,
                cancellationToken);

        private static Task ExecuteOnThreadPool(
            Action<CancellationToken> action,
            CancellationToken cancellationToken = default) =>
            ExecuteOnThreadPool(
                (
                    st,
                    ct) =>
                {
                    Contract.RequiresNotNullPrivate(
                        in st,
                        nameof(st));
                    Contract.RequiresArgumentOfTypePrivate<Action<CancellationToken>>(
                        st,
                        nameof(st));

                    ((Action<CancellationToken>)st)(ct);

                    return 0;
                }, action,
                cancellationToken);

        [SuppressMessage("Performance", "HAA0603:Delegate allocation from a method group", Justification = "This is unavoidable in this case.")]
        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            Func<TResult> action,
            CancellationToken cancellationToken = default)
        {
            static TResult Action(
                object st,
                CancellationToken ct)
            {
                Contract.RequiresNotNullPrivate(
                    in st,
                    nameof(st));
                Contract.RequiresArgumentOfTypePrivate<Func<TResult>>(
                    st,
                    nameof(st));

                ct.ThrowIfCancellationRequested();

                return ((Func<TResult>)st)();
            }

            return ExecuteOnThreadPool(
                Action,
                action,
                cancellationToken);
        }

        [SuppressMessage("Performance", "HAA0603:Delegate allocation from a method group", Justification = "This is unavoidable in this case.")]
        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            Func<CancellationToken, TResult> action,
            CancellationToken cancellationToken = default)
        {
            static TResult Action(
                object st,
                CancellationToken ct)
            {
                Contract.RequiresNotNullPrivate(
                    in st,
                    nameof(st));
                Contract.RequiresArgumentOfTypePrivate<Func<CancellationToken, TResult>>(
                    st,
                    nameof(st));

                return ((Func<CancellationToken, TResult>)st)(ct);
            }

            return ExecuteOnThreadPool(
                Action,
                action,
                cancellationToken);
        }

        private static Task ExecuteOnThreadPool(
            Action<object> action,
            object state,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
            (
                st,
                ct) =>
            {
                Contract.RequiresNotNullPrivate(
                    in st,
                    nameof(st));
                Contract.RequiresArgumentOfTypePrivate<Tuple<Action<object>, object>>(
                    st,
                    nameof(st));

                var innerState = (Tuple<Action<object>, object>)st;
                innerState.Item1(innerState.Item2);
                return 0;
            }, new Tuple<Action<object>, object>(
                action,
                state), cancellationToken);

        private static Task ExecuteOnThreadPool(
            Action<object, CancellationToken> action,
            object state,
            CancellationToken cancellationToken = default) => ExecuteOnThreadPool(
            (
                st,
                ct) =>
            {
                Contract.RequiresNotNullPrivate(
                    in st,
                    nameof(st));
                Contract.RequiresArgumentOfTypePrivate<Tuple<Action<object, CancellationToken>, object>>(
                    st,
                    nameof(st));

                var innerState = (Tuple<Action<object, CancellationToken>, object>)st;
                innerState.Item1(
                    innerState.Item2,
                    ct);
                return 0;
            }, new Tuple<Action<object, CancellationToken>, object>(
                action,
                state), cancellationToken);

        [SuppressMessage("Performance", "HAA0603:Delegate allocation from a method group", Justification = "This is unavoidable in this case.")]
        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            Func<object, TResult> action,
            object state,
            CancellationToken cancellationToken = default)
        {
            static TResult Action(
                object st,
                CancellationToken ct)
            {
                Contract.RequiresNotNullPrivate(
                    in st,
                    nameof(st));
                Contract.RequiresArgumentOfTypePrivate<Tuple<Func<object, TResult>, object>>(
                    st,
                    nameof(st));

                ct.ThrowIfCancellationRequested();

                var innerState = (Tuple<Func<object, TResult>, object>)st;

                return innerState.Item1(innerState.Item2);
            }

            return ExecuteOnThreadPool(
                Action,
                new Tuple<Func<object, TResult>, object>(
                    action,
                    state), cancellationToken);
        }
    }
}