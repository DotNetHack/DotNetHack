using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core
{
    /// <summary>
    /// Game engine.
    /// <remarks>
    /// The core functionality provided by the game engine includes a 
    /// rendering engine (“renderer”) for 2D or 3D graphics, a physics engine or 
    /// collision detection (and collision response), sound, scripting, animation, 
    /// artificial intelligence, networking, streaming, memory management, threading, 
    /// localization support, and a scene graph.
    /// </remarks>
    /// </summary>
    public class GameEngine : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetHack.GameEngine.GameEngine"/> class.
        /// </summary>
        public GameEngine(GameEngineFlags flags)
        {
            Flags = flags;
            State = GameState.New();
        }

        #region Methods

        /// <summary>
        /// Start the <see cref="GameEngine"/>
        /// </summary>
        public void Start()
        {
            if (StartCallback != null)
            {
                StartCallback();
            }
        }

        /// <summary>
        /// Stop the <see cref="GameEngine"/>
        /// </summary>
        public void Stop()
        {
            if (StopCallback != null)
            {
                StopCallback();
            }
        }

        /// <summary>
        /// Updates the state of the GameEngines status.
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        public void Update(object sender, EventArgs e)
        {
            State.Update();
        }

        #endregion

        /// <summary>
        /// RegisterStartStopCallbacks
        /// </summary>
        /// <param name="startCallback">Start callback</param>
        /// <param name="stopCallback">Stop callback</param>
        /// <returns><see cref="GameEngine"/> for chaining.</returns>
        public GameEngine RegisterStartStopCallbacks(Action startCallback, Action stopCallback) 
        {
            if (startCallback == null && stopCallback == null)
            {
                throw new ArgumentException("GameEngine::StartCallback and GameEngine::StopCallback cannot be set to null.");
            }
            else if (startCallback == null || stopCallback == null) 
            {
                if (startCallback == null)
                {
                    throw new ArgumentException("GameEngine::StartCallback cannot be set to null.");
                }

                throw new ArgumentException("GameEngine::StopCallback cannot be set to null.");
            }

            return RegisterStopCallback(stopCallback).RegisterStartCallback(startCallback);
        }

        /// <summary>
        /// RegisterStartCallback
        /// </summary>
        /// <param name="startCallback">The method called on GameEngine.Start</param>
        /// <returns><see cref="GameEngine"/> for chaining</returns>
        public GameEngine RegisterStartCallback(Action aStartCallback)
        {
            if (aStartCallback == null)
            {
                throw new ArgumentException("GameEngine::StartCallback cannot be set to null.");
            }

            StartCallback = aStartCallback;

            return this;
        }

        /// <summary>
        /// RegisterStopCallback
        /// </summary>
        /// <param name="stopCallback">The method called on GameEngine.Stop()</param>
        /// <returns><see cref="GameEngine"/> for chaining.</returns>
        public GameEngine RegisterStopCallback(Action aStopCallback) 
        {
            if (aStopCallback == null)
            {
                throw new ArgumentException("GameEngine::StopCallback cannot be set to null.");
            }

            StopCallback = aStopCallback;

            return this;
        }

        #region IDisposable implementation

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {

        }

        #endregion

        #region Fields

        /// <summary>
        /// StopFunction
        /// </summary>
        private Action StartCallback = null;

        /// <summary>
        /// StartFunction
        /// </summary>
        private Action StopCallback = null;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>
        /// The flags.
        /// </value>
        public GameEngineFlags Flags { get; private set; }

        /// <summary>
        /// GameState
        /// </summary>
        public GameState State { get; set; }

        #endregion

        /// <summary>
        /// Game engine flags.
        /// </summary>
        public enum GameEngineFlags
        {
            /// <summary>
            /// The none flag.
            /// </summary>
            Default,

            /// <summary>
            /// The debug flag.
            /// </summary>
            Debug,

            /// <summary>
            /// The editor flag.
            /// </summary>
            Editor,

            /// <summary>
            /// The god mode.
            /// </summary>
            GodMode,

            /// <summary>
            /// The no clip.
            /// </summary>
            NoClip,
        }

        #region Sub-Interfaces

        /// <summary>
        /// IGameEngineController
        /// </summary>
        public interface IRenderingAgent
        {
            void Render(IGameEngineController gameState);
        }

        /// <summary>
        /// GameEngine
        /// </summary>
        public interface IGameEngineController
        {
            GameEngine Engine { get; set; }
        }

        #endregion

        #region Subclasses

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

        #endregion
    }
}
