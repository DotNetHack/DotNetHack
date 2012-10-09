using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DotNetHack.Serialization;

namespace DotNetHack.Core.Game.World
{
    /// <summary>
    /// Extension Methods
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Saves a <see cref="TileMapping"/>.
        /// </summary>
        public static void Save(this TileMapping tileMapping, string fileName)
        {
            tileMapping.Write(fileName);
        }
    }

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
            public int X { get; set; }

            /// <summary>
            /// Y-Coord
            /// </summary>
            public int Y { get; set; }

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
                return string.Format("{0}, {1}", Name, Tile.Type);
            }

            /// <summary>
            /// Equals
            /// </summary>
            /// <param name="other">other</param>
            /// <returns>true if the the two are equally mapped</returns>
            public bool Equals(MappedTile other)
            {
                return this.X == other.X && this.Y == other.Y && this.Name == other.Name;
            }
        }
    }

    /// <summary>
    /// Tile
    /// </summary>
    [Serializable]
    public class Tile
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public Tile() { }
        
        /// <summary>
        /// Type
        /// </summary>
        public TileType Type { get; set; }

        /// <summary>
        /// Flags
        /// </summary>
        public TileFlags Flags { get; set; }

        /// <summary>
        /// TileType
        /// </summary>
        
        public enum TileType
        {
            [XmlEnum]
            Nothing,

            [XmlEnum]
            Wall,
        }

        /// <summary>
        /// TileFlags
        /// </summary>
        [Flags]
        public enum TileFlags
        {
            [XmlEnum]
            None = 1,

            [XmlEnum]
            Door = 2,

            [XmlEnum]
            Trap = 4,

            [XmlEnum]
            Secret = 8,

            [XmlEnum]
            Sacred = 16,

            [XmlEnum]
            Stairs = 32,

            [XmlEnum]
            Spawn = 128,

            [XmlEnum]
            Impassable = 256,
        }
    }
}
