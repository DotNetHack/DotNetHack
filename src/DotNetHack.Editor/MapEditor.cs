using DotNetHack.Controls;
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
            _mapViewControl = new MapViewControl() { Dock = DockStyle.Fill };
            _mapViewControl.Scroll += _mapViewControl_Scroll;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _mapViewControl_Scroll(object sender, ScrollEventArgs e)
        {
            var vector = new Point(0, 0);
            switch (e.ScrollOrientation)
            {
                case ScrollOrientation.HorizontalScroll:
                    vector.X = e.OldValue - e.NewValue;
                    break;
                case ScrollOrientation.VerticalScroll:
                    vector.Y = e.OldValue - e.NewValue;
                    break;
            }

            _mapViewControl.X += vector.X;
            _mapViewControl.Y += vector.Y;

            toolStripStatusLabelLocation.Text = string.Format("({0},{1})", _mapViewControl.X, _mapViewControl.Y);
            toolStripStatusLabelLocation.Invalidate();

        }

        /// <summary>
        /// MapEditor_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapEditor_Load(object sender, EventArgs e)
        {
            Controls.Add(_mapViewControl);
        }

        /// <summary>
        /// _mapViewControl
        /// </summary>
        MapViewControl _mapViewControl;
    }
}
