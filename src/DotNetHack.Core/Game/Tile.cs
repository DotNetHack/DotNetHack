using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotNetHack.Core.Game
{
    /// <summary>
    /// Tile
    /// </summary>
    [Serializable]
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
            Nothing,
            Wall,
        }

        /// <summary>
        /// TileFlags
        /// </summary>
        [Flags]
        public enum TileFlags
        {
            None = 1,
            Door = 2,
            Trap = 4,
            Secret = 8,
            Sacred = 16,
            Stairs = 32,
            Spawn = 128,
            Impassable = 256,
        }
    }
}
