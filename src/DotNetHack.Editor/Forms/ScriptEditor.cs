using DotNetHack.Editor.Objects;
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
    /// ScriptEditor
    /// </summary>
    public partial class ScriptEditor : Form
    {
        /// <summary>
        /// Creates a new ScriptEditor
        /// </summary>
        public ScriptEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new ScriptEditor tied to the associated file.
        /// </summary>
        /// <param name="fileName">the file name to create this script editor with</param>
        public ScriptEditor(string fileName)
            : this()    // be sure to get init component in there.
        {
            CurrentScriptEntity = new EditorEntity(fileName);
        }

        /// <summary>
        /// ScriptEditor_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void ScriptEditor_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// CurrentScriptEntity
        /// </summary>
        EditorEntity CurrentScriptEntity { get; set; }
    }
}
