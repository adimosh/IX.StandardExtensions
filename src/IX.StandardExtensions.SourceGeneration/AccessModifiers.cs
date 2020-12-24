using System;

namespace IX.StandardExtensions.SourceGeneration
{
    [Flags]
    internal enum AccessModifiers
    {
        None = 0,
        Public = 1,
        Private = 2,
        Internal = 4,
        Protected = 8
    }
}