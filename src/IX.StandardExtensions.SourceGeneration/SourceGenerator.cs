// <copyright file="SourceGenerator.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IX.StandardExtensions.Extensions;
using IX.StandardExtensions.SourceGeneration.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace IX.StandardExtensions.SourceGeneration
{
    /// <summary>
    ///     A source generator for an automatically-disposable container.
    /// </summary>
    /// <seealso cref="Microsoft.CodeAnalysis.ISourceGenerator" />
    [Generator]
    public class SourceGenerator : ISourceGenerator
    {
        private readonly object lockTarget = new();

        #region Methods

        #region Interface implementations

        /// <summary>
        ///     Executes the generator in the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0302:Display class allocation to capture closure",
            Justification = "This is acceptable in this case.")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0301:Closure Allocation Source",
            Justification = "This is acceptable in this case.")]
        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not StandardTypesSyntaxReceiver receiver)
            {
                return;
            }

            if (receiver.Candidates.Count == 0)
            {
                return;
            }

            try
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        DiagnosticDescriptors.Dd1003,
                        Location.None,
                        receiver.Candidates.Count));

                ConcurrentBag<(TypeDeclarationSyntax Type, string[] FieldNames)> autoDisposeMembers = new();

                Parallel.ForEach(
                    receiver.Candidates,
                    SelectCandidateMembers);

                void SelectCandidateMembers(StandardTypesSyntaxReceiver.CandidateEntry candidate)
                {
                    var syntaxTree = candidate.TypeDeclaration.SyntaxTree;
                    SemanticModel semanticModel = context.Compilation.GetSemanticModel(syntaxTree);
                    var semanticType = semanticModel.GetDeclaredSymbol(candidate.TypeDeclaration);

                    if (semanticType == null)
                    {
                        return;
                    }

                    if (!candidate.IsPartial)
                    {
                        context.ReportDiagnostic(
                            Diagnostic.Create(
                                DiagnosticDescriptors.Dd1001,
                                Location.Create(
                                    syntaxTree,
                                    candidate.TypeDeclaration.Identifier.Span),
                                semanticType.Name));

                        return;
                    }

                    foreach (var member in candidate.TypeDeclaration.Members)
                    {
                        if (member is FieldDeclarationSyntax field)
                        {
                            // Test for auto-disposable
                            if (field.AttributeLists.Any(
                                q => q.Attributes.Any(
                                    r => r.Name.ToString()
                                        .IsAttributeName("AutoDisposableMember"))))
                            {
                                var names = field.GetDeclaredFieldNames(semanticModel);

                                // Check whether the base class is inherited from DisposableBase
                                if (semanticType.GetBaseTypesAndThis()
                                    .All(p => p.Name != "DisposableBase"))
                                {
                                    context.ReportDiagnostic(
                                        Diagnostic.Create(
                                            DiagnosticDescriptors.Dd1002,
                                            Location.Create(
                                                syntaxTree,
                                                field.Span),
                                            string.Join(
                                                ",",
                                                names),
                                            semanticType.Name));
                                }
                                else
                                {
                                    autoDisposeMembers.Add((candidate.TypeDeclaration, names));
                                }
                            }
                        }
                    }
                }

                // Auto-dispose members
                Parallel.ForEach(
                    autoDisposeMembers.GroupBy(p => p.Type),
                    ProcessAutoDispose);

                void ProcessAutoDispose(
                    IGrouping<TypeDeclarationSyntax, (TypeDeclarationSyntax Type, string[] FieldNames)> s)
                {
                    try
                    {
                        TypeDeclarationSyntax key = s.Key;
                        var syntaxTree = key.SyntaxTree;
                        SemanticModel semanticModel = context.Compilation.GetSemanticModel(syntaxTree);
                        var className = semanticModel.GetDeclaredSymbol(key)
                            ?.Name;

                        if (className == null)
                        {
                            return;
                        }

                        var fileName = className.Replace(
                            Path.GetInvalidFileNameChars(),
                            '_');

                        StringBuilder sb = new();

                        sb.Append(
                            $@"// <auto-generated />

namespace {key.GetContainingNamespace()}
{{
    ");

                        sb.AppendAccessModifierKeywords(key.GetApplicableAccessModifier());

                        sb.Append(
                            $@"partial class {className}
    {{
        protected override void DisposeAutomatically()
        {{
            this.Dispose_AutoGenerated();
        }}

        private void Dispose_AutoGenerated()
        {{
");

                        foreach (var (_, fieldNames) in s)
                        {
                            foreach (var name in fieldNames)
                            {
                                sb.Append("            this.");
                                sb.Append(name);
                                sb.AppendLine("?.Dispose();");
                            }
                        }

                        sb.Append(
                            @"
            base.DisposeAutomatically();
        }
    }
}");

                        lock (this.lockTarget)
                        {
                            context.AddSource(
                                $"{fileName}.AutoDispose.cs",
                                SourceText.From(
                                    sb.ToString(),
                                    Encoding.UTF8));
                        }
                    }
                    catch (Exception ex)
                    {
                        context.ReportDiagnostic(
                            Diagnostic.Create(
                                DiagnosticDescriptors.Dd1004,
                                Location.None,
                                ex.GetType(),
                                ex));
                    }
                }
            }
            catch (Exception e)
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        DiagnosticDescriptors.Dd1004,
                        Location.None,
                        e.GetType(),
                        e));
            }
        }

        /// <summary>
        ///     Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Initialize(GeneratorInitializationContext context) =>
            context.RegisterForSyntaxNotifications(() => new StandardTypesSyntaxReceiver());

        #endregion

        #endregion
    }
}