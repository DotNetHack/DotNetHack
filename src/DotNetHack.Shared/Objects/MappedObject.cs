using System;
using System.Collections.Generic;

namespace DotNetHack.Shared.Objects
{
    /// <summary>
    /// MappedObject, Ties a tileset mapped tile to a DNH object.
    /// </summary>
    /// <typeparam name="T">the type of mapped object this is.</typeparam>
    public class MappedObject<T> where T : class, new()
    {
        /// <summary>
        /// Create a new mapped object
        /// <remarks>supports serialization</remarks>
        /// </summary>
        public MappedObject() { }

        /// <summary>
        /// Create a new mapped object given the object that is mapped.
        /// </summary>
        /// <param name="aMappedTile">the mapped tile</param>
        /// <param name="aObject">the object being mapped to the mapped tile.</param>
        public MappedObject(TileMapping.MappedTile aMappedTile, T aObject) 
        {
            Object = aObject;
            MappedTile = aMappedTile;
        }

        /// <summary>
        /// The object that was mapped
        /// </summary>
        public T Object { get; set; }

        /// <summary>
        /// The mapped tile associated with this mapped object.
        /// </summary>
        public TileMapping.MappedTile MappedTile { get; set; }
    }
}
