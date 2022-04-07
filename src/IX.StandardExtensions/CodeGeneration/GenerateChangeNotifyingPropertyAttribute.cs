// <copyright file="GenerateChangeNotifyingPropertyAttribute.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.CodeGeneration;

/// <summary>
///     An attribute to signal that this field should have an autom-generated property that notifies changes.
/// </summary>
/// <seealso cref="Attribute" />
[AttributeUsage(AttributeTargets.Field)]
[PublicAPI]
public class GenerateChangeNotifyingPropertyAttribute : Attribute
{
#region Constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="GenerateChangeNotifyingPropertyAttribute" /> class.
    /// </summary>
    /// <param name="name">The name of the property.</param>
    public GenerateChangeNotifyingPropertyAttribute(string name)
    {
        this.Name = name;
    }

#endregion

#region Properties and indexers

    /// <summary>
    ///     Gets or sets the name of the property.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name { get; set; }

#endregion
}