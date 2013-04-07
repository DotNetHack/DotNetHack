using DotNetHack.Editor.Forms;
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
        /// The instance of the map editor.
        /// </summary>
        MapEditor mapEditor;

        /// <summary>
        /// The instance of the tileset editor
        /// </summary>
        TileSetEditor tileSetEditor;

        /// <summary>
        /// Editor
        /// </summary>
        public Editor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Editor_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void Editor_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// mapEditorToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapEditor == null)
            {
                mapEditor = new MapEditor() { Visible = true, TopLevel = false };

                mapEditor.FormClosed += delegate
                {
                    mapEditorToolStripMenuItem.Checked = false;
                    mapEditor = null;
                };
            }

            if (mapEditorToolStripMenuItem.Checked)
            {
                flowLayoutPanelEditorMain.Controls.Add(mapEditor);
            }
            else if (flowLayoutPanelEditorMain.Controls.Contains(mapEditor))
            {
                flowLayoutPanelEditorMain.Controls.Remove(mapEditor);
                mapEditor.Close();
            }
        }

        /// <summary>
        /// tileMappingToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tileSetEditor == null)
            {
                toolStripStatusLabel.Text = "Initializing tileset editor ...";
                tileSetEditor = new TileSetEditor() { Visible = true, TopLevel = false  };
                tileSetEditor.FormClosed += delegate 
                {
                    tileMappingToolStripMenuItem.Checked = false;
                    tileSetEditor = null;
                };
            }

            if (!tileMappingToolStripMenuItem.Checked)
            {
                tileMappingToolStripMenuItem.Checked = true;
                flowLayoutPanelEditorMain.Controls.Add(tileSetEditor);
                
            }
            else if (flowLayoutPanelEditorMain.Controls.Contains(tileSetEditor))
            {
                flowLayoutPanelEditorMain.Controls.Remove(tileSetEditor);
                tileSetEditor.Close();
            }
        }
    }
}
