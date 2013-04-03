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
    /// Editor
    /// </summary>
    public partial class Editor : Form
    {
        /// <summary>
        /// Editor
        /// </summary>
        public Editor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// mapEditorToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapEditorToolStripMenuItem.Checked)
                flowLayoutPanelEditorMain.Controls.Add(_mapEditor);
            else if (flowLayoutPanelEditorMain.Controls.Contains(_mapEditor))
                flowLayoutPanelEditorMain.Controls.Remove(_mapEditor);
        }

        /// <summary>
        /// The instance of the map editor.
        /// </summary>
        MapEditor _mapEditor = new MapEditor() { Visible = true, TopLevel = false };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainerEditorMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (_mapEditor.Visible && _mapEditor.Focused)
            {
                if (flowLayoutPanelEditorMain.Controls.Contains(_mapEditor))
                {
                    flowLayoutPanelEditorMain.Controls.Remove(_mapEditor);
                    _mapEditor.WindowState = FormWindowState.Maximized;
                    flowLayoutPanelEditorMain.Controls.Remove(_mapEditor);
                }
         
            }
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }
    }
}
