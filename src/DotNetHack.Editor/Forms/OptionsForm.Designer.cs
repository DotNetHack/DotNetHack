namespace DotNetHack.Editor.Forms
{
    partial class OptionsForm
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
            this.groupBoxEntities = new System.Windows.Forms.GroupBox();
            this.buttonOkay = new System.Windows.Forms.Button();
            this.labelEntitiesPath = new System.Windows.Forms.Label();
            this.textBoxEntities = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogEntities = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxEntities.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEntities
            // 
            this.groupBoxEntities.Controls.Add(this.textBoxEntities);
            this.groupBoxEntities.Controls.Add(this.labelEntitiesPath);
            this.groupBoxEntities.Location = new System.Drawing.Point(12, 12);
            this.groupBoxEntities.Name = "groupBoxEntities";
            this.groupBoxEntities.Size = new System.Drawing.Size(494, 58);
            this.groupBoxEntities.TabIndex = 0;
            this.groupBoxEntities.TabStop = false;
            this.groupBoxEntities.Text = "Entities Information";
            // 
            // buttonOkay
            // 
            this.buttonOkay.Location = new System.Drawing.Point(414, 76);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(75, 23);
            this.buttonOkay.TabIndex = 1;
            this.buttonOkay.Text = "Okay";
            this.buttonOkay.UseVisualStyleBackColor = true;
            this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
            // 
            // labelEntitiesPath
            // 
            this.labelEntitiesPath.AutoSize = true;
            this.labelEntitiesPath.Location = new System.Drawing.Point(24, 27);
            this.labelEntitiesPath.Name = "labelEntitiesPath";
            this.labelEntitiesPath.Size = new System.Drawing.Size(102, 13);
            this.labelEntitiesPath.TabIndex = 0;
            this.labelEntitiesPath.Text = "Global Entities Path:";
            // 
            // textBoxEntities
            // 
            this.textBoxEntities.Location = new System.Drawing.Point(132, 24);
            this.textBoxEntities.Name = "textBoxEntities";
            this.textBoxEntities.Size = new System.Drawing.Size(332, 20);
            this.textBoxEntities.TabIndex = 1;
            this.textBoxEntities.DoubleClick += new System.EventHandler(this.textBoxEntities_DoubleClick);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.buttonOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 107);
            this.ControlBox = false;
            this.Controls.Add(this.buttonOkay);
            this.Controls.Add(this.groupBoxEntities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.groupBoxEntities.ResumeLayout(false);
            this.groupBoxEntities.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEntities;
        private System.Windows.Forms.Button buttonOkay;
        private System.Windows.Forms.Label labelEntitiesPath;
        private System.Windows.Forms.TextBox textBoxEntities;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogEntities;
    }
}