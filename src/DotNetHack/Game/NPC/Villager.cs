using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.NPC.AI;

namespace DotNetHack.Game.NPC
{
    /// <summary>
    /// A villager
    /// </summary>
    public abstract class Villager : NonPlayerControlled, IVillagerAI
    {
        /// <summary>
        /// Create a new villager
        /// </summary>
        /// <param name="aName">The name of the villager.</param>
        /// <param name="l">The location of the villager.</param>
        public Villager(string aName, Location3i l)
            : base(aName, '@', Colour.DarkYellow, l)
        { }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="aPlayer"></param>
        public override void Execute(Player aPlayer)
        {

        }
    }
}
