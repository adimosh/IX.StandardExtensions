// <copyright file="AutoDisposableMemberAttribute.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using JetBrains.Annotations;

namespace IX.CodeGeneration
{
    /// <summary>
    /// An attribute that should be placed for any members of code-generation classes that require auto-disposability.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, Inherited = false)]
    [PublicAPI]
    public class AutoDisposableMemberAttribute : Attribute
    {
    }
}