using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotNetHack.Core.Game.World;

namespace DotNetHack.Core.Game
{
    /// <summary>
    /// GameState
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Explicitly deny construction such that a <c>bad</c> <see cref="GameState"/> cannot be created. A bad 
        /// <see cref="GameState"/> for example would be one with a <c>NULL</c> current map.
        /// </summary>
        private GameState() { Ticks = 0x0000L; }

        /// <summary>
        /// Safely return a new <see cref="GameState"/> following a strict set of conditions.
        /// </summary>
        internal static GameState New()
        {
            return new GameState()
            {
                CurrentMap = new Map() { },
            };
        }

        /// <summary>
        /// UpdateCallback
        /// </summary>
        Action<GameState> UpdateCallback;

        /// <summary>
        /// Register an action such that it takes place in the update pipeline.
        /// </summary>
        /// <param name="action">The action to register</param>
        /// <returns><see cref="GameState"/> for chaining.</returns>
        public GameState Register(Action<GameState> action)
        {
            if (action == null)
            {
                throw new ArgumentException("GameState::Register cannot register null callback.");
            }

            UpdateCallback += action;

            return this;
        }

        /// <summary>
        /// CurrentMap
        /// </summary>
        public Map CurrentMap { get; set; }

        /// <summary>
        /// Ticks
        /// </summary>
        public long Ticks { get; private set; }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="updateDelegate">The update delegation to execute.</param>
        public void Update()
        {
            UpdateCallback(this);
            ++Ticks;
            if (OnUpdateEvent != null)
                OnUpdateEvent(this, null);
        }

        /// <summary>
        /// GameStateUpdateEventArgs
        /// </summary>
        public class GameStateUpdateEventArgs : EventArgs
        {
            /// <summary>
            /// GameStateUpdateEventArgs
            /// </summary>
            public GameStateUpdateEventArgs(GameState aGameState)
                : base()
            {
                if (aGameState == null)
                    throw new ArgumentException("GameState cannot be set to null.");

                GameState = aGameState;
            }

            /// <summary>
            /// GameState
            /// </summary>
            GameState GameState { get; set; }
        }

        /// <summary>
        /// OnUpdateEvent
        /// </summary>
        public event EventHandler<GameStateUpdateEventArgs> OnUpdateEvent;
    }
}
