using System;
using DotNetHack.Game.Interfaces;
using System.Collections.Generic;
using DotNetHack.Game.Items;
namespace DotNetHack.Game.Dungeon.Tiles
{
    /// <summary>
    /// ITile interface
    /// </summary>
    interface ITile : IGlyph
    {
        bool HasItems { get; }
        ItemCollection Items { get; set; }
        TileFlags TileFlags { get; set; }
        TileType TileType { get; set; }
        bool Impassable { get; }
    }
}
