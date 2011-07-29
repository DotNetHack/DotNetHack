using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.NPC.AI;

namespace DotNetHack.Game.NPC
{
    /// <summary>
    /// non player controlled character.
    /// </summary>
    [Serializable]
    public abstract class NonPlayerControlled : Actor, IAI
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
        public int Level { get; set; }
        
        public event EventHandler<Events.ActorEventArgs> OnSeePlayer;

        public event EventHandler<Events.ActorEventArgs> OnSeeMonster;

        /// <summary>
        /// Execute the AI operation.
        /// </summary>
        /// <param name="aPlayer">The player</param>
        /// <param name="aDungeon">The dungeon</param>
        public virtual void Exec(Player aPlayer, Dungeon.Dungeon3 aDungeon) { }
    }
}
