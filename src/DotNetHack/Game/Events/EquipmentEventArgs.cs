using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// potion event args
    /// </summary>
    /// <typeparam name="G"></typeparam>
    public class PotionEventArgs : ActorEventArgs
    {
        /// <summary>
        /// creates a new potion event args
        /// </summary>
        /// <param name="aActor"></param>
        public PotionEventArgs(Actor aActor, IPotion aPotion) 
            : base(aActor)
        { PotionInvolved = aPotion; }

        /// <summary>
        /// the potion involved
        /// </summary>
        public IPotion PotionInvolved { get; set; }
    }

    /// <summary>
    /// equipment based event argument
    /// </summary>
    /// <typeparam name="T">the special event type</typeparam>
    /// <typeparam name="G">the equipment iteself</typeparam>
    public class EquipmentEventArgs<T, G> : GameEventArgs
        where G: IEquipment
    {
        /// <summary>
        /// Creates a new EquipmentEventArgs
        /// </summary>
        /// <param name="aType">The special event type</param>
        /// <param name="aEquipmentInvoled">The equipment that is involved</param>
        public EquipmentEventArgs(T aType, G aEquipmentInvoled) 
        {
            EquipmentInvolved = aEquipmentInvoled;
            EquipEventType = aType;
        }

        /// <summary>
        /// the peice of equipment involved
        /// </summary>
        public G EquipmentInvolved { get; set; }

        /// <summary>
        /// EquipEventType
        /// </summary>
        public T EquipEventType { get; set; }
    }
}
