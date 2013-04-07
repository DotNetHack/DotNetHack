using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetHack.Core.Game.World;
using DotNetHack.Shared.Events;

namespace DotNetHack.Shared.Controls
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

        /// <summary>
        /// MapViewControl_Paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapViewControl_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        /// <summary>
        /// LocationChangedEvent
        /// </summary>
        public event EventHandler<LocationChangedEventArgs> LocationChangedEvent;

        /// <summary>
        /// Location
        /// </summary>
        public Location MapViewLocation { get; set; }

        /// <summary>
        /// MapViewControl_KeyUp
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void MapViewControl_KeyUp(object sender, KeyEventArgs e)
        {
            var oldLocation = MapViewLocation;

            switch (e.KeyData)
            {
                case Keys.Left:
                    MapViewLocation = new Location(MapViewLocation.X - 1, MapViewLocation.Y, MapViewLocation.Z);
                    break;
                case Keys.Right:
                    MapViewLocation = new Location(MapViewLocation.X + 1, MapViewLocation.Y, MapViewLocation.Z);
                    break;
                case Keys.Up:
                    MapViewLocation = new Location(MapViewLocation.X, MapViewLocation.Y - 1, MapViewLocation.Z);
                    break;
                case Keys.Down:
                    MapViewLocation = new Location(MapViewLocation.X, MapViewLocation.Y + 1, MapViewLocation.Z);
                    break;
            }

            if (LocationChangedEvent != null)
            {
                LocationChangedEvent(this, new LocationChangedEventArgs(MapViewLocation));
            }
        }
    }
}
