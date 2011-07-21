using System;
using System.Collections.Generic;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items
{
    /// <summary>
    /// ItemCollection
    ///    Is a specialized collection of items that offerrs up
    ///    various enumerators for just about any occasion.
    /// </summary>
    public class ItemCollection : ICollection<IItem>
    {
        /// <summary>
        /// Items, this is the core list of items in the collection.
        /// <remarks>Use this if you want to get everything!</remarks>
        /// </summary>
        public List<IItem> Items { get; set; }

        /// <summary>
        /// Add the item to the collection.
        /// </summary>
        /// <param name="item">The item to add to the item collection.</param>
        public void Add(IItem item) { Items.Add(item); }

        /// <summary>
        /// Creates a new instance of item collection.
        /// </summary>
        public ItemCollection() { Items = new List<IItem>(); }

        /// <summary>
        /// All potions in this item collection.
        /// </summary>
        public IEnumerable<IPotion> Potions
        {
            get
            {
                return (IEnumerable<IPotion>)
                    ItemFilter(x => x.ItemType == ItemType.Potion);
            }
        }

        /// <summary>
        /// All weapons in this item collection.
        /// </summary>
        public IEnumerable<IWeapon> Weapons
        {
            get
            {
                return (IEnumerable<IWeapon>)
                    ItemFilter(x => x.ItemType == ItemType.Weapon);
            }
        }

        /// <summary>
        /// All armour in this item collection.
        /// </summary>
        public IEnumerable<IArmor> Armor
        {
            get
            {
                return (IEnumerable<IArmor>)
                    ItemFilter(x => x.ItemType == ItemType.Armor);
            }
        }

        /// <summary>
        /// All scrolls in this item collection.
        /// </summary>
        public IEnumerable<IScroll> Scrolls
        {
            get
            {
                return (IEnumerable<IScroll>)
                    ItemFilter(x => x.ItemType == ItemType.Scroll);
            }
        }

        /// <summary>
        /// All tools in this item collection.
        /// </summary>
        public IEnumerable<ITool> Tools
        {
            get
            {
                return (IEnumerable<ITool>)
                    ItemFilter(x => x.ItemType == ItemType.Tool);
            }
        }

        /// <summary>
        /// All tomes in this item collection.
        /// </summary>
        public IEnumerable<ITome> Tomes
        {
            get
            {
                return (IEnumerable<ITome>)
                    ItemFilter(x => x.ItemType == ItemType.Tome);
            }
        }

        /// <summary>
        /// All keys in this item collection.
        /// </summary>
        public IEnumerable<IKey> Keys
        {
            get
            {
                return (IEnumerable<IKey>)
                    ItemFilter(x => x.ItemType == ItemType.Key);
            }
        }

        /// <summary>
        /// All food in this item collection.
        /// </summary>
        public IEnumerable<IFood> Food
        {
            get 
            {
                return (IEnumerable<IFood>)
                    ItemFilter(x => x.ItemType == ItemType.Food);
            }
        }

        /// <summary>
        /// All Equipment in this item collection.
        /// </summary>
        public IEnumerable<IEquipment> Equipment
        {
            get
            {
                return (IEnumerable<IEquipment>)
                    ItemFilter(x => x.ItemType == ItemType.Armor ||
                    x.ItemType == ItemType.Weapon);
            }
        }

        /// <summary>
        /// ItemFilter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns>An enumerable list of items, depending on the lam</returns>
        IEnumerable<IItem> ItemFilter(Func<IItem, bool> aFilter)
        {
            foreach (var iItem in Items)
                if (aFilter(iItem))
                    yield return iItem;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear() { Items.Clear(); }

        /// <summary>
        /// Contains, if the passed item is in the collection.
        /// </summary>
        /// <param name="item">Is this item in the collection.</param>
        /// <returns>true if the item is in the collection.</returns>
        public bool Contains(IItem item) { return Items.Contains(item); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(IItem[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Count, the number of items in the collection.
        /// </summary>
        public int Count { get { return Items.Count; } }

        /// <summary>
        /// IsReadOnly
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="item">The item to remove from the item collection</param>
        /// <returns>true on success</returns>
        public bool Remove(IItem item) { return Items.Remove(item); }

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IItem> GetEnumerator() { return Items.GetEnumerator(); }

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator 
            System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }

        
    }
}