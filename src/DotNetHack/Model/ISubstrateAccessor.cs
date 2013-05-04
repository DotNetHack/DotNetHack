using System;

namespace DotNetHack.Model
{
    /// <summary>
    /// ISubstrateAccessor
    /// </summary>
    public interface ISubstrateAccessor
    {
        /// <summary>
        /// DNHObject
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        DNHObject this[int x, int y, int z] { get; }
    }

    /// <summary>
    /// ISubstrateAccessor
    /// </summary>
    public interface ISubstrateAccessor<T> : ISubstrateAccessor
    {
        /// <summary>
        /// DNHObject
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        DNHObject this[T t, int x, int y, int z] { get; }
    }
}
