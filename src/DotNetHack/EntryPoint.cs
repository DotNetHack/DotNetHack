using System;
using DotNetHack.Game;
using DotNetHack.Game.Dungeon;

namespace DotNetHack
{
    /// <summary>
    /// EntryPoint
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">
        /// A <see cref="System.String[]"/>
        /// </param>
        public static void Main(string[] args)
        {
            // Parse runtime arguments
            R.ParseArgs(args);

            // Initialize graphics
            UI.Graphics.Initialize();

            Dungeon3 d = new Dungeon3(UI.Graphics.ScreenWidth, 
                UI.Graphics.ScreenHeight, 10);

            // Create a new game engine
            GameEngine g = new GameEngine(new Player("pete"), d);

            // Run
            GameEngine.EngineRunFlags runFlags =
                GameEngine.EngineRunFlags.Normal;

            // If runtime is setup for debug, set the run flags
            if (R.IsDebug)
                runFlags |= GameEngine.EngineRunFlags.Debug;

            g.Run(runFlags, ref args);
        }
    }
}