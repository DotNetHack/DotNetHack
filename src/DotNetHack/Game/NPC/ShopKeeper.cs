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
            OnSeeMonster += new EventHandler<ActorEventArgs>(ShopKeeper_OnSeeMonster);
            OnSeePlayer += new EventHandler<ActorEventArgs>(ShopKeeper_OnSeePlayer);
            OnReceivePayment +=new EventHandler(ShopKeeper_OnReceivePayment);
        }

        
        void ShopKeeper_OnSeeMonster(object sender, ActorEventArgs e) { }

        void ShopKeeper_OnSeePlayer(object sender, ActorEventArgs e) { }

        void ShopKeeper_OnReceivePayment(object sender, EventArgs e) { }


        public void Greet(Actor aActor) 
        {
            UI.Graphics.Display.ShowMessage(
                "Hello {0}, welcome to {1}'s general store!", aActor.Name, this.Name);
        }

        public event EventHandler OnReceivePayment;
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
        /// Exec AI
        /// </summary>
        /// <param name="aPlayer"></param>
        /// <param name="aDungeon"></param>
        public override void Exec(Player aPlayer, Dungeon.Dungeon3 aDungeon)
        {
            
        }
    }
}
