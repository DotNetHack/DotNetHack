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
    /// ScriptEditorControl
    /// </summary>
    [ToolboxItem(true)]
    public partial class ScriptEditorControl : UserControl, IContainerControl
    {
        /// <summary>
        /// ScriptEditorControl
        /// </summary>
        public ScriptEditorControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ScriptEditorControl_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void ScriptEditorControl_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// richTextBoxCodeSet_TextChanged
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void richTextBoxCodeSet_TextChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// ScriptEditorControl_KeyUp
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void ScriptEditorControl_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
