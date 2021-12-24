// <copyright file="StringExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Linq;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions;

/// <summary>
///     Extensions to the <see cref="string" /> class.
/// </summary>
[PublicAPI]
public static class StringExtensions
{
#region Methods

#region Static methods

    /// <summary>
    ///     Determines whether the source string represents a given attribute name.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="attributeName">Name of the attribute.</param>
    /// <returns>
    ///     <c>true</c> if is an attribute name; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     source
    ///     or
    ///     attributeName
    ///     are <c>null</c> (<c>Nothing</c> in Visual Basic).
    /// </exception>
    /// <remarks>
    ///     <para>
    ///         The comparison is always done in an ordinal manner. The method does not check any other convention than the
    ///         English standard, optionally ending in Attribute.
    ///     </para>
    ///     <para>For any other comparison, or for culture-sensitive checks, please do not use this method.</para>
    /// </remarks>
    public static bool IsAttributeName(
        this string source,
        string attributeName)
    {
        Requires.NotNullOrEmpty(source);
        Requires.NotNullOrEmpty(attributeName);

        return source.Equals(
                   attributeName,
                   StringComparison.Ordinal) ||
               (source.Length > 9 &&
                source.EndsWith(
                    "Attribute",
                    StringComparison.Ordinal) &&
                string.Compare(
                    attributeName,
                    0,
                    source,
                    0,
                    source.Length - 9) ==
                0);
    }

    /// <summary>
    ///     Replaces the specified characters in a string with a specific character.
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
        Requires.NotEmpty(charactersToReplace);

        var array = Requires.NotNull(source)
            .ToCharArray();

        for (var i = 0; i < array.Length; i++)
        {
            var c = array[i];
            if (charactersToReplace.Contains(c))
            {
                array[i] = replacementCharacter;
            }
        }

        return new string(array);
    }

#endregion

#endregion
}