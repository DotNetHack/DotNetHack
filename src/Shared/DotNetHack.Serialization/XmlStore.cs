using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DotNetHack.Serialization
{
    /// <summary>
    /// XmlStore
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XmlStore<T> : IStore<T> where T : class, new()
    {
        #region backing store
        private readonly string _storePath; 
        #endregion

        /// <summary>
        /// XmlStore
        /// </summary>
        public XmlStore(string storePath)
        {
            _storePath = storePath;

            if (_storePath == null) throw new ArgumentNullException("storePath");

            Debug.WriteLine("Initializing {0} Store: {1}",
                StoreName, Exists ? "Found" : "Not Found");
        }

        /// <summary>
        /// StoreName
        /// </summary>
        public string StoreName { get { return typeof(T).Name; } }

        /// <summary>
        /// 
        /// </summary>
        public string StorePath { get { return _storePath; } }

        /// <summary>
        /// StoreFullPath
        /// </summary>
        public string StoreFullPath { get { return Path.Combine(StorePath, StoreName); }}

        /// <summary>
        /// Store the passed collection
        /// </summary>
        /// <param name="collection">the collection to store</param>
        public void Store(IEnumerable<T> collection)
        {
            collection.ToArray().Write(StoreFullPath);
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Load()
        {
            return Exists ? StoreFullPath.Read<T[]>() : new T[]{};
        }

        /// <summary>
        /// Exists
        /// </summary>
        public bool Exists
        {
            get { return File.Exists(StoreFullPath); }
        }
    }
}