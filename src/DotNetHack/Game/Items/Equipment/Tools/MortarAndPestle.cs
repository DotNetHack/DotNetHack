using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Tools
{
    /// <summary>
    /// MortarAndPestle
    /// </summary>
    public class MortarAndPestle : Tool
    {
        /// <summary>
        /// MortarAndPestle
        /// </summary>
        public MortarAndPestle()
            : base("MortarAndPestle", 'ü', Colour.Standard)
        { }

        /// <summary>
        /// Occurs when the mortar and pestle is applied to a collection 
        /// of items. (usually herbs)
        /// </summary>
        /// <param name="items">A collection of items</param>
        public override void Apply(Interfaces.IItem[] items)
        {

        }

        /// <summary>
        /// Occurs when the mortar and pestle is "used".
        /// </summary>
        public override void Use()
        {
            
        }
    }
}
