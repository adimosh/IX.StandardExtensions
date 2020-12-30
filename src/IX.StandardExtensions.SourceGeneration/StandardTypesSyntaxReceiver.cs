// <copyright file="StandardTypesSyntaxReceiver.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using IX.StandardExtensions.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IX.StandardExtensions.SourceGeneration
{
    internal sealed partial class StandardTypesSyntaxReceiver : ISyntaxReceiver
    {
#region Properties and indexers

        public List<CandidateEntry> Candidates
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
                // We'll discover types
                return;
            }

            if (!typeDeclarationSyntax.AttributeLists.SelectMany(p => p.Attributes)
                .Any(
                    attribute => attribute.Name.ToString().IsAttributeName("SourceGenerationEnabled")))
            {
                // Type not marked for source generation
                return;
            }

            // We'll see if the type is partial - we can't do generation if it isn't, and we must show a warning
            bool isPartial = typeDeclarationSyntax.Modifiers.Any(SyntaxKind.PartialKeyword);

            // We'll add our candidate to the list
            this.Candidates.Add(new CandidateEntry
            {
                TypeDeclaration = typeDeclarationSyntax,
                IsPartial = isPartial
            });
        }

#endregion

#endregion
    }
}