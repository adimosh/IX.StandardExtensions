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
    ///     Unit tests for working on thread pool.
    /// </summary>
    public class WorkOnThreadPoolUnitTests
    {
        /// <summary>
        ///     Tests running on the thread pool and, because of a lack of a synchronization context, not returning to the same
        ///     thread.
        /// </summary>
        /// <returns>A <see cref="Task" /> representing the asynchronous unit test.</returns>
        [Fact(DisplayName = "Test running on thread pool and not returning to thread context.")]
        public async Task Test1()
        {
            // ARRANGE
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            var separateThreadId = currentThreadId;
            int returningThreadId;

            void LocalMethod() { separateThreadId = Thread.CurrentThread.ManagedThreadId; }

            // ACT
            await Work.OnThreadPool(LocalMethod);
            returningThreadId = Thread.CurrentThread.ManagedThreadId;

            // ASSERT
            Assert.NotEqual(
                currentThreadId,
                separateThreadId);
            Assert.NotEqual(
                currentThreadId,
                returningThreadId);
        }
    }
}