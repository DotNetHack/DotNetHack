using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items.Equipment.Armour;
using DotNetHack.Game.Events;


namespace DotNetHack.Game.Items.Equipment.Armor
{
    [Serializable]
    public class Armour : Item, IArmour, IDisposable
    {
        /// <summary>
        /// Armour
        /// </summary>
        public Armour() : base() { }

        public Armour(string aName, char aGlyph, Colour aColour, Location3i l,
            ArmourLocation aArmourLocation) 
            : base(ItemType.Armour, aName, aGlyph, aColour, l)
        {
            // set armour stats
            ArmourStats = new Armor.ArmourStats()
            {
                Condition = 100,
                Weight = 1.0, // WARNING: Add weight.
            };

            ArmourLocation = aArmourLocation;
            ArmourStats.Condition = 100;
        }

        /// <summary>
        /// OnSpellStrike
        /// </summary>
        public event EventHandler<ArmourStrikeEventArgs> OnSpellStrike;

        /// <summary>
        /// OnMeleeStrike
        /// </summary>
        public event EventHandler<ArmourStrikeEventArgs> OnMeleeStrike;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void ArmourStrike(ArmourStrikeEventArgs args)
        {
            if (OnMeleeStrike != null)
                OnMeleeStrike(this, args);
        }

        /// <summary>
        /// ArmourLocation
        /// </summary>
        public ArmourLocation ArmourLocation { get; set; }

        /// <summary>
        /// StatsBase
        /// </summary>
        public StatsBase StatsBase { get; set; }

        /// <summary>
        /// ArmourStats
        /// </summary>
        public ArmourStats ArmourStats { get; set; }

        /// <summary>
        /// The condition of this piece of armour.
        /// </summary>
        public int Condition
        {
            get { return ArmourStats.Condition; }
            set { ArmourStats.Condition = value; }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            OnSpellStrike = null;
            OnMeleeStrike = null;
        }
    }
}
