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
        }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>
        /// The flags.
        /// </value>
        public GameEngineFlags Flags { get; private set; }

        /// <summary>
        /// Run
        /// </summary>
        public void Run()
        {
            while(true)
            {

            }
        }

        #region IDisposable implementation

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
        }

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

        /// <summary>
        /// IGameEngineController
        /// </summary>
        public interface IGameEngineComponent
        {
            /// <summary>
            /// GameState
            /// </summary>
            GameState GameState { get; set; }
        }

        /// <summary>
        /// IGameEngineController
        /// </summary>
        public interface IRenderingControl
        {
            void Render(IGameEngineComponent gameState);
        }

        /// <summary>
        /// GameState
        /// </summary>
        public class GameState
        {
            /// <summary>
            /// CurrentMap
            /// </summary>
            public Map CurrentMap { get; set; }

            /// <summary>
            /// Ticks
            /// </summary>
            long Ticks { get; set; }
        }
    }
}
