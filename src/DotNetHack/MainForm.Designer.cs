
using DotNetHack.Shared.Components;
namespace DotNetHack
{
    partial class MainForm
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
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageInventory = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.inventoryViewControl = new DotNetHack.Shared.Controls.InventoryViewControl();
            this.mapViewControlMain = new DotNetHack.Shared.Controls.MapViewControl();
            this.chatControlMain = new DotNetHack.Shared.Controls.ChatControlMain();
            this.dnhClient = new DotNetHack.Shared.Components.DNHClientComponent();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 390);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(913, 22);
            this.statusStripMain.TabIndex = 0;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(913, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(913, 366);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageInventory);
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(244, 366);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageInventory
            // 
            this.tabPageInventory.Controls.Add(this.inventoryViewControl);
            this.tabPageInventory.Location = new System.Drawing.Point(4, 22);
            this.tabPageInventory.Name = "tabPageInventory";
            this.tabPageInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInventory.Size = new System.Drawing.Size(236, 340);
            this.tabPageInventory.TabIndex = 0;
            this.tabPageInventory.Text = "Inventory";
            this.tabPageInventory.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(236, 340);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Equipment";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.mapViewControlMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chatControlMain);
            this.splitContainer2.Size = new System.Drawing.Size(665, 366);
            this.splitContainer2.SplitterDistance = 297;
            this.splitContainer2.TabIndex = 0;
            // 
            // inventoryViewControl
            // 
            this.inventoryViewControl.AllowDrop = true;
            this.inventoryViewControl.AutoScroll = true;
            this.inventoryViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryViewControl.Location = new System.Drawing.Point(3, 3);
            this.inventoryViewControl.Name = "inventoryViewControl";
            this.inventoryViewControl.Size = new System.Drawing.Size(230, 334);
            this.inventoryViewControl.TabIndex = 0;
            // 
            // mapViewControlMain
            // 
            this.mapViewControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewControlMain.Location = new System.Drawing.Point(0, 0);
            this.mapViewControlMain.Name = "mapViewControlMain";
            this.mapViewControlMain.Size = new System.Drawing.Size(665, 297);
            this.mapViewControlMain.TabIndex = 1;
            // 
            // chatControlMain
            // 
            this.chatControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatControlMain.Location = new System.Drawing.Point(0, 0);
            this.chatControlMain.Name = "chatControlMain";
            this.chatControlMain.Size = new System.Drawing.Size(665, 65);
            this.chatControlMain.TabIndex = 0;
            // 
            // dnhClient
            // 
            this.dnhClient.HostName = "localhost";
            this.dnhClient.Port = 9090;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 412);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "DotNetHack";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageInventory.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DNHClientComponent dnhClient;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageInventory;
        private System.Windows.Forms.TabPage tabPage1;
        private Shared.Controls.InventoryViewControl inventoryViewControl;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Shared.Controls.MapViewControl mapViewControlMain;
        private Shared.Controls.ChatControlMain chatControlMain;
    }
}

