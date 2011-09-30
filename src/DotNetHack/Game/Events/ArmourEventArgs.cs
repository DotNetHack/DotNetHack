using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// ArmourEventArgs
    /// </summary>
    public class ArmourEventArgs : GameEventArgs
    {
        /// <summary>
        /// ArmourEventArgs
        /// </summary>
        /// <param name="aArmour">The armour involved in this armour event</param>
        public ArmourEventArgs(Actor aActor, IArmour aArmour)
        { Armour = aArmour; WornByActor = aActor; }

        /// <summary>
        /// The armour involved in this armour event
        /// </summary>
        public IArmour Armour { get; set; }

        /// <summary>
        /// Actor
        /// </summary>
        public Actor WornByActor { get; set; }
    }

    /// <summary>
    /// ArmourEventArgs
    /// </summary>
    public class ArmourStrikeEventArgs : ArmourEventArgs
    {
        /// <summary>
        /// ArmourStrikeEventArgs
        /// </summary>
        /// <param name="aWornByActor">The actor doing the wearing of this armour piece</param>
        /// <param name="aAttackingActor">The actor doing the attacking</param>
        /// <param name="aArmour">The armour piece involved.</param>
        public ArmourStrikeEventArgs(Actor aWornByActor, Actor aAttackingActor, IArmour aArmour)
            : base(aWornByActor, aArmour) { AttackingActor = aAttackingActor; }

        /// <summary>
        /// Attacking actor.
        /// </summary>
        public Actor AttackingActor { get; set; }
    }
}
