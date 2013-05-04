using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.UserInterface
{
    /// <summary>
    /// SubstrateOrderer
    /// </summary>
    public class SubstrateDisplayModel : Model.ISubstrateAccessor
    {
        /// <summary>
        /// Substrate
        /// </summary>
        public Model.Substrate Substrate { get; private set; }

        /// <summary>
        /// SubstrateOrderer
        /// </summary>
        /// <param name="substrate"></param>
        public SubstrateDisplayModel(Model.Substrate substrate)
        { 
            Substrate = substrate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public DNHObject this[int x, int y, int z]
        {
            get
            {
                if (Substrate.NPCOverlay[x, y, z].Any())
                    return Substrate.NPCOverlay[x, y, z].Peek();
                else if (Substrate.ItemOverlay[x, y, z].Any())
                    return Substrate.ItemOverlay[x, y, z].Peek();
                else
                    return Substrate.MapOverlay[x, y, z];
            }
        }
    }
}
