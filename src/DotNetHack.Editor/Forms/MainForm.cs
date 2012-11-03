using DotNetHack.Serialization;
using DotNetHack.Shared.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            toolStripDropDownButtonMaps.Image = Shared.Properties.Resources.globe;

            TileSetsRootNode = treeViewMain.Nodes[KeyTileSets];
            ScriptsRootNode = treeViewMain.Nodes[KeyScripts];

            openFileDialogPak.InitialDirectory = Shared.R.DataFullPath;
            saveFileDialogPak.InitialDirectory = Shared.R.DataFullPath;

            if (!Editor.TryLoadLastPackage())
                Editor.CurrentPackage = new Package();

            //MetaEntity.MetaEntities.ForEach(AddEntityToToolStrip);
            //MetaEntity.MetaEntities.ForEach(AddEntityToTree);

            // add reference to the main form.
            Editor.MainForm = this;
        }

        /// <summary>
        /// AddEntityToTree
        /// </summary>
        /// <param name="entity"></param>
        private void AddEntityToTree(MetaEntity entity)
        {
            string tmpEntityName = Path.GetFileName(entity.FileName);
            switch (entity.MetaEntityType)
            {
                case MetaEntityType.TileSet:
                    TileSetsRootNode.Nodes.Add(tmpEntityName);
                    break;
                case MetaEntityType.Map:              
                    break;
                case MetaEntityType.Script:
                    ScriptsRootNode.Nodes.Add(tmpEntityName);
                    break;
            }
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
                case MetaEntityType.Script:
                    AddNewMenuItemFromEntity(toolStripDropDownButtonScripts, entity);
                    break;
                case MetaEntityType.Map:
                    AddNewMenuItemFromEntity(toolStripDropDownButtonMaps, entity);
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
                    // tmpForm = new TileSetEditor(entity);
                    break;
            }

            OpenForm(tmpForm);
        }

        /// <summary>
        /// OpenForm
        /// </summary>
        /// <param name="tmpForm"></param>
        public void OpenForm(Form tmpForm)
        {
            tmpForm.TopLevel = false;
            flowLayoutPanelEditorMain.Controls.Add(tmpForm);
            tmpForm.FormClosing += tmpForm_FormClosing;
            tmpForm.Show();
        }

        /// <summary>
        /// tmpForm_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tmpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Editor.SaveLastSavedPackage();
            toolStripStatusLabelMain.Text = "Pak Updated " + DateTime.Now.ToShortTimeString();
        }

        #region Various References to TreeNodes

        /// <summary>
        /// TileSetsNode
        /// </summary>
        TreeNode TileSetsRootNode = null;

        /// <summary>
        /// ScriptsRootNode
        /// </summary>
        TreeNode ScriptsRootNode = null;

        #endregion

        #region Constants

        /// <summary>
        /// KeyTileSets
        /// </summary>
        const string KeyTileSets = "NodeTileSets";

        /// <summary>
        /// KeyScripts
        /// </summary>
        const string KeyScripts = "NodeScripts";

        #endregion

        /// <summary>
        /// MainForm_FormClosing
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Editor.SaveLastSavedPackage();
            //MetaEntity.Save();
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


        /// <summary>
        /// toolStripDropDownButtonTileSets_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void toolStripDropDownButtonTileSets_DoubleClick(object sender, EventArgs e)
        {
            OpenForm(new TileSetEditor());
        }

        /// <summary>
        /// newToolStripMenuItemNewScript_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void newToolStripMenuItemNewScript_Click(object sender, EventArgs e)
        {
            OpenForm(new ScriptEditor());
        }

        /// <summary>
        /// toolStripDropDownButtonScripts_DoubleClick
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void toolStripDropDownButtonScripts_DoubleClick(object sender, EventArgs e)
        {
            OpenForm(new ScriptEditor());
        }

        /// <summary>
        /// newMapToolStripMenuItemNewMap_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void newMapToolStripMenuItemNewMap_Click(object sender, EventArgs e)
        {
            OpenForm(new MapEditor());
        }

        /// <summary>
        /// openToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogPak.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Editor.LoadPackage(openFileDialogPak.FileName);
            }
        }

        /// <summary>
        /// saveToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogPak.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Editor.SavePackage(saveFileDialogPak.FileName);
            }
        }

        /// <summary>
        /// toolStripDropDownButtonTileSets_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void toolStripDropDownButtonTileSets_Click(object sender, EventArgs e)
        {
            OpenForm(new TileSetEditor());
        }
    }
}
