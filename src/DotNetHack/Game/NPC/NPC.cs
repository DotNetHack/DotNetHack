using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.NPC
{
    /// <summary>
    /// non player controlled character.
    /// </summary>
    [Serializable]
    public class NPC : Actor
    {
        /// <summary>
        /// Creates a new NPC
        /// </summary>
        public NPC(string aNPCName)
            : base() { Name = aNPCName; }

        /// <summary>
        /// The name of this non-player controlled character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The level of this NPC.
        /// </summary>
        public int Level { get; set; }   
    }

}
