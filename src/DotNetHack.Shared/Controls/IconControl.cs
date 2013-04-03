using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Shared.Controls
{
    /// <summary>
    /// IconControl
    /// </summary>
    public partial class IconControl : UserControl
    {
        /// <summary>
        /// IconControl
        /// </summary>
        public IconControl()
            : this(0, 0)
        {

        }

        /// <summary>
        /// IconControl
        /// </summary>
        public IconControl(int xCoord, int yCoord)
        {
            InitializeComponent();
            TilesetCoordX = xCoord;
            TilesetCoordY = yCoord;
            pictureBoxImage.Image = Util.GetTile(Properties.Resources.X11tiles_32_32, TilesetCoordX, TilesetCoordY);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            

            base.OnPaint(e);
        }

        /// <summary>
        /// TilesetCoordX
        /// </summary>
        public int TilesetCoordX
        {
            get { return xCoord; }
            set 
            {
                if (xCoord != value)
                {
                    xCoord = value;

                    pictureBoxImage.Image = Util.GetTile(Properties.Resources.X11tiles_32_32, TilesetCoordX, TilesetCoordY);
                }
            }
        }

        /// <summary>
        /// TilesetCoordY
        /// </summary>
        public int TilesetCoordY
        {
            get { return yCoord; }
            set 
            {
                if (yCoord != value)
                {
                    yCoord = value;

                    pictureBoxImage.Image = Util.GetTile(Properties.Resources.X11tiles_32_32, TilesetCoordX, TilesetCoordY);
                }
            }
        }

        /// <summary>
        /// The x-coordinate for the tile
        /// </summary>
        private int xCoord;

        /// <summary>
        /// The y-coordinate for the tile
        /// </summary>
        private int yCoord;
    }
}
