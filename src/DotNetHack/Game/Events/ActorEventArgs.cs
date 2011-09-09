using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// ActorEventArgs
    /// </summary>
    public abstract class ActorEventArgs : GameEventArgs
    {
        /// <summary>
        /// Creates a new actor event
        /// </summary>
        /// <param name="aActor"></param>
        public ActorEventArgs(Actor aActor)
        {
            ActorInvolved = aActor;
        }

        /// <summary>
        /// Actor involved in the event.
        /// </summary>
        public Actor ActorInvolved { get; set; }
    }

}
