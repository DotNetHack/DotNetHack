using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DotNetHack.Core;

namespace DotNetHack.Forms
{
    /// <summary>
    /// MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MainForm_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event argument</param>
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// helpToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event argument</param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm frmAboutBox = new AboutForm())
                frmAboutBox.ShowDialog(this);
        }

        /// <summary>
        /// editorToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Editor.Forms.EditorForm frmEditor = new Editor.Forms.EditorForm())
                frmEditor.ShowDialog();
        }
    }
}
