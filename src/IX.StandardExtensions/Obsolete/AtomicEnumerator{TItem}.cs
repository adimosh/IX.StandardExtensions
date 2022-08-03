using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

using IX.StandardExtensions.Contracts;

// ReSharper disable once CheckNamespace
namespace IX.StandardExtensions.Threading;

public partial class AtomicEnumerator<TItem>
{
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
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
        Justification = "We need this instance allocated.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "CA1000:Do not declare static members on generic types",
        Justification = "This is, honestly, a stupid rule.")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Not an issue, since we're returning a class-based atomic enumerator anyway.")]
    [Obsolete("This method will be removed in the next breaking changes release.")]
    [ExcludeFromCodeCoverage]
    public static AtomicEnumerator<TItem> FromCollection<TCollection>(
        TCollection collection,
        Func<ReadOnlySynchronizationLocker> readLock)
        where TCollection : class, IEnumerable<TItem>
    {
        // Validate arguments
        _ = Requires.NotNull(collection);
        _ = Requires.NotNull(readLock);

        Delegate initializer = OldConstructionDelegates.GetOrAdd(
            collection.GetType(),
            static (collectionType) =>
            {
                // Get used types
                MethodInfo getEnumeratorMethodInfo = collectionType.GetMethod(
                    "GetEnumerator",
                    BindingFlags.Public | BindingFlags.Instance)!;

                Type enumeratorType = getEnumeratorMethodInfo.ReturnType;
                Type atomicEnumeratorType = typeof(AtomicEnumerator<,>).MakeGenericType(
                    typeof(TItem),
                    enumeratorType);
                ConstructorInfo atomicEnumeratorConstructorInfo = atomicEnumeratorType.GetConstructors()
                    .Single(
                        p => p.GetParameters()[1]
                              .ParameterType == typeof(Func<ReadOnlySynchronizationLocker>));

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
            });

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
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "CA1000:Do not declare static members on generic types",
        Justification = "This is, honestly, a stupid rule.")]
    [Obsolete("This method will be removed in the next breaking changes release.")]
    [ExcludeFromCodeCoverage]
    public static AtomicEnumerator<TItem> FromEnumerator<TEnumerator>(
        TEnumerator enumerator,
        Func<ReadOnlySynchronizationLocker> readLock)
        where TEnumerator : IEnumerator<TItem>
    {
        _ = Requires.NotNull(enumerator);
        _ = Requires.NotNull(readLock);

        return new AtomicEnumerator<TItem, TEnumerator>(
            enumerator,
            readLock);
    }
}