using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Engine
{
    /// <summary>
    /// GameEngine
    /// </summary>
    public partial class GameEngine
    {
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
