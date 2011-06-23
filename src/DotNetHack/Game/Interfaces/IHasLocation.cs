using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;

namespace DotNetHack.Game.Interfaces
{
    /// <summary>
    /// IHasLocation is used to mark things or objects that are locatable in 2-space.
    /// </summary>
    public interface IHasLocation
    {
        /// <summary>
        /// Location
        /// </summary>
        Location Location { get; set; }
    }
}
