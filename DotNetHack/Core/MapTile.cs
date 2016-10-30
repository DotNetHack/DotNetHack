using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DotNetHack.Core
{
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
}