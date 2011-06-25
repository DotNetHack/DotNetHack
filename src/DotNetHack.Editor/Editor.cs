using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using DotNetHack.UI;
using DotNetHack.Game;
using DotNetHack.Game.Items.Equipment.Weapons;
using DotNetHack.Game.Monsters;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items.Containers;
using DotNetHack.Game.Items;


namespace DotNetHack.Editor
{
    /// <summary>
    /// Editor
    /// </summary>
    class Editor
    {
        // static World World;
        static Dungeon CurrentMap;

        static int x = 1;
        static int y = 1;

        static bool done = false;

        static EditorMode Mode { get; set; }

        public enum EditorMode
        {
            World,
            Dungeon,
            DungeonLevel,
        }

        /// <summary>
        /// SetTile
        /// </summary>
        /// <param name="x">X-Coord</param>
        /// <param name="y">Y-Coord</param>
        /// <param name="aTile">The name of the tile.</param>
        public static void SetTile(int x, int y, Tile aTile)
        {
            if (aTile.C.Equals(Colour.Void))
                aTile.C = Colour.Standard;

            CurrentMap.SetMapTile(new MapTile(new Location(x, y))
            {
                C = aTile.C,
                G = aTile.G,
                TileType = aTile.TileType,
            });
        }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            UI.Graphics.MessageBox.Show("Editor", "Welcome to DotNetHack Editor!");

            Mode = EditorMode.DungeonLevel;

            Refresh();

            CurrentMap = new Dungeon(Console.WindowWidth, Console.WindowHeight - Dungeon.Y_OFFSET);

            x = 5;
            y = 5;

            while (!done)
            {
                switch (Mode)
                {
                    case EditorMode.DungeonLevel:
                        InputTrap = new InputDelTrap(DungeonLevelModeCommands);
                        break;
                    case EditorMode.Dungeon:
                        InputTrap = new InputDelTrap(DungeonLevelModeCommands);
                        break;
                    case EditorMode.World:
                        // CurrentMap = World.GetInstance();
                        InputTrap = new InputDelTrap(WorldModeCommands);
                        break;
                }

                var input = Console.ReadKey();

                InputTrap(input);


                switch (input.Key)
                {
                    default:
                        break;
                    case ConsoleKey.F9:
                        Mode = EditorMode.DungeonLevel;
                        ShowStatusMessage("Editor Mode: " + Mode + "     ");
                        break;
                    case ConsoleKey.F10:
                        Mode = EditorMode.World;
                        ShowStatusMessage("Editor Mode: " + Mode + "     ");
                        break;
                }

                Graphics.CursorToLocation(new Location(1, 1));
            }
        }

        /// <summary>
        /// InputTrap
        /// </summary>
        public static InputDelTrap InputTrap { get; set; }

        /// <summary>
        /// InputDelTrap
        /// </summary>
        /// <param name="input"></param>
        public delegate void InputDelTrap(ConsoleKeyInfo input);

        /// <summary>
        /// DungeonLevelModeCommands
        /// </summary>
        /// <param name="k"></param>
        private static void WorldModeCommands(ConsoleKeyInfo k)
        {
            switch (k.Key)
            {
                default:
                    DungeonLevelModeCommands(k);
                    break;
                case ConsoleKey.F2:
                    {
                        // World.SaveAs(Console.ReadLine()); break;
                        break;
                    }
                case ConsoleKey.F1:
                    {
                        ShowStatusMessage("Adding dungeon level"); break;
                    }
            }
        }

        /// <summary>
        /// LayoutModeCommands
        /// </summary>
        /// <param name="k"></param>
        private static void DungeonLevelModeCommands(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                case ConsoleKey.RightArrow:
                    x++;
                    break;
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                case ConsoleKey.DownArrow:
                    y++;
                    break;
                case ConsoleKey.Escape:
                    if (YesNo("Are you sure? "))
                        done = true;
                    break;
                case ConsoleKey.F2:
                    Console.SetCursorPosition(1, 1);
                    Console.Write("Save As: ");
                    CurrentMap.SaveAs(Console.ReadLine());
                    break;
                case ConsoleKey.F6:
                    Console.SetCursorPosition(1, 1);
                    Console.Write("Load: ");
                    string loadFile = Console.ReadLine();
                    if (File.Exists(loadFile))
                        if (YesNo("Are you sure you want to load " + loadFile + "? "))
                        {
                            // Refresh();
                            CurrentMap = Dungeon.Load(loadFile);
                            CurrentMap.ClearBuffer();
                        }
                    break;
                case ConsoleKey.F3:
                    if (YesNo("Are you sure? "))
                    {
                        Refresh();

                    bad_input:
                        try
                        {
                            Console.Write("Width: ");
                            int cWidth = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Height: ");
                            int cHeight = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            CurrentMap = new Dungeon(cWidth, cHeight);
                        }
                        catch { goto bad_input; }
                    }
                    break;
                case ConsoleKey.T:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        Menu.MenuAction mActionGrass = new Menu.MenuAction()
                        {
                            Action = delegate(object k) 
                            {
                                // CurrentMap
                                CurrentMap.SetAllTiles(new Tile() { 
                                    C = Colour.Grass,
                                    G = '.',
                                    TileType = TileType.GRASS,
                                });
                            },
                            ActionKey = ConsoleKey.D1,
                            Name = "Grass",
                        };

                        List<Menu.MenuAction> mActions = new List<Menu.MenuAction>();
                        mActions.Add(mActionGrass);
                        Menu m = new Menu("Clear Map With?", mActions.ToArray());
                        m.Show(5, 5);
                        m.Exec(Console.ReadKey());
                        CurrentMap.ClearBuffer();
                    }
                    else
                        SetTile(x, y, new Tile()
                        {
                            C = Colour.Grass,
                            TileType = TileType.TREE,
                            G = Symbols.TAU
                        });
                    break;
                case ConsoleKey.W:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                        SetTile(x, y, new Tile()
                        {
                            C = Colour.DeepOcean,
                            TileType = TileType.WATER,
                            G = '~',
                        });
                    else
                        SetTile(x, y, new Tile()
                        {
                            C = Colour.Ocean,
                            TileType = TileType.WATER,
                            G = '~',
                        });
                    break;
                case ConsoleKey.G:
                    {
                        if (input.Modifiers == ConsoleModifiers.Shift)
                        {
                            Console.Write("$:");
                            int gVal = int.Parse(Console.ReadLine());
                            AddSetItem(new Currency(10));
                        }
                        else
                            SetTile(x, y, new Tile()
                            {
                                C = Colour.Grass,
                                TileType = TileType.GRASS,
                                G = '.',
                            });
                        break;
                    }
                case ConsoleKey.R:
                    SetTile(x, y, new Tile()
                    {
                        C = Colour.Road,
                        TileType = TileType.ROAD,
                        G = Symbols.FILL_LIGHT,
                    });
                    break;
                case ConsoleKey.M:
                    {
                        SetTile(x, y, new Tile()
                        {
                            C = Colour.Mountain,
                            TileType = TileType.MOUNTAIN,
                            G = '^',
                        });
                        break;
                    }
                case ConsoleKey.A:
                    {
                        SetTile(x, y, new Tile()
                        {
                            C = Colour.White,
                            TileType = TileType.ALTAR,
                            G = '_',
                        });
                    }
                    break;
                case ConsoleKey.F5:
                    Dungeon d = new Dungeon(CurrentMap.Width, CurrentMap.Height);

                    // TODO: Shallow copy, IClone
                    d.MapFile = CurrentMap.MapFile;
                    d.MapData = CurrentMap.MapData;

                    //d.Monsters = CurrentMap.Monsters;
                    //d.RenderBuffer = CurrentMap.RenderBuffer;

                    ShowStatusMessage(string.Format("Running {0}", d));
                    GameEngine g = new GameEngine(new Player("Editor", new Location(x, y)), d);
                    g.Run(GameEngine.EngineRunFlags.EDITOR | GameEngine.EngineRunFlags.DEBUG);
                    x = g.Player.Location.X;    // Drop in to last location.
                    y = g.Player.Location.Y;    // Drop in to last location.
                    CurrentMap.ClearBuffer();

                    break;
                case ConsoleKey.L:
                    {



                        break;
                    }
                case ConsoleKey.D1:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_HORIZONTAL,
                                TileType = TileType.WALL,
                            });
                            break;
                        case ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_VERTICAL,
                                TileType = TileType.WALL,
                            });
                            break;
                        case ConsoleModifiers.Control:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_HORIZONTAL,
                                TileType = TileType.WALL,
                            });
                            break;
                        case ConsoleModifiers.Control | ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_VERTICAL,
                                TileType = TileType.WALL,
                            });
                            break;
                    } break;
                case ConsoleKey.D2:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_BOTTOM_LEFT,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_BOTTOM_RIGHT,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Control:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_BOTTOM_LEFT,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Control | ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_BOTTOM_RIGHT,
                                TileType = TileType.WALL,
                            }); break;
                    } break;
                case ConsoleKey.D3:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_TOP_RIGHT,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_TOP_LEFT,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Control:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_TOP_RIGHT,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Control | ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_TOP_LEFT,
                                TileType = TileType.WALL,
                            }); break;
                    }
                    break;
                case ConsoleKey.D4:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_4_WAY,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_4_WAY_JUNCTION,
                                TileType = TileType.WALL,
                            }); break;
                    } break;
                case ConsoleKey.F:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                        SetTile(x, y, new Tile()
                        {
                            G = Symbols.FILL_LIGHT,
                            TileType = TileType.FIELD,
                            C = Colour.Field,
                        });
                    else
                        SetTile(x, y, new Tile()
                        {
                            G = Symbols.FUNCTION,
                            TileType = TileType.FOUNTAIN,
                            C = Colour.Fountain,
                        });

                    break;
                case ConsoleKey.D5:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_TOP_T_JUNC,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_BOT_T_JUNC,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Control:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_HORIZONTAL_DOWN_JUNCTION,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Control | ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_HORIZONTAL_UP_JUNCTION,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Alt | ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBLSGL_BOT_JUNC,
                                TileType = TileType.WALL,
                            }); break;
                        case ConsoleModifiers.Alt | ConsoleModifiers.Control:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBLSGL_TOP_JUNC,
                                TileType = TileType.WALL,
                            }); break;
                    } break;
                case ConsoleKey.D6:
                    switch (input.Modifiers)
                    {
                        default:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_V_RIGHT_JUNC,
                                TileType = TileType.WALL,
                            });
                            break;
                        case ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_DBL_V_LEFT_JUNC,
                                TileType = TileType.WALL,
                            });
                            break;
                        case ConsoleModifiers.Control:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_VERTICAL_RIGHT_JUNCTION,
                                TileType = TileType.WALL,
                            });
                            break;
                        case ConsoleModifiers.Control | ConsoleModifiers.Shift:
                            SetTile(x, y, new Tile()
                            {
                                G = Symbols.W_THIN_VERTICAL_LEFT_JUNCTION,
                                TileType = TileType.WALL,
                            });
                            break;
                    } break;
                case ConsoleKey.OemPeriod:
                    SetTile(x, y, new Tile()
                    {
                        G = '.',
                        TileType = TileType.FLOOR,
                    }); break;
            }

            if (x < 0)
                x++;
            if (y < 0)
                y++;
            if (x >= CurrentMap.Width)
                x--;
            if (y >= CurrentMap.Height)
                y--;

            Location lNewLocation = new Location(x, y);

#if DEBUG
            ShowStatusMessage(new Location(x, y).ToString());
#endif
            CurrentMap.Render(new Location(x, y));
            Graphics.CursorToLocation(x, y);
            Console.Write('#');
        }


        /*
        /// <summary>
        /// QuestModeCommands
        /// </summary>
        /// <param name="input"></param>
        private static void QuestModeCommands(ConsoleKeyInfo input)
        {

        }*/

        /*
        /// <summary>
        /// MonsterModeCommands
        /// </summary>
        /// <param name="k"></param>
        private static void MonsterModeCommands(ConsoleKeyInfo k)
        {
            Menu m = new Menu("Select Monster", new Menu.MenuAction[] 
            {
                new Menu.MenuAction()
                {
                    Action = new Menu.MAction( delegate(object o)
                        {
                            AddSetMonster(new Monster("Orc",'O', new Location(x, y)));
                        }),
                    ActionKey = ConsoleKey.O,
                    Name = "Orc",
                },
            });

            m.Show(5, 5);
            m.Exec(k);
        }*/

        public static void AddSetItem(IItem item)
        {

            //CurrentMap.Items.Add(item);
        }

        public static void AddSetMonster(Monster aMonster)
        {
            //CurrentMap.Monsters.Add(aMonster);
        }

        /*
        /// <summary>
        /// TrapModeCommands
        /// </summary>
        /// <param name="k"></param>
        private static void TrapModeCommands(ConsoleKeyInfo k)
        {

        }

        /// <summary>
        /// ItemModeCommands
        /// </summary>
        /// <param name="k"></param>
        private static void ItemModeCommands(ConsoleKeyInfo k)
        {

        }*/

        private static void Refresh()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        /// <summary>
        /// ShowStatusMessage
        /// </summary>
        /// <param name="aMessage">status message</param>
        private static void ShowStatusMessage(string aMessage)
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 2);
            Console.WriteLine(aMessage);
        }

        /// <summary>
        /// YesNo
        /// </summary>
        /// <param name="aMessage"></param>
        /// <returns></returns>
        public static bool YesNo(string aMessage = "")
        {
            const string YES_NO = " [Y/N]: ";
            Console.Write(aMessage + YES_NO);
            int x_loc = Console.CursorLeft;
            int y_loc = Console.CursorTop;
        redo:
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.Y:
                    return true;
                case ConsoleKey.N:
                    return false;
                default:
                    Console.SetCursorPosition(x_loc, y_loc);
                    goto redo;
            }
        }
    }
}
