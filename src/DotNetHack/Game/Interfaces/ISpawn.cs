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
        DateTime LastVisited { get; set; }

        /// <summary>
        /// The resource that is spawned by this spawn.
        /// </summary>
        T Resource { get; set; }
    }
}
