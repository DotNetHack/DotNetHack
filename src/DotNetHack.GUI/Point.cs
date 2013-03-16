using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI
{
    /// <summary>
    /// Point
    /// </summary>
    public class Point : IPoint
    {
        /// <summary>
        /// Point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X-Coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y-Coordinate
        /// </summary>
        public int Y { get; set; }
    }
}
