// <copyright file="GlobalSuppressions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics.CodeAnalysis;

// TODO: Check with new version of analyzer
[assembly: SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "There seems to be an analyzer error.", Scope = "module")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1316:Tuple element names should use correct casing", Justification = "This does not appear to be correctly implemented in the analyzer.", Scope = "module")]