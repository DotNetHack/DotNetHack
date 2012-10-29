namespace DotNetHack.Editor.Forms
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Scripts");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Quests");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Maps");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Items");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Actors");
            this.menuStripEditorMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripEditorMain = new System.Windows.Forms.StatusStrip();
            this.splitContainerEditorMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelEditorMain = new System.Windows.Forms.FlowLayoutPanel();
            this.mapViewControl1 = new DotNetHack.Shared.Controls.MapViewControl();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.menuStripEditorMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditorMain)).BeginInit();
            this.splitContainerEditorMain.Panel1.SuspendLayout();
            this.splitContainerEditorMain.Panel2.SuspendLayout();
            this.splitContainerEditorMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripEditorMain
            // 
            this.menuStripEditorMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tilesSetToolStripMenuItem,
            this.scriptEditorToolStripMenuItem});
            this.menuStripEditorMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripEditorMain.Name = "menuStripEditorMain";
            this.menuStripEditorMain.Size = new System.Drawing.Size(692, 24);
            this.menuStripEditorMain.TabIndex = 0;
            this.menuStripEditorMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // tilesSetToolStripMenuItem
            // 
            this.tilesSetToolStripMenuItem.Name = "tilesSetToolStripMenuItem";
            this.tilesSetToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.tilesSetToolStripMenuItem.Text = "&Tileset";
            // 
            // scriptEditorToolStripMenuItem
            // 
            this.scriptEditorToolStripMenuItem.Name = "scriptEditorToolStripMenuItem";
            this.scriptEditorToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.scriptEditorToolStripMenuItem.Text = "&Script Editor";
            // 
            // statusStripEditorMain
            // 
            this.statusStripEditorMain.Location = new System.Drawing.Point(0, 537);
            this.statusStripEditorMain.Name = "statusStripEditorMain";
            this.statusStripEditorMain.Size = new System.Drawing.Size(692, 22);
            this.statusStripEditorMain.TabIndex = 1;
            this.statusStripEditorMain.Text = "statusStrip1";
            // 
            // splitContainerEditorMain
            // 
            this.splitContainerEditorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEditorMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerEditorMain.Name = "splitContainerEditorMain";
            // 
            // splitContainerEditorMain.Panel1
            // 
            this.splitContainerEditorMain.Panel1.Controls.Add(this.treeViewMain);
            // 
            // splitContainerEditorMain.Panel2
            // 
            this.splitContainerEditorMain.Panel2.Controls.Add(this.flowLayoutPanelEditorMain);
            this.splitContainerEditorMain.Panel2.Controls.Add(this.mapViewControl1);
            this.splitContainerEditorMain.Size = new System.Drawing.Size(692, 513);
            this.splitContainerEditorMain.SplitterDistance = 230;
            this.splitContainerEditorMain.TabIndex = 2;
            // 
            // flowLayoutPanelEditorMain
            // 
            this.flowLayoutPanelEditorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelEditorMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelEditorMain.Name = "flowLayoutPanelEditorMain";
            this.flowLayoutPanelEditorMain.Size = new System.Drawing.Size(458, 513);
            this.flowLayoutPanelEditorMain.TabIndex = 1;
            // 
            // mapViewControl1
            // 
            this.mapViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewControl1.Location = new System.Drawing.Point(0, 0);
            this.mapViewControl1.Name = "mapViewControl1";
            this.mapViewControl1.Size = new System.Drawing.Size(458, 513);
            this.mapViewControl1.TabIndex = 0;
            // 
            // treeViewMain
            // 
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMain.Location = new System.Drawing.Point(0, 0);
            this.treeViewMain.Name = "treeViewMain";
            treeNode1.Name = "NodeScripts";
            treeNode1.Text = "Scripts";
            treeNode1.ToolTipText = "Scripts from the global namespace.";
            treeNode2.Name = "NodeQuests";
            treeNode2.Text = "Quests";
            treeNode2.ToolTipText = "All quests.";
            treeNode3.Name = "NodeActors";
            treeNode3.Text = "Maps";
            treeNode3.ToolTipText = "All maps";
            treeNode4.Name = "NodeItems";
            treeNode4.Text = "Items";
            treeNode4.ToolTipText = "All items";
            treeNode5.Name = "NodeActors";
            treeNode5.Text = "Actors";
            treeNode5.ToolTipText = "All non-player controlled actors";
            this.treeViewMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeViewMain.Size = new System.Drawing.Size(230, 513);
            this.treeViewMain.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 559);
            this.Controls.Add(this.splitContainerEditorMain);
            this.Controls.Add(this.statusStripEditorMain);
            this.Controls.Add(this.menuStripEditorMain);
            this.MainMenuStrip = this.menuStripEditorMain;
            this.Name = "MainForm";
            this.Text = "DotNetHack :: Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStripEditorMain.ResumeLayout(false);
            this.menuStripEditorMain.PerformLayout();
            this.splitContainerEditorMain.Panel1.ResumeLayout(false);
            this.splitContainerEditorMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditorMain)).EndInit();
            this.splitContainerEditorMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripEditorMain;
        private System.Windows.Forms.StatusStrip statusStripEditorMain;
        private System.Windows.Forms.SplitContainer splitContainerEditorMain;
        private Shared.Controls.MapViewControl mapViewControl1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesSetToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEditorMain;
        private System.Windows.Forms.ToolStripMenuItem scriptEditorToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewMain;
    }
}