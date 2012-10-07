using DotNetHack.Editor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Editor.Forms
{
    /// <summary>
    /// EditorForm
    /// </summary>
    public partial class EditorForm : Form
    {
        /// <summary>
        /// EditorForm
        /// </summary>
        public EditorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// EditorForm_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void EditorForm_Load(object sender, EventArgs e)
        {
            TabPage startTabPage = new TabPage("Start Page");
            startTabPage.Controls.Add(
                new StartPageControl()
                {
                    Dock = DockStyle.Fill,
                });
            tabControlMain.TabPages.Add(startTabPage);
        }

        /// <summary>
        /// treeViewEditorMain_AfterSelect
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void treeViewEditorMain_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
