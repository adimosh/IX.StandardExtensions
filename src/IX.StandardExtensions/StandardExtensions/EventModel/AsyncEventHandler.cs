// <copyright file="AsyncEventHandler.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IX.StandardExtensions.EventModel;

/// <summary>
///     An asynchronous event handler delegate.
/// </summary>
/// <param name="sender">The sender.</param>
/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
/// <returns>A task that can be awaited on by the event trigger.</returns>
[PublicAPI]
public delegate Task AsyncEventHandler(
    object sender,
    EventArgs e);

/// <summary>
///     An asynchronous event handler delegate.
/// </summary>
/// <typeparam name="TEventArguments">The type of the event arguments.</typeparam>
/// <param name="sender">The sender.</param>
/// <param name="e">The e.</param>
/// <returns>A task that can be awaited on by the event trigger.</returns>
[PublicAPI]
public delegate Task AsyncEventHandler<in TEventArguments>(
    object sender,
    TEventArguments e)
    where TEventArguments : EventArgs;