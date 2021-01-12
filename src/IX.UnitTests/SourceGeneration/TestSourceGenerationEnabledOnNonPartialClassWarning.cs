// <copyright file="TestSourceGenerationEnabledOnNonPartialClassWarning.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !NET46
using IX.CodeGeneration;
using IX.StandardExtensions.ComponentModel;
using JetBrains.Annotations;

namespace IX.UnitTests.SourceGeneration
{
    /// <summary>
    /// Tests for some auto-disposable warnings.
    /// </summary>
    [SourceGenerationEnabled]
    [UsedImplicitly]
    public class TestSourceGenerationEnabledOnNonPartialClassWarning : DisposableBase
    {
    }
}
#endif