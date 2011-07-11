using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;
using DotNetHack.UI;

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

        /// <summary>
        /// The current map file name
        /// </summary>
        static string CurrentMapFileName { get; set; }

        /// <summary>
        /// Set tile
        /// <remarks>Makes things a bit cleaner.</remarks>
        /// </summary>
        /// <param name="t">type</param>
        /// <param name="g">glyph</param>
        /// <param name="c">colour = standard.</param>
        static void SetTile(TileType t, char g, Colour c)
        {
            CurrentMap.SetTile(CurrentLocation, new Tile()
            {
                G = g,
                TileType = t,
                C = c ?? Colour.Standard,
            });
        }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            // Parse incoming args for the runtime env.
            R.ParseArgs(args);

            // Show welcome message.
            UI.Graphics.MessageBox.Show("DNH-Edit", "Welcome to DotNetHack-Editor!");

            // Create a new map with a couple of floors
            CurrentMap = new Dungeon3(UI.Graphics.ScreenWidth,
                UI.Graphics.ScreenHeight, 3);

            CurrentLocation = new Location3i(0, 0, 0);

            #region Main Loop
        redo__main_input:
            try
            {
                var inkey = Console.ReadKey();
                Location3i UnitMovement = new Location3i(0, 0, 0);
                switch (inkey.Key)
                {
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

                    #region Editor Control Commands
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.F1:
                        {
                            // Show File Menu
                            // (1) Save
                            // (2) Load
                            // (3) Exit

                            break;
                        }
                    case ConsoleKey.F5:
                        // Create a new instance of the game engine with the current location
                        // and the current map.
                        GameEngine g = new GameEngine(
                            new Player("Editor", CurrentLocation), CurrentMap);

                        // Run the full out game engine except with editor and debug run flags.
                        g.Run(GameEngine.EngineRunFlags.DEBUG | GameEngine.EngineRunFlags.EDITOR);

                        break;
                    #endregion

                    #region Editing Commands

                    // Add a new basic wall tile.
                    case ConsoleKey.Enter:
                        CurrentMap.SetTile(CurrentLocation, new Tile()
                        {
                            G = '#',
                            TileType = TileType.WALL,
                            C = Colour.Standard,
                        });
                        break;

                    // Add a stairs-up tile.
                    case ConsoleKey.OemPeriod:
                        SetTile(TileType.STAIRS_UP, Symbols.ARROW_UP, Colour.Standard);
                        break;

                    // Add stairs down tile.
                    case ConsoleKey.OemComma:
                        SetTile(TileType.STAIRS_DOWN, Symbols.ARROW_DOWN, Colour.Standard);
                        break;

                    // wall
                    case ConsoleKey.Insert:
                        SetTile(TileType.WALL, Symbols.SOLID, Colour.Standard);
                        break;

                    #region Out of Doors Tiles

                    /// water
                    case ConsoleKey.W:
                        SetTile(TileType.WATER, Symbols.ALMOST_EQUAL, Colour.Ocean);
                        break;

                    /// field
                    case ConsoleKey.F:
                        SetTile(TileType.FIELD, Symbols.FILL_LIGHT, Colour.Field);
                        break;

                    // road
                    case ConsoleKey.R:
                        SetTile(TileType.ROAD, Symbols.FILL_HEAVY, Colour.Road);
                        break;

                    // gress
                    case ConsoleKey.G:
                        SetTile(TileType.GRASS, Symbols.FILL_LIGHT, Colour.Grass);
                        break;

                    // tree.
                    case ConsoleKey.T:
                        SetTile(TileType.TREE, 'T', Colour.Grass);
                        break;

                    // mountain
                    case ConsoleKey.M:
                        SetTile(TileType.MOUNTAIN, '^', Colour.Mountain);
                        break;

                    // home
                    case ConsoleKey.H:
                        SetTile(TileType.HOME, '⌂', Colour.CurrentColour);
                        break;

                    #endregion

                    #endregion

                    #region Map Load/Save Commands
                    /**
                     * Load
                     */
                    case ConsoleKey.A:
                        if (ConsoleModifiers.Control == (inkey.Modifiers | ConsoleModifiers.Control))
                        {
                            if (CurrentMapFileName == null)
                            {
                                UI.Graphics.CursorToLocation(1, 1);
                                Console.Write("Save As: ");
                                CurrentMapFileName = Console.ReadLine();
                            }

                            // save the map, but if this fails say so.
                            CurrentMap.SaveAs(CurrentMapFileName);
                            CurrentMap.DungeonRenderer.HardRefresh(CurrentLocation);
                        }
                        break;
                    /**
                     * Save
                     */
                    case ConsoleKey.O:
                        if (ConsoleModifiers.Control == (inkey.Modifiers | ConsoleModifiers.Control))
                        {
                            UI.Graphics.CursorToLocation(1, 1);
                            Console.Write("Load Dungeon: ");
                            string strLoadFile = Console.ReadLine();
                            CurrentMap = Dungeon3.Load(strLoadFile);
                            CurrentMapFileName = strLoadFile;
                            CurrentMap.DungeonRenderer.HardRefresh(CurrentLocation);
                        }
                        break;

                    #endregion
                }

                // Check the boundaries of the dungeon.
                if (!CurrentMap.CheckBounds(CurrentLocation + UnitMovement))
                    goto redo__main_input;

                // Add UnitMovement to the CurrentLocation.
                CurrentLocation += UnitMovement;

                // Render
                CurrentMap.Render(CurrentLocation);

                // Move cursor to current location
                UI.Graphics.CursorToLocation(CurrentLocation);

                // Show the editor "hand"
                Console.Write(EDITOR_GLYPH);

                // CursorToLocation
                UI.Graphics.CursorToLocation(0, UI.Graphics.ScreenHeight - 1);

                Console.Write(CurrentLocation);
            }
            catch (Exception ex)
            {
                UI.Graphics.MessageBox.Show("DNH-Edit Exception", ex);
                CurrentMap.DungeonRenderer.HardRefresh(CurrentLocation);
            }

            // jump back to main input
            goto redo__main_input;

            #endregion
        }

        const char EDITOR_GLYPH = '#';
    }
}
