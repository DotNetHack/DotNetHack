/// FSM can be used for quick genericized state machines.
/// Copyright (C) 2011  Peter Jensen
///
/// This program is free software: you can redistribute it and/or modify
/// it under the terms of the GNU General Public License as published by
/// the Free Software Foundation, either version 3 of the License, or
/// (at your option) any later version.
///
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU General Public License for more details.
///
/// You should have received a copy of the GNU General Public License
/// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.NPC.AI
{
    /// <summary>
    /// A genericized finite state machine.
    /// <typeparam name="S">The type of state this FSM may be in.</typeparam>
    /// </summary>
    public class FSM<S>
    {
        /// <summary>
        /// Creates a new instance of the finite state machine.
        /// <param name="initialState">The initial state of the state machine.</param>
        /// </summary>
        public FSM(S aInitialState) { CurrentState = aInitialState; }

        /// <summary>
        /// Creates a new instance of the finite state machine.
        /// <remarks>The default constructor will default the state in the 
        /// standard manner using <code>default(S)</code></remarks>
        /// </summary>
        public FSM() { CurrentState = default(S); }

        /// <summary>
        /// The current state of the state machine.
        /// <remarks>readonly</remarks>
        /// </summary>
        public S CurrentState { get; private set; }

        /// <summary>
        /// Reads and yield returns the current state then moves
        /// to the next state.
        /// </summary>
        public IEnumerable<S> Next
        {
            get
            {
                yield return CurrentState;
                CurrentState = fOf(CurrentState);
            }
        }

        /// <summary>
        /// The transition function / table.
        /// </summary>
        Func<S, S> fOf { get; set; }
    }
}
