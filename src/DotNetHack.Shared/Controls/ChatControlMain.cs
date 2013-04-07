using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetHack.Shared.Components;

namespace DotNetHack.Shared.Controls
{
    /// <summary>
    /// ChatControlMain
    /// </summary>
    [ToolboxItem(true)]
    public partial class ChatControlMain : UserControl
    {
        /// <summary>
        /// ChatControlMain
        /// </summary>
        public ChatControlMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ChatControlMain_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatControlMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// AddChannel
        /// </summary>
        public void AddChannel(string channel)
        {
            TabPage tmpTabPage = new TabPage(channel);
            tmpTabPage.Controls.Add(new ChatChannel(channel) { Dock = DockStyle.Fill });
            tabControlChat.TabPages.Add(tmpTabPage);
        }

        /// <summary>
        /// RemoveChannel
        /// </summary>
        public void RemoveChannel(string channel)
        {
        }

        /// <summary>
        /// generalToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChannel("General");
        }

        /// <summary>
        /// tabControlChat_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ChatControlMain_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatControlMain_DoubleClick(object sender, EventArgs e)
        {
            contextMenuStrip.Show(this, 0, 0);
        }

        /// <summary>
        /// removeToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlChat.TabPages.Remove(tabControlChat.SelectedTab);
        }
    }
}
