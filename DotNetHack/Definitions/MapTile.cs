using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DotNetHack.Core;

namespace DotNetHack.Definitions
{
    [Serializable]
    public class MapTile : ILocation, IHasLocation
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

        #region Implementation of IHasLocation

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Location Location
        {
            get
            {
                return new Location(X, Y, Z);
            }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        #endregion
    }
}