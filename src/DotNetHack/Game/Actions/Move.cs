using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Actions
{
    public class Move : DAction
    {
        public Move(Actor aActor, Location3i aFrom, Location3i aTo) { }

        public override bool Perform()
        {
            return false;
        }
    }
}
