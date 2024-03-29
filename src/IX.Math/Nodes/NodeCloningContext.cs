// <copyright file="NodeCloningContext.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using IX.Math.Registration;

using JetBrains.Annotations;

namespace IX.Math.Nodes;

/// <summary>
///     A context for cloning nodes.
/// </summary>
[PublicAPI]
public class NodeCloningContext
{
    /// <summary>
    ///     Gets or sets the parameter registry.
    /// </summary>
    /// <value>The parameter registry.</value>
    public IParameterRegistry ParameterRegistry { get; set; }

    /// <summary>
    ///     Gets or sets the special request function.
    /// </summary>
    /// <value>
    ///     The special request function.
    /// </value>
    public Func<Type, object>? SpecialRequestFunction { get; set; }
}