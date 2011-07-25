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
        event EventHandler<ActorEventArgs> OnSeePlayer;

        event EventHandler<ActorEventArgs> OnSeeMonster;

        void Exec(Player aPlayer, Dungeon3 aDungeon);
    }
}
