// <copyright file="AutoDisposableContainerAttribute.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IX.CodeGeneration
{
    /// <summary>
    /// Attribute to mark classes that should have automatically-disposable code generation.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AutoDisposableContainerAttribute : Attribute
    {
    }
}