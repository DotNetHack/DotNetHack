using System;

using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


using DotNetHack.Game.Interfaces;
using System.Xml.Serialization;

namespace DotNetHack.Game
{
    /// <summary>
    /// DungeonExtensions
    /// </summary>
    public static class DungeonExtensions
    {
        /// <summary>
        /// SaveAs
        /// </summary>
        public static bool SaveAs(this Dungeon aLevel, string aMapFile)
        {
            try
            {
                // Create a new binary formatter
                BinaryFormatter binFormatter = new BinaryFormatter();

                using (FileStream tmpRawStream = File.Open(aMapFile, FileMode.CreateNew))
                    binFormatter.Serialize(tmpRawStream, aLevel);

                return true;
            }
            catch { return false; }
            finally { aLevel.MapFile = aMapFile; }
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="aLevel"></param>
        /// <returns></returns>
        public static bool Save(this Dungeon aLevel)
        {
            return aLevel.SaveAs(aLevel.MapFile);
        }
    }

    [Serializable]
    public class Dungeon
    {
        public Dungeon() { }

        public Dungeon(int w, int h)
        {
            Width = w;
            Height = h - Y_OFFSET;

            MapData = new MapTile[w, h];
            RenderBuffer = new MapTile[w, h];

            IterXY(delegate(int x, int y)
            {
                char xx = '.';

                if (h == 0)
                    xx = '0';
                if (w == 0)
                    xx = '0';

                if (h == UI.Graphics.ScreenCenter.Y)
                    xx = 'Y';
                if (w == UI.Graphics.ScreenCenter.X)
                    xx = 'X';

                if (x == Width - 5)
                    xx = 'W';
                if (y == Height - 5)
                    xx = 'H';

                MapData[x, y] = new MapTile(new Location(x, y))
                {
                    TileType = TileType.FLOOR,
                    C = Colour.Standard,
                    G = xx,
                };

                RenderBuffer[x, y] = new MapTile(x, y)
                {
                    G = ' ',
                };
            });
        }

        public void Render(Location l)
        {
            IterXY(delegate(int x, int y)
            {
                if (RenderBuffer[x, y].G != MapData[x, y].G)
                {
                    UI.Graphics.CursorToLocation(x, y);
                    MapData[x, y].C.Set();
                    Console.Write(MapData[x, y].G);
                    RenderBuffer[x, y].G = MapData[x, y].G;
                    UI.Graphics.CursorToLocation(x, y);
                }
            });

            RenderBuffer[l.X, l.Y].G = '\0';
        }

        void IterXY(IterMapTiles aMapIterator)
        {
            for (int x = 0; x < Width - 1; ++x)
                for (int y = 0; y < Height - 1; ++y)
                    aMapIterator(x, y);
        }

        delegate void IterMapTiles(int x, int y);

        public void SetMapTile(MapTile aMapTile) { MapData[aMapTile.Location.X, aMapTile.Location.Y] = aMapTile; }

        public Tile GetTile(Location aLocation) { return GetTile(aLocation.X, aLocation.Y); }

        public Tile GetTile(int x, int y) { return (Tile)MapData[x, y]; }

        public bool CheckBounds(Location l) 
        {
            return (l.X > 0 && l.Y > 0 && l.X < Width && l.Y < Height);
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public MapTile[,] MapData { get; set; }

        [XmlAttribute("MapFile")]
        public string MapFile { get; set; }

        [XmlIgnore]
        IGlyph[,] RenderBuffer { get; set; }

        public const int Y_OFFSET = 2;

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="aMapFile">The map file to load.</param>
        /// <returns></returns>
        public static Dungeon Load(string aMapFile)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream tmpRawStream = File.Open(aMapFile, FileMode.Open))
                return (Dungeon)binFormatter.Deserialize(tmpRawStream);
        }
    }
}