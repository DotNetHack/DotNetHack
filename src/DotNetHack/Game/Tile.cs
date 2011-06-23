using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Monsters;
using DotNetHack.UI;

namespace DotNetHack.Game
{
    /// <summary>
    /// MapTile
    /// </summary>
    [Serializable]
    public class MapTile : Tile, IHasLocation, IEquatable<MapTile>
    {
        public MapTile(Location aTileLocation)
            : base()
        { Location = aTileLocation; }

        public MapTile(int x, int y)
            : base()
        { Location = new Location(x, y); }

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

    /// <summary>
    /// Tile
    /// </summary>
    [Serializable]
    public class Tile : IGlyph
    {
        /// <summary>
        /// Tile
        /// </summary>
        public Tile()
        {
            C = new Colour();
        }

        /// <summary>
        /// Tile Type
        /// </summary>
        public TileType TileType { get; set; }

        /// <summary>
        /// TileFlags
        /// </summary>
        // public TileFlags TileFlags { get; set; }

        /// <summary>
        /// Tile Glyph
        /// </summary>
        public char G { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public Colour C { get; set; }
    }
}
