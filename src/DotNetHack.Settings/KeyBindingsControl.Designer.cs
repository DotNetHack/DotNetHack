namespace DotNetHack.Options
{
    partial class KeyBindingsControl
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
            this.splitContainerKeyBindings = new System.Windows.Forms.SplitContainer();
            this.propertyGridKeyBindings = new System.Windows.Forms.PropertyGrid();
            this.buttonOkay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerKeyBindings)).BeginInit();
            this.splitContainerKeyBindings.Panel1.SuspendLayout();
            this.splitContainerKeyBindings.Panel2.SuspendLayout();
            this.splitContainerKeyBindings.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerKeyBindings
            // 
            this.splitContainerKeyBindings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerKeyBindings.Location = new System.Drawing.Point(0, 0);
            this.splitContainerKeyBindings.Name = "splitContainerKeyBindings";
            this.splitContainerKeyBindings.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerKeyBindings.Panel1
            // 
            this.splitContainerKeyBindings.Panel1.Controls.Add(this.propertyGridKeyBindings);
            // 
            // splitContainerKeyBindings.Panel2
            // 
            this.splitContainerKeyBindings.Panel2.Controls.Add(this.buttonOkay);
            this.splitContainerKeyBindings.Size = new System.Drawing.Size(231, 212);
            this.splitContainerKeyBindings.SplitterDistance = 178;
            this.splitContainerKeyBindings.TabIndex = 1;
            // 
            // propertyGridKeyBindings
            // 
            this.propertyGridKeyBindings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridKeyBindings.Location = new System.Drawing.Point(0, 0);
            this.propertyGridKeyBindings.Name = "propertyGridKeyBindings";
            this.propertyGridKeyBindings.Size = new System.Drawing.Size(231, 178);
            this.propertyGridKeyBindings.TabIndex = 1;
            this.propertyGridKeyBindings.Click += new System.EventHandler(this.propertyGridKeyBindings_Click);
            // 
            // buttonOkay
            // 
            this.buttonOkay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOkay.Location = new System.Drawing.Point(0, 0);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(231, 30);
            this.buttonOkay.TabIndex = 0;
            this.buttonOkay.Text = "Okay";
            this.buttonOkay.UseVisualStyleBackColor = true;
            this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
            // 
            // KeyBindingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerKeyBindings);
            this.Name = "KeyBindingsControl";
            this.Size = new System.Drawing.Size(231, 212);
            this.splitContainerKeyBindings.Panel1.ResumeLayout(false);
            this.splitContainerKeyBindings.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerKeyBindings)).EndInit();
            this.splitContainerKeyBindings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerKeyBindings;
        private System.Windows.Forms.PropertyGrid propertyGridKeyBindings;
        private System.Windows.Forms.Button buttonOkay;
    }
}
