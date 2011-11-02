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
    public class MortarAndPestle : AlchemyEquipment
    {
        /// <summary>
        /// MortarAndPestle
        /// </summary>
        public MortarAndPestle(double m)
            : base("Mortar & Pestle", new Glyph('ü', Colour.Standard),
            m, 0.0, 0.0, 0.0)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
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
