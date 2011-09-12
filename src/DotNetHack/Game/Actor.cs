using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Events;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items;
using DotNetHack.Game.Effects;
using System.Xml.Serialization;
using DotNetHack.Game.Items.Equipment.Armour;
using DotNetHack.Game.Items.Equipment.Weapons;

namespace DotNetHack.Game
{
    /// <summary>
    /// Actor
    /// </summary>
    [Serializable]
    public abstract class Actor : IDrawable
    {
        /// <summary>
        /// Create a new instance of Actor.
        /// </summary>
        public Actor()
        {
            // Create inventory collection for this actor.
            Inventory = new ItemCollection();

            // Active effects on this actor.
            EffectStack = new List<Effect>();

            // The actors stats.
            Stats = new Stats();

            WieldedWeapons = new WeaponsWielded();
        }

        /// <summary>
        /// Creates a new instance of <see cref="Actor"/> with the specified glyph
        /// and colour.
        /// </summary>
        public Actor(string aName, char aGlyph, Colour aColor, Location3i aLocation)
            : this()
        {
            Location = aLocation;
            Name = aName;
            G = aGlyph;
            C = aColor;
        }

        /// <summary>
        /// Location
        /// </summary>
        [XmlIgnore]
        public Location3i Location { get; set; }

        /// <summary>
        /// The name of this actor.
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Stats for this Actor
        /// </summary>
        public Stats Stats { get; set; }

        /// <summary>
        /// All actors have inventory.
        /// </summary>
        [XmlIgnore]
        public ItemCollection Inventory { get; set; }

        /// <summary>
        /// EffectStack
        /// </summary>
        [XmlIgnore]
        public List<Effect> EffectStack { get; set; }

        /// <summary>
        /// ApplyEffects
        /// </summary>
        public void ApplyEffects() 
        {
            foreach (var effect in EffectStack)
                effect.Tick(this);
            
            EffectStack.RemoveAll(e => e.Duration <= 0);
        }

        /// <summary>
        /// The glyph representing this actor.
        /// </summary>
        public virtual char G { get; set; }

        /// <summary>
        /// The colour of this actors
        /// </summary>
        public virtual Colour C { get; set; }

        /// <summary>
        /// Draw this actor.
        /// </summary>
        public void Draw() { UI.Graphics.Draw(this); }

        /// <summary>
        /// suplicant classes can add their own flavourings also.
        /// this should be called after stats have been created.
        /// </summary>
        public virtual void Initialize()
        {
            Stats.Health = Stats.HitPoints;
            WornArmour = new ArmourWorn();
            WieldedWeapons = new WeaponsWielded();
        }

        public bool Dead { get; set; }

        /// <summary>
        /// RegenerateMagika
        /// </summary>
        public virtual void RegenerateMagika()
        {
            if (++MagikaRegenTicks > (100 - (Stats.Intelligence + Stats.Wisdom)))
            {
                MagikaRegenTicks = 0;
            }
        }

        int HealthRegenTicks = 0;
        int MagikaRegenTicks = 0;

        /// <summary>
        /// RegenerateHealth
        /// </summary>
        public virtual void RegenerateHealth()
        {
            if (++HealthRegenTicks > (100 - Stats.Endurance))
            {
                HealthRegenTicks = 0;
                Stats.Health++;
            }
        }

        /// <summary>
        /// The armour that is worn by the player.
        /// </summary>
        [XmlIgnore]
        public ArmourWorn WornArmour { get; set; }

        /// <summary>
        /// the weapons currently being wielded (or sheathed) by the player.
        /// </summary>
        [XmlIgnore]
        public WeaponsWielded WieldedWeapons { get; set; }
    }
}