using DotNetHack.Editor.Objects;
using DotNetHack.Serialization;
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
        /// <param name="e">event args</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            EditorEntity.Load(out EditorEntities);

            TileSetsRootNode = treeViewMain.Nodes[KeyTileSets];

            if (EditorEntities != null)
                foreach (var entity in EditorEntities)
                {
                    switch (entity.EditorEntityType)
                    {
                        case EditorEntityType.TileSet:
                            TileSetsRootNode.Nodes.Add(entity.FileName);
                            break;
                    }
                }

            // Utility.RecentTileSetMappings().ForEach((string s) => { });
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

        #region Various References to TreeNodes

        /// <summary>
        /// TileSetsNode
        /// </summary>
        TreeNode TileSetsRootNode = null;

        #endregion

        #region Constants

        /// <summary>
        /// KeyTileSets
        /// </summary>
        const string KeyTileSets = "NodeTileSets";

        #endregion

        /// <summary>
        /// EditorEntities
        /// </summary>
        EditorEntity[] EditorEntities = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EditorEntity.Save(ref EditorEntities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm frmOptions = new OptionsForm();
            frmOptions.ShowDialog(this);
        }
        
        /// <summary>
        /// exitToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
