using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game
{
    /// <summary>
    /// A DotNetHack Map.
    /// </summary>
    [Serializable]
    public class Map
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public Map() { }

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="width">width of the map</param>
        /// <param name="height">height of the map</param>
        /// <param name="depth">the depth of the map</param>
        public Map(int width, int height, int depth)
        {
            Tiles = new Tile[width, height, depth];
        }

        /// <summary>
        /// Tiles
        /// </summary>
        Tile[, ,] Tiles { get; set; }
    }
}
