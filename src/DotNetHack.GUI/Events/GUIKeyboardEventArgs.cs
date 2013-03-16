using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Events
{
    /// <summary>
    /// GUIKeyboardEventArgs
    /// </summary>
    public class GUIKeyboardEventArgs : GUIEventArgs
    {
        /// <summary>
        /// GUIKeyboardEventArgs
        /// </summary>
        /// <param name="info">info for the key that was pressed</param>
        public GUIKeyboardEventArgs(ConsoleKeyInfo info)
        {
            ConsoleKeyInfo = info;
        }

        /// <summary>
        /// ConsoleKeyInfo
        /// </summary>
        public ConsoleKeyInfo ConsoleKeyInfo { get; private set; }
    }
}
