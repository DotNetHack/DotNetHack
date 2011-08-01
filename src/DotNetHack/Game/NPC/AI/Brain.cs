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
    /// Extension methods for brain.
    /// </summary>
    public static class BrainExt
    {
        /// <summary>
        /// SwitchDungeon allows for changing the dungeon.
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown when dungeon is null.</exception>
        public static void SwitchDungeon(this Brain b, Dungeon.Dungeon3 aDungeon)
        {
            // Make sure the passed parameter is not null.
            if (aDungeon == null)
                throw new ArgumentNullException("Cannot switch to a null dungeon.");

            // Set the dungeon.
            b.Dungeon = aDungeon;

            // Update path finding.
            b.PathFinding = new DungeonPathFinding(b.Dungeon);
        }
    }

    /// <summary>
    /// Brain
    /// </summary>
    [Serializable]
    public class Brain
    {
        /// <summary>
        /// The various states this brain may be in.
        /// </summary>
        public enum BrainState 
        {
            Idle,
            Patrol,
            Attack,
            Flee,
            Stop,
        }

        /// <summary>
        /// The state machine responsible 
        /// </summary>
        FSM<BrainState> FSM { get; set; }

        /// <summary>
        /// CurrentState
        /// </summary>
        public BrainState CurrentState { get { return FSM.CurrentState; } }

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
        public Brain() 
        {
            FSM = new FSM<BrainState>(
                delegate(BrainState a)
                {
                    if (Self.Stats.HealthPercent < 10)
                        return BrainState.Flee;
                    return BrainState.Patrol;
                });
        }

        /// <summary>
        /// Creates a new instance of Brain.  A brain requires a reference to the
        /// actor and the surroundings or dungeon.
        /// </summary>
        /// <param name="aSelf">The actor that this brain belongs to.</param>
        /// <param name="aDungeon">The surroundings the brain is aware of.</param>
        public Brain(Actor aSelf, Dungeon.Dungeon3 aDungeon) 
            : this()
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
        public Dungeon3 Dungeon { get; set; }

        /// <summary>
        /// The brains ability to find a way to things.
        /// </summary>
        public DungeonPathFinding PathFinding { get; set; }
    }
}
