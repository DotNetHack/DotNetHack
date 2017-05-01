using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using DotNetHack.Core;

namespace DotNetHack.Definitions
{
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
        public LocationIndexedCollection<MapTile> MapTiles { get; set; }

        /// <summary>
        /// Gets the specified x.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public MapTile Get(ILocation location)
        {
            return MapTiles[location];
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
}