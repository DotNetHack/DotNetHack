using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Tiles
{
    /// <summary>
    /// MapTile
    /// <remarks>
    /// </remarks>
    /// </summary>
    [Serializable]
    public class MapTile: Tile
    {
        /// <summary>
        /// Create a new MapTile
        /// <remarks>Supports serialization</remarks>
        /// </summary>
        public MapTile()
            : base(TileType.Map)
        { }

        /// <summary>
        /// Tile Flags
        /// </summary>
        public TileFlags Flags { get; set; }

        /// <summary>
        /// TileFlags
        /// </summary>
        public enum TileFlags 
        {
            None,
            Impassable,
        };
    }
}
