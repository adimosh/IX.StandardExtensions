// <copyright file="Fire.ExecuteOnThreadPool.Task.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Threading
{
    /// <summary>
    ///     A class that provides methods and extensions to fire events.
    /// </summary>
    public partial class Fire
    {
        [NotNull]
        private static Task ExecuteOnThreadPool(
            [NotNull] Action action,
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

        [NotNull]
        private static Task ExecuteOnThreadPool(
            [NotNull] Action<CancellationToken> action,
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [NotNull]
        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            [NotNull] Func<TResult> action,
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0603:Delegate allocation from a method group",
            Justification = "This is unavoidable in this case.")]
        [NotNull]
        private static Task<TResult> ExecuteOnThreadPool<TResult>(
            [NotNull] Func<CancellationToken, TResult> action,
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

        [NotNull]
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
    }
}