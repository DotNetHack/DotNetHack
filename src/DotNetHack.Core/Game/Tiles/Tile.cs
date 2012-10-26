using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Tiles
{
    /// <summary>
    /// Tile
    /// </summary>
    [Serializable]
    public abstract class Tile
    {
        /// <summary>
        /// Parameterless constructor
        /// <remarks>Supports serialization</remarks>
        /// </summary>
        public Tile() { }

        /// <summary>
        /// Tile
        /// </summary>
        protected Tile(TileType tileType)
        {
            Type = tileType;
        }

        /// <summary>
        /// The type of tile this is
        /// </summary>
        public TileType Type { get; set; }

        /// <summary>
        /// The type of tile this is
        /// </summary>
        public enum TileType { None, Map, Actor, Item};
    }
}
