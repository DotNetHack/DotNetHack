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
using DotNetHack.Core.Game.World;

namespace DotNetHack.Shared.Controls
{
    /// <summary>
    /// MapViewControl
    /// </summary>
    [ToolboxItem(true)]
    [Description("DotNetHack MapView Control")]
    public partial class MapViewControl : UserControl, IComponent
    {
        /// <summary>
        /// MapViewControl
        /// </summary>
        public MapViewControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// panelMapView_Paint
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event arguments</param>
        private void panelMapView_Paint(object sender, PaintEventArgs e)
        {
            //int size_t = Properties.Settings.Default.TileSize;
            //panelMapView.CreateGraphics().DrawImage(R.GetTile(1, 1), 0, 0);
            var size_t = Shared.Properties.Settings.Default.TileSize;
            var g = panelMapView.CreateGraphics();
            for (int x = 0; x < this.Width; x += size_t)
            {
                for (int y = 0; y < this.Height; y += size_t)
                {

                }
            }
        }
    }
}
