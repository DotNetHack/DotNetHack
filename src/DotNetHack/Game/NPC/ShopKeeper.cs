using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.NPC.AI;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;

namespace DotNetHack.Game.NPC
{
    /// <summary>
    /// ShopKeeper
    /// </summary>
    [Serializable]
    public abstract class ShopKeeper : NonPlayerControlled, IShopKeeperAI
    {
        /// <summary>
        /// supports serialization.
        /// </summary>
        public ShopKeeper() { }

        /// <summary>
        /// Creates a new shopkeeper.
        /// </summary>
        /// <param name="aShopKeeperName"></param>
        public ShopKeeper(string aShopKeeperName, Location3i l)
            : base(aShopKeeperName, '@', Colour.White, l)
        {
        }

        public void Greet(Actor aActor) 
        {
            UI.Graphics.Display.ShowMessage(
                "Hello {0}, welcome to {1}'s general store!", aActor.Name, this.Name);
        }

        public event EventHandler OnReceivePayment;

        event EventHandler IShopKeeperAI.OnReceivePayment
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        void IShopKeeperAI.Greet(Actor aActor) { }


    }

    /// <summary>
    /// TheShopKeeper
    /// </summary>
    [Serializable]   
    public class GulDarTheShopKeeper : ShopKeeper
    {
        /// <summary>
        /// Creates a new instance of the shop keeper.
        /// </summary>
        public GulDarTheShopKeeper(Location3i aLoc)
            : base("Gul'dar", aLoc) { }

        /// <summary>
        /// should be called after stats exist.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
