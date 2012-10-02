using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core
{
    /// <summary>
    /// Game engine.
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
        /// GameState
        /// </summary>
        public GameState GameState { get; set; }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>
        /// The flags.
        /// </value>
        public GameEngineFlags Flags { get; private set; }

        /// <summary>
        /// Ticks
        /// </summary>
        internal long Ticks { get; set; }

        /// <summary>
        /// Run
        /// </summary>
        public void Run()
        {
            while (true)
            {


                ++Ticks;
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
    }
}
