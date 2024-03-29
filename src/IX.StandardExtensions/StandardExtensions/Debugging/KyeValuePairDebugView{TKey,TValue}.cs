// <copyright file="KyeValuePairDebugView{TKey,TValue}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Diagnostics;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Debugging;

/// <summary>
///     A debug view for a key/value pair. This class cannot be inherited.
/// </summary>
/// <typeparam name="TKey">The type of the key.</typeparam>
/// <typeparam name="TValue">The type of the value.</typeparam>
[ComVisible(false)]
[DebuggerDisplay("[{" + nameof(Key) + "}] = \"{" + nameof(Value) + "}\"")]
[PublicAPI]
public sealed class KyeValuePairDebugView<TKey, TValue>
{
#region Properties and indexers

    /// <summary>
    ///     Gets the key.
    /// </summary>
    /// <value>The key.</value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public TKey? Key { get; internal set; }

    /// <summary>
    ///     Gets the value.
    /// </summary>
    /// <value>The value.</value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public TValue? Value { get; internal set; }

#endregion
}