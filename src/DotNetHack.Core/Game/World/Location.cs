using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.World
{
    /// <summary>
    /// Location
    /// </summary>
    public struct Location
    {
        /// <summary>
        /// Location
        /// </summary>
        public Location(int x, int y, int z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Z
        /// </summary>
        public int Z { get; set; }
    }
}
