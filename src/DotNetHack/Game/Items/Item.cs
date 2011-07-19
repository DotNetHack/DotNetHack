using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.UI;
using System.Diagnostics;

namespace DotNetHack.Game.Items
{
    /// <summary>
    /// TileType
    /// </summary>
    public enum ItemType { Other, Potion, Currency, Key, }

    /// <summary>
    /// Item
    /// </summary>
    [DebuggerDisplay("{Name}"), Serializable]
    public abstract class Item : IItem
    {
        /// <summary>
        /// Creates a new instance of an Item
        /// </summary>
        /// <param name="aItemType">The type of item this is.</param>
        /// <param name="aName">The name of the item to create</param>
        /// <param name="aGlyph">The glyph used to represent the item on screen.</param>
        /// <param name="aColor">The color of the item.</param>
        /// <param name="aLocation">The location of the item</param>
        public Item(ItemType aItemType, string aName, char aGlyph,
            Colour aColor, Location3i aLocation)
        {
            ItemType = aItemType;       // Set the item type of this item.
            Name = aName;               // Set the name of the item
            G = aGlyph;                 // Set the glyph
            C = aColor;                 // Set the color
            Location = aLocation;       // The the location
        }

        public Item(ItemType aItemType, string aName, char aGlyph, Colour aColor)
            : this(aItemType, aName, aGlyph, aColor, null)
        { }

        /// <summary>
        /// Creates a new instance of an Item
        /// </summary>
        /// <param name="aName">The name of the item to create</param>
        /// <param name="aGlyph">The glyph used to represent the item on screen.</param>
        /// <param name="aColor">The color of the item.</param>
        /// <param name="aLocation">The location of the item</param>
        public Item(string aName, char aGlyph, Colour aColor, Location3i aLocation)
            : this(ItemType.Other, aName, aGlyph, aColor, aLocation)
        { }

        /// <summary>
        /// Item
        /// </summary>
        /// <param name="aGlyph"></param>
        /// <param name="aColor"></param>
        public Item(string aName, char aGlyph, Colour aColor)
            : this(aName, aGlyph, aColor, null)
        { }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// G
        /// </summary>
        public char G { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public Colour C { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public Location3i Location { get; set; }

        /// <summary>
        /// ItemType
        /// </summary>
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Draw
        /// </summary>
        public virtual void Draw()
        {
            Graphics.CursorToLocation(Location);
            Graphics.Draw(this);
        }
    }
}
