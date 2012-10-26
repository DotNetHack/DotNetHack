using DotNetHack.Core.Game.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.World
{
    public class CC1
    {
        public CC1()
        {

            Substrate s1 = new Substrate(10,10,10);
        }
    }
    /// <summary>
    /// Substrate
    /// </summary>
    [Serializable]
    public class Substrate
    {
        /// <summary>
        /// Substrate
        /// <remarks>supports serialization</remarks>
        /// </summary>
        public Substrate() { }

        /// <summary>
        /// Substrate
        /// </summary>
        /// <param name="w">width</param>
        /// <param name="h">height</param>
        /// <param name="d">depth</param>
        public Substrate(int w, int h, int d)
        {
            CoreLayer = new Tile[w, h, d];
        }

        /// <summary>
        /// CoreLayer
        /// </summary>
        public Tile[, ,] CoreLayer { get; set; }
    }
}
