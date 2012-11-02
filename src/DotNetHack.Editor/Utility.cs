
using DotNetHack.Shared.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Editor
{
    /// <summary>
    /// Utility
    /// </summary>
    internal static class Utility
    {
        /// <summary>
        /// SaveEntity
        /// </summary>
        /// <param name="entity"></param>
        internal static void SaveEntity(this SaveFileDialog dialogue, ref MetaEntity entity)
        {
            if (!entity.Saved)
            {
                dialogue.FileName = entity.FileName;
                var tmpReturn = dialogue.ShowDialog();
                if (tmpReturn == DialogResult.OK)
                {
                    entity.FileName = dialogue.FileName;
                    entity.Saved = true;
                }
            }

            entity.LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// LoadEntity
        /// </summary>
        /// <param name="dialogue"></param>
        /// <param name="entity"></param>
        internal static void LoadEntity(this OpenFileDialog dialogue, ref MetaEntity entity)
        {
            dialogue.FileName = entity.FileName;
            var tmpReturn = dialogue.ShowDialog();
            if (tmpReturn == DialogResult.OK)
            {
                entity.FileName = dialogue.FileName;
                entity.Saved = true;
            }
            entity.LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// RecentTileSetMappings
        /// </summary>
        /// <returns></returns>
        internal static List<string> RecentTileSetMappings()
        {
            List<string> tmpReturn = new List<string>(Properties.Settings.Default.RecentTileSets.Count);

            if (Properties.Settings.Default.RecentTileSets == null)
            {
                Properties.Settings.Default.RecentTileSets = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }

            foreach (string s in Properties.Settings.Default.RecentTileSets)
                tmpReturn.Add(s);

            return tmpReturn;
        }

        /// <summary>
        /// EntityFormClose
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        internal static void CloseForm(this MetaEntity entity, object sender, FormClosingEventArgs e, Action actionYes = null)
        {
            if (!entity.Saved)
            {
                switch (MessageBox.Show("Save your work?", "DotNetHack Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        e.Cancel = true;
                        if (actionYes != null)
                            actionYes();
                        break;
                }
            }

            if (!MetaEntity.MetaEntities.Contains(entity))
                MetaEntity.MetaEntities.Add(entity);
        }
    }
}
