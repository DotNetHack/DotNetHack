using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.NPC
{
    /// <summary>
    /// ShopKeeper
    /// </summary>
    [Serializable]
    public class ShopKeeper : NPC
    {
        /// <summary>
        /// Creates a new shopkeeper.
        /// </summary>
        /// <param name="aShopKeeperName"></param>
        public ShopKeeper(string aShopKeeperName)
            : base(aShopKeeperName)
        { }
    }
}
