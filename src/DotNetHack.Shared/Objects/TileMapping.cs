using DotNetHack.Core.Game.Tiles;
using DotNetHack.Core.Game.World;
using DotNetHack.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Shared.Objects
{
    /// <summary>
    /// TileMapping
    /// </summary>
    [Serializable]
    public class TileMapping
    {
        /// <summary>
        /// Loads a <see cref="TileMapping"/>
        /// </summary>
        /// <param name="fileName">the file to load</param>
        /// <param name="tileMapping">the tileMapping to load into.</param>
        public static void Load(string fileName, out TileMapping tileMapping)
        {
            tileMapping = Persisted.Read<TileMapping>(fileName);
        }

        /// <summary>
        /// TileMapping
        /// </summary>
        public TileMapping()
        {
            Mapping = new List<MappedTile>();
        }

        /// <summary>
        /// Saves a <see cref="TileMapping"/>.
        /// </summary>
        public static void Save(TileMapping tileMapping, string fileName)
        {
            tileMapping.Write(fileName);
        }

        /// <summary>
        /// Mapping
        /// </summary>
        public List<MappedTile> Mapping { get; set; }

        /// <summary>
        /// MappedTile
        /// </summary>
        [Serializable]
        public class MappedTile : IEquatable<MappedTile>
        {
            /// <summary>
            /// MappedTile
            /// </summary>
            public MappedTile() { }

            /// <summary>
            /// The name of associated tile.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// X-Coord
            /// </summary>
            public int XMapping { get; set; }

            /// <summary>
            /// Y-Coord
            /// </summary>
            public int YMapping { get; set; }

            /// <summary>
            /// The mapped tile
            /// </summary>
            public Tile Tile { get; set; }

            /// <summary>
            /// The name of the mapping.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("{0}, {1}", Name);
            }

            /// <summary>
            /// Equals
            /// </summary>
            /// <param name="other">other</param>
            /// <returns>true if the the two are equally mapped</returns>
            public bool Equals(MappedTile other)
            {
                return this.XMapping == other.XMapping && 
                    this.YMapping == other.YMapping && 
                    this.Name == other.Name;
            }
        }
    }
}
