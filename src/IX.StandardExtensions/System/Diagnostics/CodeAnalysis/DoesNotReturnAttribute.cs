// <copyright file="DoesNotReturnAttribute.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !FRAMEWORK_ADVANCED
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace - We want this
namespace System.Diagnostics.CodeAnalysis;

/// <summary>
///     Attribute to indicate that the method never returns, and has an exit path that will bring the process down.
/// </summary>
[AttributeUsage(
    AttributeTargets.Method,
    Inherited = false)]
[PublicAPI]
public sealed class DoesNotReturnAttribute : Attribute { }
#endif