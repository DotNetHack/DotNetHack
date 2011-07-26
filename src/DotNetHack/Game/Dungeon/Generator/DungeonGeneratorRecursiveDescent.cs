using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Dungeon.Generator
{
    /// <summary>
    /// DungeonGeneratorRecursiveDescent
    /// </summary>
    public class DungeonGeneratorRecursiveDescent : DungeonGenerator, IDungeonGenerator
    {
        /// <summary>
        /// DungeonGeneratorRecursiveDescent
        /// <remarks>WARNING: dungeon will be wiped.</remarks>
        /// </summary>
        /// <param name="aDungeon"></param>
        public DungeonGeneratorRecursiveDescent(Dungeon3 aDungeon)
            : base(aDungeon)
        { }

        /// <summary>
        /// Generates the dungeon using recursive descent model.
        /// </summary>
        public override void Generate() { }
    }
}
