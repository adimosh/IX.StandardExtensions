// <copyright file="RoslynExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IX.StandardExtensions.SourceGeneration.Helpers
{
    internal static class RoslynExtensions
    {
        public static IEnumerable<ITypeSymbol> GetBaseTypesAndThis(this ITypeSymbol type)
        {
            var current = type;
            while (current != null)
            {
                yield return current;
                current = current.BaseType;
            }
        }

        public static IEnumerable<ISymbol> GetAllMembers(this ITypeSymbol type) =>
            type.GetBaseTypesAndThis()
                .SelectMany(n => n.GetMembers());

        public static string GetName(this ClassDeclarationSyntax source) =>
            source.Identifier.Text;

        public static string GetContainingNamespace(this TypeDeclarationSyntax source)
        {
            SyntaxNode namespaceParent = source.Parent?.Parent;
            List<string> namespaceList = new();

            while (namespaceParent is NamespaceDeclarationSyntax ns)
            {
                namespaceList.Add(ns.Name.ToFullString());
                namespaceParent = ns.Parent;
            }

            if (namespaceList.Count > 0)
            {
                return string.Join(
                    ".",
                    namespaceList);
            }

            if (namespaceParent is CompilationUnitSyntax root)
            {
                return root.ChildNodes()
                    .OfType<NamespaceDeclarationSyntax>()
                    .FirstOrDefault()?
                    .Name.ToString() ?? string.Empty;
            }

            return string.Empty;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0302:Display class allocation to capture closure",
            Justification = "Yeah this is OK.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Performance",
            "HAA0301:Closure Allocation Source",
            Justification = "Yeah this is OK.")]
        public static string[] GetDeclaredFieldNames(
            this FieldDeclarationSyntax source,
            SemanticModel semanticModel) =>
            source.Declaration.Variables.Select(vari => semanticModel.GetDeclaredSymbol(vari) as IFieldSymbol)
                .Where(p => !string.IsNullOrEmpty(p?.Name))
                .Select(p => p.Name)
                .ToArray();
    }
}