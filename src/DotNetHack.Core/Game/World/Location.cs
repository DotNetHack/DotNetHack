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
    public struct Location : IEquatable<Location>
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
        /// X Coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y Coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Z Coordinate
        /// </summary>
        public int Z { get; set; }

        /// <summary>
        /// Distance between two locations.
        /// </summary>
        /// <returns></returns>
        public static double Distance(Location a, Location b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(a.Z - b.Z, 2));
        }

        /// <summary>
        /// Determine if one location equals another.
        /// </summary>
        /// <param name="other">compared to,</param>
        /// <returns>true if the two locations are the same.</returns>
        public bool Equals(Location other)
        {
            return this.X == other.X &&
                this.Y == other.Y &&
                this.Z == other.Z;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>a string representation of this location</returns>
        public override string ToString()
        {
            return string.Format("({0},{1},{2})", X, Y, Z);
        }
    }
}
