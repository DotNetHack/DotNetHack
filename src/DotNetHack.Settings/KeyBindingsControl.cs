using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetHack.Settings;

namespace DotNetHack.Options
{
    /// <summary>
    /// KeyBindingsControl
    /// </summary>
    [ToolboxItem(true)]
    public partial class KeyBindingsControl : UserControl, IComponent
    {
        /// <summary>
        /// KeyBindings
        /// </summary>
        public SettingsKeyBindings KeyBindings { get; set; }

        /// <summary>
        /// KeyBindingsControl
        /// </summary>
        public KeyBindingsControl()
        {
            KeyBindings = new SettingsKeyBindings();
            InitializeComponent();
            propertyGridKeyBindings.SelectedObject = KeyBindings;
        }


        /// <summary>
        /// buttonOkay_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            KeyBindings.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertyGridKeyBindings_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try 
            {
                KeyBindings.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + (ex.InnerException != null ? "; " + ex.InnerException.Message : ""));
            }
        }
    }
}
