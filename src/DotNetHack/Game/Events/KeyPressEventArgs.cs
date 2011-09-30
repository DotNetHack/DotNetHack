using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Events
{
    public class KeyPressEventArgs : GameEventArgs
    {
        public KeyPressEventArgs(ConsoleKeyInfo aConsoleKeyInfo) 
        {
            ConsoleKeyInfo = aConsoleKeyInfo;
        }

        ConsoleKeyInfo ConsoleKeyInfo { get; set; }
    }
}
