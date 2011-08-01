using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Actions
{
    /// <summary>
    /// An action.
    /// </summary>
    public abstract class Action
    {
        /// <summary>
        /// performs the action, returns boolean result.
        /// </summary>
        /// <returns></returns>
        public abstract bool Perform();
    }

    /// <summary>
    /// ActionAttack
    /// </summary>
    public abstract class ActionAttack : Action
    {
        /// <summary>
        /// Creates a new attack action to be performed.
        /// </summary>
        /// <param name="aAttacker">The attacker</param>
        /// <param name="aDefender">The defender</param>
        public ActionAttack(Actor aAttacker, Actor aDefender)
        {
            Attacker = aAttacker;
            Defender = aDefender;
        }

        /// <summary>
        /// The attacker involved in this attack action.
        /// </summary>
        protected Actor Attacker { get; set; }

        /// <summary>
        /// The defender involved in this attack action.
        /// </summary>
        protected Actor Defender { get; set; }

        /// <summary>
        /// The ActOn function for ActionAttack takes two actors, 
        /// and returns a boolean.
        /// <remarks>LHS - Attacker, RHS - Defender</remarks>
        /// </summary>
        protected Func<Actor, Actor, bool> ActOn { get; set; }

        /// <summary>
        /// Performs the attack action, and returns the success boolean.
        /// </summary>
        public override bool Perform()
        {
            if (ActOn != null)
                return ActOn(Attacker, Defender);
            return false;
        }
    }

    /// <summary>
    /// ActionMeleeAttack
    /// </summary>
    public class ActionMeleeAttack : ActionAttack
    {
        public ActionMeleeAttack(Actor aAttacker, Actor aDefender)
            : base(aAttacker, aDefender)
        {
            ActOn = MeleeAttack;
        }

        static bool MeleeAttack(Actor aAttacker, Actor aDefender)
        {
            aDefender.Stats.Health--;

            return true;
        }
    }
}
