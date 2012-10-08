using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotNetHack.Core.Game.World
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
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Tile(int x, int y, int z) 
        {
            X = x;
            Y = y;
            Z = z;
        }

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

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

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
