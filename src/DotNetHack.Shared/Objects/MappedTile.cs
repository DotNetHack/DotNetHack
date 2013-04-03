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
    public partial class TileMapping
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
        /// The path of the tile set that the mapping applies to.
        /// </summary>
        public string TileSetPath { get; set; }
    }
}
