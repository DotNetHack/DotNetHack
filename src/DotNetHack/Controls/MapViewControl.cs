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
using DotNetHack.Resources;
using DotNetHack.Engine.Interfaces;

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
        public MapViewControl(IGameEngineController aController)
        {
            Controller = aController;
            InitializeComponent();
        }

        /// <summary>
        /// Controller
        /// </summary>
        IGameEngineController Controller { get; set; }

        /// <summary>
        /// panelMapView_Paint
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event arguments</param>
        private void panelMapView_Paint(object sender, PaintEventArgs e)
        {
            int size_t = Properties.Settings.Default.TileSize;
            panelMapView.CreateGraphics().DrawImage(R.GetTile(1, 1), 0, 0);
        }
    }
}
