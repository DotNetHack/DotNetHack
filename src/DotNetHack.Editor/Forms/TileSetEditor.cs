using DotNetHack.Core.Game.Tiles;
using DotNetHack.Core.Game.World;
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
    /// TileSetEditor
    /// </summary>
    public partial class TileSetEditor : Form
    {
        /// <summary>
        /// TileSetEditor
        /// </summary>
        public TileSetEditor()
        {
            InitializeComponent();

            if (Editor.CurrentPackage.TileMapping == null)
                Editor.CurrentPackage.TileMapping = new Shared.Objects.TileMapping();

            OriginalFormTitle = Text;
            TopLevel = false;
        }

        /// <summary>
        /// CurrentOffset
        /// </summary>
        Point CurrentOffset = new Point();

        /// <summary>
        /// CurrentTile
        /// <remarks>This tile may or may not be mapped & saved.</remarks>
        /// </summary>
        TileMapping.MappedTile CurrentTile { get; set; }

        /// <summary>
        /// TileMapping
        /// </summary>
        TileMapping TileMapping
        {
            get { return Editor.CurrentPackage.TileMapping; }
        }

        /// <summary>
        /// OriginalFormTitle
        /// </summary>
        readonly string OriginalFormTitle;

        /// <summary>
        /// UpdateTileProperties();
        /// </summary>
        private void UpdateTileProperties(TileMapping.MappedTile tile)
        {
            UpdateImage(CurrentTile);

            propertyGridMain.SelectedObject = CurrentTile;
            propertyGridMain.Refresh();
        }

        /// <summary>
        /// UpdateImage
        /// </summary>
        /// <param name="tile">tile</param>
        private void UpdateImage(TileMapping.MappedTile mappedTile)
        {
            pictureBoxSecondary.Image = Shared.R.GetTileImageFromMapping(
                Editor.CurrentPackage.TileMapping,
                mappedTile);
        }

        /// <summary>
        /// AddUpdateMapping();
        /// </summary>
        private void AddUpdateMapping(TileMapping.MappedTile tmpMappedTile)
        {
            if (TileMapping.Mapping.Contains(tmpMappedTile))
            {
                TileMapping.MappedTile tmpLookupTile =
                    TileMapping.Mapping.Single(t => t.Equals(tmpMappedTile));
                tmpLookupTile = tmpMappedTile;
            }
            else { TileMapping.Mapping.Add(tmpMappedTile); }
        }

        /// <summary>
        /// TileEditor_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void TileEditor_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Shared.Properties.Settings.Default.TileSetImagePath) &&
                string.IsNullOrEmpty(Shared.Properties.Settings.Default.TileSetImagePath))
                SaveUpdateTileSetPath();

            UpdateTileSetTextBoxAndImage();
            UpdateListBox();
        }

        /// <summary>
        /// UpdateStatus
        /// </summary>
        private void UpdateStatus(string frmt, params object[] argv)
        {
            toolStripStatusLabel.Text = string.Format(frmt, argv);
        }

        /// <summary>
        /// UpdateTileSetTextBoxAndImage
        /// </summary>
        private void UpdateTileSetTextBoxAndImage()
        {
            textBoxTileSetPath.Text = Shared.Properties.Settings.Default.TileSetImagePath;
            TileMapping.TileSetPath = Shared.Properties.Settings.Default.TileSetImagePath;
     
            pictureBoxMain.Image = Image.FromFile(Shared.Properties.Settings.Default.TileSetImagePath);

            pictureBoxMain.Width = pictureBoxMain.Image.Width * 2;
            pictureBoxMain.Height = pictureBoxMain.Image.Height * 2;

            CurrentOffset = new Point();
        }

        /// <summary>
        /// SaveUpdateTileSetPath
        /// </summary>
        private void SaveUpdateTileSetPath()
        {
            if (openFileDialogTileSetImage.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Shared.Properties.Settings.Default.TileSetImagePath = openFileDialogTileSetImage.FileName;
                Shared.Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// buttonAddMapping_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void buttonAddMapping_Click(object sender, EventArgs e)
        {
            AddUpdateMapping(CurrentTile);
            UpdateTileProperties(CurrentTile);
            UpdateListBox();
        }

        /// <summary>
        /// UpdateListBox
        /// </summary>
        private void UpdateListBox()
        {
            listBoxMapping.Items.Clear();
            listBoxMapping.Items.AddRange(TileMapping.Mapping.ToArray());
        }

        /// <summary>
        /// buttonRemoveMapping_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void buttonRemoveMapping_Click(object sender, EventArgs e)
        {
            RemoveSelectedMapping();
            UpdateListBox();
        }

        /// <summary>
        /// RemoveSelectedMapping
        /// </summary>
        private void RemoveSelectedMapping()
        {
            TileMapping.Mapping.Remove(SelectedMapping);
        }

        /// <summary>
        /// The currently selected mapping.
        /// </summary>
        TileMapping.MappedTile SelectedMapping
        {
            get 
            {
                return (TileMapping.MappedTile)listBoxMapping.SelectedItem;
            }
        }

        /// <summary>
        /// listBoxMapping_SelectedIndexChanged
        /// <remarks>Shows the newly selected tile.</remarks>
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void listBoxMapping_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMapping.SelectedItem != null)
            {
                CurrentTile = (TileMapping.MappedTile)listBoxMapping.SelectedItem;

                UpdateTileProperties(CurrentTile);
                UpdateImage(CurrentTile);

                listBoxMapping.Refresh();
            }
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
        /// toolStripMenuItemRemove_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void toolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            RemoveSelectedMapping();
        }

        /// <summary>
        /// listBoxMapping_MouseDoubleClick
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void listBoxMapping_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    contextMenuStripTileSet.Show(listBoxMapping, e.Location);
                    break;
            }
        }

        /// <summary>
        /// textBoxTileSetPath_MouseDoubleClick
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void textBoxTileSetPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SaveUpdateTileSetPath();
            UpdateTileSetTextBoxAndImage();
        }

        /// <summary>
        /// pictureBoxMain_Move
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void pictureBoxMain_Move(object sender, EventArgs e)
        {
            CurrentOffset = pictureBoxMain.Location;
        }

        /// <summary>
        /// pictureBoxMain_Paint
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void pictureBoxMain_Paint(object sender, PaintEventArgs e) { }

        /// <summary>
        /// openInBeastiaryToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void createActorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmpMappedTile = (TileMapping.MappedTile)listBoxMapping.SelectedItem;
            new ActorEditor();
        }

        /// <summary>
        /// pictureBoxMain_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pictureBoxMain_Click(object sender, EventArgs e)
        {
            int tileSize = Shared.Properties.Settings.Default.TileSize;
            Point tmpOffset = pictureBoxMain.PointToScreen(pictureBoxMain.Location);

            tmpOffset.X += Math.Abs(CurrentOffset.X);
            tmpOffset.Y += Math.Abs(CurrentOffset.Y);

            int xTile = Math.Abs((tmpOffset.X - MousePosition.X) / tileSize);
            int yTile = Math.Abs((tmpOffset.Y - MousePosition.Y) / tileSize);

            CurrentTile = new TileMapping.MappedTile(xTile, yTile, Tile.TileType.None);

            UpdateImage(CurrentTile);
            UpdateTileProperties(CurrentTile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weaponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ItemEditor(CurrentTile).Show();
        }
    }
}
