using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IX.StandardExtensions.Contracts;

namespace IX.StandardExtensions.Extensions
{
    /// <summary>
    /// Generic extensions for chaining multiple method calls on objects.
    /// </summary>
    public static class ChainExtensions
    {
        /// <summary>
        /// Chains a specific delegate onto an instance of an object.
        /// </summary>
        /// <typeparam name="TInput">The input object type.</typeparam>
        /// <param name="input">The input object instance.</param>
        /// <param name="chainDelegate">The delegate to chain.</param>
        /// <returns>The input object.</returns>
        public static TInput Chain<TInput>(
            this TInput input,
            Action<TInput> chainDelegate)
        {
            Requires.NotNull(chainDelegate)(Requires.NotNull(input));

            return input;
        }

        /// <summary>
        /// Chains a specific delegate onto an instance of an object.
        /// </summary>
        /// <typeparam name="TInput">The input object type.</typeparam>
        /// <typeparam name="TOutput">The output object type.</typeparam>
        /// <param name="input">The input object instance.</param>
        /// <param name="chainDelegate">The delegate to chain.</param>
        /// <returns>The output object, returned by the chain delegate.</returns>
        public static TOutput Chain<TInput, TOutput>(
            this TInput input,
            Func<TInput, TOutput> chainDelegate) =>
            Requires.NotNull(chainDelegate)(Requires.NotNull(input));
    }
}
