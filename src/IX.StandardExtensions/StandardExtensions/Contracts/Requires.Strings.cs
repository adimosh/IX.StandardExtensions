// <copyright file="Requires.Strings.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using IX.StandardExtensions.Efficiency;
using IX.StandardExtensions.Globalization;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Contracts;

/// <summary>
///     Methods for approximating the works of contract-oriented programming.
/// </summary>
public static partial class Requires
{
    #region Not Null

    /// <summary>
    ///     Called when a contract requires that an argument is not null.
    /// </summary>
    /// <typeparam name="T">The type of argument to validate.</typeparam>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     The argument is <see langword="null" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static T NotNull<T>(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument is null)
        {
            throw new ArgumentNullException(argumentName);
        }

        return argument;
    }

    /// <summary>
    ///     Called when a contract requires that an argument is not null.
    /// </summary>
    /// <typeparam name="T">The type of argument to validate.</typeparam>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     The argument is <see langword="null" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static void NotNull<T>(
        out T field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        T? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (argument is null)
        {
            throw new ArgumentNullException(argumentName);
        }

        field = argument;
    }

    #endregion

    #region Not Null or Empty / Whitespace-only

    /// <summary>
    ///     Called when a contract requires that a string argument is not null or empty.
    /// </summary>
    /// <param name="argument">
    ///     The string argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNullOrEmptyStringException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static string NotNullOrEmpty(
        [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (string.IsNullOrEmpty(argument))
        {
            throw new ArgumentNullOrEmptyStringException(argumentName);
        }

        return argument!;
    }

    /// <summary>
    ///     Called when a contract requires that a string argument is not null or empty.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The string argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNullOrEmptyStringException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static void NotNullOrEmpty(
        out string field,
        [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (string.IsNullOrEmpty(argument))
        {
            throw new ArgumentNullOrEmptyStringException(argumentName);
        }

        field = argument!;
    }

    /// <summary>
    ///     Called when a contract requires that a string argument is not null empty or whitespace-only.
    /// </summary>
    /// <param name="argument">
    ///     The string argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <returns>
    ///     The validated argument.
    /// </returns>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static string NotNullOrWhiteSpace(
        [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        return argument!;
    }

    /// <summary>
    ///     Called when a contract requires that a string argument is not null empty or whitespace-only.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">
    ///     The string argument.
    /// </param>
    /// <param name="argumentName">
    ///     The argument name.
    /// </param>
    /// <exception cref="ArgumentNullOrWhiteSpaceStringException">
    ///     The argument is <see langword="null" /> or empty.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static void NotNullOrWhiteSpace(
        out string field,
        [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? argument,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument")
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            throw new ArgumentNullOrWhiteSpaceStringException(argumentName);
        }

        field = argument!;
    }

    #endregion

    #region Length

    /// <summary>Called when a contract requires that an string is of a specific length.</summary>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("stringToTest:null => halt")]
    public static string FixedLength(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length != length)
        {
            throw new ArgumentOutOfRangeException(lengthArgumentName);
        }

        return stringToTest;
    }

    /// <summary>Called when a contract requires that an string is of a specific length.</summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("stringToTest:null => halt")]
    public static void FixedLength(
        out string field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length != length)
        {
            throw new ArgumentOutOfRangeException(lengthArgumentName);
        }

        field = stringToTest;
    }

    /// <summary>Called when a contract requires that an string's length is at least a specific value.</summary>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("stringToTest:null => halt")]
    public static string LengthAtLeast(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        return stringToTest;
    }

    /// <summary>Called when a contract requires that an string's length is at least a specific value.</summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("stringToTest:null => halt")]
    public static void LengthAtLeast(
        out string field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 0)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        field = stringToTest;
    }

    /// <summary>Called when a contract requires that an string's length is at most a specific value.</summary>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("stringToTest:null => halt")]
    public static string LengthAtMost(
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length < 1)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length > length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        return stringToTest;
    }

    /// <summary>Called when a contract requires that an string's length is at most a specific value.</summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="stringToTest">The string for which we are validating the length.</param>
    /// <param name="length">The exact length.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="lengthArgumentName">The name for the length argument.</param>
    /// <exception cref="ArgumentNotPositiveIntegerException">
    ///     The argument is either negative or exceeds the bounds of the
    ///     string.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("stringToTest:null => halt")]
    public static void LengthAtMost(
        out string field,
        [NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
        string? stringToTest,
        in int length,
        [CallerArgumentExpression("stringToTest")]
        string argumentName = "stringToTest",
        [CallerArgumentExpression("length")]
        string lengthArgumentName = "length")
    {
        if (stringToTest == null)
        {
            throw new ArgumentNullOrEmptyArrayException(argumentName);
        }

        if (length > 1)
        {
            throw new ArgumentNotValidLengthException(lengthArgumentName);
        }

        if (stringToTest.Length < length)
        {
            throw new ArgumentOutOfRangeException(argumentName);
        }

        field = stringToTest;
    }

    #endregion

    #region Matches

    [SuppressMessage(
        "StyleCop.CSharp.OrderingRules",
        "SA1201:Elements should appear in the correct order",
        Justification = "Better code readability this way.")]
    private static readonly Lazy<ConcurrentDictionary<string, Regex>> Regexes = new(() => new ConcurrentDictionary<string, Regex>());

    /// <summary>
    /// Called when a contract requires that a string matches a specific pattern.
    /// </summary>
    /// <param name="argument">The string to validate.</param>
    /// <param name="pattern">The pattern to match.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="patternArgumentName">The argument name for the pattern argument.</param>
    /// <returns>The validated argument.</returns>
    /// <exception cref="ArgumentNullOrEmptyStringException">The pattern is <c>null</c> (<c>Nothing in Visual Basic</c>) or empty.</exception>
    /// <exception cref="ArgumentNullException">The argument is <c>null</c> (<c>Nothing in Visual Basic</c>).</exception>
    /// <exception cref="ArgumentDoesNotMatchException">The argument does not match the pattern.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt; pattern:null => halt")]
    [AssertionMethod]
    public static string Matches(
        string? argument,
        string pattern,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("pattern")]
        string patternArgumentName = "pattern")
    {
        if (string.IsNullOrEmpty(pattern))
        {
            throw new ArgumentNullOrEmptyStringException(patternArgumentName);
        }

        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        var patternRegex = Regexes.Value.GetOrAdd(
            pattern,
            p => new Regex(p));

        if (!patternRegex.IsMatch(argument))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        return argument;
    }

    /// <summary>
    /// Called when a contract requires that a string matches a specific pattern.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">The string to validate.</param>
    /// <param name="pattern">The pattern to match.</param>
    /// <param name="argumentName">The argument name.</param>
    /// <param name="patternArgumentName">The argument name for the pattern argument.</param>
    /// <exception cref="ArgumentNullOrEmptyStringException">The pattern is <c>null</c> (<c>Nothing in Visual Basic</c>) or empty.</exception>
    /// <exception cref="ArgumentNullException">The argument is <c>null</c> (<c>Nothing in Visual Basic</c>).</exception>
    /// <exception cref="ArgumentDoesNotMatchException">The argument does not match the pattern.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt; pattern:null => halt")]
    [AssertionMethod]
    public static void Matches(
        out string field,
        string? argument,
        string pattern,
        [CallerArgumentExpression("argument")]
        string argumentName = "argument",
        [CallerArgumentExpression("pattern")]
        string patternArgumentName = "pattern")
    {
        if (string.IsNullOrEmpty(pattern))
        {
            throw new ArgumentNullOrEmptyStringException(patternArgumentName);
        }

        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        var patternRegex = Regexes.Value.GetOrAdd(
            pattern,
            p => new Regex(p));

        if (!patternRegex.IsMatch(argument))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        field = argument;
    }

    #endregion

    #region Web validation

    private static readonly Lazy<Regex> EmailValidationRegex = new(() => new Regex(@"^[\w\d](?:[\w\d.!#$%&’*+/=?^_`{|}~-]*[\w\d])?@(?:[\w\d-]+\.)*(?<tld>[\w\d-]+)$"));

    private static readonly Lazy<string[]> IanaTlds = new(
        () =>
        {
            using StreamReader sr = new StreamReader(
                Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(
                        "IX.StandardExtensions.Contracts.ValidationResources.tlds-alpha-by-domain.txt")!,
                Encoding.ASCII,
                false,
                1000,
                true);

            List<string> tlds = new();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine()?
                    .Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line.StartsWith("#"))
                {
                    continue;
                }

                tlds.Add(line);
            }

            return tlds.ToArray();
        });

    /// <summary>
    /// Called when a contract requires that a string is a valid email address.
    /// </summary>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <returns>The validated argument.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static string ValidEmailAddress(
        string argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        var match = EmailValidationRegex.Value.Match(argument);

        if (!match.Success)
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        return argument;
    }

    /// <summary>
    /// Called when a contract requires that a string is a valid email address.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The name of the argument.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static void ValidEmailAddress(
        out string field,
        string argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        var match = EmailValidationRegex.Value.Match(argument);

        if (!match.Success)
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        field = argument;
    }

    /// <summary>
    /// Called when a contract requires that a string is a valid email address, including IANA TLDs.
    /// </summary>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <returns>The validated argument.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static string ValidEmailAddressStrict(
        string argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        var match = EmailValidationRegex.Value.Match(argument);

        if (!match.Success)
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        var tld = match.Groups["tld"]
            .Value;

        if (!IanaTlds.Value.Any(p => p.OrdinalEqualsInsensitive(tld)))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        return argument;
    }

    /// <summary>
    /// Called when a contract requires that a string is a valid email address, including IANA TLDs.
    /// </summary>
    /// <param name="field">
    ///     The field that this argument is initializing.
    /// </param>
    /// <param name="argument">The argument to validate.</param>
    /// <param name="argumentName">The name of the argument.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [ContractAnnotation("argument:null => halt")]
    [AssertionMethod]
    public static void ValidEmailAddressStrict(
        out string field,
        string argument,
        [CallerArgumentExpression("argument")] string argumentName = "argument")
    {
        if (argument == null)
        {
            throw new ArgumentNullException(argumentName);
        }

        var match = EmailValidationRegex.Value.Match(argument);

        if (!match.Success)
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        if (!IanaTlds.Value.Any(p => p.OrdinalEqualsInsensitive(p)))
        {
            throw new ArgumentDoesNotMatchException(argumentName);
        }

        field = argument;
    }

    #endregion
}