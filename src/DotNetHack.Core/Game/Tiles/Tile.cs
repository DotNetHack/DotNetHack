using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Tiles
{
    /// <summary>
    /// ITile
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
        /// MapLayer
        /// </summary>
        public MapTile MapLayer { get; set; }

        /// <summary>
        /// ItemLayer
        /// </summary>
        public ItemTile ItemLayer { get; set; }

        /// <summary>
        /// ActorLayer
        /// </summary>
        public ActorTile ActorLayer { get; set; }

        /// <summary>
        /// The type of tile this is
        /// </summary>
        public TileType Type { get; set; }

        /// <summary>
        /// The type of tile this is
        /// </summary>
        public enum TileType { Map, Actor, Item};
    }
}
