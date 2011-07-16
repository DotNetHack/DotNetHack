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
            // Set the linked dungeon.
            FogOfWarDungeon = aDungeon;

            // Mimc the size and shape of the dungeon.
            SeenData = new bool[aDungeon.DungeonWidth, aDungeon.DungeonHeight,
                aDungeon.DungeonDepth];
        }

        /// <summary>
        /// UpdateSeenData
        /// </summary>
        /// <param name="aLocation">The location to update "seen" data with.</param>
        public void UpdateSeenData(Location3i aLocation, double aSightDistance)
        {
            SeenRadius(delegate(int x, int y)
            {
                // Compute the distance from the passed location to the
                // [x, y] in the iterator
                if (Location2i.GetNew(x,y).Distance(aLocation) <= aSightDistance)
                    SeenData[x, y, aLocation.D] = true; 
            });
        }

        /// <summary>
        /// IterXYDelegate
        /// </summary>
        /// <param name="d">x,y iterator delegate</param>
        void SeenRadius(IterXYDelegate d)
        {
            for (int x = 0; x < FogOfWarDungeon.DungeonWidth; ++x)
                for (int y = 0; y < FogOfWarDungeon.DungeonHeight; ++y)
                    d(x, y);
        }

        /// <summary>
        /// SeenData is a three dimensional array that mimics the size and shape of
        /// the dungeon that was used to create the <c>FogOfWar</c> object.
        /// </summary>
        bool[, ,] SeenData { get; set; }

        /// <summary>
        /// Linked back to the dungeon.
        /// </summary>
        private readonly Dungeon3 FogOfWarDungeon;
    }
}
