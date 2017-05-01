using System;
using System.Collections.Generic;
using System.Linq;
using DotNetHack.Core;

namespace DotNetHack.Definitions
{
    public class IdCollection<T> : List<T> where T : Id
    {
        #region instance fields
        private readonly object _syncRoot = new object();
        private readonly Dictionary<string, T> _cache = new Dictionary<string, T>();
        #endregion

        /// <summary>
        /// Adds the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public new void Add(T obj)
        {
            lock (_syncRoot)
            {
                _cache.Add(obj.Id, obj);

                base.Add(obj);
            }
        }

        /// <summary>
        /// Removes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public new void Remove(T obj)
        {
            lock (_syncRoot)
            {
                _cache.Remove(obj.Id);

                base.Remove(obj);
            }
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Remove(string id)
        {
            lock (_syncRoot)
            {
                if (_cache.ContainsKey(id))
                {
                    Remove(_cache[id]);
                }
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
            return Contains(obj.Id);
        }

        /// <summary>
        /// Determines whether [contains] [the specified identifier].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified identifier]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(string id)
        {
            lock (_syncRoot)
            {
                return _cache.ContainsKey(id);
            }
        }

        /// <summary>
        /// Removes all elements from the <see cref="T:System.Collections.Generic.List`1" />.
        /// </summary>
        public new void Clear()
        {
            lock (_syncRoot)
            {
                _cache.Clear();

                base.Clear();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified identifier.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T this[string id]
        {
            get
            {
                lock (_syncRoot)
                {
                    return Find(id);
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    if (_cache.ContainsKey(id))
                    {
                        _cache[id] = value;
                    }
                    else
                    {
                        _cache.Add(id, value);
                    }

                    base.Add(value);
                }
            }
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T Find(string id)
        {
            lock (_syncRoot)
            {
                return _cache.ContainsKey(id) ? _cache[id] : default(T);
            }
        }
    }

    [Serializable]
    public abstract class DefCollection<T> : IdCollection<T> where T : Id { }
}