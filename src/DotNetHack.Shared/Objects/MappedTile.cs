using DotNetHack.Core.Game.Tiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Shared.Objects
{
    /// <summary>
    /// TileMapping
    /// </summary>
    public partial class TileMapping
    {
        /// <summary>
        /// MappedTile
        /// </summary>
        [Serializable]
        [DefaultPropertyAttribute("Name")]
        [DebuggerDisplay("{Name}")]
        public class MappedTile : Tile, IEquatable<MappedTile>
        {
            /// <summary>
            /// MappedTile
            /// </summary>
            public MappedTile() { }

            /// <summary>
            /// MappedTile
            /// </summary>
            public MappedTile(int xCoord, int yCoord, TileType tileType)
                : base(tileType)
            {
                XMapping = xCoord;
                YMapping = yCoord;
            }

            /// <summary>
            /// Name
            /// </summary>
            [CategoryAttribute("Tile Info")]
            [DescriptionAttribute("The name of this specific tile mapping.")]
            public string Name { get; set; }

            /// <summary>
            /// Descriptions
            /// </summary>
            [CategoryAttribute("Tile Info")]
            [DescriptionAttribute("The description of this specific tile mapping.")]
            public string Description { get; set; }

            /// <summary>
            /// XMapping
            /// </summary>
            [CategoryAttribute("Tileset Coordinates")]
            [DescriptionAttribute("X-Coordinate for this tile within the tile set")]
            public int XMapping { get; set; }

            /// <summary>
            /// YMapping
            /// </summary>
            [CategoryAttribute("Tileset Coordinates")]
            [DescriptionAttribute("Y-Coordinate for this tile within the tile set")]
            public int YMapping { get; set; }

            /// <summary>
            /// Equals
            /// </summary>
            /// <param name="other">other</param>
            /// <returns>true if the the two are equally mapped</returns>
            public bool Equals(MappedTile other)
            {
                return this.XMapping == other.XMapping &&
                    this.YMapping == other.YMapping &&
                    this.Name == other.Name;
            }

            /// <summary>
            /// ToString
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("{0}, {1}", Name,
                    string.Format("({0},{1})", XMapping, YMapping));
            }          
        }
    }
}
