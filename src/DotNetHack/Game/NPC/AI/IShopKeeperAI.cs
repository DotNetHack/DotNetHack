using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.NPC.AI
{
    /// <summary>
    /// All shopkeepers share this common interface.
    /// </summary>
    public interface IShopKeeperAI : IAgent
    {
        /// <summary>
        /// Occurs when the shopkeeper recieves payment for goods purchased.
        /// </summary>
        event EventHandler OnReceivePayment;

        /// <summary>
        /// Greet
        /// </summary>
        /// <param name="aActor"></param>
        void Greet(Actor aActor);
    }
}
