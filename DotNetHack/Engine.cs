using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using DotNetHack.Core;
using DotNetHack.Definitions;
using DotNetHack.GUI;
using DotNetHack.Tools;

namespace DotNetHack
{
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
            TileFactory = new TileFactory(this);
        }

        public TileFactory TileFactory { get; }

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

                        Map[tmpLoc] = TileFactory.Get(mapTile.TileId);

                        foreach (var itemId in mapTile.Items)
                        {
                            var itemDef = Package.Items[itemId];

                            Map[tmpLoc].Items.Push(new Item(itemDef));
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
            ScriptEngine.Compile(this);
            
            LoadMap(MapId);

            ThreadPool.QueueUserWorkItem(KeyboardCallback);

            while (!_done)
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
            while (!_done)
            {
                if (EditMode) continue;

                var input = Console.ReadKey(true);

                var tmpLocation = Player.Location;

                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        _done = true;
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

                    Map[tmpLocation].Enter(Player);
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
        private bool _done;
    }

    public abstract class ObjectFactory<TDef, TObj> where TDef : IDef where TObj : class
    {
        /// <summary>
        /// The definitions that this object factory will use to build the objects.
        /// </summary>
        private readonly IdCollection<TDef> _definitions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFactory{TDef, TObj}"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="definitions">The definitions.</param>
        protected ObjectFactory(Engine engine, IdCollection<TDef> definitions)
        {
            _definitions = definitions;
            Engine = engine;
        }

        /// <summary>
        /// Gets the engine.
        /// </summary>
        /// <value>
        /// The engine.
        /// </value>
        public Engine Engine { get; }

        /// <summary>
        /// Gets the specified object identifier.
        /// </summary>
        /// <param name="objId">The object identifier.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">missing .ctor</exception>
        public TObj Get(string objId)
        {
            var def = _definitions[objId];

            var objType = typeof(TObj);
            var ctor = objType.GetConstructor(new[] { typeof(TDef) });
            if (ctor == null) throw new InvalidOperationException("missing .ctor");
            var obj = ctor.Invoke(new object[] { def });

            if (def.Events != null)
            {
                foreach (var e in def.Events)
                {
                    var objEvent = objType.GetEvent(e.Key);
                    Type tDelegate = objEvent.EventHandlerType;
                    MethodInfo miHandler = ScriptEngine.ScriptContext.GetType()
                        .GetMethod(e.Value, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                    Delegate d = Delegate.CreateDelegate(tDelegate, ScriptEngine.ScriptContext, miHandler);
                    MethodInfo addHandler = objEvent.GetAddMethod();
                    addHandler.Invoke(obj, new object[] {d});
                }
            }

            return obj as TObj;
        }
    }

    /// <summary>
    /// The <see cref="TileFactory"/> supports creating tiles on the fly.
    /// </summary>
    /// <seealso>
    ///     <cref>DotNetHack.ObjectFactory{DotNetHack.Definitions.TileDef, DotNetHack.Core.Tile}</cref>
    /// </seealso>
    public sealed class TileFactory : ObjectFactory<TileDef, Tile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TileFactory"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public TileFactory(Engine engine)
            : base(engine, engine.Package.TileSet)
        { }
    }
}