using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetHack.Core;

namespace DotNetHack.Controls
{
    /// <summary>
    /// MapViewControl
    /// </summary>
    [ToolboxItem(true)]
    [Description("DotNetHack MapView Control")]
    public partial class MapViewControl : UserControl
    {
        /// <summary>
        /// MapViewControl
        /// </summary>
        public MapViewControl(GameEngine.IGameEngineController controller)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Controller
        /// </summary>
        GameEngine.IGameEngineController Controller { get; set; }
    }
}
