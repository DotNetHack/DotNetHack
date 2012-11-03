using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DotNetHack.Shared.Objects;
using DotNetHack.Core.Game.Items;
namespace DotNetHack.Editor.Forms
{
    /// <summary>
    /// ItemEditor
    /// </summary>
    public partial class ItemEditor : Form
    {
        /// <summary>
        /// ItemEditor
        /// </summary>
        public ItemEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create item editor from tile.
        /// <remarks>Be sure to leave this()</remarks>
        /// </summary>
        public ItemEditor(TileMapping.MappedTile mappedTile)
            : this()
        {
            CurrentMappedItem = new MappedObject<Item>();
            CurrentMappedItem.MappedTile = mappedTile;
            CurrentMappedItem.Object = new Item();

            pictureBoxMain.Image = Shared.R.GetTileImageFromMapping(
                Editor.CurrentPackage.TileMapping, mappedTile);

            propertyGridMain.SelectedObject = CurrentMappedItem.Object;
        }

        /// <summary>
        /// CurrentMappedItem
        /// </summary>
        MappedObject<Item> CurrentMappedItem { get; set; }

        /// <summary>
        /// CurrentItem
        /// </summary>
        Item CurrentItem { get { return CurrentMappedItem.Object; } }

        /// <summary>
        /// exitToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor.CurrentPackage.Items.Add(CurrentMappedItem);

            this.Close();
        }

        /// <summary>
        /// ItemEditor_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
