using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Items
{
    /// <summary>
    /// Item
    /// </summary>
    [Serializable]
    public abstract class Item
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}
