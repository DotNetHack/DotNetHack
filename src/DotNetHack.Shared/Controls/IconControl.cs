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
    /// InventoryItemControl
    /// </summary>
    public partial class IconControl : UserControl
    {
        /// <summary>
        /// InventoryItemControl
        /// </summary>
        public IconControl(int xCoord, int yCoord)
        {
            InitializeComponent();

            pictureBoxImage.Image = Util.GetTile(xCoord, yCoord);
        }
    }
}
