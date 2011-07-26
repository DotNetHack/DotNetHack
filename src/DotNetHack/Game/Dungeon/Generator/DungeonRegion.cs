using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Utility;
using DotNetHack.Game.Dungeon.Tiles;

namespace DotNetHack.Game.Dungeon.Generator
{
    /// <summary>
    /// DungeonRegion
    /// </summary>
    public class DungeonRegion : Rectangle
    {
        /// <summary>
        /// Creates a new dungeon region.
        /// </summary>
        /// <param name="a">The first point used for form the region</param>
        /// <param name="b">The second point used to for the region.</param>
        public DungeonRegion(Dungeon3 d, Location2i a, Location2i b)
            : base(a, b)
        { Dungeon = d; }

        /// <summary>
        /// Creates a new dungeon region.
        /// </summary>
        /// <param name="x1">x-coord of the first point used to form the region</param>
        /// <param name="y1">y-coord of the first point used to form the region</param>
        /// <param name="x2">x-coord of the second point used to form the region</param>
        /// <param name="y2">y-coord of the second point used to form the region</param>
        public DungeonRegion(Dungeon3 d, int x1, int y1, int x2, int y2)
            : base(x1, y1, x2, y2) { Dungeon = d; }

        /// <summary>
        /// Returns an enumeration over the dungeon regions tiles.
        /// <remarks>This is highly dependent upon the dungeon level so <c>d</c> is passed 
        /// as a parameter.</remarks>
        /// </summary>
        /// <exception cref="DNHException">logical failure</exception>
        public IEnumerable<Tile> RegionTiles(int d)
        {
            if (P1.Equals(P2))
                // P1 and P2 are on the same tile, return the tile.
                yield return Dungeon.GetTile(P1, d);
            else if (P1 < P2)
            {
                // starting @ P1, moving to P2
                for (int x = P1.X; x < P2.X; ++x)
                    for (int y = P1.Y; y < P2.Y; ++y)
                        yield return Dungeon.GetTile(Location3i.GetNew(x, y, d));
            }
            else if (P2 < P1)
            {
                // starting @ P2, moving to P1
                for (int x = P2.X; x < P1.X; ++x)
                    for (int y = P2.Y; y < P1.Y; ++y)
                        yield return Dungeon.GetTile(Location3i.GetNew(x, y, d));
            }
            // the x-coord(s) align, || the y-coords align
            else
            {
                // the x-coordinates align.
                if (P1.X == P2.X)
                {
                    ///
                    /// working with the y-coordinate.
                    ///

                    if (P1.Y < P2.Y)
                    {
                        // P1 on "top"
                        for (int y = P1.Y; y < P2.Y; ++y)
                            yield return Dungeon.GetTile(
                                Location3i.GetNew(P1.X, y, d));
                    }
                    else if (P2.Y < P1.Y)
                    {
                        // P2 on "top"
                        for (int y = P2.Y; y < P1.Y; ++y)
                            yield return Dungeon.GetTile(
                                Location3i.GetNew(P1.X, y, d));
                    }
                    else new DNHackException("logical failure");
                }
                // the y-coordinates align.
                else if (P1.Y == P2.Y)
                {
                    ///
                    /// working with the x-coordinate.
                    ///

                    if (P1.X < P2.X)
                    {
                        // P1 on "left"
                        for (int x = P1.X; x < P2.X; ++x)
                            yield return Dungeon.GetTile(
                                Location3i.GetNew(x, P1.Y, d));
                    }
                    else if (P2.X < P1.X)
                    {
                        // P2 on "left"
                        for (int x = P2.X; x < P1.X; ++x)
                            yield return Dungeon.GetTile(
                                Location3i.GetNew(x, P1.Y, d));
                    }
                    else new DNHackException("logical failure");
                }
                else new DNHackException("logical failure");
            }
        }

        /// <summary>
        /// Check 2d-boundaries of this dungeon region.
        /// <remarks>preconditions, dungeon must have at least one floor.</remarks>
        /// </summary>
        /// <returns></returns>
        public bool CheckBounds()
        {
            var p1 = Location3i.GetNew(P1.X, P1.Y, 0);
            var p2 = Location3i.GetNew(P2.X, P2.Y, 0);
            return Dungeon.CheckBounds(p1) && Dungeon.CheckBounds(p2);
        }

        /// <summary>
        /// The dungeon region maintains a reference to the dungeon, this 
        /// would be that reference.
        /// </summary>
        Dungeon3 Dungeon { get; set; }
    }
}
