namespace DotNetHack.Editor.Controls
{
    partial class ScriptEditorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxCodeSet = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxCodeSet
            // 
            this.richTextBoxCodeSet.Location = new System.Drawing.Point(155, 109);
            this.richTextBoxCodeSet.Name = "richTextBoxCodeSet";
            this.richTextBoxCodeSet.Size = new System.Drawing.Size(100, 96);
            this.richTextBoxCodeSet.TabIndex = 0;
            this.richTextBoxCodeSet.Text = "";
            // 
            // ScriptEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxCodeSet);
            this.Name = "ScriptEditorControl";
            this.Size = new System.Drawing.Size(571, 448);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCodeSet;
    }
}
