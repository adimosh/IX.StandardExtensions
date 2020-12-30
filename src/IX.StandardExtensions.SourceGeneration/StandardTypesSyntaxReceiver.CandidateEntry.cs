using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IX.StandardExtensions.SourceGeneration
{
    internal sealed partial class StandardTypesSyntaxReceiver
    {
#if NET50
        internal readonly struct CandidateEntry
        {
            internal TypeDeclarationSyntax TypeDeclaration
            {
                get;
                init;
            }

            internal bool IsPartial
            {
                get;
                init;
            }
        }
#else
        internal struct CandidateEntry
        {
            internal TypeDeclarationSyntax TypeDeclaration
            {
                get;
                set;
            }

            internal bool IsPartial
            {
                get;
                set;
            }
        }
#endif
    }
}