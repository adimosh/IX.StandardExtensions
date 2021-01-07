// <copyright file="DebugDiagnosticsExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using Microsoft.CodeAnalysis;

namespace IX.StandardExtensions.SourceGeneration.Helpers
{
    internal static class DebugDiagnosticsExtensions
    {
        [Conditional("DEBUG")]
        internal static void DebugWarning(this GeneratorExecutionContext context, string message) => context.ReportDiagnostic(
                Diagnostic.Create(
                    "IXDEBUGDEBUG",
                    "Debug",
                    message,
                    DiagnosticSeverity.Warning,
                    DiagnosticSeverity.Warning,
                    true,
                    4));
    }
}