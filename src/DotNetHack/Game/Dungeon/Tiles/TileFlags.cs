using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Dungeon.Tiles
{
    /// <summary>
    /// TileFlags represet the various flags that a tile may have.
    /// <remarks>These flags may be stacked.</remarks>
    /// </summary>
    [Flags]
    public enum TileFlags
    {
        None = 1,
        Door = 2,
        Trap = 4,
        Secret = 8,
        Shop = 16,
        Sacred = 32,
        Stairs = 64,
        Spawn = 128,
    }
}
