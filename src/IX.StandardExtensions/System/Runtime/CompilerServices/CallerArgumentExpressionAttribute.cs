// <copyright file="CallerArgumentExpressionAttribute.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

#if !NET5_0_OR_GREATER
using System;

namespace System.Runtime.CompilerServices;

/// <summary>
/// Allows capturing of the expressions passed to a method.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class CallerArgumentExpressionAttribute : Attribute
{
    private string parameterName;

    /// <summary>
    /// Initializes a new instance of the <see cref="CallerArgumentExpressionAttribute"/> class.
    /// </summary>
    /// <param name="parameterName">The name of the targeted parameter.</param>
    public CallerArgumentExpressionAttribute(string parameterName)
    {
        this.parameterName = parameterName;
    }

    /// <summary>
    /// Gets the target parameter name of the CallerArgumentExpression.
    /// </summary>
    /// <value>
    /// The name of the targeted parameter of the CallerArgumentExpression.
    /// </value>
    public string ParameterName
    {
        get
        {
            return this.parameterName;
        }
    }
}
#endif