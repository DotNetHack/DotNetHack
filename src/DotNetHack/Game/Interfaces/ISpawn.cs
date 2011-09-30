using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Interfaces
{
    /// <summary>
    /// ISpawn
    /// </summary>
    public interface ISpawn<T> where T : IItem
    {
        /// <summary>
        /// The last time this spawn was visited.
        /// </summary>
        long TicksSinceLastVisited { get; set; }

        /// <summary>
        /// The resource that is spawned by this spawn.
        /// </summary>
        T Resource { get; set; }

        /// <summary>
        /// The location of this spawn.
        /// </summary>
        Location3i Location { get; set; }

        /// <summary>
        /// Take this resource from the spawn.
        /// </summary>
        /// <returns>The resource or default(T)</returns>
        T Take();

        /// <summary>
        /// CanTake
        /// </summary>
        bool CanTake { get; }
    }
}
