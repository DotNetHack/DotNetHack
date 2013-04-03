namespace DotNetHack.Shared.Controls
{
    partial class InventoryViewControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelInventory = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanelInventory);
            this.splitContainer1.Size = new System.Drawing.Size(302, 301);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFilter.Location = new System.Drawing.Point(0, 0);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(302, 20);
            this.textBoxFilter.TabIndex = 0;
            // 
            // flowLayoutPanelInventory
            // 
            this.flowLayoutPanelInventory.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInventory.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelInventory.Name = "flowLayoutPanelInventory";
            this.flowLayoutPanelInventory.Size = new System.Drawing.Size(302, 272);
            this.flowLayoutPanelInventory.TabIndex = 1;
            this.flowLayoutPanelInventory.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelInventory_Paint);
            // 
            // InventoryViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "InventoryViewControl";
            this.Size = new System.Drawing.Size(302, 301);
            this.Load += new System.EventHandler(this.InventoryViewControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInventory;

    }
}
