using DotNetHack.Core.Game.Tiles;
using DotNetHack.Core.Game.World;
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
    /// TileEditor
    /// TODO: 
    /// </summary>
    public partial class TileEditor : Form
    {
        /// <summary>
        /// TileEditor
        /// </summary>
        public TileEditor()
        {
            InitializeComponent();
            TileMapping = new TileMapping();
            ImageCache = new Dictionary<Point, Image>();
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

            int xTile = Math.Abs((tmpOffset.X - MousePosition.X) / tileSize);
            int yTile = Math.Abs((tmpOffset.Y - MousePosition.Y) / tileSize);

            CurrentTile = new EditorTile(xTile, yTile);

            UpdateImage(CurrentTile);
            UpdateTileProperties(CurrentTile);
        }

        /// <summary>
        /// UpdateTileProperties();
        /// </summary>
        private void UpdateTileProperties(EditorTile tile)
        {
            UpdateImage(tile);
            
            propertyGridMain.SelectedObject = tile;
            propertyGridMain.Refresh();
        }

        private void UpdateImage(EditorTile tile)
        {
            Point tmpPoint = new Point(tile.X, tile.Y);
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
                            TileMapping.Save(saveFileDialog.FileName);
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

            if (TileMapping.Mapping.Contains(tmpMappedTile))
            {
                TileMapping.MappedTile tmpLookupTile = TileMapping.Mapping.Single(t => t.Equals(tmpMappedTile));

                // overwrite
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
        EditorTile CurrentTile { get; set; }

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
            AddUpdateMapping(new TileMapping.MappedTile()
            {
                Name = CurrentTile.Name,
                Tile = CurrentTile.Tile,
                X = CurrentTile.X,
                Y = CurrentTile.Y,
            });

            UpdateListBox();
        }

        private void UpdateListBox()
        {
            listBoxMapping.Items.Clear();
            listBoxMapping.Items.AddRange(TileMapping.Mapping.ToArray());
        }

        /// <summary>
        /// buttonRemoveMapping_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveMapping_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved)
            {
                switch (MessageBox.Show("Save your work?","DotNetHack Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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
                CurrentTile = new EditorTile(((TileMapping.MappedTile)(listBoxMapping.SelectedItem)));
                UpdateTileProperties(CurrentTile);
                UpdateImage(CurrentTile);

                listBoxMapping.Refresh();
            }
        }
    }

    /// <summary>
    /// EditorTile
    /// 
    /// TODO: 
    /// Make a decision about using full out wrappers w/o subclassing 
    /// -- or -- 
    /// adding attributes directly to game objects.
    /// </summary>
    [DefaultPropertyAttribute("Name")]
    public class EditorTile
    {
        /// <summary>
        /// EditorTile
        /// </summary>
        /// <param name="x">x-mapping coord</param>
        /// <param name="y">y-mapping coord</param>
        public EditorTile(int x, int y)
        {
            MappedTile = new TileMapping.MappedTile()
            {
                Tile = new Tile(),
                Name = "",
                X = x,
                Y = y,
            };
        }

        /// <summary>
        /// EditorTile
        /// </summary>
        /// <param name="mappedTile">mapped tile</param>
        public EditorTile(TileMapping.MappedTile mappedTile)
        {
            MappedTile = mappedTile;
        }

        /// <summary>
        /// <see cref="TileMapping.MappedTile"/> backing store.
        /// </summary>
        private TileMapping.MappedTile MappedTile { get; set; }

        /// <summary>
        /// Get the mapped <see cref="Tile"/>
        /// </summary>
        public Tile Tile { get { return MappedTile.Tile; } }

        /// <summary>
        /// Flags
        /// </summary>
        [CategoryAttribute("Tile Flags")]
        [DescriptionAttribute("Set the flags for this tile.")]
        public Tile.TileFlags Flags { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [CategoryAttribute("Tile Flags")]
        [DescriptionAttribute("The type of tile this is.")]
        public Tile.TileType Type { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [CategoryAttribute("Tile Name")]
        [DescriptionAttribute("The name of this specific tile.")]
        public string Name { get; set; }

        /// <summary>
        /// X-Mapping Coord
        /// </summary>
        [CategoryAttribute("Tileset Mapping")]
        public int X { get { return MappedTile.X; } }

        /// <summary>
        /// Y-Mapping Coord
        /// </summary>
        [CategoryAttribute("Tileset Mapping")]
        public int Y { get { return MappedTile.Y; } }
    }
}
