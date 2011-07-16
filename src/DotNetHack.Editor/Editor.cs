using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using DotNetHack.UI;
using DotNetHack.Game;
using DotNetHack.Game.Dungeon;
using DotNetHack.Game.Dungeon.Tiles;

namespace DotNetHack.Editor
{
    /// <summary>
    /// CommandProcessor
    /// </summary>
    /// <param name="k">input</param>
    public delegate void CommandProcessor(ConsoleKeyInfo k);

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
        /// The editor mode.
        /// This can be switched using {F9 - F12}
        /// </summary>
        static EditorMode EditorMode { get; set; }

        /// <summary>
        /// CommandProcessor
        /// </summary>
        static CommandProcessor CommandProcessor { get; set; }

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
            var tmpSetTile = new Tile()
            {
                G = g,
                TileType = t,
                C = c ?? Colour.Standard,
            };

            // Store the previous tile.
            CurrentMap.SetTile(CurrentLocation, tmpSetTile);
            PreviousTile = tmpSetTile;
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

            // The last unit movement is recorded.
            Location3i LastUnitMovement = Location3i.Origin3i;

            // The default is the "Layout" mode.
            CommandProcessor = ProcessLayoutModeCommands;

            // Set the game engine run flags
            GameEngine.RunFlags = GameEngine.EngineRunFlags.DEBUG |                             GameEngine.EngineRunFlags.EDITOR;

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
                        // Create a new instance of the game engine with the current location and map.
                        GameEngine g = new GameEngine(
                            new Player("Editor", CurrentLocation), CurrentMap);

                        // Run the full out game engine except with editor and debug run flags.
                        g.Run(GameEngine.EngineRunFlags.DEBUG | GameEngine.EngineRunFlags.EDITOR);

                        break;
                    // Change editor mode to "Layout"
                    case ConsoleKey.F9:
                        EditorMode = DotNetHack.Editor.EditorMode.Layout;
                        break;
                    // Change editor mode to "Items"
                    case ConsoleKey.F10:
                        EditorMode = DotNetHack.Editor.EditorMode.Items;
                        break;
                    case ConsoleKey.F11:
                        EditorMode = DotNetHack.Editor.EditorMode.Monsters;
                        break;
                    #endregion

                    #region Map Load/Save Commands
                    /**
                     * Save
                     */
                    case ConsoleKey.F2:
                        if (ConsoleModifiers.Control == inkey.Modifiers)
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
                     * Load
                     */
                    case ConsoleKey.F3:
                        if (ConsoleModifiers.Control == inkey.Modifiers)
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

                // Depending on the editor "mode" re-wire the command procesor
                // (kind of like a func pointer)
                switch (EditorMode)
                {
                    case DotNetHack.Editor.EditorMode.Layout:
                        CommandProcessor = ProcessLayoutModeCommands;
                        break;
                    case DotNetHack.Editor.EditorMode.Items:
                        CommandProcessor = ProcessItemModeCommands;
                        break;
                    case DotNetHack.Editor.EditorMode.Monsters:
                        CommandProcessor = ProcessMonsterModeCommands;
                        break;
                }

                // Fire off command processor, be sure to see the switch above 
                CommandProcessor(inkey);

                // Record what the last UnitMovement was.
                LastUnitMovement = UnitMovement;

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

        /// <summary>
        /// No different than a mouse cursor.
        /// </summary>
        const char EDITOR_GLYPH = '#';

        /// <summary>
        /// ProcessLayoutModeCommands
        /// </summary>
        /// <param name="input">The input</param>
        static void ProcessLayoutModeCommands(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                #region Editing Commands

                // Add a new basic wall tile.
                case ConsoleKey.Enter:
                    if (PreviousTile != null)
                        SetTile(PreviousTile.TileType, PreviousTile.G, PreviousTile.C);
                    break;

                // Add a stairs-up tile.
                case ConsoleKey.OemPeriod:
                    SetTile(TileType.STAIRS_UP, Symbols.ARROW_UP, Colour.Standard);
                    break;

                // Allow for deltion
                case ConsoleKey.Delete:
                    SetTile(TileType.NOTHING, '.', Colour.Standard);
                    break;

                case ConsoleKey.A:
                    SetTile(TileType.ALTAR, '_', Colour.Standard);
                    break;

                // Add stairs down tile.
                case ConsoleKey.OemComma:
                    SetTile(TileType.STAIRS_DOWN, Symbols.MOD_EQUAL, Colour.Standard);
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

                // road
                case ConsoleKey.R:
                    SetTile(TileType.ROAD, Symbols.FILL_LIGHT, Colour.Road);
                    break;

                // tree.
                case ConsoleKey.T:
                    SetTile(TileType.TREE, 'T', Colour.CurrentColour);
                    break;

                // mountain
                case ConsoleKey.M:
                    SetTile(TileType.MOUNTAIN, '^', Colour.Mountain);
                    break;

                // home
                case ConsoleKey.H:
                    SetTile(TileType.HOME, '⌂', Colour.CurrentColour);
                    break;

                // gress
                case ConsoleKey.G:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(TileType.GRASS, Symbols.FILL_LIGHT, Colour.Grass);
                            break;
                        case ConsoleModifiers.Shift:
                            SetTile(TileType.GRAVE, Symbols.SMALL_T, Colour.Grave);
                            break;
                    }
                    break;

                // bridge horizontal, bridge vertical
                case ConsoleKey.B:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(TileType.BRIDGE, Symbols.W_DBL_HORIZONTAL, Colour.Road);
                            break;
                        case ConsoleModifiers.Shift:
                            SetTile(TileType.BRIDGE, Symbols.W_DBL_VERTICAL, Colour.Road);
                            break;
                    }
                    break;

                // field, fountain
                case ConsoleKey.F:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(TileType.FIELD, Symbols.FILL_LIGHT, Colour.Field);
                            break;
                        case ConsoleModifiers.Shift:
                            SetTile(TileType.FOUNTAIN, Symbols.FUNCTION, Colour.Fountain);
                            break;
                    }
                    break;

                #endregion

                #endregion
            }
        }

        /// <summary>
        /// ProcessMonsterModeCommands
        /// </summary>
        /// <param name="input">The input</param>
        static void ProcessMonsterModeCommands(ConsoleKeyInfo input) { }

        /// <summary>
        /// ProcessItemModeCommands
        /// </summary>
        /// <param name="input">The input</param>
        static void ProcessItemModeCommands(ConsoleKeyInfo input) { }
    }
}
