// <copyright file="AutoDisposableStuff3.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !NET46
using System;
using System.Diagnostics.CodeAnalysis;
using IX.CodeGeneration;
using IX.StandardExtensions.ComponentModel;
using JetBrains.Annotations;

namespace IX.UnitTests.SourceGeneration
{
    /// <summary>
    /// Tests for some auto-disposable stuff.
    /// </summary>
    [SourceGenerationEnabled]
    [UsedImplicitly]
    [SuppressMessage(
        "ReSharper",
        "PartialTypeWithSinglePart",
        Justification = "This is a specific test for code generators.")]
    public partial class AutoDisposableStuff3 : DisposableBase
    {
        [AutoDisposableMember]
        [UsedImplicitly]
        private readonly IDisposable disposableField;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoDisposableStuff3"/> class.
        /// </summary>
        /// <param name="field">The disposable field.</param>
        public AutoDisposableStuff3(IDisposable field)
        {
            this.disposableField = field;
        }

        /// <summary>
        /// Ecs.
        /// </summary>
        [PublicAPI]
        public void X() =>
            this.Dispose_AutoGenerated();
    }
}
#endif