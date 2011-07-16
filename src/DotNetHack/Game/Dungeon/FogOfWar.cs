using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Dungeon
{
    /// <summary>
    /// FogOfWar
    /// </summary>
    public class FogOfWar
    {
        /// <summary>
        /// FogOfWar
        /// </summary>
        /// <param name="aDungeon"></param>
        public FogOfWar(Dungeon3 aDungeon)
        {
            SeenData = new bool[aDungeon.DungeonWidth, aDungeon.DungeonHeight,
                aDungeon.DungeonDepth];
        }
        bool[, ,] SeenData { get; set; }
    }
}
