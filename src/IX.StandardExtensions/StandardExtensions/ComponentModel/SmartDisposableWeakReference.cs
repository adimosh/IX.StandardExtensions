// <copyright file="SmartDisposableWeakReference.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace IX.StandardExtensions.ComponentModel;

/// <summary>
///     A smart weak reference for a <see cref="DisposableBase" />-derived object.
/// </summary>
/// <typeparam name="T">The type of object to hold a weak reference to.</typeparam>
/// <remarks>
///     <para>
///         This class is not intended to offer high performance or to be used in high-throughput scenarios. Should that
///         be the aim of the code, please use a standard <see cref="WeakReference{T}" /> instead.
///     </para>
/// </remarks>
[PublicAPI]
public class SmartDisposableWeakReference<T>
    where T : DisposableBase
{
#region Internal state

    private readonly WeakReference<T> reference;

#endregion

#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="SmartDisposableWeakReference{T}" /> class.
    /// </summary>
    /// <param name="obj">The object.</param>
    public SmartDisposableWeakReference(T obj) => reference = new(obj);

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets a value indicating whether the target is alive.
    /// </summary>
    /// <value>
    ///     <see langword="true" /> if the target hasn't been either disposed or collected; otherwise,
    ///     <see langword="false" />.
    /// </value>
    public bool TargetAlive => TryGetTarget(out _);

#endregion

#region Methods

    /// <summary>
    ///     Tries to retrieve the target object that is weakly referenced by the current
    ///     <see cref="SmartDisposableWeakReference{T}" /> instance.
    /// </summary>
    /// <param name="target">The target, if one isn't already dead or disposed.</param>
    /// <returns>
    ///     <see langword="true" /> if the target is both not disposed and not collected, <see langword="false" />
    ///     otherwise.
    /// </returns>
    public bool TryGetTarget(
        [MaybeNullWhen(false)] [NotNullWhen(true)]
        out T target)
    {
        if (!reference.TryGetTarget(out T? intermediateTarget))
        {
            target = null!;

            return false;
        }

        if (intermediateTarget.Disposed)
        {
            target = null!;

            return false;
        }

        target = intermediateTarget;

        return true;
    }

    /// <summary>
    ///     Sets the target to a new object.
    /// </summary>
    /// <param name="newObject">The new object.</param>
    public void SetTarget(T newObject) => reference.SetTarget(newObject);

#endregion
}