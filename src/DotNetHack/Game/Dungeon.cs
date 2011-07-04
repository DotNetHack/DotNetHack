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
    /// Dungeon3 is an experimental dungeon that has a third dimension.
    /// </summary>
    public class Dungeon3
    {
        #region Constructors

        /// <summary>
        /// Parameterless constructor supports serialization.
        /// </summary>
        public Dungeon3() { }

        /// <summary>
        /// Creates a new empty dungeon with the passed parameters.
        /// </summary>
        /// <param name="w">The width of the dungeon.</param>
        /// <param name="h">The height of the dungeon.</param>
        /// <param name="d">The depth of the dungeon.</param>
        public Dungeon3(int w, int h, int d)
        {
            // Set the width, height and depth.
            DungeonWidth = w; DungeonHeight = h; DungeonDepth = d;

            // Initialize the mapdata array.
            MapData = new Tile[w, h, d];

            // Set all dungeon tiles to empty.
            IterateDungeonData(delegate(int x, int y, int depth)
            {
                SetTile(x, y, depth, Tile.EmptyTile);
            });
        }

        #endregion

        #region Public Delegates

        /// <summary>
        /// Used as an argument for interating over all dungeon tiles.  This 
        /// is a common operation. so it's been crafted into a delegate.
        /// </summary>
        /// <param name="x">x parameter</param>
        /// <param name="y">y parameter</param>
        /// <param name="d">d parameter</param>
        delegate void DungeonIterator(int x, int y, int d);

        /// <summary>
        /// IterateDungeonData will iterate of all dungeon data and call the DungeonIterator.
        /// This is the preferred method to iterate over all dungeon data
        /// </summary>
        /// <param name="aDungeonIterator"></param>
        void IterateDungeonData(DungeonIterator aDungeonIterator)
        {
            for (int d = 0; d < DungeonDepth; ++d)
                for (int x = 0; x < DungeonWidth; ++x)
                    for (int y = 0; y < DungeonHeight; ++y)
                        aDungeonIterator(x, y, d);
        }

        #endregion

        #region Public Facing Methods

        /// <summary>
        /// Returns the specified tile.
        /// </summary>
        /// <param name="x">The x-coordinate of the tile to get.</param>
        /// <param name="y">The y-coordinate of the tile to get.</param>
        /// <param name="d">The dungeon level of the tile to get.</param>
        /// <returns></returns>
        public Tile GetTile(int x, int y, int d) { return MapData[x, y, d]; }

        /// <summary>
        /// SetTile will set the passed tile at the passed location parameters.
        /// </summary>
        /// <param name="x">The x-coordinate of the tile to set.</param>
        /// <param name="y">The y-coordinate of the tile to set.</param>
        /// <param name="d">The depth of the tile to set.</param>
        /// <param name="aTile">The tile object to set at the location.</param>
        public void SetTile(int x, int y, int d, Tile aTile) { MapData[x, y, d] = aTile; }

        #endregion

        #region Public Facing Properties

        /// <summary>
        /// The height of this dungeon.
        /// <remarks>This is not the same as depth. <see cref="DungeonDepth"/></remarks>
        /// </summary>
        public int DungeonHeight { get; private set; }

        /// <summary>
        /// The width of this dungeon
        /// </summary>
        public int DungeonWidth { get; private set; }

        /// <summary>
        /// The depth of this dungeon
        /// </summary>
        public int DungeonDepth { get; private set; }

        /// <summary>
        /// MapData contains all data that pretains to the physicality of the dungeon.
        /// </summary>
        public Tile[, ,] MapData { get; private set; }

        #endregion

        #region Supporting Structs & Classes

        // TODO: DungeonLocation *is a* Location.

        /// <summary>
        /// DungeonLocation is a location that specifically refers to a 
        /// location inside of a dungeon that has depth.
        /// </summary>
        public class DungeonLocation
        {
            /// <summary>
            /// Creates a new DungeonLocation with the passed parameters that
            /// refer to the specific Location.
            /// </summary>
            /// <param name="x">The x-coordinate of the dungeon location.</param>
            /// <param name="y">The y-coordinate of the dungeon location.</param>
            /// <param name="d">The depth of the dungeon location.</param>
            public DungeonLocation(int x, int y, int d) { X = x; Y = y; D = d; }

            /// <summary>
            /// The x-coordinate of this dungeon location.
            /// </summary>
            public int X { get; set; }

            /// <summary>
            /// The y-coordinate of this dungeon location.
            /// </summary>
            public int Y { get; set; }

            /// <summary>
            /// The depth of this dungeon location.
            /// </summary>
            public int D { get; set; }
        }

        #endregion
    }

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
                    TileType = TileType.FLOOR,
                    C = Colour.Standard,
                    G = '.',
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
            foreach (IItem iItem in Items)
                UI.Graphics.Draw(iItem);

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

            foreach (IItem iItem in Items)
            {
                int x1 = iItem.Location.X;
                int y1 = iItem.Location.Y;
                iItem.C.SetBG(MapData[x1, y1].C.BG);
                UI.Graphics.Draw(iItem);
            }

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

        public List<IItem> Items = new List<IItem>();

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