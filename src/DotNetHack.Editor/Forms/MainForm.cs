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
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Utility.LoadRecentTileSetMappings(tilesSetToolStripMenuItem,
                delegate(string s) 
                {
                    OpenTileSetEditor(s);
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        private void OpenTileSetEditor(string fileName = "")
        {
            Form frmTileSetEditor = string.IsNullOrEmpty(fileName) ?
                new TileSetEditor() : new TileSetEditor(fileName);            
            flowLayoutPanelEditorMain.Controls.Add(frmTileSetEditor);
            frmTileSetEditor.Show();
        }
    }
}
