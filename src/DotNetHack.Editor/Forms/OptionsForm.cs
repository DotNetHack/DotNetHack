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
    /// OptionsForm
    /// </summary>
    public partial class OptionsForm : Form
    {
        /// <summary>
        /// OptionsForm
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// textBoxEntities_DoubleClick
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void textBoxEntities_DoubleClick(object sender, EventArgs e)
        {
            var tmpReturn = folderBrowserDialogEntities.ShowDialog();
            if (tmpReturn == System.Windows.Forms.DialogResult.OK)
            {
                textBoxDatPath.Text = folderBrowserDialogEntities.SelectedPath;
            }
        }

        /// <summary>
        /// OptionsForm_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            textBoxDatPath.Text = Shared.R.DataFullPath;
        }

        /// <summary>
        /// OptionsForm_FormClosing
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Shared.R.DataFullPath = textBoxDatPath.Text;
        }

        /// <summary>
        /// buttonOkay_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
