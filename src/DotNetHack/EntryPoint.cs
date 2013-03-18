using DotNetHack.Engine;
using DotNetHack.GUI;
using DotNetHack.GUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI = DotNetHack.GUI.GUI;

namespace DotNetHack
{
    /// <summary>
    /// EntryPoint
    /// </summary>
    static class EntryPoint
    {
        [STAThread]
        static void Main(string[] args)
        {
            GameEngine = new Engine.GameEngine(
#if DEBUG
                Engine.GameEngine.GameEngineFlags.Debug
#endif
                );

            UI.Instance.Run(new MainWindow());
        }

        /// <summary>
        /// GameEngine
        /// </summary>
        public static GameEngine GameEngine { get; set; }
    }
}
