// <copyright file="NotifyPropertyChangedBase.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using JetBrains.Annotations;

namespace IX.StandardExtensions.ComponentModel
{
    /// <summary>
    ///     A base class for advertising and notifying on changes of properties.
    /// </summary>
    /// <seealso cref="INotifyPropertyChanged" />
    [PublicAPI]
    public abstract class NotifyPropertyChangedBase : SynchronizationContextInvokerBase,
        INotifyPropertyChanged
    {
#region Constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotifyPropertyChangedBase" /> class.
        /// </summary>
        protected NotifyPropertyChangedBase() { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotifyPropertyChangedBase" /> class.
        /// </summary>
        /// <param name="synchronizationContext">The specific synchronization context to use.</param>
        protected NotifyPropertyChangedBase(SynchronizationContext? synchronizationContext)
            : base(synchronizationContext) { }

#endregion

#region Events

        /// <summary>
        ///     Triggered whenever a property has changed its value and its display should be refreshed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

#endregion

#region Methods

        /// <summary>
        ///     Triggers the <see cref="PropertyChanged" /> event.
        /// </summary>
        /// <param name="changedPropertyName">The name of the changed property.</param>
        [SuppressMessage(
            "Design",
            "CA1030:Use events where appropriate",
            Justification = "This is not a violation, we're actively using an event.")]
        protected void RaisePropertyChanged(string changedPropertyName)
        {
            if (SuppressNotificationsContext.AmbientSuppressionActive.Value)
            {
                return;
            }

            if (this.PropertyChanged != null)
            {
                this.Invoke(
                    (
                        invoker,
                        propertyName) => invoker.PropertyChanged?.Invoke(
                        invoker,
                        new PropertyChangedEventArgs(propertyName)),
                    this,
                    changedPropertyName);
            }
        }

        /// <summary>
        ///     Triggers the <see cref="PropertyChanged" /> event asynchronously.
        /// </summary>
        /// <param name="changedPropertyName">The name of the changed property.</param>
        protected void PostPropertyChanged(string changedPropertyName)
        {
            if (SuppressNotificationsContext.AmbientSuppressionActive.Value)
            {
                return;
            }

            if (this.PropertyChanged != null)
            {
                this.InvokePost(
                    (
                        invoker,
                        propertyName) => invoker.PropertyChanged?.Invoke(
                        invoker,
                        new PropertyChangedEventArgs(propertyName)),
                    this,
                    changedPropertyName);
            }
        }

        /// <summary>
        ///     Triggers the <see cref="PropertyChanged" /> event synchronously.
        /// </summary>
        /// <param name="changedPropertyName">The name of the changed property.</param>
        protected void SendPropertyChanged(string changedPropertyName)
        {
            if (SuppressNotificationsContext.AmbientSuppressionActive.Value)
            {
                return;
            }

            if (this.PropertyChanged != null)
            {
                this.InvokeSend(
                    (
                        invoker,
                        propertyName) => invoker.PropertyChanged?.Invoke(
                        invoker,
                        new PropertyChangedEventArgs(propertyName)),
                    this,
                    changedPropertyName);
            }
        }

#endregion
    }
}