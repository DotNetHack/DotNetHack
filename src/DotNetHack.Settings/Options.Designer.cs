namespace DotNetHack.Options
{
    /// <summary>
    /// 
    /// </summary>
    partial class Options
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.keyBindingsControl = new DotNetHack.Options.KeyBindingsControl();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabControlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.keyBindingsControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Key Bindings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // keyBindingsControl
            // 
            this.keyBindingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyBindingsControl.Location = new System.Drawing.Point(3, 3);
            this.keyBindingsControl.Name = "keyBindingsControl";
            this.keyBindingsControl.Size = new System.Drawing.Size(270, 229);
            this.keyBindingsControl.TabIndex = 0;
            this.keyBindingsControl.Load += new System.EventHandler(this.keyBindingsControl_Load);
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.tabPage1);
            this.tabControlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOptions.Location = new System.Drawing.Point(0, 0);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(284, 261);
            this.tabControlOptions.TabIndex = 0;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabControlOptions);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabControlOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControlOptions;
        private KeyBindingsControl keyBindingsControl;

    }
}