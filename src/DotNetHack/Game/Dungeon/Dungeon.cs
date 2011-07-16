using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Dungeon.Tiles;

namespace DotNetHack.Game.Dungeon
{
    /// <summary>
    /// IterXYDelegate
    /// </summary>
    /// <param name="x">The x-coord</param>
    /// <param name="y">The y-coord</param>
    internal delegate void IterXYDelegate(int x, int y);

    /// <summary>
    /// DungeonExtensions
    /// </summary>
    public static class DungeonExtensions
    {
        /// <summary>
        /// SaveAs
        /// </summary>
        public static void SaveAs(this Dungeon3 aLevel, string aMapFile)
        {
            string fullPath = Path.Combine(R.WorkingDirectory,
                aMapFile + Dungeon3.DungeonExtension);
            // Create a new binary formatter
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream tmpRawStream = File.Open(fullPath, FileMode.OpenOrCreate))
                binFormatter.Serialize(tmpRawStream, aLevel);
        }
    }

    /// <summary>
    /// Dungeon3 is an experimental dungeon that has a third dimension.
    /// </summary>
    [Serializable]
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

            // Create a new dungeon renderer using this as the dungeon.
            DungeonRenderer = new DungeonRenderer(this);
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

        public void Render(Location3i aLoc) { DungeonRenderer.Render(aLoc); }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="aMapFile">The map file to load.</param>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public static Dungeon3 Load(string aMapFile)
        {
            string fullPath = Path.Combine(R.WorkingDirectory,
                aMapFile + DungeonExtension);
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream tmpRawStream = File.Open(fullPath, FileMode.Open))
                return (Dungeon3)binFormatter.Deserialize(tmpRawStream);
        }

        /// <summary>
        /// Returns the specified tile.
        /// </summary>
        /// <param name="x">The x-coordinate of the tile to get.</param>
        /// <param name="y">The y-coordinate of the tile to get.</param>
        /// <param name="d">The dungeon level of the tile to get.</param>
        /// <returns></returns>
        public Tile GetTile(int x, int y, int d) { return MapData[x, y, d]; }

        /// <summary>
        /// GetTile
        /// </summary>
        /// <param name="l"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public Tile GetTile(Location3i l) { return GetTile(l.X, l.Y, l.D); }

        /// <summary>
        /// GetTile
        /// </summary>
        /// <param name="l"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public Tile GetTile(Location2i l, int d) { return MapData[l.X, l.Y, d]; }

        /// <summary>
        /// SetTile will set the passed tile at the passed location parameters.
        /// </summary>
        /// <param name="x">The x-coordinate of the tile to set.</param>
        /// <param name="y">The y-coordinate of the tile to set.</param>
        /// <param name="d">The depth of the tile to set.</param>
        /// <param name="aTile">The tile object to set at the location.</param>
        public void SetTile(int x, int y, int d, Tile aTile) { MapData[x, y, d] = aTile; }

        /// <summary>
        /// SetTile will set the passed tile at the passed location parameters.
        /// </summary>
        /// <param name="l">l3i to set</param>
        /// <param name="aTile">tile to set</param>
        public void SetTile(Location3i l, Tile aTile) { MapData[l.X, l.Y, l.D] = aTile; }

        /// <summary>
        /// CheckBounds
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public bool CheckBounds(Location3i l)
        {
            Location3i lLowerRight = Location3i.GetNew(DungeonWidth, DungeonHeight, DungeonDepth);
            if (l < Location3i.Origin3i)
                return false;
            else if (l >= lLowerRight)
                return false;
            return true;
        }

        #endregion

        #region Public Facing Properties

        /// <summary>
        /// Used specificially to render this dungeon
        /// </summary>
        [XmlIgnore]
        public DungeonRenderer DungeonRenderer { get; set; }

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
        [Serializable]
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

        #region Constants
        /// <summary>
        /// DungeonExtension
        /// </summary>
        public const string DungeonExtension = ".dungeon";
        #endregion
    }

#if OBSOLETE
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
                MapData[x, y] = new MapTile(new Location2i(x, y))
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

        public bool CheckBounds(Location2i l)
        {
            Location2i lLowerRight = new Location2i(Width, Height);
            if (l < Location2i.Origin2i)
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
#endif
}