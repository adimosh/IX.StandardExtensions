// <copyright file="RequiresUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using IX.StandardExtensions.Contracts;
using Xunit;

namespace IX.UnitTests.StandardExtensions.Contracts
{
    /// <summary>
    /// Unit tests for Requires class.
    /// </summary>
    public class RequiresUnitTests
    {
        /// <summary>
        /// Requires.NotNull on null class.
        /// </summary>
        [Fact(DisplayName = "Requires.NotNull on null class.")]
        [SuppressMessage(
            "ReSharper",
            "HeuristicUnreachableCode",
            Justification = "This is the purpose of the test.")]
        public void Test1()
        {
            string x = null;
            try
            {
                Requires.NotNull(x, nameof(x));
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.True(false, "The expected exception was not thrown.");
        }

        /// <summary>
        /// Requires.NotNull on not-null class.
        /// </summary>
        [Fact(DisplayName = "Requires.NotNull on not-null class.")]
        [SuppressMessage(
            "ReSharper",
            "HeuristicUnreachableCode",
            Justification = "This is the purpose of the test.")]
        public void Test2()
        {
            string x = "alabala";
            try
            {
                Requires.NotNull(x, nameof(x));
            }
            catch
            {
                Assert.True(false, "An exception was thrown even if one was not expected.");
            }
        }

        /// <summary>
        /// Requires.NotNull on null nullable value.
        /// </summary>
        [Fact(DisplayName = "Requires.NotNull on null nullable value.")]
        [SuppressMessage(
            "ReSharper",
            "HeuristicUnreachableCode",
            Justification = "This is the purpose of the test.")]
        public void Test3()
        {
            int? x = null;
            try
            {
                Requires.NotNull(x, nameof(x));
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.True(false, "The expected exception was not thrown.");
        }

        /// <summary>
        /// Requires.NotNull on not-null nullable value.
        /// </summary>
        [Fact(DisplayName = "Requires.NotNull on not-null nullable value.")]
        [SuppressMessage(
            "ReSharper",
            "HeuristicUnreachableCode",
            Justification = "This is the purpose of the test.")]
        public void Test4()
        {
            int? x = 2;
            try
            {
                Requires.NotNull(x, nameof(x));
            }
            catch
            {
                Assert.True(false, "An exception was thrown even if one was not expected.");
            }
        }

        #nullable enable

        /// <summary>
        /// Requires.NotNull on null nullable class.
        /// </summary>
        [Fact(DisplayName = "Requires.NotNull on null nullable class.")]
        [SuppressMessage(
            "ReSharper",
            "HeuristicUnreachableCode",
            Justification = "This is the purpose of the test.")]
        public void Test5()
        {
            string? x = null;
            try
            {
                Requires.NotNull(x, nameof(x));
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.True(false, "The expected exception was not thrown.");
        }

        /// <summary>
        /// Requires.NotNull on not-null nullable class.
        /// </summary>
        [Fact(DisplayName = "Requires.NotNull on not-null nullable class.")]
        [SuppressMessage(
            "ReSharper",
            "HeuristicUnreachableCode",
            Justification = "This is the purpose of the test.")]
        public void Test6()
        {
            string? x = "alabala";
            try
            {
                Requires.NotNull(x, nameof(x));
            }
            catch
            {
                Assert.True(false, "An exception was thrown even if one was not expected.");
            }
        }

        /// <summary>
        /// Requires.NotNull on null non-nullable class.
        /// </summary>
        [Fact(DisplayName = "Requires.NotNull on null non-nullable class.")]
        [SuppressMessage(
            "ReSharper",
            "HeuristicUnreachableCode",
            Justification = "This is the purpose of the test.")]
        public void Test7()
        {
            string x = null!;
            try
            {
                Requires.NotNull(x, nameof(x));
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.True(false, "The expected exception was not thrown.");
        }

        /// <summary>
        /// Requires.NotNull on not-null non-nullable class.
        /// </summary>
        [Fact(DisplayName = "Requires.NotNull on not-null non-nullable class.")]
        [SuppressMessage(
            "ReSharper",
            "HeuristicUnreachableCode",
            Justification = "This is the purpose of the test.")]
        public void Test8()
        {
            string x = "alabala";
            try
            {
                Requires.NotNull(x, nameof(x));
            }
            catch
            {
                Assert.True(false, "An exception was thrown even if one was not expected.");
            }
        }

        /// <summary>
        /// Requires.NotNull on null struct.
        /// </summary>
        [Fact(DisplayName = "Requires.NotNull on null non-nullable class.")]
        [SuppressMessage(
            "ReSharper",
            "HeuristicUnreachableCode",
            Justification = "This is the purpose of the test.")]
        public void Test9()
        {
            int x = 2;
            try
            {
                Requires.NotNull(x, nameof(x));
            }
            catch (ArgumentNullException)
            {
                Assert.True(false, "An exception was thrown even if one was not expected.");
            }
        }
    }
}