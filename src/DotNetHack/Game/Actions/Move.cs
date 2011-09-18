using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Actions
{
    /// <summary>
    /// Move
    /// </summary>
    public class Move : DAction
    {
        /// <summary>
        /// Move
        /// </summary>
        /// <param name="aActor">Actor</param>
        /// <param name="aFrom">From</param>
        /// <param name="aTo">To</param>
        public Move(Actor aActor, Location3i aFrom, Location3i aTo) { }

        /// <summary>
        /// Perform the Action
        /// </summary>
        /// <returns></returns>
        public override bool Perform()
        {
            return false;
        }
    }
}
