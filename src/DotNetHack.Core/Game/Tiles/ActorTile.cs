using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Tiles
{
    /// <summary>
    /// ActorTile
    /// </summary>
    public class ActorTile : Tile
    {
        /// <summary>
        /// Creates a new ActorTile
        /// </summary>
        public ActorTile() 
            : base(TileType.Actor)
        { }
    }
}
