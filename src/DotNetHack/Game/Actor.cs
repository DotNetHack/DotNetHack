using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Events;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items;
using DotNetHack.Game.Effects;
using System.Xml.Serialization;

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
            EffectStack = new Stack<Effect>();

            // The actors stats.
            Stats = new Stats();
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
        public Stack<Effect> EffectStack { get; set; }

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
        /// RegenerateMagika
        /// </summary>
        public abstract void RegenerateMagika();

        /// <summary>
        /// RegenerateHealth
        /// </summary>
        public abstract void RegenerateHealth();
    }


    public class StatRegen
    {
        public StatRegen() { RegenTicks = 0; }
        void Regen(int aSpeed, ref Stats s, Func<Stats, Stats> r)
        {
            if (++RegenTicks > aSpeed)
            {
                s = r(s);
                Reset();
            }
        }

        void Reset() { RegenTicks = 0; }

        int RegenTicks { get; set; }
    }
}