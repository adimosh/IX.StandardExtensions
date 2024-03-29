// <copyright file="RefDelegates.WithParameters.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using JetBrains.Annotations;

namespace IX.StandardExtensions.Efficiency;

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc<TParam1, out TResult>(ref TParam1 param1);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefAction<TParam1>(ref TParam1 param1);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc1<TParam1, in TParam2, out TResult>(ref TParam1 param1, TParam2 param2);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
[PublicAPI]
public delegate void RefAction1<TParam1, in TParam2>(ref TParam1 param1, TParam2 param2);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc<TParam1, TParam2, out TResult>(ref TParam1 param1, ref TParam2 param2);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefAction<TParam1, TParam2>(ref TParam1 param1, ref TParam2 param2);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc2<TParam1, in TParam2, in TParam3, out TResult>(ref TParam1 param1, TParam2 param2, TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
[PublicAPI]
public delegate void RefAction2<TParam1, in TParam2, in TParam3>(ref TParam1 param1, TParam2 param2, TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc1<TParam1, TParam2, in TParam3, out TResult>(ref TParam1 param1, ref TParam2 param2, TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
[PublicAPI]
public delegate void RefAction1<TParam1, TParam2, in TParam3>(ref TParam1 param1, ref TParam2 param2, TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc<TParam1, TParam2, TParam3, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefAction<TParam1, TParam2, TParam3>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc3<TParam1, in TParam2, in TParam3, in TParam4, out TResult>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
[PublicAPI]
public delegate void RefAction3<TParam1, in TParam2, in TParam3, in TParam4>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc2<TParam1, TParam2, in TParam3, in TParam4, out TResult>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
[PublicAPI]
public delegate void RefAction2<TParam1, TParam2, in TParam3, in TParam4>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc1<TParam1, TParam2, TParam3, in TParam4, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
[PublicAPI]
public delegate void RefAction1<TParam1, TParam2, TParam3, in TParam4>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc<TParam1, TParam2, TParam3, TParam4, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefAction<TParam1, TParam2, TParam3, TParam4>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc4<TParam1, in TParam2, in TParam3, in TParam4, in TParam5, out TResult>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
[PublicAPI]
public delegate void RefAction4<TParam1, in TParam2, in TParam3, in TParam4, in TParam5>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc3<TParam1, TParam2, in TParam3, in TParam4, in TParam5, out TResult>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
[PublicAPI]
public delegate void RefAction3<TParam1, TParam2, in TParam3, in TParam4, in TParam5>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc2<TParam1, TParam2, TParam3, in TParam4, in TParam5, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
[PublicAPI]
public delegate void RefAction2<TParam1, TParam2, TParam3, in TParam4, in TParam5>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc1<TParam1, TParam2, TParam3, TParam4, in TParam5, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
[PublicAPI]
public delegate void RefAction1<TParam1, TParam2, TParam3, TParam4, in TParam5>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc<TParam1, TParam2, TParam3, TParam4, TParam5, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefAction<TParam1, TParam2, TParam3, TParam4, TParam5>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc5<TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, out TResult>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefAction5<TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc4<TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, out TResult>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefAction4<TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc3<TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefAction3<TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc2<TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefAction2<TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc1<TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefAction1<TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefAction<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc6<TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, out TResult>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefAction6<TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc5<TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, out TResult>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefAction5<TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc4<TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, in TParam7, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefAction4<TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, in TParam7>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc3<TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, in TParam7, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefAction3<TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, in TParam7>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc2<TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, in TParam7, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefAction2<TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, in TParam7>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc1<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, in TParam7, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefAction1<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, in TParam7>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefAction<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc7<TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TResult>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefAction7<TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8>(ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc6<TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TResult>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefAction6<TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8>(ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc5<TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefAction5<TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc4<TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefAction4<TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, in TParam7, in TParam8>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc3<TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, in TParam7, in TParam8, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefAction3<TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, in TParam7, in TParam8>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc2<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, in TParam7, in TParam8, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefAction2<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, in TParam7, in TParam8>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc1<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, in TParam8, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefAction1<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, in TParam8>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefFunc<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, out TResult>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7, ref TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;.
/// </summary>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefAction<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7, ref TParam8 param8);