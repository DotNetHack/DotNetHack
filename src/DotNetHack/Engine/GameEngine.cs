
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Engine
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
    public partial class GameEngine : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetHack.Engine.GameEngine"/> class.
        /// </summary>
        public GameEngine(GameEngineFlags flags)
        {
            Flags = flags;
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
        }

        #endregion

        /// <summary>
        /// RegisterStartStopCallbacks
        /// </summary>
        /// <param name="startCallback">Start callback</param>
        /// <param name="stopCallback">Stop callback</param>
        /// <returns><see cref="GameEngine"/> for chaining.</returns>
        public GameEngine RegisterStartStopCallbacks(System.Action startCallback, System.Action stopCallback) 
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
        public GameEngine RegisterStartCallback(System.Action aStartCallback)
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
        public GameEngine RegisterStopCallback(System.Action aStopCallback) 
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
        private System.Action StartCallback = null;

        /// <summary>
        /// StartFunction
        /// </summary>
        private System.Action StopCallback = null;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>
        /// The flags.
        /// </value>
        public GameEngineFlags Flags { get; private set; }

        #endregion
    }
}
