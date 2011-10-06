using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Items.Herbs;

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

        public override void Apply(Interfaces.IItem[] items)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Occurs when the mortar and pestle is "used".
        /// </summary>
        public override void Use()
        {
            
        }
    }
}
