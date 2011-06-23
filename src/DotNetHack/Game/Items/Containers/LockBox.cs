using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Containers
{
    /// <summary>
    /// LockBox
    /// </summary>
    public class LockBox : LootContainer
    {
        /// <summary>
        /// LockBox
        /// </summary>
        /// <param name="aIsLocked">Is this lockbox actually locked?</param>
        public LockBox(bool aIsLocked, Location aLocation)
            : base("lockbox") 
        {
            IsLocked = aIsLocked;
            Location = aLocation;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item"></param>
        public override void Add(IItem item)
        {
            base.Add(item);
        }

        /// <summary>
        /// IsLocked
        /// </summary>
        public bool IsLocked { get; set; }
    }
}
