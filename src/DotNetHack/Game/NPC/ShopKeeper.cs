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
            Brain = new Brain();
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


        public override void Execute(Player aPlayer)
        {
            if (Dice.D(1))
                Location.X++;
            else if (Dice.D(1))
                Location.X--;
            else if (Dice.D(1))
                Location.Y++;
            else if (Dice.D(1))
                Location.Y--;

            if (this.Distance(aPlayer) < 5)
            {
                if (Dice.D(20))
                {
                    if (aPlayer.Stats.HealthPercent < 50)
                        GameEngine.DoSound(new Sound(this, 
                            10, "Perhaps I can interest you in a healing potion?"));
                    else
                        Greet(aPlayer);
                }
            }
        }
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
            : base("Gul'dar", aLoc)
        {
            //            Brain = new Brain(
        }

        /// <summary>
        /// should be called after stats exist.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
