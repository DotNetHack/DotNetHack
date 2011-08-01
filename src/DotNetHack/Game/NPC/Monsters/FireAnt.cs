using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Dungeon.Tiles;
using DotNetHack.Utility.Graph.Algorithm;

using System.Xml.Serialization.Persisted;

namespace DotNetHack.Game.NPC.Monsters
{
    /// <summary>
    /// FireAnt
    /// </summary>
    [Serializable]
    public class FireAnt : Monster
    {
        public FireAnt()
            : base("fire ant", 'f', Colour.DarkRed, null)
        { }
        
        /// <summary>
        /// FireAnt
        /// </summary>
        /// <param name="aLocation"></param>
        public FireAnt(Location3i aLocation)
            : base("fire ant", 'f', Colour.DarkRed, aLocation)
        {
            // All fire-ants start out as passive agressive.
            Agression = Game.NPC.Agression.PassiveAgressive;

            this.Write<FireAnt>(@"c:\DNH\monsters.dat");
        }
    }
}


#if __
/**
// if (GameEngine.Time) // % Speed != 0
               //  return;
                
            if (aPlayer.Distance(this) < SightDistance)
                Agression = NPC.Agression.Agressive;
            else Agression = NPC.Agression.PassiveAgressive;

            switch (Agression)
            {
                default:
                    {

                        // TODO: this code pattern is common, should be factored out.
                    redo_movement:
                        Location3i UnitMovement = new Location3i(0, 0, Location.D);
                        RandomDirection.ApplyTo(UnitMovement);
                        Tile nMoveTo = aDungeon.GetTile(Location + UnitMovement);
                        if (!aDungeon.CheckBounds(Location + UnitMovement))
                            goto redo_movement;
                        else if (nMoveTo.TileType == TileType.Wall)
                            goto redo_movement;
                        else if (nMoveTo.TileType == TileType.Water)
                            goto redo_movement;
  
                        Location += UnitMovement;
                        break;
                    }
                case NPC.Agression.Agressive:
                    {
                        Location3i UnitMovement = new Location3i(0, 0, Location.D);

                        if (aPlayer.Location.X < Location.X)
                            UnitMovement.X--;
                        else if (aPlayer.Location.X > Location.X)
                            UnitMovement.X++;
                        else if (aPlayer.Location.Y < Location.Y)
                            UnitMovement.Y--;
                        else if (aPlayer.Location.Y > Location.Y)
                            UnitMovement.Y++;

                        Tile nMoveTo = aDungeon.GetTile(Location + UnitMovement);
                        if (!aDungeon.CheckBounds(Location + UnitMovement))
                            break;
                        else if (nMoveTo.TileType == TileType.Wall)
                            break;
                        Location += UnitMovement;
                        break;
                    }
            }
*/
#endif