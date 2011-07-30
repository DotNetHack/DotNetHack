using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.NPC.AI
{
    /// <summary>
    /// A genericized finite state machine.
    /// </summary>
    /// <typeparam name="S">The state type</typeparam>
    /// <typeparam name="H">The heuristic, a function of H, returning S.</typeparam>
    /// <typeparam name="G">Other</typeparam>
    public class FSM<S, H, G> where H : Func<H, S>
    {
        /// <summary>
        /// Creates a new instance of the finite state machine.
        /// </summary>
        public FSM(int s)
        {
            Heuristics = new H[s];
        }

        /// <summary>
        /// An array of heuristics.
        /// </summary>
        H[] Heuristics { get; set; }
    }
}
