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
    /// TileEditor
    /// TODO: 
    /// </summary>
    public partial class TileSetEditor : Form
    {
        /// <summary>
        /// TileEditor
        /// </summary>
        public TileSetEditor()
        {
            InitializeComponent();
            TileMapping = new TileMapping();
            ImageCache = new Dictionary<Point, Image>();
            TopLevel = false;
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
        private void UpdateImage(TileMapping.MappedTile tile)
        {
            Point tmpPoint = new Point(tile.XMapping, tile.YMapping);
            if (!ImageCache.ContainsKey(tmpPoint))
                ImageCache.Add(tmpPoint, Shared.R.GetTile(tmpPoint.X, tmpPoint.Y));
            pictureBoxSecondary.Image = ImageCache[tmpPoint];
        }

        /// <summary>
        /// ImageCache
        /// </summary>
        Dictionary<Point, Image> ImageCache;

        /// <summary>
        /// saveToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (saveFileDialog.ShowDialog(this))
            {
                case System.Windows.Forms.DialogResult.OK:
                    {
                        try { SaveTileSet(saveFileDialog.FileName); }
                        catch (Exception ex) { UpdateStatus(ex.Message); }

                        break;
                    }
            }
        }

        /// <summary>
        /// SaveTileSet
        /// </summary>
        /// <param name="fullPath"></param>
        private void SaveTileSet(string fullPath)
        {
            TileMapping.Save(TileMapping, fullPath);
            UpdateStatus("Saved: {0}", saveFileDialog.FileName);

            Saved = true;

            if (!Properties.Settings.Default.RecentTileSets.Contains(saveFileDialog.FileName))
                Properties.Settings.Default.RecentTileSets.Add(saveFileDialog.FileName);

            UpdateListBox();
        }

        /// <summary>
        /// AddUpdateMapping();
        /// </summary>
        private void AddUpdateMapping(TileMapping.MappedTile tmpMappedTile)
        {
            Saved = false;

            Text = "*" + Text;

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
            #region Recent TileSets

            if (Properties.Settings.Default.RecentTileSets == null)
            {
                Properties.Settings.Default.RecentTileSets = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }

            recentToolStripMenuItem.DropDownItems.Clear();
            if (Properties.Settings.Default.RecentTileSets != null)
                foreach (string s in Properties.Settings.Default.RecentTileSets)
                {
                    ToolStripMenuItem tmpNewMenuItem = new ToolStripMenuItem(s);
                    tmpNewMenuItem.Click += (object senderInner, EventArgs eInner) => { LoadTileSet(s); };
                    recentToolStripMenuItem.DropDownItems.Add(tmpNewMenuItem);
                }

            #endregion

            if (!File.Exists(Shared.Properties.Settings.Default.TileSetPath) &&
                string.IsNullOrEmpty(Shared.Properties.Settings.Default.TileSetPath))
                SaveUpdateTileSetPath();
            UpdateTileSetTextBoxAndImage();
        }

        /// <summary>
        /// LoadTileSet
        /// </summary>
        /// <param name="fullPath"></param>
        private void LoadTileSet(string fullPath)
        {
            TileMapping.Load(fullPath, out TileMapping);
            UpdateStatus("Loaded: {0}", fullPath);
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
            textBoxTileSetPath.Text = Shared.Properties.Settings.Default.TileSetPath;
            pictureBoxMain.Image = Image.FromFile(Shared.Properties.Settings.Default.TileSetPath);
            pictureBoxMain.Width = pictureBoxMain.Image.Width * 2;
            pictureBoxMain.Height = pictureBoxMain.Image.Height * 2;
            CurrentOffset = new Point();
        }

        /// <summary>
        /// SaveUpdateTileSetPath
        /// </summary>
        private void SaveUpdateTileSetPath()
        {
            if (openFileDialogTileSet.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Shared.Properties.Settings.Default.TileSetPath = openFileDialogTileSet.FileName;
                Shared.Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// loadToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (openFileDialog.ShowDialog())
            {
                case System.Windows.Forms.DialogResult.OK:
                    {
                        LoadTileSet(openFileDialog.FileName);
                        break;
                    }
            }
        }

        /// <summary>
        /// buttonAddMapping_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddMapping_Click(object sender, EventArgs e)
        {
            AddUpdateMapping(CurrentTile);
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
            UpdateListBox();
        }

        /// <summary>
        /// TileEditor_FormClosing
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void TileEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved)
            {
                switch (MessageBox.Show("Save your work?", "DotNetHack Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        e.Cancel = true;
                        saveToolStripMenuItem_Click(sender, e);
                        break;
                }
            }
        }

        /// <summary>
        /// listBoxMapping_SelectedIndexChanged
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
            if (listBoxMapping.SelectedItem != null)
                listBoxMapping.Items.Remove(listBoxMapping.SelectedItem);
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
                    contextMenuStripTileSet.Show(this, e.Location);
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
        /// pictureBoxMain_Paint
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void pictureBoxMain_Paint(object sender, PaintEventArgs e) { }

        /// <summary>
        /// CurrentOffset
        /// </summary>
        Point CurrentOffset = new Point();

        /// <summary>
        /// CurrentTile
        /// </summary>
        TileMapping.MappedTile CurrentTile { get; set; }

        /// <summary>
        /// TileMapping
        /// </summary>
        TileMapping TileMapping;

        /// <summary>
        /// Saved
        /// <remarks>Set to false within AddUpdateMapping</remarks>
        /// </summary>
        bool Saved = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxMain_Move(object sender, EventArgs e)
        {
            CurrentOffset = pictureBoxMain.Location;
        }
    }
}
