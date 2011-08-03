using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Utility;

namespace DotNetHack.Game.Items.Equipment.Weapons
{
    /// <summary>
    /// WeaponProperties
    /// </summary>
    [Serializable]
    public class WeaponProperties
    {
        /// <summary>
        /// creates a new instance of weapon properties
        /// </summary>
        public WeaponProperties() 
        {
            _rustAccumulator = 0;
        }

        /// <summary>
        /// the base weapon damage
        /// </summary>
        public int BaseWeaponDamage { get; set; }

        /// <summary>
        /// Condition
        /// </summary>
        public int Condition { get; set; }

        /// <summary>
        /// The maximum condiation or health for this weapon.
        /// </summary>
        public int MaxCondition { get; set; }

        /// <summary>
        /// Rusted
        /// </summary>
        public int RustAccumulator
        {
            get { return _rustAccumulator; }
            set 
            {
                // not all materials rust
                if (WeaponMaterial.HasFlag(Material.Iron) ||
                    WeaponMaterial.HasFlag(Material.Steel))
                    _rustAccumulator = value;
            }
        }

        // assumulates rust
        private int _rustAccumulator;

        /// <summary>
        /// The material this weapon is made out of.
        /// </summary>
        public Material WeaponMaterial { get; set; }

        /// <summary>
        /// Is this weapon below the condition threshold.
        /// </summary>
        public bool Broken
        {
            get 
            {
                return (Util.Percent(Condition, MaxCondition) 
                    < CONDITION_THRESHOLD);
            }
        }

        /// <summary>
        /// percentage points
        /// </summary>
        const int CONDITION_THRESHOLD = 5;
    }
}
