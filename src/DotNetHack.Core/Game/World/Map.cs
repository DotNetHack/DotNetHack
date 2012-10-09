using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.World
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
        public Map(string name, int width, int height, int depth)
        {
            Name = name;
            Tiles = new Tile[width, height, depth];

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    for (int z = 0; z < depth; ++z)
                    {
                        Tiles[x, y, z] = new Tile()
                        {
                            Type = Tile.TileType.Nothing,
                        };
                    }
                }
            }
        }

        /// <summary>
        /// Tiles
        /// </summary>
        public Tile[, ,] Tiles { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}
