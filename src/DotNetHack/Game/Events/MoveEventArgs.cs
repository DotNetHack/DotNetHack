using System;
using DotNetHack.Game.Dungeon.Tiles;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// actor movement event arguments
    /// </summary>
    public class MoveEventArgs : ActorEventArgs
    {
        /// <summary>
        /// creates a new instance of actor movement event
        /// </summary>
        /// <param name="aActor">the actor that moved</param>
        /// <param name="aTile">the tile the actor moved to</param>
        public MoveEventArgs(Actor aActor, Tile aToTile, Tile aFromTile)
            : base(aActor) 
        {
            MoveToTile = aToTile;
            MoveFromTile = aFromTile;
        }

        /// <summary>
        /// the tile that the actor moved to
        /// </summary>
        public Tile MoveToTile { get; set; }

        /// <summary>
        /// sometimes is not where you are, it's where you came from.
        /// </summary>
        public Tile MoveFromTile { get; set; }
    }
}
