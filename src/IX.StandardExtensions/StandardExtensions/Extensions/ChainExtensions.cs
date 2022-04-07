// <copyright file="ChainExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions;

/// <summary>
/// Generic extensions for chaining multiple method calls on objects.
/// </summary>
[PublicAPI]
public static class ChainExtensions
{
    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <returns>The input object.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    public static TInput Chain<TInput>(
        this TInput input,
        Action<TInput> chainDelegate)
    {
        Requires.NotNull(chainDelegate)(Requires.NotNull(input));

        return input;
    }

    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <typeparam name="TOutput">The output object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <returns>The output object, returned by the chain delegate.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    public static TOutput Chain<TInput, TOutput>(
        this TInput input,
        Func<TInput, TOutput> chainDelegate) =>
        Requires.NotNull(chainDelegate)(Requires.NotNull(input));

    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The input object.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    [SuppressMessage("Performance", "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance", Justification = "No, this is an integral part of the chain.")]
    [SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "We need boxing anyway, since we're spanning threads.")]
    public static Task<TInput> Chain<TInput>(
        this TInput input,
        Func<TInput, Task> chainDelegate,
        CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<TInput>(cancellationToken);
        }

        var localInput = Requires.NotNull(input);

        return Requires.NotNull(chainDelegate)(localInput)
            .ContinueWith(
                (
                    _,
                    o) => (TInput)o!,
                localInput,
                TaskContinuationOptions.OnlyOnRanToCompletion);
    }

    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <typeparam name="TOutput">The output object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The output object, returned by the chain delegate.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    public static Task<TOutput> Chain<TInput, TOutput>(
        this TInput input,
        Func<TInput, Task<TOutput>> chainDelegate,
        CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<TOutput>(cancellationToken);
        }

        return Requires.NotNull(chainDelegate)(Requires.NotNull(input));
    }

    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The input object.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    [SuppressMessage("Performance", "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance", Justification = "No, this is an integral part of the chain.")]
    public static Task<TInput> Chain<TInput>(
        this Task<TInput> input,
        Func<TInput, Task> chainDelegate,
        CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<TInput>(cancellationToken);
        }

        var localInput = Requires.NotNull(input);
        return localInput
            .ContinueWith(
                (
                    antecedent,
                    state) =>
                {
                    var (innerChainDelegate, innerCancellationToken) =
                        (Tuple<Func<TInput, Task>, CancellationToken>)state!;
                    innerCancellationToken.ThrowIfCancellationRequested();

                    return innerChainDelegate(antecedent.Result);
                },
                new Tuple<Func<TInput, Task>, CancellationToken>(
                    Requires.NotNull(chainDelegate),
                    cancellationToken),
                TaskContinuationOptions.OnlyOnRanToCompletion)
            .Unwrap()
            .ContinueWith(
                (
                    _,
                    o) => (TInput)o!,
                localInput,
                TaskContinuationOptions.OnlyOnRanToCompletion);
    }

    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <typeparam name="TOutput">The output object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The output object, returned by the chain delegate.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    [SuppressMessage("Performance", "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance", Justification = "No, this is an integral part of the chain.")]
    public static Task<TOutput> Chain<TInput, TOutput>(
        this Task<TInput> input,
        Func<TInput, Task<TOutput>> chainDelegate,
        CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<TOutput>(cancellationToken);
        }

        return Requires.NotNull(input)
            .ContinueWith(
                (
                    antecedent,
                    state) =>
                {
                    var (innerChainDelegate, innerCancellationToken) =
                        (Tuple<Func<TInput, Task<TOutput>>, CancellationToken>)state!;
                    innerCancellationToken.ThrowIfCancellationRequested();

                    return innerChainDelegate(antecedent.Result);
                },
                new Tuple<Func<TInput, Task<TOutput>>, CancellationToken>(
                    Requires.NotNull(chainDelegate),
                    cancellationToken),
                TaskContinuationOptions.OnlyOnRanToCompletion)
            .Unwrap();
    }

    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The input object.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    [SuppressMessage("Performance", "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance", Justification = "No, this is an integral part of the chain.")]
    [SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "We need boxing anyway, since we're spanning threads.")]
    public static ValueTask<TInput> Chain<TInput>(
        this TInput input,
        Func<TInput, ValueTask> chainDelegate,
        CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return new ValueTask<TInput>(Task.FromCanceled<TInput>(cancellationToken));
        }

        var vt = Requires.NotNull(chainDelegate)(Requires.NotNull(input));

        if (vt.IsCompletedSuccessfully)
        {
            return new ValueTask<TInput>(input);
        }

        return new ValueTask<TInput>(
            vt.AsTask()
                .ContinueWith(
                    (
                        _,
                        o) => (TInput)o!,
                    input,
                    TaskContinuationOptions.OnlyOnRanToCompletion));
    }

    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <typeparam name="TOutput">The output object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The output object, returned by the chain delegate.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    public static ValueTask<TOutput> Chain<TInput, TOutput>(
        this TInput input,
        Func<TInput, ValueTask<TOutput>> chainDelegate,
        CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return new ValueTask<TOutput>(Task.FromCanceled<TOutput>(cancellationToken));
        }

        return Requires.NotNull(chainDelegate)(Requires.NotNull(input));
    }

    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The input object.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    [SuppressMessage("Performance", "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance", Justification = "No, this is an integral part of the chain.")]
    [SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "We need boxing anyway, since we're spanning threads.")]
    public static ValueTask<TInput> Chain<TInput>(
        this ValueTask<TInput> input,
        Func<TInput, ValueTask> chainDelegate,
        CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return new ValueTask<TInput>(Task.FromCanceled<TInput>(cancellationToken));
        }

        var vt = Requires.NotNull(input);

        if (vt.IsCompletedSuccessfully)
        {
            var innerVt = Requires.NotNull(chainDelegate)(vt.Result);
            if (innerVt.IsCompletedSuccessfully)
            {
                return vt;
            }

            return new ValueTask<TInput>(
                innerVt.AsTask()
                    .ContinueWith(
                        (
                            _,
                            o) => (TInput)o!,
                        vt.Result,
                        TaskContinuationOptions.OnlyOnRanToCompletion));
        }

        return new ValueTask<TInput>(
            vt.AsTask()
                .ContinueWith(
                    (
                        antecedent,
                        state) =>
                    {
                        var (innerChainDelegate, innerCancellationToken) =
                            (Tuple<Func<TInput, ValueTask>, CancellationToken>)state!;
                        innerCancellationToken.ThrowIfCancellationRequested();
                        var innerVt = innerChainDelegate(antecedent.Result);

                        if (innerVt.IsCompletedSuccessfully)
                        {
                            return Task.FromResult(antecedent.Result);
                        }

                        return innerVt.AsTask().ContinueWith(
                            (
                                _,
                                o) => (TInput)o!,
                            antecedent.Result,
                            TaskContinuationOptions.OnlyOnRanToCompletion);
                    },
                    new Tuple<Func<TInput, ValueTask>, CancellationToken>(
                        Requires.NotNull(chainDelegate),
                        cancellationToken),
                    TaskContinuationOptions.OnlyOnRanToCompletion)
                .Unwrap());
    }

    /// <summary>
    /// Chains a specific delegate onto an instance of an object.
    /// </summary>
    /// <typeparam name="TInput">The input object type.</typeparam>
    /// <typeparam name="TOutput">The output object type.</typeparam>
    /// <param name="input">The input object instance.</param>
    /// <param name="chainDelegate">The delegate to chain.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>The output object, returned by the chain delegate.</returns>
    /// <exception cref="ArgumentNullException">Either <paramref name="input"/> or <paramref name="chainDelegate"/> is <c>null</c> (<c>Nothing</c> in Visual Basic).</exception>
    [SuppressMessage("Performance", "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance", Justification = "No, this is an integral part of the chain.")]
    public static ValueTask<TOutput> Chain<TInput, TOutput>(
        this ValueTask<TInput> input,
        Func<TInput, ValueTask<TOutput>> chainDelegate,
        CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return new ValueTask<TOutput>(Task.FromCanceled<TOutput>(cancellationToken));
        }

        var vt = Requires.NotNull(input);

        if (vt.IsCompletedSuccessfully)
        {
            return Requires.NotNull(chainDelegate)(vt.Result);
        }

        return new ValueTask<TOutput>(
            vt.AsTask()
                .ContinueWith(
                    (
                        antecedent,
                        state) =>
                    {
                        var (innerChainDelegate, innerCancellationToken) =
                            (Tuple<Func<TInput, ValueTask<TOutput>>, CancellationToken>)state!;
                        innerCancellationToken.ThrowIfCancellationRequested();
                        var innerVt = innerChainDelegate(antecedent.Result);

                        if (innerVt.IsCompletedSuccessfully)
                        {
                            return Task.FromResult(innerVt.Result);
                        }

                        return innerVt.AsTask();
                    },
                    new Tuple<Func<TInput, ValueTask<TOutput>>, CancellationToken>(
                        Requires.NotNull(chainDelegate),
                        cancellationToken),
                    TaskContinuationOptions.OnlyOnRanToCompletion)
                .Unwrap());
    }
}