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
    public class HerbSpawn : ISpawn<Herb>
    {
        /// <summary>
        /// Creates a new instance of an herb-spawn.
        /// </summary>
        public HerbSpawn() 
        {
            // set the last visited time to min-value.
            LastVisited = DateTime.MinValue;
        }

        /// <summary>
        /// The last time this herb spawn was last visited.
        /// </summary>
        public DateTime LastVisited { get; set; }

        /// <summary>
        /// The herb spawned up by this spawn tile.
        /// </summary>
        public Herb Resource { get; set; }
    }
}
