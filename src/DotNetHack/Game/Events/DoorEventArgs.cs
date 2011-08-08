using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Dungeon.Tiles;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// DoorEventArgs
    /// </summary>
    public class DoorEventArgs : ActorEventArgs
    {
        public DoorEventArgs(Actor aActor, Door aDoor)
            : base(aActor) { DoorInvolved = aDoor; }

        public Door DoorInvolved { get; set; }
    }
}
