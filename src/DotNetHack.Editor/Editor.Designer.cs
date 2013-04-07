namespace DotNetHack.Editor
{
    partial class Editor
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Tile Set");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("DNH", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.splitContainerEditorMain = new System.Windows.Forms.SplitContainer();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageToolbox = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelEditorMain = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripProgressBarEditorMain = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStripEditorMain = new System.Windows.Forms.StatusStrip();
            this.menuStripEditorMain = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vIEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPagePAK = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditorMain)).BeginInit();
            this.splitContainerEditorMain.Panel1.SuspendLayout();
            this.splitContainerEditorMain.Panel2.SuspendLayout();
            this.splitContainerEditorMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.statusStripEditorMain.SuspendLayout();
            this.menuStripEditorMain.SuspendLayout();
            this.tabPagePAK.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerEditorMain
            // 
            this.splitContainerEditorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEditorMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerEditorMain.Name = "splitContainerEditorMain";
            // 
            // splitContainerEditorMain.Panel1
            // 
            this.splitContainerEditorMain.Panel1.Controls.Add(this.tabControlMain);
            // 
            // splitContainerEditorMain.Panel2
            // 
            this.splitContainerEditorMain.Panel2.Controls.Add(this.flowLayoutPanelEditorMain);
            this.splitContainerEditorMain.Size = new System.Drawing.Size(674, 387);
            this.splitContainerEditorMain.SplitterDistance = 203;
            this.splitContainerEditorMain.TabIndex = 2;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageToolbox);
            this.tabControlMain.Controls.Add(this.tabPagePAK);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(203, 387);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageToolbox
            // 
            this.tabPageToolbox.Location = new System.Drawing.Point(4, 22);
            this.tabPageToolbox.Name = "tabPageToolbox";
            this.tabPageToolbox.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageToolbox.Size = new System.Drawing.Size(195, 361);
            this.tabPageToolbox.TabIndex = 0;
            this.tabPageToolbox.Text = "Toolbox";
            this.tabPageToolbox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelEditorMain
            // 
            this.flowLayoutPanelEditorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelEditorMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelEditorMain.Name = "flowLayoutPanelEditorMain";
            this.flowLayoutPanelEditorMain.Size = new System.Drawing.Size(467, 387);
            this.flowLayoutPanelEditorMain.TabIndex = 0;
            // 
            // toolStripProgressBarEditorMain
            // 
            this.toolStripProgressBarEditorMain.Name = "toolStripProgressBarEditorMain";
            this.toolStripProgressBarEditorMain.Size = new System.Drawing.Size(100, 16);
            // 
            // statusStripEditorMain
            // 
            this.statusStripEditorMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarEditorMain,
            this.toolStripStatusLabel});
            this.statusStripEditorMain.Location = new System.Drawing.Point(0, 411);
            this.statusStripEditorMain.Name = "statusStripEditorMain";
            this.statusStripEditorMain.Size = new System.Drawing.Size(674, 22);
            this.statusStripEditorMain.TabIndex = 1;
            this.statusStripEditorMain.Text = "statusStrip1";
            // 
            // menuStripEditorMain
            // 
            this.menuStripEditorMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.eDITToolStripMenuItem,
            this.vIEWToolStripMenuItem});
            this.menuStripEditorMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripEditorMain.Name = "menuStripEditorMain";
            this.menuStripEditorMain.Size = new System.Drawing.Size(674, 24);
            this.menuStripEditorMain.TabIndex = 0;
            this.menuStripEditorMain.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fILEToolStripMenuItem.Text = "File";
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.eDITToolStripMenuItem.Text = "Edit";
            // 
            // vIEWToolStripMenuItem
            // 
            this.vIEWToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapEditorToolStripMenuItem,
            this.tileMappingToolStripMenuItem});
            this.vIEWToolStripMenuItem.Name = "vIEWToolStripMenuItem";
            this.vIEWToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.vIEWToolStripMenuItem.Text = "View";
            // 
            // mapEditorToolStripMenuItem
            // 
            this.mapEditorToolStripMenuItem.CheckOnClick = true;
            this.mapEditorToolStripMenuItem.Name = "mapEditorToolStripMenuItem";
            this.mapEditorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mapEditorToolStripMenuItem.Text = "Map Editor";
            this.mapEditorToolStripMenuItem.Click += new System.EventHandler(this.mapEditorToolStripMenuItem_Click);
            // 
            // tileMappingToolStripMenuItem
            // 
            this.tileMappingToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tileMappingToolStripMenuItem.Name = "tileMappingToolStripMenuItem";
            this.tileMappingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tileMappingToolStripMenuItem.Text = "Tile Mapping";
            this.tileMappingToolStripMenuItem.Click += new System.EventHandler(this.tileMappingToolStripMenuItem_Click);
            // 
            // tabPagePAK
            // 
            this.tabPagePAK.Controls.Add(this.treeView1);
            this.tabPagePAK.Location = new System.Drawing.Point(4, 22);
            this.tabPagePAK.Name = "tabPagePAK";
            this.tabPagePAK.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePAK.Size = new System.Drawing.Size(195, 361);
            this.tabPagePAK.TabIndex = 1;
            this.tabPagePAK.Text = "PAK";
            this.tabPagePAK.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode3.Name = "NodeTileSet";
            treeNode3.Text = "Tile Set";
            treeNode3.ToolTipText = "The tileset for this PAK";
            treeNode4.Name = "root";
            treeNode4.Text = "DNH";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(189, 355);
            this.treeView1.TabIndex = 0;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 433);
            this.Controls.Add(this.splitContainerEditorMain);
            this.Controls.Add(this.statusStripEditorMain);
            this.Controls.Add(this.menuStripEditorMain);
            this.MainMenuStrip = this.menuStripEditorMain;
            this.Name = "Editor";
            this.Text = "DNH Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Editor_Load);
            this.splitContainerEditorMain.Panel1.ResumeLayout(false);
            this.splitContainerEditorMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditorMain)).EndInit();
            this.splitContainerEditorMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.statusStripEditorMain.ResumeLayout(false);
            this.statusStripEditorMain.PerformLayout();
            this.menuStripEditorMain.ResumeLayout(false);
            this.menuStripEditorMain.PerformLayout();
            this.tabPagePAK.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerEditorMain;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageToolbox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEditorMain;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarEditorMain;
        private System.Windows.Forms.StatusStrip statusStripEditorMain;
        private System.Windows.Forms.MenuStrip menuStripEditorMain;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vIEWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileMappingToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPagePAK;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;

    }
}

