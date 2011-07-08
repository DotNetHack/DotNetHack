using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;

namespace DotNetHack.Editor
{
    /// <summary>
    /// DNH Editor (2nd) Revision
    /// </summary>
    public class Editor
    {
        /// <summary>
        /// The current location inside of the current map
        /// </summary>
        static Location3i CurrentLocation { get; set; }

        /// <summary>
        /// The current map
        /// </summary>
        static Dungeon3 CurrentMap { get; set; }

        /// <summary>
        /// The very last tile that was added to the mapped. Can 
        /// be used to repeat the last tile added.
        /// </summary>
        static Tile PreviousTile { get; set; }

        static void ShowHelp() 
        {
            UI.Graphics.Clear();
            Console.WriteLine("\t{0} - {1}",
                "PageUp", "Up a dungeon level");
            Console.WriteLine("\t{0} - {1}",
                "PageDown", "Down a dungeon level");
        }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            ShowHelp();
            UI.Graphics.MessageBox.Show("DNH-Edit", "Welcome to DotNetHack-Editor!");
            Console.ReadKey();
            

            // Create a new map with a couple of floors
            CurrentMap = new Dungeon3(UI.Graphics.ScreenWidth,
                UI.Graphics.ScreenHeight, 3);
            CurrentLocation = new Location3i(0, 0, 0);

        redo__main_input:
            var inkey = Console.ReadKey();
            Location3i UnitMovement = new Location3i(0, 0, 0);
            switch (inkey.Key)
            {
                #region Editor Control
                case ConsoleKey.Escape:
                    return;
                #endregion

                #region Directional Keys
                case ConsoleKey.LeftArrow:
                    UnitMovement.X--;
                    break;
                case ConsoleKey.RightArrow:
                    UnitMovement.X++;
                    break;
                case ConsoleKey.UpArrow:
                    UnitMovement.Y--;
                    break;
                case ConsoleKey.DownArrow:
                    UnitMovement.Y++;
                    break;
                case ConsoleKey.PageUp:
                    UnitMovement.D--;
                    break;
                case ConsoleKey.PageDown:
                    UnitMovement.D++;
                    break;
                #endregion

                case ConsoleKey.A:
                    CurrentMap.SetTile(CurrentLocation, new Tile() 
                    {
                        G = '_',
                        TileType = TileType.ALTAR,
                        C = Colour.Standard,
                    });
                    break;
            }

            // Check the boundaries of the dungeon.
            if (!CurrentMap.CheckBounds(CurrentLocation + UnitMovement))
                goto redo__main_input;

            // Add UnitMovement to the CurrentLocation.
            CurrentLocation += UnitMovement;

            // Render
            CurrentMap.DungeonRenderer.Render(CurrentLocation);

            // Move cursor to current location
            UI.Graphics.CursorToLocation(CurrentLocation);

            // Show the editor "hand"
            Console.Write(EDITOR_GLYPH);

            // CursorToLocation
            UI.Graphics.CursorToLocation(0, UI.Graphics.ScreenHeight - 1);

            Console.Write(CurrentLocation);

            // jump back to main input
            goto redo__main_input;
        }

        const char EDITOR_GLYPH = '#';
    }
}
