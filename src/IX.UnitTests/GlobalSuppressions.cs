// <copyright file="GlobalSuppressions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "These are unit tests, we don't really care about XML docs.", Scope = "module")]
[assembly: SuppressMessage("Performance", "HAA0301:Closure Allocation Source", Justification = "We're not really interested in closures in unit tests.", Scope = "module")]
[assembly: SuppressMessage("Performance", "HAA0302:Display class allocation to capture closure", Justification = "We're not really interested in closures in unit tests.", Scope = "module")]
[assembly: SuppressMessage("Performance", "HAA0603:Delegate allocation from a method group", Justification = "Not a concern in unit tests.", Scope = "module")]
[assembly: SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "Not a concern in unit tests.", Scope = "module")]

// TODO: Check with new version of analyzer
[assembly: SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "There seems to be an analyzer error.", Scope = "module")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1316:Tuple element names should use correct casing", Justification = "This does not appear to be correctly implemented in the analyzer.", Scope = "module")]