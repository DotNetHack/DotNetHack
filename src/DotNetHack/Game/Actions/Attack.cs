using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Effects;

namespace DotNetHack.Game.Actions
{
    /// <summary>
    /// An action.
    /// </summary>
    public abstract class DAction
    {
        /// <summary>
        /// performs the action, returns boolean result.
        /// </summary>
        /// <returns></returns>
        public abstract bool Perform();
    }

    public abstract class DAction<T>
    {
        public abstract bool Perform(T on);
    }

    /// <summary>
    /// ActionAttack
    /// </summary>
    public abstract class ActionAttack : DAction
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
            if (aAttacker.WieldedWeapons.CurrentWeapon == null)
                return false;

            // this junk should be rollec up into a game-engine delegate
            // http://www.uesp.net/wiki/Oblivion:The_Complete_Damage_Formula
            double weaponRating =
            aAttacker.WieldedWeapons.CurrentWeapon.WeaponProperties.BaseWeaponDamage
                * 0.5 * (aAttacker.WieldedWeapons.CurrentWeapon.WeaponProperties.Condition
                / aAttacker.WieldedWeapons.CurrentWeapon.WeaponProperties.MaxCondition + 1)
                / 2;

            aDefender.Stats.Health -= (int)weaponRating;

            return true;
        }
    }
}
