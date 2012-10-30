using DotNetHack.Serialization;
using DotNetHack.Shared.Objects;
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
            MetaEntity.Load();

            toolStripDropDownButtonTileSets.Image = Shared.Properties.Resources.artificial_hive;
            toolStripDropDownButtonScripts.Image = Shared.Properties.Resources.cog;

            TileSetsRootNode = treeViewMain.Nodes[KeyTileSets];

            MetaEntity.MetaEntities.ForEach(AddEntityToToolStrip);
        }

        /// <summary>
        /// AddEntityToToolStrip
        /// <remarks>will add the entity to the appropriate toolstrip</remarks>
        /// </summary>
        /// <param name="entity">entity</param>
        private void AddEntityToToolStrip(MetaEntity entity) 
        {
            switch (entity.MetaEntityType)
            {
                case MetaEntityType.TileSet:
                    AddNewMenuItemFromEntity(toolStripDropDownButtonTileSets, entity);
                    break;
            }
        }

        /// <summary>
        /// MakeMenuItemFromEntity
        /// </summary>
        /// <param name="parent">the parent dropdown button</param>
        /// <param name="entity">the entity to add</param>
        private void AddNewMenuItemFromEntity(ToolStripDropDownButton parent, MetaEntity entity)
        {
            ToolStripMenuItem retVal = new ToolStripMenuItem(entity.FileName, parent.Image);

            retVal.Click += (object innerSender, EventArgs innerArgs) =>
            {
                OpenEntity(entity);
            };

            parent.DropDownItems.Add(retVal);
        }

        /// <summary>
        /// OpenEntity
        /// </summary>
        private void OpenEntity(MetaEntity entity)
        {
            Form tmpForm = null;
            switch (entity.MetaEntityType)
            {
                case MetaEntityType.TileSet:
                    tmpForm = new TileSetEditor(entity);
                    break;
            }

            flowLayoutPanelEditorMain.Controls.Add(tmpForm);
            tmpForm.Show();
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
        /// MainForm_FormClosing
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MetaEntity.Save();
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

        /// <summary>
        /// tileSetToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void tileSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// treeViewMain_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewMain_MouseClick(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// treeViewMain_MouseDoubleClick
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void treeViewMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

            }
        }

        private void splitContainerEditorMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
