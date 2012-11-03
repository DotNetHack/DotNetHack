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
using System.IO;
using DotNetHack.Engine.Scripting;
using DotNetHack.Serialization;

namespace DotNetHack.Editor.Forms
{
    /// <summary>
    /// ScriptEditor
    /// </summary>
    public partial class ScriptEditor : Form
    {
        /// <summary>
        /// 
        /// </summary>
        static ScriptEditor()
        {

        }

        /// <summary>
        /// Creates a new ScriptEditor
        /// </summary>
        public ScriptEditor()
        {
            InitializeComponent();

            openFileDialogScriptEditor.InitialDirectory = Shared.R.ScriptFullPath;
            saveFileDialogScriptEditor.InitialDirectory = Shared.R.ScriptFullPath;
        }

        /// <summary>
        /// Creates a new ScriptEditor tied to the associated file.
        /// </summary>
        /// <param name="fileName">the file name to create this script editor with</param>
        public ScriptEditor(MetaEntity entity)
            : this()    // be sure to get init component in there.
        {
            CurrentScriptEntity = entity;
        }

        /// <summary>
        /// ScriptEditor_Load
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void ScriptEditor_Load(object sender, EventArgs e)
        {
            Text = CurrentScriptEntity.FileName;
        }

        /// <summary>
        /// CurrentScriptEntity
        /// </summary>
        public MetaEntity CurrentScriptEntity;

        /// <summary>
        /// newToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentScriptEntity.FileName = Path.Combine(Shared.R.ScriptFullPath, Path.GetTempFileName());
            CurrentScriptEntity.Saved = false;
        }

        /// <summary>
        /// saveToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogScriptEditor.FileName = Path.GetFileName(CurrentScriptEntity.FileName);
            saveFileDialogScriptEditor.SaveEntity(ref CurrentScriptEntity);
            using (FileStream tmpWriteStream = File.Open(CurrentScriptEntity.FileName, FileMode.OpenOrCreate))
            using (TextWriter tmpWriter = new StreamWriter(tmpWriteStream))
            {
                tmpWriter.Write(richTextBoxScriptEditorMain.Text);
            }
        }

        /// <summary>
        /// saveAsToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentScriptEntity.Saved = false;
            saveFileDialogScriptEditor.SaveEntity(ref CurrentScriptEntity);

            //CurrentScript.Write(CurrentScriptEntity.FileName);
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
        /// ScriptEditor_FormClosing
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void ScriptEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            CurrentScriptEntity.CloseForm(sender, e);
        }

        /// <summary>
        /// openToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogScriptEditor.LoadEntity(ref CurrentScriptEntity))
            {
                using (StreamReader tmpStream = File.OpenText(CurrentScriptEntity.FileName))
                {
                    richTextBoxScriptEditorMain.Text = tmpStream.ReadToEnd();
                }
            }
        }
    }
}
