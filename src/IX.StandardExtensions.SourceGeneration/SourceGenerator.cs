// <copyright file="SourceGenerator.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        #region Methods

        #region Interface implementations

        /// <summary>
        ///     Executes the generator in the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        [SuppressMessage(
            "CodeSmell",
            "ERP022:Unobserved exception in a generic exception handler",
            Justification = "It is important that exceptions do not break the build process.")]
        [SuppressMessage(
            "ReSharper",
            "EmptyGeneralCatchClause",
            Justification = "It is important that exceptions do not break the build process.")]
        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not StandardTypesSyntaxReceiver receiver)
            {
                return;
            }

            List<(TypeDeclarationSyntax Type, string[] fieldNames)> autoDisposeMembers = new();

            Parallel.ForEach(
                receiver.Candidates,
                candidate =>
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
                                            string.Join(",", names),
                                            semanticType.Name));
                                }
                                else
                                {
                                    autoDisposeMembers.Add((candidate.TypeDeclaration, names));
                                }
                            }
                        }
                    }
                });

            var invalidPathChars = Path.GetInvalidFileNameChars();

            // Auto-dispose members
            Parallel.ForEach(
                autoDisposeMembers.GroupBy(p => p.Type),
                s =>
                {
                    try
                    {
                        TypeDeclarationSyntax key = s.Key;
                        var syntaxTree = key.SyntaxTree;
                        SemanticModel semanticModel = context.Compilation.GetSemanticModel(syntaxTree);
                        var className = semanticModel.GetDeclaredSymbol(key)?
                            .Name;

                        if (className == null)
                        {
                            return;
                        }

                        var fileName = className.Replace(
                            invalidPathChars,
                            '_');

                        StringBuilder sb = new();

                        sb.Append($@"// <auto-generated />

namespace {key.GetContainingNamespace()}
{{
    ");

                        sb.AppendAccessModifierKeywords(key.GetApplicableAccessModifier());

                        sb.Append($@"partial class {className}
    {{
        protected override void DisposeAutomatically()
        {{
");

                        foreach (var fieldGroups in s)
                        {
                            foreach (var name in fieldGroups.fieldNames)
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

                        context.AddSource(
                            $"{fileName}.AutoDispose.cs",
                            SourceText.From(
                                sb.ToString(),
                                Encoding.UTF8));
                    }
                    catch
                    {
                    }
                });
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