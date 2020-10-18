// <copyright file="SwitchEventArgs.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using JetBrains.Annotations;

namespace IX.StandardExtensions.EventModel
{
    /// <summary>
    ///     An event arguments class depicting a boolean switch.
    /// </summary>
    /// <seealso cref="EventArgs" />
    [PublicAPI]
    public class SwitchEventArgs : EventArgs
    {
#region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SwitchEventArgs" /> class.
        /// </summary>
        /// <param name="switchValue">The value of the switch.</param>
        public SwitchEventArgs(bool switchValue)
        {
            this.Value = switchValue;
        }

#endregion

#region Properties and indexers

        /// <summary>
        ///     Gets a value indicating whether the switch is set.
        /// </summary>
        /// <value>The switch value.</value>
        public bool Value
        {
            get;
        }

#endregion
    }
}