using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Monsters;
using DotNetHack.UI;
using DotNetHack.Game.Items;

namespace DotNetHack.Game.Dungeon.Tiles
{

#if OBSOLETE
    /// <summary>
    /// MapTile
    /// </summary>
    [Serializable]
    public class MapTile : Tile, IHasLocation, IEquatable<MapTile>
    {
        public MapTile(Location3i aTileLocation)
            : base()
        { Location = aTileLocation; }

        public MapTile(int x, int y)
            : base()
        { Location = new Location3i(x, y); }

        public MapTile(int x, int y, Tile aTile)
            : this(x, y) 
        {
            TileType = aTile.TileType;
            G = aTile.G;
            C = aTile.C;
        }

        public Location Location { get; set; }

        public bool Equals(MapTile other)
        {
            return Location.Equals(other.Location);
        }

        public override int GetHashCode()
        {
            return this.Location.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

#endif

    /// <summary>
    /// Tile
    /// </summary>
    [Serializable]
    public class Tile : IGlyph, DotNetHack.Game.Dungeon.Tiles.ITile
    {
        /// <summary>
        /// Tile
        /// </summary>
        public Tile()
        {
            TileGlyph = '\0';
            C = new Colour();
            Items = new ItemCollection();
        }

        /// <summary>
        /// Creates a new tile with the passed parameters
        /// </summary>
        /// <param name="aGlyph">The glyph representing this tile.</param>
        /// <param name="aColour">The color of this tile.</param>
        public Tile(char aGlyph, Colour aColour)
            : this(aGlyph, aColour, TileFlags.None) { }

        /// <summary>
        /// Creates a new tile with the passed parameters
        /// </summary>
        /// <param name="aGlyph">The glyph representing this tile.</param>
        /// <param name="aColour">The color of this tile.</param>
        /// <param name="aFlags">The flags present on this tile.</param>
        public Tile(char aGlyph, Colour aColour, TileFlags aFlags)
        {
            G = aGlyph;
            C = aColour;
            TileFlags = aFlags;
        }

        /// <summary>
        /// Tile Type
        /// </summary>
        public TileType TileType { get; set; }

        /// <summary>
        /// TileFlags
        /// </summary>
        public TileFlags TileFlags { get; set; }

        /// <summary>
        /// Tile Glyph
        /// </summary>
        public virtual char G
        {
            get 
            {
                if (HasItems)
                    G = Items.First().G;
                
                return TileGlyph;
            }
            set { TileGlyph = value; }
        }

        /// <summary>
        /// TileGlyph
        /// </summary>
        private char TileGlyph { get; set; }

        /// <summary>
        /// Returns true if this tile has items on it.
        /// </summary>
        public bool HasItems { get { return Items.Count > 0; } }

        /// <summary>
        /// Color
        /// </summary>
        public Colour C { get; set; }

        /// <summary>
        /// Items
        /// <remarks>The following method for storing items is experiemental.</remarks>
        /// </summary>
        // public Stack<IItem> Items { get; set; }

        public ItemCollection Items { get; set; }

        /// <summary>
        /// EmptyTile has standard colour, a '.' as the Glyph and Nothing as the TileType.
        /// </summary>
        public static Tile EmptyTile 
        {
            get 
            {
                return new Tile() 
                {
                    C = Colour.Standard,
                    G = '.',
                    TileType = TileType.Nothing,
                };
            }
        }
    }

}
