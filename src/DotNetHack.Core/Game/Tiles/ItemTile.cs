using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Tiles
{
    /// <summary>
    /// ItemTile
    /// </summary>
    public class ItemTile : Tile
    {
         /// <summary>
        /// Create a new ItemTile
        /// <remarks>Supports serialization</remarks>
        /// </summary>
        public ItemTile()
            : base(TileType.Item)
        { }
    }
}
