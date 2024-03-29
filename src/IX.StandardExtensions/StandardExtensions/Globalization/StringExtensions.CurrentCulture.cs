// <copyright file="StringExtensions.CurrentCulture.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Globalization;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Globalization;

/// <summary>
///     Extensions to strings to help with globalization.
/// </summary>
[PublicAPI]
public static partial class StringExtensions
{
#region Methods

#region Static methods

    /// <summary>
    ///     Compares the source string with a selected value in a case-sensitive manner using the comparison rules of the UI
    ///     thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     The comparison of the two strings, with 0 meaning equality.
    /// </returns>
    public static int CurrentCultureCompareTo(
        this string source,
        string value) =>
        CultureInfo.CurrentCulture.CompareInfo.Compare(
            source,
            value,
            CompareOptions.None);

    /// <summary>
    ///     Compares the source string with a selected value in a case-insensitive manner using the comparison rules of the UI
    ///     thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     The comparison of the two strings, with 0 meaning equality.
    /// </returns>
    public static int CurrentCultureCompareToInsensitive(
        this string source,
        string value) =>
        CultureInfo.CurrentCulture.CompareInfo.Compare(
            source,
            value,
            CompareOptions.IgnoreCase);

    /// <summary>
    ///     Determines whether a source string contains the specified value string in a case-sensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string contains the specified value string; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool CurrentCultureContains(
        this string source,
        string value) =>
        source.CurrentCultureIndexOf(value) >= 0;

    /// <summary>
    ///     Determines whether a source string contains the specified value string in a case-insensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string contains the specified value string; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool CurrentCultureContainsInsensitive(
        this string source,
        string value) =>
        source.CurrentCultureIndexOfInsensitive(value) >= 0;

    /// <summary>
    ///     Checks whether or not the source string ends with a selected value in a case-sensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool CurrentCultureEndsWith(
        this string source,
        string value) =>
        CultureInfo.CurrentCulture.CompareInfo.IsSuffix(
            source,
            value,
            CompareOptions.None);

    /// <summary>
    ///     Checks whether or not the source string ends with a selected value in a case-insensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool CurrentCultureEndsWithInsensitive(
        this string source,
        string value) =>
        CultureInfo.CurrentCulture.CompareInfo.IsSuffix(
            source,
            value,
            CompareOptions.IgnoreCase);

    /// <summary>
    ///     Equates the source string with a selected value in a case-sensitive manner using the comparison rules of the UI
    ///     thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool CurrentCultureEquals(
        this string source,
        string value) =>
        source.CurrentCultureCompareTo(value) == 0;

    /// <summary>
    ///     Equates the source string with a selected value in a case-insensitive manner using the comparison rules of the UI
    ///     thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool CurrentCultureEqualsInsensitive(
        this string source,
        string value) =>
        source.CurrentCultureCompareToInsensitive(value) == 0;

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     The index where the string is found, otherwise -1.
    /// </returns>
    public static int CurrentCultureIndexOf(
        this string source,
        string value) =>
        CultureInfo.CurrentCulture.CompareInfo.IndexOf(
            source,
            value,
            CompareOptions.None);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <param name="startIndex">The index in the source string to start searching at.</param>
    /// <returns>The index where the string is found, otherwise -1.</returns>
    public static int CurrentCultureIndexOf(
        this string source,
        string value,
        int startIndex) =>
        CultureInfo.CurrentCulture.CompareInfo.IndexOf(
            source,
            value,
            startIndex,
            CompareOptions.None);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-sensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <param name="startIndex">The index in the source string to start searching at.</param>
    /// <param name="count">The number of characters to search.</param>
    /// <returns>The index where the string is found, otherwise -1.</returns>
    public static int CurrentCultureIndexOf(
        this string source,
        string value,
        int startIndex,
        int count) =>
        CultureInfo.CurrentCulture.CompareInfo.IndexOf(
            source,
            value,
            startIndex,
            count,
            CompareOptions.None);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     The index where the string is found, otherwise -1.
    /// </returns>
    public static int CurrentCultureIndexOfInsensitive(
        this string source,
        string value) =>
        CultureInfo.CurrentCulture.CompareInfo.IndexOf(
            source,
            value,
            CompareOptions.IgnoreCase);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <param name="startIndex">The index in the source string to start searching at.</param>
    /// <returns>The index where the string is found, otherwise -1.</returns>
    public static int CurrentCultureIndexOfInsensitive(
        this string source,
        string value,
        int startIndex) =>
        CultureInfo.CurrentCulture.CompareInfo.IndexOf(
            source,
            value,
            startIndex,
            CompareOptions.IgnoreCase);

    /// <summary>
    ///     Finds the index of the specified value string in a source string in a case-insensitive manner using the comparison
    ///     rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <param name="startIndex">The index in the source string to start searching at.</param>
    /// <param name="count">The number of characters to search.</param>
    /// <returns>The index where the string is found, otherwise -1.</returns>
    public static int CurrentCultureIndexOfInsensitive(
        this string source,
        string value,
        int startIndex,
        int count) =>
        CultureInfo.CurrentCulture.CompareInfo.IndexOf(
            source,
            value,
            startIndex,
            count,
            CompareOptions.IgnoreCase);

    /// <summary>
    ///     Checks whether or not the source string starts with a selected value in a case-sensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool CurrentCultureStartsWith(
        this string source,
        string value) =>
        CultureInfo.CurrentCulture.CompareInfo.IsPrefix(
            source,
            value,
            CompareOptions.None);

    /// <summary>
    ///     Checks whether or not the source string starts with a selected value in a case-insensitive manner using the
    ///     comparison rules of the UI thread culture.
    /// </summary>
    /// <param name="source">The source to search in.</param>
    /// <param name="value">The string value to do the evaluation.</param>
    /// <returns>
    ///     <see langword="true" /> if the source string is equal to the value; otherwise, <see langword="false" />.
    /// </returns>
    public static bool CurrentCultureStartsWithInsensitive(
        this string source,
        string value) =>
        CultureInfo.CurrentCulture.CompareInfo.IsPrefix(
            source,
            value,
            CompareOptions.IgnoreCase);

#endregion

#endregion
}