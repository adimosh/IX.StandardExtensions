// <copyright file="DiagnosticDescriptors.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using Microsoft.CodeAnalysis;

namespace IX.StandardExtensions.SourceGeneration
{
    internal static class DiagnosticDescriptors
    {
        internal static readonly DiagnosticDescriptor Dd1001 = new(
            "IXSTDEXTSG1001",
            "Type with source generation enabled not marked as 'partial'",
            "The type '{0}' is marked for source generation, but the type is not marked as partial, so source generation cannot take place.",
            "Design",
            DiagnosticSeverity.Warning,
            true);

        internal static readonly DiagnosticDescriptor Dd1002 = new(
            "IXSTDEXTSG1002",
            "Auto-dispose member on non-disposable type",
            "The field(s) '{0}' have an auto-dispose attribute, but the containing type '{1}' does not inherit DisposableBase.",
            "Design",
            DiagnosticSeverity.Warning,
            true);

        internal static readonly DiagnosticDescriptor Dd1003 = new(
            "IXSTDEXTSG1003",
            "Classes found",
            "There are {0} candidate classes to do source generation on.",
            "Statistics",
            DiagnosticSeverity.Info,
            true);

        internal static readonly DiagnosticDescriptor Dd1004 = new(
            "IXSTDEXTSG1004",
            "Error during source generation",
            "There was an exception of type {0} during source generation: {1}.",
            "Errors",
            DiagnosticSeverity.Error,
            true);
    }
}