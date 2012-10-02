using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core
{
    /// <summary>
    /// Tile
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public Tile() { }

        /// <summary>
        /// Type
        /// </summary>
        public TileType Type { get; set; }

        /// <summary>
        /// TileType
        /// </summary>
        public enum TileType
        {

        }

        /// <summary>
        /// TileFlags
        /// </summary>
        public enum TileFlags
        {

        }
    }
}
