using DotNetHack.Core.Game.World;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Editor
{
    /// <summary>
    /// MapEditor
    /// </summary>
    public partial class MapEditor : Form
    {
        /// <summary>
        /// MapEditor
        /// </summary>
        public MapEditor()
        {
            InitializeComponent();

            mapViewControl.MapViewLocation = new Location(Properties.Settings.Default.X, 
                Properties.Settings.Default.Y, Properties.Settings.Default.Z);
        }

        /// <summary>
        /// MapEditor_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapEditor_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapViewControl_LocationChangedEvent(object sender, Shared.Events.LocationChangedEventArgs e)
        {
            toolStripStatusLabelLocation.Text = e.Location.ToString();
        }
    }
}
