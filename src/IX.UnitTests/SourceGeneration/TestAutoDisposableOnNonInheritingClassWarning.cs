// <copyright file="TestAutoDisposableOnNonInheritingClassWarning.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !NET46
using System;
using System.Diagnostics.CodeAnalysis;
using IX.CodeGeneration;
using JetBrains.Annotations;

namespace IX.UnitTests.SourceGeneration
{

    /// <summary>
    /// Tests for some more auto-disposable warnings.
    /// </summary>
    [SourceGenerationEnabled]
    [UsedImplicitly]
    [SuppressMessage(
        "ReSharper",
        "PartialTypeWithSinglePart",
        Justification = "This is a specific test for code generators.")]
    public partial class TestAutoDisposableOnNonInheritingClassWarning
    {
        /// <summary>
        /// This field is for testing purposes only.
        /// </summary>
        [AutoDisposableMember]
        [UsedImplicitly]
        [SuppressMessage(
            "StyleCop.CSharp.MaintainabilityRules",
            "SA1401:Fields should be private",
            Justification = "According to test protocol.")]
        public IDisposable DisposableField;
    }
}
#endif