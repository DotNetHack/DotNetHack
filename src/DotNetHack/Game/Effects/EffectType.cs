using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Effects
{
    /// <summary>
    /// The intent for <see cref="EffectType"/> is that they are used in 
    /// conjuction with one another to create a flexible method for the
    /// implementation of various effects without mindnumbing indirection.
    ///
    /// <example>
    /// Here is a what a sleep spell light look like,
    /// <code>Spell | Sleep</code>
    ///
    /// A lightning bolt from the sky would be,
    /// <code>Nature | Electric</code>
    ///
    /// A worn amulet that enhances stats might be,
    /// <code>Enchantment</code>
    ///
    /// A disease that blinds and slowly drains health.
    /// <code>Blind | Drain | Disease</code>
    ///
    /// A basic healing spell.
    /// <code>Healing | Spell</code>
    /// </example>
    ///
    /// It is very tempting to add various schools, destruction, restoration, etc. But
    /// there isn't yet a *reason* to do so. This will have to do for now.
    ///
    /// <remarks>Combining these are not intented to reflect multiple effects. 
    /// Rather, the combination of these lead to a single effect.</remarks>
    /// </summary>
    [Flags]
    public enum EffectType
    {
        Hallucination,
        Disintergate,
        Enchantment,
        Polymorph,
        Physical,
        Electric,
        Confused,
        Crippled,
        Healing,
        Poision,
        Disease,
        Arcane,
        Shadow,
        Nature,
        Frenzy,
        Hunger,
        Sleep,
        Blind,
        Drain,
        Spell,
        Frost,
        Stun,
        Acid,
        Fire,
        Holy,
        Fear,
    }
}
