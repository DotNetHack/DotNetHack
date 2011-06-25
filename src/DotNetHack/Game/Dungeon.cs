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
            Height = h;

            MapData = new MapTile[w, h];
            RenderBuffer = new MapTile[w, h];

            IterXY(delegate(int x, int y)
            {
                MapData[x, y] = new MapTile(new Location(x, y))
                {
                    TileType = TileType.NOTHING,
                    C = Colour.Standard,
                    G = ' ',
                };
            });

            ClearBuffer();
        }

        public void ClearBuffer()
        {
            IterXY(delegate(int x, int y)
            {
                RenderBuffer[x, y] = new MapTile(x, y) { G = ' ' };
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

        public void SetAllTiles(Tile aTile)
        {
            IterXY(delegate(int x, int y)
            {
                if (MapData[x, y].TileType == TileType.NOTHING)
                    MapData[x, y] = new MapTile(x, y)
                    {
                        C = aTile.C,
                        G = aTile.G,
                        TileType = aTile.TileType,
                    };
            });
        }

        void IterXY(IterMapTiles aMapIterator)
        {
            for (int x = 0; x < Width; ++x)
                for (int y = 0; y < Height; ++y)
                    aMapIterator(x, y);
        }

        delegate void IterMapTiles(int x, int y);

        public void SetMapTile(MapTile aMapTile) { MapData[aMapTile.Location.X, aMapTile.Location.Y] = aMapTile; }

        public Tile GetTile(Location aLocation) { return GetTile(aLocation.X, aLocation.Y); }

        public Tile GetTile(int x, int y) { return (Tile)MapData[x, y]; }

        public bool CheckBounds(Location l)
        {
            Location lLowerRight = new Location(Width, Height);
            if (l < Location.Origin)
                return false;
            else if (l >= lLowerRight)
                return false;
            return true;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public MapTile[,] MapData { get; set; }

        [XmlAttribute("MapFile")]
        public string MapFile { get; set; }

        [XmlIgnore]
        IGlyph[,] RenderBuffer { get; set; }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return MapFile; }

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