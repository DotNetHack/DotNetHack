using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;

namespace DotNetHack.Utility
{
    /// <summary>
    /// BufferedRegion
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Creates a new buffered region.
        /// </summary>
        /// <param name="a">The first point used for form the region</param>
        /// <param name="b">The second point used to for the region.</param>
        public Rectangle(Location2i a, Location2i b) { P1 = a; P2 = b; }

        /// <summary>
        /// Creates a new buffered region.
        /// </summary>
        /// <param name="x1">x-coord of the first point used to form the region</param>
        /// <param name="y1">y-coord of the first point used to form the region</param>
        /// <param name="x2">x-coord of the second point used to form the region</param>
        /// <param name="y2">y-coord of the second point used to form the region</param>
        public Rectangle(int x1, int y1, int x2, int y2)
            : this(new Location2i(x1, y1), new Location2i(x2, y2))
        { }

        /// <summary>
        /// The first point of the buffered region.
        /// </summary>
        public Location2i P1 { get; set; }

        /// <summary>
        /// The second point of the buffered region.
        /// </summary>
        public Location2i P2 { get; set; }
    }
}
