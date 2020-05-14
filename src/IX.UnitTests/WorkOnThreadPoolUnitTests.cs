// <copyright file="WorkOnThreadPoolUnitTests.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using IX.StandardExtensions.Threading;
using Xunit;

namespace IX.UnitTests
{
    /// <summary>
    /// Unit tests for working on thread pool.
    /// </summary>
    public class WorkOnThreadPoolUnitTests
    {
        /// <summary>
        /// Fact testing method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact(DisplayName = "Test running on thread pool.")]
        public async Task Test1()
        {
            // ARRANGE
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;
            int separateThreadId = currentThreadId;

            void LocalMethod()
            {
                separateThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            // ACT
            await Work.OnThreadPool(LocalMethod);

            // ASSERT
            Assert.NotEqual(currentThreadId, separateThreadId);
        }
    }
}