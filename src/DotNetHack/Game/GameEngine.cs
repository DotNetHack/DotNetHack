using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack;
using DotNetHack.UI;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game
{
    /// <summary>
    /// GameEngine
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// GameEngine
        /// </summary>
        /// <param name="aPlayer"></param>
        public GameEngine(Player aPlayer, Dungeon aStartDungeon)
        {
            Time = 0L;
            Player = aPlayer;
            CurrentMap = aStartDungeon;
        }

        /// <summary>
        /// Run
        /// </summary>
        public void Run(EngineRunFlags aFlags)
        {
            // set engine run flags
            RunFlags = aFlags;

            // CursorVisible
            Console.CursorVisible = false;

            // set to true for exit.
            bool done = false;

            while (!done)
            {

            redo_input:
                Graphics.CursorToLocation(1, 1); // So as not to pile up blanks.
                ConsoleKeyInfo input = Console.ReadKey();
                Location UnitMovement = new Location(0, 0);
                switch (input.Key)
                {
                    default:
                        continue;
                    case ConsoleKey.LeftArrow:
                        UnitMovement.X--; break;
                    case ConsoleKey.RightArrow:
                        UnitMovement.X++; break;
                    case ConsoleKey.UpArrow:
                        UnitMovement.Y--; break;
                    case ConsoleKey.DownArrow:
                        UnitMovement.Y++; break;
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                }
                if (!CurrentMap.CheckBounds(Player.Location + UnitMovement))
                    goto redo_input;
                Tile nPlayerTile = CurrentMap.GetTile(Player.Location + UnitMovement);
                if (nPlayerTile != null)
                    if (nPlayerTile.TileType == TileType.WALL)
                        goto redo_input;

                Player.Location += UnitMovement;

                Update();

                CurrentMap.Render(Player.Location);

                Player.Draw();

                ++Time;
            }
        }

        public void Update()
        {
            /*
            foreach (var m in World.Monsters)
            {
                if (m.Location.X < Player.Location.X)
                    m.Location.X++;
                if (m.Location.Y < Player.Location.Y)
                    m.Location.Y++;

                if (m.Location.Y > Player.Location.Y)
                    m.Location.Y--;
                if (m.Location.X > Player.Location.X)
                    m.Location.X--;
            }*/
        }

        /// <summary>
        /// Time
        /// </summary>
        public long Time { get; private set; }

        /// <summary>
        /// Player
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        // private Dictionary<DistantLocation, IItem> Items { get; set; }

        /// <summary>
        /// CurrentMap
        /// </summary>
        private Dungeon CurrentMap { get; set; }

        /// <summary>
        /// RunFlags
        /// </summary>
        public EngineRunFlags RunFlags { get; set; }

        /// <summary>
        /// EngineRunFlags
        /// </summary>
        [Flags]
        public enum EngineRunFlags { NORMAL, EDITOR, DEBUG }
    }
}
