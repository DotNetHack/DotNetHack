using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ConsoleApplication58
{
    /// <summary>
    /// The entry point for DotNetHack
    /// </summary>
    public static class EntryPoint
    {
        static void Main(string[] args)
        {
            const string cTempMainPak = "Main.pak";

            new Engine(cTempMainPak).Run();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class Editor
    {
        /// <summary>
        /// Gets or sets the engine.
        /// </summary>
        /// <value>
        /// The engine.
        /// </value>
        public Engine Engine { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Editor"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public Editor(Engine engine)
        {
            Engine = engine;
        }


        /// <summary>
        /// Opens the specified map identifier.
        /// </summary>
        /// <param name="mapId">The map identifier.</param>
        public void Open(string mapId)
        {
            var m = Engine.Package.Maps[mapId];

            var location = Location.Origin;

            var currentTileId = "Grass";

            var done = false;

            Engine.EditMode = true;

            while (!done)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(location);

                var k = Console.ReadKey(true);
                done = k.Key == ConsoleKey.Escape;

                var skip = false;

                foreach (var tileDef in Engine.Package.TileSet.Where(s => s.EditorCommand != null))
                {
                    if (tileDef.EditorCommand.ConsoleKey == k.Key && tileDef.EditorCommand.Modifiers == k.Modifiers)
                    {
                        currentTileId = tileDef.Id;

                        m[location.X, location.Y, location.Z] = currentTileId;

                        skip = true;

                        break;
                    }
                }

                if (skip)
                {
                    var t0 = Engine.Package.TileSet[currentTileId];

                    Console.SetCursorPosition(location.X, location.Y);

                    if (t0 != null)
                    {
                        Console.ForegroundColor = t0.Glyph.FG;
                        Console.BackgroundColor = t0.Glyph.BG;
                        Console.Write(t0.Glyph.G);
                    }
                    else
                    {
                        Console.Write(' ');
                    }

                    continue;
                }

                var yOffset =
                    k.Key == ConsoleKey.UpArrow ? -1 :
                    k.Key == ConsoleKey.DownArrow ? 1 : 0;

                var xOffset =
                    k.Key == ConsoleKey.LeftArrow ? -1 :
                    k.Key == ConsoleKey.RightArrow ? 1 : 0;

                var zOffset =
                    k.Key == ConsoleKey.PageUp ? -1 :
                    k.Key == ConsoleKey.PageDown ? 1 : 0;

                location.Offset(xOffset, yOffset, zOffset);

                Console.SetCursorPosition(location.X, location.Y);

                var t1 = Engine.Package.TileSet[m[location.X, location.Y, location.Z]];

                if (t1 != null)
                {
                    Console.ForegroundColor = t1.Glyph.FG;
                    Console.BackgroundColor = t1.Glyph.BG;
                    Console.Write(t1.Glyph.G);
                }
                else
                {
                    Console.Write(' ');
                }

                if (zOffset != 0) Console.Clear();
            }

            Console.SetCursorPosition(1, 1);
            Console.Write("Saved " + Engine.FileName);
            Engine.Package.Save(Engine.FileName);
            Console.SetCursorPosition(1, 1);

            Engine.EditMode = false;
        }
    }

    /// <summary>
    /// Map
    /// </summary>
    public class Map
    {
        /// <summary>
        /// The _tiles
        /// </summary>
        private readonly Tile[,,] _tiles;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="mapDef">The map definition.</param>
        public Map(MapDef mapDef)
        {
            Id = mapDef.Id;

            _tiles = new Tile[Width = mapDef.Width, Height = mapDef.Height, Depth = mapDef.Depth];
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; }

        /// <summary>
        /// Gets the depth.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        public int Depth { get; }

        /// <summary>
        /// Gets or sets the <see cref="Tile"/> with the specified x.
        /// </summary>
        /// <value>
        /// The <see cref="Tile"/>.
        /// </value>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <returns></returns>
        public Tile this[int x, int y, int z]
        {
            get { return _tiles[x, y, z]; }
            set { _tiles[x, y, z] = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Tile"/> with the specified location.
        /// </summary>
        /// <value>
        /// The <see cref="Tile"/>.
        /// </value>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public Tile this[ILocation location]
        {
            get { return this[location.X, location.Y, location.Z]; }
            set { this[location.X, location.Y, location.Z] = value; }
        }
    }

    /// <summary>
    /// Item
    /// </summary>
    public class Item : Id
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="itemDef">The item definition.</param>
        public Item(ItemDef itemDef)
        {
            Id = itemDef.Id;
            Glyph = itemDef.Glyph;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>
        /// The glyph.
        /// </value>
        public Glyph Glyph { get; set; }
    }

    /// <summary>
    /// Tile
    /// </summary>
    public class Tile : Id
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="tileDef">The tile definition.</param>
        public Tile(TileDef tileDef)
        {
            Id = tileDef.Id;
            Glyph = tileDef.Glyph;

            var attrIsPassable = tileDef.Attributes.SingleOrDefault(s => s.Name == "IsPassable");

            if (attrIsPassable != null)
            {
                IsPassable = (bool)attrIsPassable.Value;
            }
            else
            {
                IsPassable = true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is passable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is passable; otherwise, <c>false</c>.
        /// </value>
        public bool IsPassable { get; }

        /// <summary>
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>
        /// The glyph.
        /// </value>
        public Glyph Glyph { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public Stack<Item> Items { get; set; } = new Stack<Item>();
    }

    /// <summary>
    /// Actor
    /// </summary>
    public class Actor : IHasLocation
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Location Location { get; set; }
    }

    /// <summary>
    /// Engine
    /// </summary>
    public sealed class Engine
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public Engine(string fileName)
        {
            FileName = fileName;
            Package = Package.Load(fileName);
            Editor = new Editor(this);
        }

        /// <summary>
        /// Gets or sets the editor.
        /// </summary>
        /// <value>
        /// The editor.
        /// </value>
        public Editor Editor { get; set; }

        /// <summary>
        /// Gets or sets the package.
        /// </summary>
        /// <value>
        /// The package.
        /// </value>
        public Package Package { get; set; }

        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public Map Map { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        public Display Display { get; set; } = new Display(Console.WindowWidth - 1, Console.WindowHeight - 1);

        /// <summary>
        /// Gets or sets the map identifier.
        /// </summary>
        /// <value>
        /// The map identifier.
        /// </value>
        public string MapId { get; set; } = "M0";

        /// <summary>
        /// Loads the map.
        /// </summary>
        /// <param name="mapId">The map identifier.</param>
        public void LoadMap(string mapId)
        {
            MapDef mapDef = Package.Maps[MapId];

            Player.Location = mapDef.StartLocation;

            Map = new Map(mapDef);

            for (var x = 0; x < Map.Width; x++)
            {
                for (var y = 0; y < Map.Height; y++)
                {
                    for (var z = 0; z < Map.Depth; z++)
                    {
                        var tmpLoc = new Location(x, y, z);

                        var mapTile = mapDef.Get(tmpLoc);

                        if (mapTile == null) continue;

                        var tileDef = Package.TileSet[mapTile.TileId];

                        if (tileDef != null)
                        {
                            Map[tmpLoc] = new Tile(tileDef);

                            foreach (var itemId in mapTile.Items)
                            {
                                var itemDef = Package.Items[itemId];

                                Map[tmpLoc].Items.Push(new Item(itemDef));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        public Actor Player { get; set; } = new Actor();

        /// <summary>
        /// Gets or sets a value indicating whether [edit mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [edit mode]; otherwise, <c>false</c>.
        /// </value>
        public bool EditMode { get; set; }

        /// <summary>
        /// Run
        /// </summary>
        public void Run()
        {
            LoadMap(MapId);

            ThreadPool.QueueUserWorkItem(KeyboardCallback);

            while (!done)
            {
                DisplayMap();
                DisplayPlayer();
                Display.Render();

                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// The keyboard callback for the game engine
        /// </summary>
        /// <param name="state">The state object for the callback</param>
        private void KeyboardCallback(object state)
        {
            while (!done)
            {
                if (EditMode) continue;

                var input = Console.ReadKey(true);

                var tmpLocation = Player.Location;

                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                    case ConsoleKey.UpArrow:
                        tmpLocation = Player.Location.Offset(0, -1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        tmpLocation = Player.Location.Offset(0, 1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                        tmpLocation = Player.Location.Offset(-1, 0, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        tmpLocation = Player.Location.Offset(1, 0, 0);
                        break;
                    case ConsoleKey.F5:
                        Editor.Open(MapId);
                        break;
                }

                if (Map[tmpLocation].IsPassable)
                {
                    Player.Location = tmpLocation;
                }
            }
        }

        /// <summary>
        /// Displays the player.
        /// </summary>
        private void DisplayPlayer()
        {
            Display[Player.Location.X, Player.Location.Y] = new Glyph('@', ConsoleColor.White, ConsoleColor.Black);
        }

        /// <summary>
        /// Displays the map.
        /// </summary>
        private void DisplayMap()
        {
            for (var x = 0; x < Map.Width; x++)
            {
                for (var y = 0; y < Map.Height; y++)
                {
                    var tmp = Map[x, y, 0];

                    if (tmp != null)
                    {
                        if (tmp.Items.Any())
                        {
                            var topItem = tmp.Items.Peek();

                            Display[x, y] = topItem.Glyph;

                            continue;
                        }

                        Display[x, y] = tmp.Glyph;
                    }
                }
            }
        }

        /// <summary>
        /// The done boolean
        /// </summary>
        private bool done = false;
    }

    /// <summary>
    /// Display
    /// </summary>
    public sealed class Display
    {
        /// <summary>
        /// The stopwatch for recording rendering times
        /// </summary>
        private readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; }

        /// <summary>
        /// The _current buffer
        /// </summary>
        private DisplayBuffer _current;

        /// <summary>
        /// The offscreen buffer
        /// </summary>
        private DisplayBuffer _offScreen;

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Display(int width, int height)
        {
            Width = width;
            Height = height;
            _current = new DisplayBuffer(width, height);
            _offScreen = new DisplayBuffer(width, height);

#if DEBUG
            _stopwatch.Start();
#endif
        }

        /// <summary>
        /// Renders the contents of the display buffer
        /// </summary>
        public void Render()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    if (_current[x, y] == _offScreen[x, y])
                    {
                        continue;
                    }

                    Console.SetCursorPosition(x, y);

                    var glyph = _current[x, y];
                    Console.ForegroundColor = glyph.FG;
                    Console.BackgroundColor = glyph.BG;
                    Console.Write(glyph.G);
                }
            }

            SwapBuffers();

#if _DEBUG
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("FPS: " + ++_ticks / _stopwatch.Elapsed.TotalSeconds + "    ");
#endif
        }

        /// <summary>
        /// Swaps the buffers.
        /// </summary>
        private void SwapBuffers()
        {
            var tmp = _current;
            _current = _offScreen;
            _offScreen = tmp;
        }

        /// <summary>
        /// Gets or sets the <see cref="Glyph"/> with the specified x.
        /// </summary>
        /// <value>
        /// The <see cref="Glyph"/>.
        /// </value>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Glyph this[int x, int y]
        {
            get { return _current[x, y]; }
            set { _current.Set(x, y, value); }
        }
    }

    /// <summary>
    /// A display buffer
    /// </summary>
    public struct DisplayBuffer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayBuffer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public DisplayBuffer(int width, int height)
        {
            Width = width;
            Height = height;
            Glyphs = new Glyph[width, height];
        }

        /// <summary>
        /// Gets the glyphs.
        /// </summary>
        /// <value>
        /// The glyphs.
        /// </value>
        public Glyph[,] Glyphs { get; }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; }

        /// <summary>
        /// Sets the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="glyph">The glyph.</param>
        public void Set(int x, int y, Glyph glyph)
        {
            Glyphs[x, y] = glyph;
        }

        /// <summary>
        /// Gets or sets the <see cref="Glyph"/> with the specified x.
        /// </summary>
        /// <value>
        /// The <see cref="Glyph"/>.
        /// </value>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Glyph this[int x, int y]
        {
            get { return Glyphs[x, y]; }
            set { Glyphs[x, y] = value; }
        }
    }

    [Serializable]
    public sealed class MapDef : Id
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get { return MapTiles.Max(s => s.X); } }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get { return MapTiles.Max(s => s.Y); } }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        public int Depth { get { return MapTiles.Max(s => s.Z) + 1; } }

        /// <summary>
        /// Gets or sets the start location.
        /// </summary>
        /// <value>
        /// The start location.
        /// </value>
        public Location StartLocation { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [XmlArray]
        public List<MapTile> MapTiles { get; set; }

        /// <summary>
        /// Gets the specified x.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public MapTile Get(ILocation location)
        {
            return MapTiles.SingleOrDefault(s => s.X == location.X && s.Y == location.Y && s.Z == location.Z);
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified x.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <returns></returns>
        public string this[int x, int y, int z]
        {
            get
            {
                var tmp = MapTiles.SingleOrDefault(s => s.X == x && s.Y == y && s.Z == z);

                return tmp?.TileId;
            }
            set
            {
                var tmp = MapTiles.SingleOrDefault(s => s.X == x && s.Y == y && s.Z == z);

                if (tmp != null)
                {
                    tmp.TileId = value;
                }
                else
                {
                    MapTiles.Add(new MapTile(value, x, y, z));
                }
            }
        }
    }

    [Serializable]
    public class MapTile : ILocation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapTile"/> class.
        /// </summary>
        public MapTile() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapTile"/> class.
        /// </summary>
        /// <param name="tileId">The tile identifier.</param>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="z">The z-coordinate.</param>
        public MapTile(string tileId, int x, int y, int z)
        {
            TileId = tileId;
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Gets or sets the tile identifier.
        /// </summary>
        /// <value>
        /// The tile identifier.
        /// </value>
        [XmlAttribute]
        public string TileId { get; set; }

        /// <summary>
        /// The x-coordinate
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        [XmlAttribute]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y-coordinate
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        [XmlAttribute]
        public int Y { get; set; }

        /// <summary>
        /// The z-coordinate
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        [XmlAttribute]
        public int Z { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        [XmlArray]
        public List<string> Items { get; set; }
    }

    /// <summary>
    /// EditorCommand
    /// </summary>
    [Serializable]
    public sealed class EditorCommand
    {
        /// <summary>
        /// Gets or sets the console key.
        /// </summary>
        /// <value>
        /// The console key.
        /// </value>
        [XmlAttribute]
        public ConsoleKey ConsoleKey { get; set; }

        /// <summary>
        /// Gets or sets the modifiers.
        /// </summary>
        /// <value>
        /// The modifiers.
        /// </value>
        [XmlAttribute]
        public ConsoleModifiers Modifiers { get; set; }
    }

    [Serializable]
    public class Package
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the tile set.
        /// </summary>
        /// <value>
        /// The tile set.
        /// </value>
        public TileSet TileSet { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ItemDefs Items { get; set; }

        /// <summary>
        /// Gets or sets the maps.
        /// </summary>
        /// <value>
        /// The maps.
        /// </value>
        public MapDefs Maps { get; set; }

        /// <summary>
        /// The package serializer
        /// </summary>
        private static readonly XmlSerializer packageSerializer = new XmlSerializer(typeof(Package));

        /// <summary>
        /// Saves the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void Save(string fileName)
        {
            using (var sr = new StreamWriter(File.OpenWrite(fileName)))
            {
                packageSerializer.Serialize(sr, this);
            }
        }

        /// <summary>
        /// Loads the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static Package Load(string fileName)
        {
            using (var streamReader = new StreamReader(File.OpenRead(fileName)))
            {
                return packageSerializer.Deserialize(streamReader) as Package;
            }
        }
    }

    [Serializable]
    public abstract class DefCollection<T> : List<T> where T : Id
    {
        /// <summary>
        /// Gets the <see cref="T"/> with the specified identifier.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T this[string id] => Get(id);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private T Get(string id)
        {
            return this.SingleOrDefault(s => s.Id == id);
        }
    }

    /// <summary>
    /// ItemDefs
    /// </summary>
    /// <seealso cref="ItemDef" />
    [Serializable]
    public sealed class ItemDefs : DefCollection<ItemDef> { }

    /// <summary>
    /// TileSet
    /// </summary>
    /// <seealso cref="TileDef" />
    [Serializable]
    public sealed class TileSet : DefCollection<TileDef> { }

    /// <summary>
    /// MapDefs
    /// </summary>
    /// <seealso cref="MapDef" />
    [Serializable]
    public sealed class MapDefs : DefCollection<MapDef> { }

    /// <summary>
    /// ItemDef
    /// </summary>
    /// <seealso cref="ConsoleApplication58.IDef" />
    [Serializable]
    public class ItemDef : IDef
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>
        /// The glyph.
        /// </value>
        public Glyph Glyph { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public AttributeCollection Attributes { get; set; }

        /// <summary>
        /// Gets or sets the editor command for this definition
        /// </summary>
        /// <value>
        /// The editor command.
        /// </value>
        [XmlElement]
        public EditorCommand EditorCommand { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public EventCollection Events { get; set; }

        /// <summary>
        /// Gets or sets the script block.
        /// </summary>
        /// <value>
        /// The script block.
        /// </value>
        [XmlIgnore]
        public string ScriptBlock { get; set; }

        /// <summary>
        /// Gets or sets the script block c data.
        /// </summary>
        /// <value>
        /// The script block c data.
        /// </value>
        [XmlElement("ScriptBlock")]
        public XmlCDataSection ScriptBlockCData
        {
            get { return new XmlDocument().CreateCDataSection(ScriptBlock); }
            set { ScriptBlock = value.Value; }
        }
    }

    [Serializable]
    public class TileDef : IDef
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>
        /// The glyph.
        /// </value>
        public Glyph Glyph { get; set; }
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public EventCollection Events { get; set; }
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public AttributeCollection Attributes { get; set; }

        /// <summary>
        /// Gets or sets the editor command for this definition
        /// </summary>
        /// <value>
        /// The editor command.
        /// </value>
        [XmlElement]
        public EditorCommand EditorCommand { get; set; }

        /// <summary>
        /// Gets or sets the script block.
        /// </summary>
        /// <value>
        /// The script block.
        /// </value>
        [XmlIgnore]
        public string ScriptBlock { get; set; }

        /// <summary>
        /// Gets or sets the script block c data.
        /// </summary>
        /// <value>
        /// The script block c data.
        /// </value>
        [XmlElement("ScriptBlock")]
        public XmlCDataSection ScriptBlockCData
        {
            get { return new XmlDocument().CreateCDataSection(ScriptBlock); }
            set { ScriptBlock = value.Value; }
        }
    }

    #region interfaces

    /// <summary>
    /// Id
    /// </summary>
    public interface Id
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        string Id { get; }
    }

    /// <summary>
    /// IDef
    /// </summary>
    public interface IDef : Id
    {
        /// <summary>
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>
        /// The glyph.
        /// </value>
        Glyph Glyph { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        EventCollection Events { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        AttributeCollection Attributes { get; set; }

        /// <summary>
        /// Gets or sets the editor command for this definition
        /// </summary>
        /// <value>
        /// The editor command.
        /// </value>
        EditorCommand EditorCommand { get; set; }

        /// <summary>
        /// Gets or sets the script block.
        /// </summary>
        /// <value>
        /// The script block.
        /// </value>
        string ScriptBlock { get; set; }
    }

    /// <summary>
    /// ILocation
    /// </summary>
    public interface ILocation
    {
        /// <summary>
        /// The x-coordinate
        /// </summary>
        /// <value>
        /// The x-coordinate
        /// </value>
        int X { get; }

        /// <summary>
        /// Gets the y-coordinate
        /// </summary>
        /// <value>
        /// The y-coordinate
        /// </value>
        int Y { get; }

        /// <summary>
        /// The z-coordinate
        /// </summary>
        /// <value>
        /// The z-coordinate
        /// </value>
        int Z { get; }
    }

    /// <summary>
    /// Any object that has a location
    /// </summary>
    public interface IHasLocation
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        Location Location { get; set; }
    }

    #endregion

    /// <summary>
    /// Glyph struct
    /// </summary>
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Serializable]
    public struct Glyph : IXmlSerializable, IEquatable<Glyph>
    {
        /// <summary>
        /// The empty glyph
        /// </summary>
        public static readonly Glyph Empty = new Glyph();

        /// <summary>
        /// Initializes a new instance of the <see cref="Glyph" /> struct.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="fg">The fg.</param>
        public Glyph(char g, ConsoleColor fg)
                    : this(g, fg, ConsoleColor.Black)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Glyph" /> struct.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="fg">The fg.</param>
        /// <param name="bg">The bg.</param>
        public Glyph(char g, ConsoleColor fg, ConsoleColor bg)
        {
            G = g;
            FG = fg;
            BG = bg;
        }

        /// <summary>
        /// The background color
        /// </summary>
        /// <value>
        /// The bg.
        /// </value>
        public ConsoleColor BG { get; }

        /// <summary>
        /// The foreground color
        /// </summary>
        /// <value>
        /// The fg.
        /// </value>
        public ConsoleColor FG { get; }

        /// <summary>
        /// The symbol
        /// </summary>
        /// <value>
        /// The g.
        /// </value>
        public char G { get; }

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            char g;
            char.TryParse(reader.GetAttribute("G"), out g);

            ConsoleColor fg;
            Enum.TryParse(reader.GetAttribute("FG"), out fg);

            ConsoleColor bg;
            Enum.TryParse(reader.GetAttribute("BG"), out bg);

            this = new Glyph(g, fg, bg);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("G", G.ToString());
            writer.WriteAttributeString("FG", FG.ToString());
            writer.WriteAttributeString("BG", BG.ToString());
        }

        #endregion

        #region Equality members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Glyph other)
        {
            return BG == other.BG && FG == other.FG && G == other.G;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false. 
        /// </returns>
        /// <param name="obj">The object to compare with the current instance. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is Glyph && Equals((Glyph)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)BG;
                hashCode = (hashCode * 397) ^ (int)FG;
                hashCode = (hashCode * 397) ^ G.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Glyph left, Glyph right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Glyph left, Glyph right)
        {
            return !left.Equals(right);
        }

        #endregion
    }


    [Serializable]
    public class AttributeCollection : List<Attribute> { }

    /// <summary>
    /// Attribute
    /// </summary>
    [Serializable]
    public sealed class Attribute
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [XmlElement]
        public object Value { get; set; }
    }

    [Serializable]
    public sealed class EventCollection : IXmlSerializable
    {
        private readonly Dictionary<string, string> _events
            = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified name.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public string this[string name]
        {
            get
            {
                return _events.ContainsKey(name) ?
                    _events[name] : string.Empty;
            }
            set
            {
                if (_events.ContainsKey(name))
                {
                    _events[name] = value;

                    return;
                }

                _events.Add(name, value);
            }
        }

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                _events.Add(reader.Name, reader.Value);
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            foreach (var e in _events)
            {
                writer.WriteAttributeString(e.Key, e.Value);
            }
        }

        #endregion

        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var e in _events)
            {
                sb.AppendLine($"{e.Key}:{e.Value}");
            }

            return sb.ToString();
        }

        #endregion
    }

    /// <summary>
    /// Location
    /// </summary>
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Serializable]
    public struct Location : IXmlSerializable, ILocation
    {
        #region instance fields

        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public Location(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Gets the origin.
        /// </summary>
        /// <value>
        /// The origin.
        /// </value>
        public static Location Origin { get; } = new Location();

        #region properties

        /// <summary>
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        public int Z => _z;

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y => _y;

        /// <summary>
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X => _x;

        #endregion

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            int x, y, z;

            int.TryParse(reader.GetAttribute("X"), out x);
            int.TryParse(reader.GetAttribute("Y"), out y);
            int.TryParse(reader.GetAttribute("Z"), out z);

            this = new Location(x, y, z);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("X", X.ToString());
            writer.WriteAttributeString("Y", Y.ToString());
            writer.WriteAttributeString("Z", Z.ToString());
        }

        #endregion

        #region Equality members

        public bool Equals(Location other)
        {
            return Z == other.Z && Y == other.Y && X == other.X;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false. 
        /// </returns>
        /// <param name="obj">The object to compare with the current instance. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is Location && Equals((Location)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Z;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ X;
                return hashCode;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Distances the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static double Distance(Location a, Location b)
        {
            var xSq = Math.Pow(b._x - a._x, 2);
            var ySq = Math.Pow(b._y - b._y, 2);
            var zSq = Math.Pow(b._y - b._z, 2);

            return Math.Sqrt(xSq + ySq + zSq);
        }

        /// <summary>
        /// Distances the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <returns></returns>
        public double Distance(Location a)
        {
            return Distance(this, a);
        }

        #endregion

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }

        /// <summary>
        /// Offsets the specified x offset.
        /// </summary>
        /// <param name="xOffset">The x offset.</param>
        /// <param name="yOffset">The y offset.</param>
        /// <param name="zOffset">The z offset.</param>
        public Location Offset(int xOffset, int yOffset, int zOffset)
        {
            return this = new Location(X + xOffset, Y + yOffset, Z + zOffset);
        }
    }
}

