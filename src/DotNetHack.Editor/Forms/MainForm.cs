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
        /// MainForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Utility.RecentTileSetMappings().ForEach((string s) => 
            {
                ToolStripMenuItem tmpNewMenuItem = new ToolStripMenuItem(s);
                tmpNewMenuItem.Click += (object innerSender, EventArgs innerArgs) => 
                {
                    OpenTileSetEditor(s);
                };
                contextMenuStripTileSet.Items.Add(tmpNewMenuItem);
            });                   
        }

        /// <summary>
        /// OpenTileSetEditor
        /// </summary>
        /// <param name="fileName"></param>
        private void OpenTileSetEditor(string fileName = "")
        {
            Form frmTileSetEditor = string.IsNullOrEmpty(fileName) ?
                new TileSetEditor() : new TileSetEditor(fileName);
            flowLayoutPanelEditorMain.Controls.Add(frmTileSetEditor);
            frmTileSetEditor.Show();
        }

        /// <summary>
        /// treeViewMain_AfterSelect
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
