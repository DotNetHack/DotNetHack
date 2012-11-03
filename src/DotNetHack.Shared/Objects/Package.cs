using DotNetHack.Core.Game.Actors;
using DotNetHack.Core.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Shared.Objects
{
    /// <summary>
    /// Package
    /// </summary>
    public class Package
    {
        /// <summary>
        /// Package
        /// </summary>
        public Package() { }

        /// <summary>
        /// The items in this package.
        /// </summary>
        public List<MappedObject<Item>> Items { get; set; }

        /// <summary>
        /// The actors in this package.
        /// </summary>
        public List<MappedObject<Actor>> Actors { get; set; }

        /// <summary>
        /// The tile mapping for this PAK
        /// </summary>
        public TileMapping TileMapping { get; set; }

        /// <summary>
        /// Modified
        /// </summary>
        public bool Modified { get; set; }

        /// <summary>
        /// LastUpdated
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}
