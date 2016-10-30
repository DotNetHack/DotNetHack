using System;
using System.Linq;

namespace DotNetHack.Tools
{
    /// <summary>
    /// Editor
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
}