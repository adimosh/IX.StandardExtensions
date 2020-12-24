// <copyright file="AutoDisposableContainerSourceGenerator.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using IX.StandardExtensions.Extensions;
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
    public class AutoDisposableContainerSourceGenerator : ISourceGenerator
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
            if (context.SyntaxReceiver is not MapToReceiver receiver)
            {
                return;
            }

            IGrouping<(string ClassName, string NamespaceName, AccessModifiers AccessModifiers), (string[] Names, string
                ClassName, string NamespaceName, AccessModifiers AccessModifiers)>[] selectedStuff;

            try
            {
                selectedStuff = receiver.Candidates.AsParallel()
                    .SelectMany(p => p.Members)
                    .Where(
                        p => p.AttributeLists.Any(
                            q => q.Attributes.Any(
                                r => r.Name.ToString() == "AutoDisposableMember" ||
                                     r.Name.ToString() == "AutoDisposableMemberAttribute")))
                    .OfType<FieldDeclarationSyntax>()
                    .Select(
                        p =>
                        {
                            SemanticModel semanticModel = context.Compilation.GetSemanticModel(p.SyntaxTree);
                            var names = p.Declaration.Variables
                                .Select(vari => semanticModel.GetDeclaredSymbol(vari) as IFieldSymbol)
                                .Where(p => !string.IsNullOrEmpty(p?.Name))
                                .Select(p => p.Name)
                                .ToArray();

                            string className;
                            AccessModifiers modifier;
                            if (p.Parent is TypeDeclarationSyntax td)
                            {
                                className = semanticModel.GetDeclaredSymbol(td)
                                    ?.Name;

                                modifier = AccessModifiers.None;
                                foreach (var m in td.Modifiers)
                                {
                                    if (m.IsKind(SyntaxKind.PublicKeyword))
                                    {
                                        modifier |= AccessModifiers.Public;
                                    }
                                    else if (m.IsKind(SyntaxKind.PrivateKeyword))
                                    {
                                        modifier |= AccessModifiers.Private;
                                    }
                                    else if (m.IsKind(SyntaxKind.ProtectedKeyword))
                                    {
                                        modifier |= AccessModifiers.Protected;
                                    }
                                    else if (m.IsKind(SyntaxKind.InternalKeyword))
                                    {
                                        modifier |= AccessModifiers.Internal;
                                    }
                                }
                            }
                            else
                            {
                                className = null;
                                modifier = AccessModifiers.None;
                            }

                            SyntaxNode namespaceParent = p.Parent?.Parent;
                            List<string> namespaceList = new();

                            while (namespaceParent is NamespaceDeclarationSyntax ns)
                            {
                                namespaceList.Add(ns.Name.ToFullString());
                                namespaceParent = ns.Parent;
                            }

                            return (Names: names, ClassName: className, NamespaceName: string.Join(
                                ".",
                                namespaceList), AccessModifiers: modifier);
                        })
                    .Where(p => (p.Names?.Length ?? 0) != 0 && p.ClassName != null)
                    .GroupBy(p => (p.ClassName, p.NamespaceName, p.AccessModifiers))
                    .ToArray();
            }
            catch
            {
                return;
            }

            var invalidPathChars = Path.GetInvalidFileNameChars();
            StringBuilder sb = new();
            foreach (IGrouping<(string ClassName, string NamespaceName, AccessModifiers AccessModifiers), (string[] Names, string ClassName, string
                NamespaceName, AccessModifiers AccessModifiers)> s in selectedStuff)
            {
                try
                {
                    var fileName = s.Key.ClassName.Replace(
                        invalidPathChars,
                        '_');

                    sb.Clear();

                    sb.Append($@"namespace {s.Key.NamespaceName}
{{
    ");
                    var modifier = s.Key.AccessModifiers;
                    if (modifier == AccessModifiers.None)
                    {
                        sb.Append("private ");
                    }
                    else
                    {
                        if ((modifier & AccessModifiers.Public) != 0)
                        {
                            sb.Append("public ");
                        }

                        if ((modifier & AccessModifiers.Protected) != 0)
                        {
                            sb.Append("protected ");
                        }

                        if ((modifier & AccessModifiers.Internal) != 0)
                        {
                            sb.Append("internal ");
                        }

                        if ((modifier & AccessModifiers.Private) != 0)
                        {
                            sb.Append("private ");
                        }
                    }

                    sb.Append($@"partial class {s.Key.ClassName}
    {{
        protected override void DisposeAutomatically()
        {{
");

                    foreach ((string[] names, string _, string _, AccessModifiers _) in s)
                    {
                        foreach (var name in names)
                        {
                            sb.Append("            this.");
                            sb.Append(name);
                            sb.AppendLine(".Dispose();");
                        }
                    }

                    sb.Append(
                        @"        }
    }
}");

                    context.AddSource(
                        $"{fileName}.cs",
                        SourceText.From(
                            sb.ToString(),
                            Encoding.UTF8));
                }
                catch
                {
                }
            }
        }

        /// <summary>
        ///     Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Initialize(GeneratorInitializationContext context) =>
            context.RegisterForSyntaxNotifications(() => new MapToReceiver());

#endregion

#endregion

#region Nested types and delegates

        [Flags]
        private enum AccessModifiers
        {
            None = 0,
            Public = 1,
            Private = 2,
            Internal = 4,
            Protected = 8
        }

        private sealed class MapToReceiver : ISyntaxReceiver
        {
#region Properties and indexers

            public List<TypeDeclarationSyntax> Candidates
            {
                get;
            } = new();

#endregion

#region Methods

#region Interface implementations

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is not TypeDeclarationSyntax typeDeclarationSyntax)
                {
                    return;
                }

                if (!typeDeclarationSyntax.Modifiers.Any(SyntaxKind.PartialKeyword))
                {
                    return;
                }

                // if (typeDeclarationSyntax.BaseList?.Ancestors().Any(p => p is type))

                if (typeDeclarationSyntax.AttributeLists.SelectMany(p => p.Attributes).Any(attribute =>
                {
                    var name = attribute.Name.ToString();

                    return name == "AutoDisposableContainer" || name == "AutoDisposableContainerAttribute";
                }))
                {
                    this.Candidates.Add(typeDeclarationSyntax);
                }
            }

#endregion

#endregion
        }

#endregion
    }
}