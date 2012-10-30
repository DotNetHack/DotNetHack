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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Quests", 19, 19);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Maps", 21, 21);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Gems", 7, 7);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Weapons", 9, 9);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Armor", 17, 17);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Containers", 20, 20);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Keys", 23, 23);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Items", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Actors");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Spells", 5, 5);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Global", 29, 29);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Scripts", 4, 4);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Tile Sets", 24, 24);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripEditorMain = new System.Windows.Forms.MenuStrip();
            this.statusStripEditorMain = new System.Windows.Forms.StatusStrip();
            this.splitContainerEditorMain = new System.Windows.Forms.SplitContainer();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanelEditorMain = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStripTileSet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapViewControl1 = new DotNetHack.Shared.Controls.MapViewControl();
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
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStripEditorMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripEditorMain.Name = "menuStripEditorMain";
            this.menuStripEditorMain.Size = new System.Drawing.Size(692, 24);
            this.menuStripEditorMain.TabIndex = 0;
            this.menuStripEditorMain.Text = "menuStrip1";
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
            // treeViewMain
            // 
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMain.ImageIndex = 0;
            this.treeViewMain.ImageList = this.imageListMain;
            this.treeViewMain.Location = new System.Drawing.Point(0, 0);
            this.treeViewMain.Name = "treeViewMain";
            treeNode1.ImageIndex = 19;
            treeNode1.Name = "NodeQuests";
            treeNode1.SelectedImageIndex = 19;
            treeNode1.Text = "Quests";
            treeNode1.ToolTipText = "All quests.";
            treeNode2.ImageIndex = 21;
            treeNode2.Name = "NodeActors";
            treeNode2.SelectedImageIndex = 21;
            treeNode2.Text = "Maps";
            treeNode2.ToolTipText = "All maps";
            treeNode3.ImageIndex = 7;
            treeNode3.Name = "NodeGems";
            treeNode3.SelectedImageIndex = 7;
            treeNode3.Text = "Gems";
            treeNode4.ImageIndex = 9;
            treeNode4.Name = "NodeWeapon";
            treeNode4.SelectedImageIndex = 9;
            treeNode4.Text = "Weapons";
            treeNode5.ImageIndex = 17;
            treeNode5.Name = "NodeArmor";
            treeNode5.SelectedImageIndex = 17;
            treeNode5.Text = "Armor";
            treeNode6.ImageIndex = 20;
            treeNode6.Name = "NodeContainers";
            treeNode6.SelectedImageIndex = 20;
            treeNode6.Text = "Containers";
            treeNode7.ImageIndex = 23;
            treeNode7.Name = "NodeKeys";
            treeNode7.SelectedImageIndex = 23;
            treeNode7.Text = "Keys";
            treeNode8.ImageIndex = 2;
            treeNode8.Name = "NodeItems";
            treeNode8.SelectedImageIndex = 2;
            treeNode8.Text = "Items";
            treeNode8.ToolTipText = "All items";
            treeNode9.ImageIndex = 3;
            treeNode9.Name = "NodeActors";
            treeNode9.Text = "Actors";
            treeNode9.ToolTipText = "All non-player controlled actors";
            treeNode10.ImageIndex = 5;
            treeNode10.Name = "NodeSpells";
            treeNode10.SelectedImageIndex = 5;
            treeNode10.Text = "Spells";
            treeNode10.ToolTipText = "Create and Edit Spells";
            treeNode11.ImageIndex = 29;
            treeNode11.Name = "NodeGlobal";
            treeNode11.SelectedImageIndex = 29;
            treeNode11.Text = "Global";
            treeNode12.ImageIndex = 4;
            treeNode12.Name = "NodeScripts";
            treeNode12.SelectedImageIndex = 4;
            treeNode12.Text = "Scripts";
            treeNode12.ToolTipText = "Scripts from the global namespace.";
            treeNode13.ImageIndex = 24;
            treeNode13.Name = "NodeTileSets";
            treeNode13.SelectedImageIndex = 24;
            treeNode13.Text = "Tile Sets";
            this.treeViewMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            this.treeViewMain.SelectedImageIndex = 0;
            this.treeViewMain.Size = new System.Drawing.Size(230, 513);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterSelect);
            // 
            // imageListMain
            // 
            this.imageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain.ImageStream")));
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain.Images.SetKeyName(0, "hammer-nails.png");
            this.imageListMain.Images.SetKeyName(1, "anvil.png");
            this.imageListMain.Images.SetKeyName(2, "battle-gear.png");
            this.imageListMain.Images.SetKeyName(3, "frankenstein-creature.png");
            this.imageListMain.Images.SetKeyName(4, "cog.png");
            this.imageListMain.Images.SetKeyName(5, "book-cover.png");
            this.imageListMain.Images.SetKeyName(6, "bottled-bolt.png");
            this.imageListMain.Images.SetKeyName(7, "cut-diamond.png");
            this.imageListMain.Images.SetKeyName(8, "anvil.png");
            this.imageListMain.Images.SetKeyName(9, "battle-axe.png");
            this.imageListMain.Images.SetKeyName(10, "chemical-drop.png");
            this.imageListMain.Images.SetKeyName(11, "arrow-cluster.png");
            this.imageListMain.Images.SetKeyName(12, "crown-coin.png");
            this.imageListMain.Images.SetKeyName(13, "minotaur.png");
            this.imageListMain.Images.SetKeyName(14, "metal-bar.png");
            this.imageListMain.Images.SetKeyName(15, "diamond-hard.png");
            this.imageListMain.Images.SetKeyName(16, "heavy-helm.png");
            this.imageListMain.Images.SetKeyName(17, "breastplate.png");
            this.imageListMain.Images.SetKeyName(18, "bottle-vapors.png");
            this.imageListMain.Images.SetKeyName(19, "quill-ink.png");
            this.imageListMain.Images.SetKeyName(20, "locked-chest.png");
            this.imageListMain.Images.SetKeyName(21, "world.png");
            this.imageListMain.Images.SetKeyName(22, "wooden-door.png");
            this.imageListMain.Images.SetKeyName(23, "key.png");
            this.imageListMain.Images.SetKeyName(24, "honeycomb.png");
            this.imageListMain.Images.SetKeyName(25, "mailed-fist.png");
            this.imageListMain.Images.SetKeyName(26, "steeltoe-boots.png");
            this.imageListMain.Images.SetKeyName(27, "tripwire.png");
            this.imageListMain.Images.SetKeyName(28, "mining.png");
            this.imageListMain.Images.SetKeyName(29, "tinker.png");
            // 
            // flowLayoutPanelEditorMain
            // 
            this.flowLayoutPanelEditorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelEditorMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelEditorMain.Name = "flowLayoutPanelEditorMain";
            this.flowLayoutPanelEditorMain.Size = new System.Drawing.Size(458, 513);
            this.flowLayoutPanelEditorMain.TabIndex = 1;
            // 
            // contextMenuStripTileSet
            // 
            this.contextMenuStripTileSet.Name = "contextMenuStripTileSet";
            this.contextMenuStripTileSet.Size = new System.Drawing.Size(61, 4);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // mapViewControl1
            // 
            this.mapViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewControl1.Location = new System.Drawing.Point(0, 0);
            this.mapViewControl1.Name = "mapViewControl1";
            this.mapViewControl1.Size = new System.Drawing.Size(458, 513);
            this.mapViewControl1.TabIndex = 0;
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEditorMain;
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.ImageList imageListMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTileSet;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}