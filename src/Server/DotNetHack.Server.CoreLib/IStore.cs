using System.Collections.Generic;

namespace DotNetHack.Server.CoreLib
{
    /// <summary>
    /// IStore
    /// </summary>
    /// <typeparam name="T">the type of store</typeparam>
    public interface IStore<T> where T: class, new()
    {
        /// <summary>
        /// Store
        /// </summary>
        /// <param name="collection"></param>
        void Store(IEnumerable<T> collection);

        /// <summary>
        /// Load the store
        /// </summary>
        /// <returns>the loaded stored values</returns>
        IEnumerable<T> Load();

        /// <summary>
        /// Exists
        /// </summary>
        bool Exists { get; }
    }
}