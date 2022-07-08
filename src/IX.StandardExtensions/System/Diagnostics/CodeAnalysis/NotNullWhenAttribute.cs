// <copyright file="NotNullWhenAttribute.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !FRAMEWORK_ADVANCED
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace - We want this
namespace System.Diagnostics.CodeAnalysis;

/// <summary>
///     Specifies that when a method returns <see cref="ReturnValue" />, the parameter will not be null even if the
///     corresponding type allows it. This type is only provided to stop warnings from unsupported frameworks.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
[PublicAPI]
public sealed class NotNullWhenAttribute : Attribute
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="NotNullWhenAttribute" /> class with the specified return value
    ///     condition.
    /// </summary>
    /// <param name="returnValue">
    ///     The return value condition. If the method returns this value, the associated parameter will not be null.
    /// </param>
    public NotNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

#endregion

#region Properties and indexers

    /// <summary>Gets the return value condition.</summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1623:Property summary documentation should match accessors",
        Justification = "This property is a return value and is not a switch.")]
    public bool ReturnValue { get; }

#endregion
}
#endif