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
            this.components = new System.ComponentModel.Container();
            this.splitContainerInventoryPanel = new System.Windows.Forms.SplitContainer();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelInventory = new System.Windows.Forms.FlowLayoutPanel();
            this.iconControl1 = new DotNetHack.Shared.Controls.IconControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInventoryPanel)).BeginInit();
            this.splitContainerInventoryPanel.Panel1.SuspendLayout();
            this.splitContainerInventoryPanel.Panel2.SuspendLayout();
            this.splitContainerInventoryPanel.SuspendLayout();
            this.flowLayoutPanelInventory.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerInventoryPanel
            // 
            this.splitContainerInventoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerInventoryPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerInventoryPanel.IsSplitterFixed = true;
            this.splitContainerInventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.splitContainerInventoryPanel.Name = "splitContainerInventoryPanel";
            this.splitContainerInventoryPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerInventoryPanel.Panel1
            // 
            this.splitContainerInventoryPanel.Panel1.Controls.Add(this.textBoxFilter);
            this.splitContainerInventoryPanel.Panel1MinSize = 20;
            // 
            // splitContainerInventoryPanel.Panel2
            // 
            this.splitContainerInventoryPanel.Panel2.Controls.Add(this.flowLayoutPanelInventory);
            this.splitContainerInventoryPanel.Panel2MinSize = 20;
            this.splitContainerInventoryPanel.Size = new System.Drawing.Size(302, 301);
            this.splitContainerInventoryPanel.SplitterDistance = 25;
            this.splitContainerInventoryPanel.TabIndex = 0;
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
            this.flowLayoutPanelInventory.Controls.Add(this.iconControl1);
            this.flowLayoutPanelInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInventory.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelInventory.Name = "flowLayoutPanelInventory";
            this.flowLayoutPanelInventory.Size = new System.Drawing.Size(302, 272);
            this.flowLayoutPanelInventory.TabIndex = 1;
            this.flowLayoutPanelInventory.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelInventory_Paint);
            // 
            // iconControl1
            // 
            this.iconControl1.AllowDrop = true;
            this.iconControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconControl1.Location = new System.Drawing.Point(3, 3);
            this.iconControl1.Name = "iconControl1";
            this.iconControl1.Size = new System.Drawing.Size(30, 30);
            this.iconControl1.TabIndex = 0;
            this.iconControl1.TilesetCoordX = 0;
            this.iconControl1.TilesetCoordY = 1;
            // 
            // InventoryViewControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.splitContainerInventoryPanel);
            this.DoubleBuffered = true;
            this.Name = "InventoryViewControl";
            this.Size = new System.Drawing.Size(302, 301);
            this.Load += new System.EventHandler(this.InventoryViewControl_Load);
            this.splitContainerInventoryPanel.Panel1.ResumeLayout(false);
            this.splitContainerInventoryPanel.Panel1.PerformLayout();
            this.splitContainerInventoryPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInventoryPanel)).EndInit();
            this.splitContainerInventoryPanel.ResumeLayout(false);
            this.flowLayoutPanelInventory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerInventoryPanel;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInventory;
        private IconControl iconControl1;

    }
}
