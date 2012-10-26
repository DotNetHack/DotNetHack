using DotNetHack.Core.Game.Tiles;
using DotNetHack.Core.Game.World;
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
    /// TileEditor
    /// TODO: 
    /// </summary>
    public partial class TileEditor : Form
    {
        /// <summary>
        /// TileEditor
        /// </summary>
        TileEditor()
        {
            InitializeComponent();
            TileMapping = new TileMapping();
            ImageCache = new Dictionary<Point, Image>();

        }

        /// <summary>
        /// _instance
        /// </summary>
        static readonly TileEditor _instance = new TileEditor();

        /// <summary>
        /// Instance
        /// </summary>
        public static TileEditor Instance { get { return _instance; } }

        /// <summary>
        /// pictureBoxMain_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pictureBoxMain_Click(object sender, EventArgs e)
        {
            int tileSize = Shared.Properties.Settings.Default.TileSize;
            Point tmpOffset = pictureBoxMain.PointToScreen(pictureBoxMain.Location);

            int xTile = Math.Abs((tmpOffset.X - MousePosition.X) / tileSize);
            int yTile = Math.Abs((tmpOffset.Y - MousePosition.Y) / tileSize);

            // CurrentTile = new EditorTile(xTile, yTile, CurrentTile);
            CurrentTile = new TileMapping.MappedTile(xTile, yTile, Tile.TileType.None);

            UpdateImage(CurrentTile);
            UpdateTileProperties(CurrentTile);
        }

        /// <summary>
        /// UpdateTileProperties();
        /// </summary>
        private void UpdateTileProperties(TileMapping.MappedTile tile)
        {
            UpdateImage(tile);

            propertyGridMain.SelectedObject = tile;
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
                        try
                        {
                            TileMapping.Save(TileMapping, saveFileDialog.FileName);
                            toolStripStatusLabel.Text = string.Format("Saved: {0}", openFileDialog.FileName);

                            Saved = true;

                            UpdateListBox();
                        }
                        catch (Exception ex)
                        {
                            toolStripStatusLabel.Text = ex.Message;
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// AddUpdateMapping();
        /// </summary>
        private void AddUpdateMapping(TileMapping.MappedTile tmpMappedTile)
        {
            Saved = false;

            if (listBoxMapping.Items.Contains(tmpMappedTile))
            {

            }
            else
            {

            }

            if (TileMapping.Mapping.Contains(tmpMappedTile))
            {
                TileMapping.MappedTile tmpLookupTile =
                    TileMapping.Mapping.Single(t => t.Equals(tmpMappedTile));
                tmpLookupTile = tmpMappedTile;
            }
            else
            {
                TileMapping.Mapping.Add(tmpMappedTile);
            }
        }

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
        /// TileEditor_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void TileEditor_Load(object sender, EventArgs e)
        {
            pictureBoxMain.Image = Shared.Properties.Resources.X11tiles_32_32;
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
                        try
                        {
                            TileMapping.Load(openFileDialog.FileName, out TileMapping);
                            toolStripStatusLabel.Text = string.Format("Loaded: {0}", openFileDialog.FileName);

                            UpdateListBox();
                        }
                        catch (Exception ex)
                        {
                            toolStripStatusLabel.Text = ex.Message;
                        }

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
                // CurrentTile = new EditorTile(((TileMapping.MappedTile)(listBoxMapping.SelectedItem)));

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
                    contextMenuStripAddRemove.Show(this, e.Location);
                    break;
            }
        }
    }
}
