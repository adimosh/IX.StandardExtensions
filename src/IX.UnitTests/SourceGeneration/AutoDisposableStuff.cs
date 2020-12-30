// <copyright file="AutoDisposableStuff.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !NET46
using System;
using IX.CodeGeneration;
using IX.StandardExtensions.ComponentModel;
using JetBrains.Annotations;

namespace IX.UnitTests.SourceGeneration
{
    [SourceGenerationEnabled]
    [UsedImplicitly]
    public partial class AutoDisposableStuff : DisposableBase
    {
        public AutoDisposableStuff(IDisposable field)
        {
            this.disposableField = field;
        }

        [AutoDisposableMember]
        private IDisposable disposableField;
    }

    [SourceGenerationEnabled]
    [UsedImplicitly]
    internal partial class AutoDisposableStuff2 : DisposableBase
    {
        public AutoDisposableStuff2(IDisposable field)
        {
            this.disposableField = field;
        }

        [AutoDisposableMember]
        private IDisposable disposableField;
    }

    [SourceGenerationEnabled]
    [UsedImplicitly]
    public class TestSourceGenerationEnabledOnNonPartialClassWarning : DisposableBase
    {
    }

    [SourceGenerationEnabled]
    [UsedImplicitly]
    public partial class TestAutoDisposableOnNonInheritingClassWarning
    {
        [AutoDisposableMember]
        public global::System.IDisposable disposableField;
    }
}
#endif