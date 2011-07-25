using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game
{
    public enum Direction { Up, Down, Left, Right }

    /// <summary>
    /// RandomDirection is used for random walks.
    /// </summary>
    public static class RandomDirection
    {
        /// <summary>
        /// Static constructor for random direction.
        /// </summary>
        static RandomDirection()
        {
            Directions.Add(Direction.Down);
            Directions.Add(Direction.Left);
            Directions.Add(Direction.Up);
            Directions.Add(Direction.Right);
        }

        /// <summary>
        /// A starting list of direction.
        /// </summary>
        public static List<Direction> Directions = new List<Direction>();

        /// <summary>
        /// Apply a random direction to a location.
        /// </summary>
        /// <param name="aLocation">The location to apply a random direction to.</param>
        public static void ApplyTo(Location2i aLocation)
        {
            switch (RandomDirection.Get)
            {
                case Direction.Up:
                    aLocation.Y--; break;
                case Direction.Right:
                    aLocation.X++; break;
                case Direction.Down:
                    aLocation.Y++; break;
                case Direction.Left:
                    aLocation.X--; break;
            }
        }

        /// <summary>
        /// Get a random direction.
        /// </summary>
        public static Direction Get
        {
            get { return Dice.RandomChoice<Direction>(Directions); }
        }
    }
}
