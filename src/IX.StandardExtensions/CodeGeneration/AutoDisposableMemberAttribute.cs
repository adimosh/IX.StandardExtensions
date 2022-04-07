// <copyright file="AutoDisposableMemberAttribute.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.StandardExtensions.ComponentModel;
using JetBrains.Annotations;

namespace IX.CodeGeneration;

/// <summary>
/// An attribute that can be placed on fields in classes inheriting from <see cref="DisposableBase"/> in order to mark them for auto-disposal.
/// </summary>
/// <seealso cref="Attribute" />
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
[PublicAPI]
public class AutoDisposableMemberAttribute : Attribute
{
}