using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.NPC.Monsters
{
    /// <summary>
    /// FireAnt
    /// </summary>
    [Serializable]
    public class FireAnt : Monster
    {
        /// <summary>
        /// FireAnt
        /// </summary>
        /// <param name="aLocation"></param>
        public FireAnt(Location3i aLocation)
            : base("fire ant", 'f', Colour.DarkRed, aLocation)
        { Agression = Game.NPC.Agression.Agressive; }
    }
}
