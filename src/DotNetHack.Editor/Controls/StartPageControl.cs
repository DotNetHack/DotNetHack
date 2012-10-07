using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Editor.Controls
{
    /// <summary>
    /// StartPageControl
    /// </summary>
    public partial class StartPageControl : UserControl
    {
        /// <summary>
        /// StartPageControl
        /// </summary>
        public StartPageControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// StartPageControl_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void StartPageControl_Load(object sender, EventArgs e)
        {
            webBrowser.Url = new Uri(Properties.Settings.Default.StartPageURL);
        }
    }
}
