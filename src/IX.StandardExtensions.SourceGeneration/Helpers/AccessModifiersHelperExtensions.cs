// <copyright file="AccessModifiersHelperExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Text;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IX.StandardExtensions.SourceGeneration.Helpers
{
    internal static class AccessModifiersHelperExtensions
    {
        internal static void AppendAccessModifierKeywords(
            this StringBuilder sb,
            AccessModifiers modifiers)
        {
            if (modifiers == AccessModifiers.None)
            {
                sb.Append("private ");
            }
            else
            {
                if ((modifiers & AccessModifiers.Public) != 0)
                {
                    sb.Append("public ");
                }

                if ((modifiers & AccessModifiers.Protected) != 0)
                {
                    sb.Append("protected ");
                }

                if ((modifiers & AccessModifiers.Internal) != 0)
                {
                    sb.Append("internal ");
                }

                if ((modifiers & AccessModifiers.Private) != 0)
                {
                    sb.Append("private ");
                }
            }
        }

        internal static AccessModifiers GetApplicableAccessModifier(this TypeDeclarationSyntax tds)
        {
            var modifier = AccessModifiers.None;
            foreach (var m in tds.Modifiers)
            {
                switch (m.RawKind)
                {
                    case (int)SyntaxKind.PublicKeyword:
                        modifier |= AccessModifiers.Public;
                        break;
                    case (int)SyntaxKind.ProtectedKeyword:
                        modifier |= AccessModifiers.Protected;
                        break;
                    case (int)SyntaxKind.InternalKeyword:
                        modifier |= AccessModifiers.Internal;
                        break;
                    case (int)SyntaxKind.PrivateKeyword:
                        modifier |= AccessModifiers.Private;
                        break;
                }
            }

            return modifier;
        }
    }
}