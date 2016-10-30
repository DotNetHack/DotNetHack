using System;
using System.Collections.Generic;
using System.Linq;
using DotNetHack.Core;

namespace DotNetHack.Definitions
{
    [Serializable]
    public abstract class DefCollection<T> : List<T> where T : Id
    {
        /// <summary>
        /// Gets the <see cref="T"/> with the specified identifier.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T this[string id] => Get(id);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private T Get(string id)
        {
            return this.SingleOrDefault(s => s.Id == id);
        }
    }
}