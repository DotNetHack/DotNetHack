using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.NPC.AI;
using System.Xml.Serialization;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Actions;

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


        IHasLocation WayPoint { get; set; }

        /// <summary>
        /// TODO: EXPERIEMTNAL.
        /// Everything will be wired up to events and state machines.
        /// </summary>
        /// <param name="aPlayer"></param>
        public virtual void Execute(Player aPlayer)
        {
            bool meleeRange = false;

            WayPoint = aPlayer;

            if (WayPoint == null)
                return;

            // TODO: factor this out.
            var nStack = Brain.PathFinding.Solve(this, WayPoint);

            // TODO: factor this out.
            if (nStack == null)
                return;

            if (_speedCounter % this.Stats.Speed == 0)
            {
                // when the player is in range, don't pop, flag as melee range.
                WayPoint = nStack.Pop();

                // dont allow this baddy to go *onto* the player.
                if (WayPoint.Location == GameEngine.Player.Location)
                {
                    // stay right here.
                    WayPoint.Location = Location;
                    meleeRange = true;
                }

                Location = WayPoint.Location;
                _speedCounter = 0;
            }

            if (meleeRange)
                new ActionMeleeAttack(this, aPlayer).Perform();

            _speedCounter++;
        }

        private int _speedCounter = 0;

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
