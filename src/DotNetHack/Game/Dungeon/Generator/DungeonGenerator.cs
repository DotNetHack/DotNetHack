using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Dungeon.Generator
{
    /// <summary>
    /// DungeonGenerator
    /// </summary>
    public class DungeonGenerator : IDungeonGenerator
    {
        public void Generate(Dungeon3 aEmptyDungeon) 
        {
            // starting location.
            Location3i l = Location3i.Origin3i;
        }
    }
}
