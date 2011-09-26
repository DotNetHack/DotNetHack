using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items.Herbs;

namespace DotNetHack.Game.Dungeon.Tiles
{
    /// <summary>
    /// HerbSpawn
    /// </summary>
    [Serializable]
    public class HerbSpawn : Tile, IHasLocation
    {
        /// <summary>
        /// Serializable
        /// </summary>
        public HerbSpawn() 
        {
            
        }

        /// <summary>
        /// Creates a new instance of an herb-spawn.
        /// </summary>
        public HerbSpawn(Herb aHerb, long aTimeToRespawn)
            : base(aHerb.G, aHerb.C)
        {
            TileFlags = Tiles.TileFlags.Spawn;

            // Set spawn resource.
            Resource = aHerb;

            // set the last visited time to min-value.
            TicksSinceLastVisited = TimeToRespawn;
            TimeToRespawn = aTimeToRespawn;

            // register tick listener w/ main game-engine tick hdlr.
            GameEngine.OnTick += new EventHandler(GameEngine_OnTick);
        }

        /// <summary>
        /// GameEngine_OnTick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GameEngine_OnTick(object sender, EventArgs e)
        {
            if (TimeToRespawn > TicksSinceLastVisited)
                TicksSinceLastVisited++;
        }

        /// <summary>
        /// The last time this herb spawn was last visited.
        /// </summary>
        public long TicksSinceLastVisited { get; set; }

        /// <summary>
        /// The herb spawned up by this spawn tile.
        /// </summary>
        public Herb Resource { get; set; }

        /// <summary>
        /// The location of this herb spawn.
        /// </summary>
        public Location3i Location { get; set; }

        /// <summary>
        /// TTL
        /// </summary>
        readonly long TimeToRespawn;

        /// <summary>
        /// Take
        /// </summary>
        /// <returns></returns>
        public Herb Take()
        {
            if (TimeToRespawn >= TicksSinceLastVisited)
            {
                TicksSinceLastVisited = 0L;
                return Resource;
            }
            return default(Herb);
        }

        /// <summary>
        /// CanTake
        /// </summary>
        public bool CanTake
        {
            get { return (TimeToRespawn > TicksSinceLastVisited); }
        }

        /// <summary>
        /// NewHerbSpawn
        /// </summary>
        /// <returns>New HerbSpawn</returns>
        public static HerbSpawn NewHerbSpawn(string aHerbName)
        {
            return new HerbSpawn(new Herb(aHerbName), 10);
        }
    }
}
