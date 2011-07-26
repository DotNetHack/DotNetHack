
using DotNetHack.Game;
using DotNetHack.Utility;

namespace DotNetHack.UI
{
    /// <summary>
    /// BufferedRegion
    /// </summary>
    public class DisplayRegion : Rectangle
    {
        /// <summary>
        /// Creates a new buffered region.
        /// </summary>
        /// <param name="a">The first point used for form the region</param>
        /// <param name="b">The second point used to for the region.</param>
        public DisplayRegion(Location2i a, Location2i b)
            : base(a, b)
        { }

        /// <summary>
        /// Creates a new buffered region.
        /// </summary>
        /// <param name="x1">x-coord of the first point used to form the region</param>
        /// <param name="y1">y-coord of the first point used to form the region</param>
        /// <param name="x2">x-coord of the second point used to form the region</param>
        /// <param name="y2">y-coord of the second point used to form the region</param>
        public DisplayRegion(int x1, int y1, int x2, int y2)
            : base(x1, y1, x2, y2)
        { }
    }
}
