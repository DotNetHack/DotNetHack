using DotNetGUI;
using DotNetGUI.Interfaces;
using DotNetHack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.UserInterface
{
    /// <summary>
    /// GUIModel
    /// </summary>
    public class GUIModel
    {
        /// <summary>
        /// SubstrateDisplayModel
        /// </summary>
        public SubstrateDisplayModel SubstrateDisplayModel { get; private set; }

        /// <summary>
        /// GUIModel
        /// </summary>
        /// <param name="displayOrderer"></param>
        public GUIModel(Widget parent, GameModel displayOrderer)
        {
            _viewDimensions = parent.Size;

            SubstrateDisplayModel = new SubstrateDisplayModel(displayOrderer.Substrate);
        }

        /// <summary>
        /// The viewport dimensions
        /// </summary>
        private readonly IDimensional _viewDimensions;
    }
}
