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
    /// InventoryViewControl
    /// </summary>
    [ToolboxItem(true)]
    [Description("Inventory View Control")]
    public partial class InventoryViewControl : UserControl
    {
        /// <summary>
        /// InventoryViewControl
        /// </summary>
        public InventoryViewControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// InventoryViewControl_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventoryViewControl_Load(object sender, EventArgs e)
        {
            flowLayoutPanelInventory.Controls.Add(new IconControl(0, 0) { Visible = true });   
        }

        /// <summary>
        /// flowLayoutPanelInventory_Paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowLayoutPanelInventory_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
