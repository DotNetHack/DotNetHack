using System;
using DotNetHack.Game.Items.Potions;
namespace DotNetHack.Game.Interfaces
{
    /// <summary>
    /// IPotion 
    /// </summary>
    public interface IPotion : IConsumable
    {
        /// <summary>
        /// The type of the potion
        /// </summary>
        PotionType PotionType { get; set; }

        /// <summary>
        /// The quaff
        /// </summary>
        void Quaff();
    }
}

