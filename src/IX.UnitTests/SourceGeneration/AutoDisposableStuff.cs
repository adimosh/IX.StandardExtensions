// <copyright file="AutoDisposableStuff.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !NET46
using IX.CodeGeneration;
using IX.StandardExtensions.ComponentModel;

namespace IX.UnitTests.SourceGeneration
{
    [AutoDisposableContainer]
    public partial class AutoDisposableStuff : DisposableBase
    {
        [AutoDisposableMember]
        public global::System.IDisposable disposableField;
    }
}
#endif