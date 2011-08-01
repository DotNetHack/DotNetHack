using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;
using DotNetHack.Game.Dungeon;

namespace DotNetHack.Game.NPC.AI
{
    /// <summary>
    /// IAgent
    /// </summary>
    public interface IAgent
    {
        /// <summary>
        /// The brain for this agent
        /// </summary>
        Brain Brain { get; set; }

        /// <summary>
        /// Step
        /// </summary>
        /// <param name="aDungeon">The dungeon</param>
        /// <param name="aPlayer">The player.</param>
        void Execute(Player aPlayer);
    }
}
