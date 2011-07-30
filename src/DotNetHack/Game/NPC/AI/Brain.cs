using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Dungeon;
using DotNetHack.Utility.Graph.Algorithm;
using DotNetHack.Game.Events;

namespace DotNetHack.Game.NPC.AI
{
    /// <summary>
    /// Brain
    /// </summary>
    public class Brain
    {
        /// <summary>
        /// Occures when this brain becomes aware of the player.
        /// </summary>
        public event EventHandler<ActorEventArgs> OnSeePlayer;

        /// <summary>
        /// Occurs when this brain becomes aware of another monster.
        /// </summary>
        public event EventHandler<ActorEventArgs> OnSeeMonster;

        /// <summary>
        /// Occurs when this brain sees an item.
        /// </summary>
        public event EventHandler<GameEventArgs> OnSeeItem;

        /// <summary>
        /// Supports serialization.
        /// </summary>
        public Brain() { }

        /// <summary>
        /// Creates a new instance of Brain.  A brain requires a reference to the
        /// actor and the surroundings or dungeon.
        /// </summary>
        /// <param name="aSelf">The actor that this brain belongs to.</param>
        /// <param name="aDungeon">The surroundings the brain is aware of.</param>
        public Brain(Actor aSelf, Dungeon.Dungeon3 aDungeon) 
        {
            Self = aSelf;
            Dungeon = aDungeon;
            PathFinding = new DungeonPathFinding(Dungeon);
        }

        /// <summary>
        /// The brain has "awareness" of it self.
        /// </summary>
        Actor Self { get; set; }

        /// <summary>
        /// The brain has "awareness" of it's surroundings.
        /// </summary>
        Dungeon3 Dungeon { get; set; }

        /// <summary>
        /// The brains ability to find a way to things.
        /// </summary>
        DungeonPathFinding PathFinding { get; set; }

        /// <summary>
        /// SwitchDungeon allows for changing the dungeon.
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown when dungeon is null.</exception>
        public void SwitchDungeon(Dungeon.Dungeon3 aDungeon)
        {
            // Make sure the passed parameter is not null.
            if (aDungeon == null)
                throw new ArgumentNullException("Cannot switch to a null dungeon.");

            // Set the dungeon.
            Dungeon = aDungeon;

            // Update path finding.
            PathFinding = new DungeonPathFinding(Dungeon);
        }
    }
}
