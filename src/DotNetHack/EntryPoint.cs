using System;
using DotNetHack.Game;

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

            // Create a new game engine
            GameEngine g = new GameEngine(new Player("pete"),
                Dungeon.Load("test"));

            // Run
            GameEngine.EngineRunFlags runFlags = 
                GameEngine.EngineRunFlags.NORMAL;

            // If runtime is setup for debug, set the run flags
            if (R.IsDebug)
                runFlags |= GameEngine.EngineRunFlags.DEBUG;

            g.Run(runFlags);
            
        }
    }
}