using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack
{
    /// <summary>
    /// MapViewControl
    /// </summary>
    public partial class MapViewControl : UserControl
    {
        /// <summary>
        /// MapViewControl
        /// </summary>
        public MapViewControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MapViewControl_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void MapViewControl_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e">event args</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
