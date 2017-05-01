using System;
using System.Collections;
using System.Collections.Generic;
using DotNetHack.Core;

namespace DotNetHack.Definitions
{
    [Serializable]
    public class LocationIndexedCollection<T> : List<T> where T : IHasLocation
    {
        private readonly object syncRoot = new object();

        private readonly Dictionary<ILocation, T> _cache = new Dictionary<ILocation, T>();

        /// <summary>
        /// Adds the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public new void Add(T obj)
        {
            lock (syncRoot)
            {
                _cache.Add(obj.Location, obj);

                base.Add(obj);
            }
        }

        /// <summary>
        /// Removes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public new void Remove(T obj)
        {
            lock (syncRoot)
            {
                Remove(obj.Location);

                base.Remove(obj);
            }
        }

        /// <summary>
        /// Removes the specified location.
        /// </summary>
        /// <param name="location">The location.</param>
        public void Remove(ILocation location)
        {
            lock (syncRoot)
            {
                _cache.Remove(location);
            }
        }

        /// <summary>
        /// Determines whether [contains] [the specified object].
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified object]; otherwise, <c>false</c>.
        /// </returns>
        public new bool Contains(T obj)
        {
            lock (syncRoot)
            {
                return Contains(obj.Location);
            }
        }

        /// <summary>
        /// Determines whether [contains] [the specified location].
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified location]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(ILocation location)
        {
            lock (syncRoot)
            {
                return _cache.ContainsKey(location);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public T this[ILocation index]
        {
            get
            {
                lock (syncRoot)
                {
                    return _cache.ContainsKey(index) ? _cache[index] : default(T);
                }
            }
            set
            {
                lock (syncRoot)
                {
                    if (_cache.ContainsKey(index))
                    {
                        _cache[index] = value;
                    }
                    else
                    {
                        _cache.Add(index, value);
                    }
                }
            }
        }
    }

}