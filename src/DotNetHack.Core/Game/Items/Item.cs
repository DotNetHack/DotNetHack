using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Items
{
    /// <summary>
    /// Item
    /// </summary>
    [Serializable]
    public class Item
    {
        /// <summary>
        /// Item
        /// <remarks>Supports serialization</remarks>
        /// </summary>
        public Item() { }

        /// <summary>
        /// Item
        /// </summary>
        /// <param name="type"></param>
        public Item(ItemType itemType, string name, double weight)
        {
            ItemType = itemType;
            Weight = weight;
            Name = name;
        }

        /// <summary>
        /// Name
        /// </summary>
        [CategoryAttribute("Standard Properties")]
        [DescriptionAttribute("The name of the item.")]
        public string Name { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        [CategoryAttribute("Standard Properties")]
        [DescriptionAttribute("The weight of this item.")]
        public double Weight { get; set; }

        /// <summary>
        /// ItemType
        /// </summary>
        [CategoryAttribute("Standard Properties")]
        [DescriptionAttribute("The type item this is.")]
        ItemType ItemType { get; set; }
    }
}
