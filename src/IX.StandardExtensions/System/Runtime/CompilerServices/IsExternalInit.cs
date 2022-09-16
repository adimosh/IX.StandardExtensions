// <copyright file="IsExternalInit.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !NET6_0_OR_GREATER
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices;

/// <summary>
///     Dummy class for allowing init-only properties in pre-.NET 5.0 frameworks.
/// </summary>
[PublicAPI]
public class IsExternalInit { }
#endif