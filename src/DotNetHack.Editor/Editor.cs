using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using DotNetHack.UI;
using DotNetHack.Game;
using DotNetHack.Game.Dungeon;
using DotNetHack.Game.Dungeon.Tiles;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items;
using System.Threading;
using DotNetHack.Game.Items.Potions;
using DotNetHack.Game.Items.Potions.Elixers;
using DotNetHack.Utility;
using DotNetHack.Game.Dungeon.Generator;
using DotNetHack.Game.Dungeon.Tiles.Traps;
using DotNetHack.Game.NPC.Monsters;

using System.Xml.Serialization.Persisted;
using System.IO;
using System.Reflection;
using DotNetHack.Game.Items.Equipment.Armor;
using DotNetHack.Game.Items.Equipment.Weapons;

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
        static List<Colour> Colours = new List<Colour>();

        /// <summary>
        /// No different than a mouse cursor.
        /// </summary>
        const char EDITOR_GLYPH = '#';

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
        /// The list of monsters
        /// </summary>
        static List<Monster> Monsters { get; set; }

        /// <summary>
        /// CommandProcessor
        /// </summary>
        static CommandProcessor CommandProcessor { get; set; }

        /// <summary>
        /// The current map file name
        /// </summary>
        static string CurrentMapFileName { get; set; }

        /// <summary>
        /// The current guid, used to tie doors, keys, locked things, together.
        /// The person editing is responsible for managing guids by using F4 to generate
        /// a new Guid, all subsequent Doors, Keys, etc, will be created tying 
        /// them together. Once F4 is pressed again, the process repeats.
        /// </summary>
        static Guid CurrentGuid { get; set; }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Parse incoming args for the runtime env.
            R.ParseArgs(args);

            // Load all monsters
            try { Monsters = Persisted.Read<List<Monster>>(R.MonsterFile); }
            catch { UI.Graphics.MessageBox.Show("DNH-Edit", "Monster file not found!"); }

            // Show welcome message.
            UI.Graphics.MessageBox.Show("DNH-Edit", "Welcome to DotNetHack-Editor!");

            // Create a new map with a couple of floors
            CurrentMap = new Dungeon3(UI.Graphics.ScreenWidth, UI.Graphics.ScreenHeight, 3);

            Console.SetWindowSize(UI.Graphics.ScreenWidth, UI.Graphics.ScreenHeight);

            CurrentLocation = new Location3i(UI.Graphics.ScreenCenter);

            // The last unit movement is recorded.
            Location3i LastUnitMovement = Location3i.Origin3i;

            // The default is the "Layout" mode.
            CommandProcessor = ProcessLayoutModeCommands;

            // Set the game engine run flags
            GameEngine.RunFlags = GameEngine.EngineRunFlags.Debug | GameEngine.EngineRunFlags.Editor;

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
                        GameEngine g = new GameEngine(new Player("Editor", CurrentLocation),
                            Util.DeepCopy<Dungeon3>(CurrentMap));

                        // Run the full out game engine except with editor and debug run flags.
                        g.Run(GameEngine.EngineRunFlags.Debug | GameEngine.EngineRunFlags.Editor,
                            ref args);
                        CurrentMap.DungeonRenderer.HardRefresh(CurrentLocation);
                        break;

                    // generate a new guid.
                    case ConsoleKey.F4:
                        UI.Graphics.CursorToLocation(1, 1);
                        CurrentGuid = Guid.NewGuid();
                        UI.Graphics.MessageBox.Show("Generated New Guid",
                            CurrentGuid.ToString());
                        UI.Graphics.Display.Refresh(CurrentMap, CurrentLocation);
                        break;
                    // Change editor mode to "Layout"
                    case ConsoleKey.F9:
                        EditorMode = DotNetHack.Editor.EditorMode.Layout;
                        UI.Graphics.Display.ShowMessage("Changed to \"{0}\" mode.", EditorMode);
                        break;
                    // Change editor mode to "Items"
                    case ConsoleKey.F10:
                        EditorMode = DotNetHack.Editor.EditorMode.Items;
                        UI.Graphics.CursorToLocation(1, 1);
                        UI.Graphics.Display.ShowMessage("Changed to \"{0}\" mode.", EditorMode);
                        break;
                    case ConsoleKey.F11:
                        EditorMode = DotNetHack.Editor.EditorMode.Monsters;
                        UI.Graphics.Display.ShowMessage("Changed to \"{0}\" mode.", EditorMode);
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
                UI.Graphics.Display.Refresh(CurrentMap, CurrentLocation);
            }

            // jump back to main input
            goto redo__main_input;

            #endregion
        }

        /// <summary>
        /// Set tile
        /// <remarks>Makes things a bit cleaner.</remarks>
        /// </summary>
        /// <param name="t">type</param>
        /// <param name="g">glyph</param>
        /// <param name="c">colour = standard.</param>
        static void SetTile(TileType t, char g, Colour c, Location3i location = null)
        {
            var tmpSetTile = new Tile()
            {
                G = g,
                TileType = t,
                C = c ?? Colour.Standard,
            };

            if (location == null)
            {
                location = CurrentLocation;
            }

            // Store the previous tile.
            CurrentMap.SetTile(location, tmpSetTile);
            PreviousTile = tmpSetTile;
        }

        /// <summary>
        /// SetTile, adds the passed tile to this location.
        /// </summary>
        /// <param name="aTile">The tile to add to this location.</param>
        static void SetTile(Tile aTile)
        {
            CurrentMap.SetTile(CurrentLocation, aTile);
        }

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
                    SetTile(TileType.StairsUp, Symbols.ARROW_UP, Colour.Standard);
                    break;

                // Allow for deltion
                case ConsoleKey.Delete:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(TileType.Nothing, '.', Colour.Standard);
                            break;
                        case ConsoleModifiers.Control:
                            bool nothing = Graphics.MessageBox.YesNo("Are you Sure?");
                            if (nothing)
                            {
                                clrScreen(TileType.Nothing, '.', Colour.Standard);
                            }
                            break;
                    }
                    break;

                case ConsoleKey.A:
                    SetTile(TileType.Altar, '_', Colour.Standard);
                    break;

                // Add stairs down tile.
                case ConsoleKey.OemComma:
                    SetTile(TileType.StairsDown, Symbols.MOD_EQUAL, Colour.Standard);
                    break;

                // wall
                case ConsoleKey.Insert:
                    SetTile(TileType.Wall, Symbols.SOLID, Colour.Standard);
                    break;

                // Adds a door.
                case ConsoleKey.D:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(Door.NewDoor());
                            break;
                        case ConsoleModifiers.Shift:
                            if (CurrentGuid.Equals(Guid.Empty))
                                throw new ApplicationException("Generate a new Guid using F4");
                            SetTile(Door.NewDoor(CurrentGuid));
                            break;
                    }

                    break;


                #region Out of Doors Tiles

                /// water
                case ConsoleKey.W:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(TileType.Water, Symbols.ALMOST_EQUAL, Colour.Ocean);
                            break;
                        case ConsoleModifiers.Control:
                            bool water = Graphics.MessageBox.YesNo("Are you Sure?");
                            if (water)
                            {
                                clrScreen(TileType.Water, Symbols.ALMOST_EQUAL, Colour.Ocean);
                            }
                            break;
                    }
                    break;

                // road
                case ConsoleKey.R:
                    SetTile(TileType.Road, Symbols.FILL_LIGHT, Colour.Road);
                    break;

                // tree.
                case ConsoleKey.T:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(TileType.Tree, 'T', Colour.CurrentColour);
                            break;

                        // Add a spike pit.
                        case ConsoleModifiers.Shift:
                            SetTile(new TrapSpikePit());
                            break;

                            
                    }
                    break;
                // mountain
                case ConsoleKey.M:
                    SetTile(TileType.Mountain, '^', Colour.Mountain);
                    break;

                // home
                case ConsoleKey.H:
                    SetTile(TileType.Home, '⌂', Colour.CurrentColour);
                    break;

                // gress
                case ConsoleKey.G:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(TileType.Grass, Symbols.FILL_LIGHT, Colour.Grass);
                            break;
                        case ConsoleModifiers.Shift:
                            SetTile(TileType.Grave, Symbols.SMALL_T, Colour.Grave);
                            break;
                        case ConsoleModifiers.Control:
                            bool grass = Graphics.MessageBox.YesNo("Are you Sure?");
                            if (grass)
                            {
                                clrScreen(TileType.Grass, Symbols.FILL_LIGHT, Colour.Grass);
                            }
                            break;
                    }
                    break;

                // WARNING: Experimental.
                case ConsoleKey.D1:
                    {
                        IDungeonGenerator g = new DungeonGeneratorRecursiveDescent(CurrentMap);
                        g.Generate(0);
                        CurrentMap.DungeonRenderer.HardRefresh(CurrentLocation);
                        break;
                    }

                // bridge horizontal, bridge vertical
                case ConsoleKey.B:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(TileType.Bridge, '■', Colour.Bridge);
                            break;
                        case ConsoleModifiers.Shift:
                            SetTile(TileType.Bridge, '▌', Colour.Bridge);
                            break;
                    }
                    break;

                // Frieldly, fountain
                case ConsoleKey.F:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(TileType.Field, Symbols.FILL_LIGHT, Colour.Field);
                            break;
                        case ConsoleModifiers.Shift:
                            SetTile(TileType.Fountain, Symbols.FUNCTION, Colour.Fountain);
                            break;
                    }
                    break;

                #endregion

                #endregion
            }
        }

        /// <summary>
        /// Clears the screen with specified tile
        /// </summary>
        static void clrScreen(TileType tileType, char symbol, Colour color)
        {
            Location3i tmpLocation = new Location3i(0, 0, CurrentLocation.D);

            // Fill entire map with tileType
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    tmpLocation.X = j;
                    tmpLocation.Y = i;

                    SetTile(tileType, symbol, color, tmpLocation);
                }
            }
        }

        /// <summary>
        /// Sets an item at the current location.
        /// </summary>
        /// <param name="aItem">The item to set in the current location.</param>
        static void SetItem(IItem aItem)
        {
            // that'll do
            CurrentMap.GetTile(CurrentLocation)
                .Items.Push(aItem);
        }

        /// <summary>
        /// Spawns the passed monster at the current location.
        /// </summary>
        /// <param name="m">The monster to spawn.</param>
        /// <exception cref="ArgumentNullException">Monster must be valid.</exception>
        static void SetMonster(Monster m)
        {
            // satisfy preconditions.
            if (m == null)
                throw new ArgumentNullException("Monster cannot be null.");
            else if (m.Stats == null)
                throw new ArgumentNullException("Monster stats cannot be null.");

            // This is the part that needed to be abstracted away from callers.
            m.Location = CurrentLocation;

            // Spawn the NPC in this map.
            CurrentMap.SpawnNPC(m);
        }

        /// <summary>
        /// ProcessItemModeCommands
        /// </summary>
        /// <param name="input">The input</param>
        static void ProcessItemModeCommands(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                // lock box
                case ConsoleKey.L:
                    break;
                case ConsoleKey.G:
                    int intGoldAmount = 0;
                    Input.GetInt(out intGoldAmount);
                    SetItem(new Currency(intGoldAmount));
                    break;
                case ConsoleKey.S:
                    int intSilverAmount = 0;
                    Input.GetInt(out intSilverAmount);
                    SetItem(new Currency(intSilverAmount, CurrencyModifier.SILVER));
                    break;
                case ConsoleKey.C:
                    int intCopperAmount = 0;
                    Input.GetInt(out intCopperAmount);
                    SetItem(new Currency(intCopperAmount, CurrencyModifier.COPPER));
                    break;
#if DEBUG

                // WARNING: Experimental
                // WARNING: Experimental
                // WARNING: Experimental
                // WARNING: Experimental
                // WARNING: Experimental


                // TODO: Remove this
                case ConsoleKey.H:
                    {
                        if (input.Modifiers.HasFlag(ConsoleModifiers.Shift))
                        {
                            SetItem(
                            Dice.RandomChoice<IArmour>(new IArmour[] 
                        {
                            new ChestpieceOfDebugging(CurrentLocation),
                            new GauntletsOfBane(CurrentLocation),
                            new GauntletsOfWisdom(CurrentLocation),
                        })
                            );
                        }
                        else
                        {
                            SetItem(Dice.RandomChoice<IWeapon>(new IWeapon[] 
                            {
                                new ShortswordOfRending(CurrentLocation),
                                new ShortswordOfTheBear(CurrentLocation)
                            }));
                        }

                        break;
                    }
#endif
                // Add a new potion, use menu to determine exactly which one.
                case ConsoleKey.P:
                    {
                        Menu mPotion = new Menu("Select Potion Type",
                            new[]
                            {
                                new Menu.MenuAction() 
                                {
                                    Name = "Light Healing Potion",
                                    MAction = delegate(object argv)
                                    {
                                        SetItem(new HealthPotion(PotionStrength.Light));
                                    },
                                    MenuActionFilter = (i => i.Key.Equals(ConsoleKey.D1)),
                                },
                                new Menu.MenuAction() 
                                {
                                    Name = "Minor Healing Potion",
                                    MAction = delegate(object argv)
                                    {
                                        SetItem(new HealthPotion(PotionStrength.Minor));
                                    },
                                    MenuActionFilter = (i => i.Key.Equals( ConsoleKey.D2)),
                                },
                                new Menu.MenuAction() 
                                {
                                    Name = "Elixer of Strength",
                                    MAction = delegate(object argv)
                                    {
                                        SetItem(new ElixerOfOgreStrength(PotionStrength.Strong));
                                    },
                                    MenuActionFilter = (i => i.Key == ConsoleKey.D0),
                                },
                                new Menu.MenuAction() 
                                {
                                    Name = "Strong Healing Potion",
                                    MAction = delegate(object argv)
                                    {
                                        SetItem(new HealthPotion(PotionStrength.Strong));
                                    },
                                    MenuActionFilter = (i => i.Key == ConsoleKey.D3),
                                },
                                new Menu.MenuAction() 
                                {
                                    Name = "Greater Healing Potion",
                                    MAction = delegate(object argv)
                                    {
                                        SetItem(new HealthPotion(PotionStrength.Greater));
                                    },
                                    MenuActionFilter = (i => i.Key == ConsoleKey.D4),
                                },
                                new Menu.MenuAction() 
                                {
                                    Name = "Super Healing Potion",
                                    MAction = delegate(object argv)
                                    {
                                        SetItem(new HealthPotion(PotionStrength.Super));
                                    },
                                    MenuActionFilter = (i => i.Key == ConsoleKey.D4),
                                },
                            });
                        mPotion.Show(1, 1);
                        mPotion.Exec(null);
                        UI.Graphics.Display.Refresh(
                            CurrentMap, CurrentLocation);
                        break;
                    }
                case ConsoleKey.K:
                    if (CurrentGuid.Equals(Guid.Empty))
                        throw new ApplicationException("Generate a new Guid using F4");
                    SetItem(new Key(CurrentGuid));
                    break;
            }
        }



        /// <summary>
        /// ProcessMonsterModeCommands
        /// </summary>
        /// <param name="input">The input</param>
        static void ProcessMonsterModeCommands(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.Insert:
                    {
                        DisplayRegion tmpDisplayRegion = new DisplayRegion(0, 0, 0, 0);
                        Monster mSelected = null;

                        int maxLen = 0;
                        int maxListLen = 0;
                        int maxListCount = 0;

                        //storage for intermediate, modifiable string.
                        string strCat = string.Empty;

                        // Read the console key, prior to entering while loop.
                        var k = Console.ReadKey(true);

                        // When enter is not pressed keep collecting keychars.
                        while (k.Key != ConsoleKey.Enter)
                        {
                            string tmpPadding = string.Empty;
                            for (int c = 0; c < maxListLen; ++c)
                                tmpPadding += " ";
                            for (int ix = 1; ix <= maxListCount + 1; ++ix)
                            {
                                UI.Graphics.CursorToLocation(1, ix);
                                Console.Write(tmpPadding);
                            }

                            if (char.IsLetter(k.KeyChar) || k.KeyChar.Equals(' '))
                            {
                                strCat += k.KeyChar;

                                // find an intermediate list of monsters that meet the selection criteria.
                                var tmpList = Monsters.Where<Monster>(
                                    x => x.Name.Contains(strCat));

                                int index = 2;
                                if (tmpList.Count() > 0)
                                {
                                    if (tmpList.Count() > maxListCount)
                                        maxListCount = tmpList.Count();

                                    // Index through tmp list, maintain index for position.
                                    foreach (var m in tmpList)
                                    {
                                        if (index == 2) mSelected = m;

                                        /// bring the cursor to the next menu place down, then write the 
                                        /// monsters level and monsters name separated by :: 
                                        string tmpListing = string.Format(
                                            "{0}. {1} :: {2}", index - 1, m.Level, m.Name);
                                        if (tmpListing.Length > maxListLen)
                                            maxListLen = tmpListing.Length;

                                        UI.Graphics.CursorToLocation(1, index);
                                        Console.Write(tmpListing);

                                        // increment index, for next line.
                                        index++;
                                    }
                                }
                            }
                            else
                            {
                                if (k.Key == ConsoleKey.Backspace)
                                {
                                    if (strCat.Length > 0)
                                        strCat = strCat.Remove(strCat.Length - 1);
                                }
                                else if (k.Key == ConsoleKey.Escape)
                                    return;
                            }

                            // record the maximal length.
                            if (strCat.Length > maxLen)
                                maxLen = strCat.Length;

                            string tmpPaddingOuter = string.Empty;
                            UI.Graphics.CursorToLocation(1, 1);
                            for (int c = 0; c < maxLen; ++c)
                                tmpPaddingOuter += " ";
                            Console.Write(tmpPaddingOuter);

                            UI.Graphics.CursorToLocation(1, 1);
                            Console.Write(strCat);

                            Console.Write(maxListCount);

                            k = Console.ReadKey();
                        }

                        // Update the second point of the region to include maximal values.
                        tmpDisplayRegion.P2 = new Location2i(maxListLen + 1, maxListCount + 2);

                        // Refresh the buffered region where all our olde junk is.
                        CurrentMap.DungeonRenderer.RefreshBufferedRegion(CurrentLocation,
                            tmpDisplayRegion);

                        // spawn the top monster on the list when the user pressed enter.
                        // this needs to be a copy, otherwise the single reference is retained throughout.
                        if (mSelected != null)
                            SetMonster(Util.DeepCopy<Monster>(mSelected));

                        // hold on a second.
                        Thread.Sleep(100);
                    }
                    break;
                case ConsoleKey.N:
                    UI.Graphics.CursorToLocation(1, 1);
                    Console.WriteLine("Create Monster");
                    Thread.Sleep(100);
                    Monster tmpNewMonster = new Monster()
                    {
                        Name = Input.GetString("Name"),
                        Stats = Input.ReadStats(),
                        G = Input.GetChar("Glyph: "),
                        C = Input.GetColour(),
                    };

                    #region Preview Monster
                    // Quick display of the monster just created.
                    var saveColour = Colour.CurrentColour;
                    UI.Graphics.CursorToLocation(1, 1);
                    Console.Write("Created Monster: ");
                    tmpNewMonster.C.Set();
                    Console.Write(tmpNewMonster.G);
                    saveColour.Set();
                    Thread.Sleep(100);
                    #endregion

                    // assert that monster list exists.
                    if (Monsters == null)
                        Monsters = new List<Monster>();

                    #region Make sure the monster has not already been created.
                    var mExists = Monsters.Where(
                        x => x.Name.Equals(tmpNewMonster.Name, StringComparison.OrdinalIgnoreCase));
                    if (mExists.Count() > 0)
                        throw new DNHackException(
                            string.Format("The monster \"{0}\" already exists in the beastiary!", tmpNewMonster.Name));
                    #endregion

                    Monsters.Add(tmpNewMonster);
                    Monsters.Write(R.MonsterFile);
                    break;
            }
        }
    }
}
