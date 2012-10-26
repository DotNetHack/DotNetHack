using DotNetHack.Core.Game.Tiles;
using System;
namespace DotNetHack.Core.Interfaces
{
    /// <summary>
    /// ITile
    /// </summary>
    public interface ITile
    {
        /// <summary>
        /// Tile type
        /// </summary>
        Tile.TileType Type { get; set; }
    }
}
