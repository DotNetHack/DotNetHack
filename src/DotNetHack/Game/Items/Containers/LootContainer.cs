using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Items;

namespace DotNetHack.Game.Interfaces
{
    /// <summary>
    /// LootContainer
    /// </summary>
    public abstract class LootContainer : Item
    {
        /// <summary>
        /// LootContainer
        /// </summary>
        public LootContainer(string aName)
            : base(aName, '[', Colour.DarkRed)
        {
            Items = new List<IItem>();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(IItem item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Clear
        /// </summary>
        protected virtual void Clear() { Items.Clear(); }

        /// <summary>
        /// Remove
        /// </summary>
        public virtual void Remove(IItem item) { Items.Remove(item); }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(IItem item) { return Items.Contains(item); }

        /// <summary>
        /// Count
        /// </summary>
        public int Count { get { return Items.Count; } }

        /// <summary>
        /// Items
        /// </summary>
        protected List<IItem> Items { get; set; }
    }
}
