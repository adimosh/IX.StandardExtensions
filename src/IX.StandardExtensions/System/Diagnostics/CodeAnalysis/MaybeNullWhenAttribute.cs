// <copyright file="MaybeNullWhenAttribute.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !FRAMEWORK_ADVANCED
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace - We want this
namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>
    ///     Specifies that when a method returns <see cref="ReturnValue" />, the parameter may be null even if the
    ///     corresponding type disallows it. This type is only provided to stop warnings from unsupported frameworks.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [PublicAPI]
    public sealed class MaybeNullWhenAttribute : Attribute
    {
#region Constructors and destructors

        /// <summary>Initializes the attribute with the specified return value condition.</summary>
        /// <param name="returnValue">
        ///     The return value condition. If the method returns this value, the associated parameter may be null.
        /// </param>
        public MaybeNullWhenAttribute(bool returnValue)
        {
            this.ReturnValue = returnValue;
        }

#endregion

#region Properties and indexers

        /// <summary>Gets the return value condition.</summary>
        public bool ReturnValue { get; }

#endregion
    }
}
#endif