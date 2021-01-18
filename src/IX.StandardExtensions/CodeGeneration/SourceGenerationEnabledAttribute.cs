// <copyright file="SourceGenerationEnabledAttribute.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using JetBrains.Annotations;

namespace IX.CodeGeneration
{
    /// <summary>
    /// Attribute to mark classes that are candidates for code generation by the IX.StandardExtensions.SourceGeneration analyzer.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    [PublicAPI]
    public class SourceGenerationEnabledAttribute : Attribute
    {
    }
}