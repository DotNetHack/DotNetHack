using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Dungeon.Generator
{
    /// <summary>
    /// DungeonGenerator
    /// </summary>
    public abstract class DungeonGenerator : IDungeonGenerator
    {
        public DungeonGenerator(Dungeon3 aDungeon) { Dungeon = aDungeon; }
        public abstract void Generate(int d);
        protected Dungeon3 Dungeon { get; set; }
    }
}
