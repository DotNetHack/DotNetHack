using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.NPC.AI;
using System.Xml.Serialization;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.NPC
{
    /// <summary>
    /// non player controlled character.
    /// </summary>
    [Serializable]
    public abstract class NonPlayerControlled : Actor, IAgent
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public NonPlayerControlled() { }

        /// <summary>
        /// Creates a new NPC with the provided parameters.
        /// </summary>
        /// <param name="aName">The name of this NPC</param>
        /// <param name="aGlyph"></param>
        /// <param name="aColour"></param>
        public NonPlayerControlled(string aName, char aGlyph, Colour aColour, Location3i l)
            : base(aName, aGlyph, aColour, l) { }

        /// <summary>
        /// The level of this NPC.
        /// </summary>
        [XmlIgnore]
        public int Level { get { return Stats.Level; } }

        /// <summary>
        /// The brain for this NPC
        /// </summary>
        [XmlIgnore]
        public Brain Brain { get; set; }

        public override void RegenerateMagika() { }

        public override void RegenerateHealth() { }

        IHasLocation WayPoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aPlayer"></param>
        public virtual void Execute(Player aPlayer)
        {
            WayPoint = aPlayer;

            // TODO: factor this out.
            var nStack = Brain.PathFinding.Solve(this, WayPoint);
            nStack.Reverse();

            // TODO: factor this out.
            WayPoint = nStack.Pop();

            switch (Brain.CurrentState)
            {
                default:
                    break;
                case AI.Brain.BrainState.Flee:
                    break;
                case AI.Brain.BrainState.Attack:
                    WayPoint = aPlayer;
                    break;
                case AI.Brain.BrainState.Patrol:
                    break;
                case AI.Brain.BrainState.Idle:
                    break;
            }

            Location = WayPoint.Location;
        }

        /// <summary>
        /// No different than initialize.
        /// </summary>
        /// <param name="aDungeon"></param>
        public void Spawn(Dungeon.Dungeon3 aDungeon)
        {
            Brain = new AI.Brain(this, aDungeon);
        }
    }
}
