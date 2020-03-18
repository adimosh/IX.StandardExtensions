// <copyright file="TypeInfoExtensions.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using IX.StandardExtensions.Contracts;
using JetBrains.Annotations;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    ///     Extensions for <see cref="TypeInfo" />.
    /// </summary>
    [PublicAPI]
    public static class TypeInfoExtensions
    {
        /// <summary>
        ///     Determines whether a type has a public parameterless constructor.
        /// </summary>
        /// <param name="info">The type information.</param>
        /// <returns><see langword="true" /> if there is a parameterless constructor; otherwise, <see langword="false" />.</returns>
        public static bool HasPublicParameterlessConstructor(this TypeInfo info) =>
            !info.IsInterface &&
            !info.IsAbstract &&
            !info.IsGenericTypeDefinition &&
            info.DeclaredConstructors.Any(
                p => !p.IsStatic &&
                     p.IsPublic &&
                     !p.IsGenericMethodDefinition &&
                     p.GetParameters()
                         .Length ==
                     0);

        /// <summary>
        ///     Instantiates an object of the specified type.
        /// </summary>
        /// <param name="info">The type information.</param>
        /// <returns>An instance of the object to instantiate.</returns>
        public static object Instantiate(this TypeInfo info) => Activator.CreateInstance(info.AsType());

        /// <summary>
        ///     Instantiates an object of the specified type.
        /// </summary>
        /// <param name="info">The type information.</param>
        /// <param name="parameters">The parameters to pass through to the constructor.</param>
        /// <returns>An instance of the object to instantiate.</returns>
        public static object Instantiate(
            this TypeInfo info,
            params object[] parameters) =>
            Activator.CreateInstance(
                info.AsType(),
                parameters);

        /// <summary>
        ///     Gets a method with exact parameters, if one exists.
        /// </summary>
        /// <param name="typeInfo">The type information.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameters">The parameters list, if any.</param>
        /// <returns>
        ///     A <see cref="MethodInfo" /> object representing the found method, or <see langword="null" /> (
        ///     <see langword="Nothing" /> in Visual Basic), if none is found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="typeInfo" /> is <see langword="null" /> (
        ///     <see langword="Nothing" /> in Visual Basic).
        /// </exception>
        public static MethodInfo GetMethodWithExactParameters(
            this TypeInfo typeInfo,
            string name,
            params Type[] parameters) =>
            typeInfo.AsType()
                .GetMethodWithExactParameters(
                    name,
                    parameters);

        /// <summary>
        ///     Gets a method with exact parameters, if one exists.
        /// </summary>
        /// <param name="typeInfo">The type information.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameters">The parameters list, if any.</param>
        /// <returns>
        ///     A <see cref="MethodInfo" /> object representing the found method, or <see langword="null" /> (
        ///     <see langword="Nothing" /> in Visual Basic), if none is found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="typeInfo" /> is <see langword="null" /> (
        ///     <see langword="Nothing" /> in Visual Basic).
        /// </exception>
        public static MethodInfo GetMethodWithExactParameters(
            this TypeInfo typeInfo,
            string name,
            params TypeInfo[] parameters) =>
            typeInfo.AsType()
                .GetMethodWithExactParameters(
                    name,
                    parameters.Select(p => p.AsType())
                        .ToArray());

        /// <summary>
        ///     Gets the attribute data by type without version binding.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get data for.</typeparam>
        /// <typeparam name="TReturn">The type of data to return.</typeparam>
        /// <param name="typeInfo">The type information.</param>
        /// <param name="value">The output value.</param>
        /// <returns><see langword="true" /> if the attribute exists and has data, <see langword="false" /> otherwise.</returns>
        [SuppressMessage(
            "Performance",
            "HAA0401:Possible allocation of reference type enumerator",
            Justification = "Expected.")]
        [SuppressMessage(
            "Performance",
            "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
            Justification = "Expected.")]
        public static bool GetAttributeDataByTypeWithoutVersionBinding<TAttribute, TReturn>(
            this TypeInfo typeInfo,
#if NETSTANDARD2_1
            [MaybeNullWhen(false)]
#endif
            out TReturn value)
        {
            Contract.RequiresNotNull(in typeInfo, nameof(typeInfo));

            CustomAttributeData attributeData = typeInfo.CustomAttributes.FirstOrDefault(
                attribute => attribute.AttributeType.FullName == typeof(TAttribute).FullName);

            if (attributeData == null)
            {
                value = default;
                return false;
            }

            using (IEnumerator<CustomAttributeTypedArgument> arguments = attributeData.ConstructorArguments
                .Where(p => p.ArgumentType == typeof(TReturn))
                .GetEnumerator())
            {
                if (arguments.MoveNext())
                {
                    value = (TReturn)arguments.Current.Value;

                    if (!arguments.MoveNext())
                    {
                        return true;
                    }
                }
            }

            if (attributeData.NamedArguments != null)
            {
                using IEnumerator<CustomAttributeTypedArgument> arguments = attributeData.NamedArguments
                    .Where(p => p.TypedValue.ArgumentType == typeof(TReturn))
                    .Select(p => p.TypedValue)
                    .GetEnumerator();

                if (arguments.MoveNext())
                {
                    value = (TReturn)arguments.Current.Value;

                    if (!arguments.MoveNext())
                    {
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }
    }
}