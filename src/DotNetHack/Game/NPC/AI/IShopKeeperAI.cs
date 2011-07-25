using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.NPC.AI
{
    public interface IShopKeeperAI : IAI
    {
        event EventHandler OnReceivePayment;

        void Greet(Actor aActor);
    }
}
