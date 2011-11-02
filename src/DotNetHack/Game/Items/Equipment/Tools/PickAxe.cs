using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Tools
{
    /// <summary>
    /// PickAxe
    /// </summary>
    public class PickAxe : Tool
    {
        /// <summary>
        /// PickAxe
        /// </summary>
        public PickAxe() 
            : base("Pick Axe", '√', Colour.Silver)
        { }

        /// <summary>
        /// Use
        /// </summary>
        public override void Use()
        {

        }

        public override void Apply(Interfaces.IItem[] items)
        {
            
        }
    }
}
