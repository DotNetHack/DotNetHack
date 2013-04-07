using DotNetHack.Core.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Shared.Events
{
    /// <summary>
    /// LocationChangedEventArgs
    /// </summary>
    public class LocationChangedEventArgs : EventArgs
    {
        /// <summary>
        /// LocationChangedEventArgs
        /// </summary>
        /// <param name="location"></param>
        public LocationChangedEventArgs(Location location) 
        {
            Location = location;
        }

        /// <summary>
        /// Location
        /// </summary>
        public Location Location { get; private set; }
    }
}
