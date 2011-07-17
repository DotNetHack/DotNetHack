using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items
{
    /// <summary>
    /// Key
    /// <see cref="http://en.wikipedia.org/wiki/Key_(lock)"/>
    /// </summary>
    public class Key : Item, IKey
    {
        /// <summary>
        /// Creates a new instance of "key" with the specified KeyGuid.
        /// </summary>
        /// <param name="aKeyGuid">The key guid to used creating this key.</param>
        public Key(Guid aKeyGuid)
            : base(Items.ItemType.Key, "Key", '╛', Colour.Yellow)
        { KeyGuid = aKeyGuid; }

        /// <summary>
        /// KeyGuid, the Guid used to represent this key.
        /// </summary>
        public Guid KeyGuid { get; set; }
    }
}
