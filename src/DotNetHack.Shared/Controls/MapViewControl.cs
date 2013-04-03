using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Controls
{
    /// <summary>
    /// MapViewControl
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxItemFilter("Map", ToolboxItemFilterType.Custom)]
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapViewControl_Load(object sender, EventArgs e)
        {

        }

        public void Render()
        {
            using (var buffered = BufferedGraphicsManager.Current.Allocate(CreateGraphics(), DisplayRectangle))
            {
                for (var y = 0; y < Height; y += 32)
                {
                    buffered.Graphics.DrawLine(new Pen(Color.White), 0, y, Width, y);
                }

                for (var x = 0; x < Width; x += 32)
                {
                    buffered.Graphics.DrawLine(new Pen(Color.White), x, 0, x, Height);
                }

                // Create string to draw.
                const string drawString = "Sample Text";
                var drawFont = new Font("Arial", 16);
                var drawBrush = new SolidBrush(Color.White);

                // Set format of string.
                var drawFormat = new StringFormat { FormatFlags = StringFormatFlags.DirectionVertical };

                // Draw string to screen.
                buffered.Graphics.DrawString(drawString, drawFont, drawBrush, 10, 10, drawFormat);

                buffered.Render();
                buffered.Render(CreateGraphics());
            }
        }

        private void MapViewControl_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
