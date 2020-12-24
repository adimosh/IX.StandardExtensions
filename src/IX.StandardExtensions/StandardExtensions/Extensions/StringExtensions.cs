// <copyright file="StringExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Linq;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    /// Extensions to the <see cref="string"/> class.
    /// </summary>
    [PublicAPI]
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces the specified characters in a string with a specific character.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="charactersToReplace">The characters to replace.</param>
        /// <param name="replacementCharacter">The replacement character.</param>
        /// <returns>A new string, with the characters replaced, if found, otherwise a copy of the original string.</returns>
        public static string Replace(
            this string source,
            char[] charactersToReplace,
            char replacementCharacter)
        {
            if (charactersToReplace == null || charactersToReplace.Length == 0)
            {
                throw new ArgumentNullException(nameof(charactersToReplace));
            }

            var array = (source ?? throw new ArgumentNullException(nameof(source))).ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                char c = array[i];
                if (charactersToReplace.Contains(c))
                {
                    array[i] = replacementCharacter;
                }
            }

            return new string(array);
        }
    }
}