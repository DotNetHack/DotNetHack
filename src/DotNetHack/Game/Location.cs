using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack.Game.Interfaces;
using System.Diagnostics;

namespace DotNetHack.Game
{
    /// <summary>
    /// LocationExtensions
    /// </summary>
    public static class LocationExtensions
    {
        /// <summary>
        /// Compute the distance between two objects that implement the <see cref="IHasLocation"/>
        /// interface.
        /// </summary>
        /// <param name="a">The first has location object.</param>
        /// <param name="b">The second has location object.</param>
        /// <returns></returns>
        public static double Distance(this IHasLocation a, IHasLocation b)
        {
            return a.Location.Distance(b.Location);
        }

        /// <summary>
        /// Compute distance between two locations.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Distance(this Location a, Location b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
    }

    /// <summary>
    /// FarLocation
    /// </summary>
    [Serializable]
    public class DistantLocation : Location
    {
        /// <summary>
        /// FarLocation
        /// </summary>
        public DistantLocation(Dungeon aDungeon, int x, int y)
            : base(x, y) { Plane = aDungeon; }

        /// <summary>
        /// The Dungeon or Plane
        /// </summary>
        public Dungeon Plane { get; set; }
    }

    /// <summary>
    /// Location is a location in the cartesian plane.
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    [Serializable]
    public class Location : IEquatable<Location>
    {
        /// <summary>
        /// Location
        /// </summary>
        /// <param name="d">The plane or dungeon on which this 2 dimensional location exists</param>
        /// <param name="x">X-Coordinate</param>
        /// <param name="y">Y-Coordinate</param>
        public Location(int x, int y)
        {
            X = x; Y = y;
        }

        /// <summary>
        /// Y-Coordinate
        /// <value>Gets or Sets the X-Coordinate of this location.</value>
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// X-Coordinate
        /// <value>Gets or Sets the Y-Coordinate of this location.</value>
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Location operator +(Location a, Location b)
        {
            return new Location(a.X + b.X, a.Y + b.Y);
        }

        public static bool operator >(Location a, Location b)
        {
            return (a.X > b.X && a.Y > b.Y);
        }

        public static bool operator >=(Location a, Location b)
        {
            return (a.X >= b.X && a.Y >= b.Y);
        }

        public static bool operator <(Location a, Location b)
        {
            return (a.X < b.X && a.Y < b.Y);
        }

        public static bool operator <=(Location a, Location b)
        {
            return (a.X <= b.X && a.Y <= b.Y);
        }

        /// <summary>
        /// The Origin is the location (0,0)
        /// </summary>
        public static readonly Location Origin = new Location(0, 0);

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other">other</param>
        /// <returns></returns>
        public bool Equals(Location other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}
