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
        None,
        Door,
        Trap,
        Secret,
        Shop,
        Sacred,
    }
}
