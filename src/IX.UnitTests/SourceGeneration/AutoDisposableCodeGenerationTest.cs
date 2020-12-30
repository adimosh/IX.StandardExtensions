// <copyright file="AutoDisposableCodeGenerationTest.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !NET46
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IX.UnitTests.SourceGeneration
{
    /// <summary>
    /// Unit tests for auto-generated stuff.
    /// </summary>
    public class AutoDisposableCodeGenerationTest
    {
        /// <summary>
        /// Test public auto-generated auto-dispose code.
        /// </summary>
        [Fact(DisplayName = "Test public auto-generated auto-dispose code")]
        public void Test1()
        {
            DisposableTest dt = new();
            AutoDisposableStuff stuff = new(dt);
            stuff.Dispose();

            Assert.True(dt.Disposed);
        }

        /// <summary>
        /// Test internal auto-generated auto-dispose code.
        /// </summary>
        [Fact(DisplayName = "Test internal auto-generated auto-dispose code")]
        public void Test2()
        {
            DisposableTest dt = new();
            AutoDisposableStuff2 stuff = new(dt);
            stuff.Dispose();

            Assert.True(dt.Disposed);
        }

        private class DisposableTest : IDisposable
        {
            public bool Disposed
            {
                get; private set;
            }

            public void Dispose() =>
                this.Disposed = true;

            public void Reset() =>
                this.Disposed = false;
        }
    }
}
#endif