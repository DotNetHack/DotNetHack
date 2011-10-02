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
        public static double Distance(this Location2i a, Location2i b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
    }

    /// <summary>
    /// Location3i
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString()}")]
    public class Location3i : Location2i
    {
        /// <summary>
        /// supports serialization
        /// </summary>
        public Location3i()
            : base()
        { }

        /// <summary>
        /// Location3i
        /// </summary>
        /// <param name="l">A two-d location.</param>
        /// <param name="d">The dungeon level.</param>
        public Location3i(Location2i l, int d = 0)
            : this(l.X, l.Y, d) { }

        /// <summary>
        /// Location3i
        /// </summary>
        /// <param name="x">The x-coord</param>
        /// <param name="y">The y-coord</param>
        /// <param name="d">The z-coord</param>
        public Location3i(int x, int y, int d)
            : base(x, y)
        { D = d; }

        /// <summary>
        /// D
        /// </summary>
        public int D { get; set; }

        /// <summary>
        /// Origin3i
        /// </summary>
        public static readonly Location3i Origin3i = new Location3i(0, 0, 0);

        /// <summary>
        ///+
        /// </summary>
        /// <param name="a">LHS</param>
        /// <param name="b">RHS</param>
        /// <returns>Adds the two locations together.</returns>
        public static Location3i operator +(Location3i a, Location3i b)
        {
            return Location3i.GetNew(a.X + b.X, a.Y + b.Y, a.D + b.D);
        }

        /// <summary>
        /// Returns a new 3i with passed params
        /// </summary>
        /// <param name="x">x-coord</param>
        /// <param name="y">y-coord</param>
        /// <param name="d">z-coord</param>
        /// <returns>Returns a new 3i with passed params</returns>
        public static Location3i GetNew(int x, int y, int d) { return new Location3i(x, y, d); }

        /// <summary>
        /// less than
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(Location3i a, Location3i b)
        {
            return a.X < b.X || a.Y < b.Y || a.D < b.D;
        }

        /// <summary>
        /// less than or equal to
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <=(Location3i a, Location3i b)
        {
            return a.X <= b.X || a.Y <= b.Y || a.D <= b.D;
        }

        /// <summary>
        /// greater than or equal to
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >=(Location3i a, Location3i b)
        {
            return a.X >= b.X || a.Y >= b.Y || a.D >= b.D;
        }

        /// <summary>
        /// g
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(Location3i a, Location3i b)
        {
            return a.X > b.X || a.Y > b.Y || a.D > b.D;
        }

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Location3i a, Location3i b)
        {
            a = a ?? Location3i.Origin3i;
            b = b ?? Location3i.Origin3i;
            return a.X == b.X && a.Y == b.Y && a.D == b.D;
        }

        public static bool operator !=(Location3i a, Location3i b)
        {
            return a.X != b.X || a.Y != b.Y || a.D != b.D;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0},{1},{2})", X, Y, D);
        }
    }

    /// <summary>
    /// Location2I
    /// </summary>
    [Serializable]
    public class Location2i
    {
        /// <summary>
        /// Supports serialization
        /// </summary>
        public Location2i() { }

        /// <summary>
        /// supports serialization.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Location2i(int x, int y) { X = x; Y = y; }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="l">The location to copy from.</param>
        public Location2i(Location2i l) { X = l.X; Y = l.Y; }

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
        /// Returns a new 2i with passed parameters
        /// </summary>
        /// <param name="x">x-coord</param>
        /// <param name="y">y-coord</param>
        /// <returns>new 2i w/ passed params</returns>
        public static Location2i GetNew(int x, int y) { return new Location2i(x, y); }

        /// <summary>
        /// TwoD
        /// </summary>
        public Location2i TwoD { get { return new Location2i(X, Y); } }

        /// <summary>
        /// The Origin is the location (0,0)
        /// </summary>
        public static readonly Location2i Origin2i = new Location2i(0, 0);

        /// <summary>
        /// +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Location2i operator +(Location2i a, Location2i b)
        {
            return new Location2i(a.X + b.X, a.Y + b.Y);
        }

        /// <summary>
        /// >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(Location2i a, Location2i b)
        {
            return (a.X > b.X || a.Y > b.Y);
        }

        /// <summary>
        /// >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >=(Location2i a, Location2i b)
        {
            return (a.X >= b.X || a.Y >= b.Y);
        }

        /// <summary>
        /// <
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(Location2i a, Location2i b)
        {
            return (a.X < b.X || a.Y < b.Y);
        }

        /// <summary>
        /// <=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <=(Location2i a, Location2i b)
        {
            return (a.X <= b.X || a.Y <= b.Y);
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

#if OBSOLETE
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
        public Location() { }

        /// <summary>
        /// Location
        /// </summary>
        /// <param name="d">The plane or dungeon on which this 2 dimensional location exists</param>
        /// <param name="x">X-Coordinate</param>
        /// <param name="y">Y-Coordinate</param>
        public Location(int x, int y, int d)
        {
            X = x; Y = y; D = d;
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
        /// Dungeon level
        /// </summary>
        public int D { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Location operator +(Location a, Location b)
        {
            return new Location(a.X + b.X, a.Y + b.Y, 0);
        }

        public static bool operator >(Location a, Location b)
        {
            return (a.X > b.X || a.Y > b.Y);
        }

        public static bool operator >=(Location a, Location b)
        {
            return (a.X >= b.X || a.Y >= b.Y);
        }

        public static bool operator <(Location a, Location b)
        {
            return (a.X < b.X || a.Y < b.Y);
        }

        public static bool operator <=(Location a, Location b)
        {
            return (a.X <= b.X || a.Y <= b.Y);
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
#endif
}
