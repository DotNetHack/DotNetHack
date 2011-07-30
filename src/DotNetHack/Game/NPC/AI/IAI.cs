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
    /// IAI
    /// </summary>
    public interface IAI
    {
        /// <summary>
        /// Occurs when the agent sees the player.
        /// </summary>
        event EventHandler<ActorEventArgs> OnSeePlayer;

        /// <summary>
        /// Occurs when the agent sees another monster,
        /// </summary>
        event EventHandler<ActorEventArgs> OnSeeMonster;
    }
}
