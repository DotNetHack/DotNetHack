using System;
using DotNetHack.Game.Interfaces;
using System.Collections.Generic;
namespace DotNetHack.Game.Dungeon.Tiles
{
    /// <summary>
    /// ITile interface
    /// </summary>
    interface ITile : IGlyph
    {
        bool HasItems { get; }
        Stack<IItem> Items { get; set; }
        TileFlags TileFlags { get; set; }
        TileType TileType { get; set; }
    }
}
