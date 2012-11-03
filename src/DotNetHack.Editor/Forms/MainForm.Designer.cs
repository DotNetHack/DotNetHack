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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Quests", 19, 19);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Maps", 21, 21);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Gems", 7, 7);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Weapons", 9, 9);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Armor", 17, 17);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Containers", 20, 20);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Keys", 23, 23);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Items", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Actors");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Spells", 5, 5);
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Global", 29, 29);
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Scripts", 4, 4);
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Tile Sets", 24, 24);
            this.menuStripEditorMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.statusStripEditorMain = new System.Windows.Forms.StatusStrip();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainerMain = new System.Windows.Forms.ToolStripContainer();
            this.splitContainerEditorMain = new System.Windows.Forms.SplitContainer();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.flowLayoutPanelEditorMain = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonTileSets = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonScripts = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonMaps = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuStripEditorMain.SuspendLayout();
            this.toolStripContainerMain.ContentPanel.SuspendLayout();
            this.toolStripContainerMain.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditorMain)).BeginInit();
            this.splitContainerEditorMain.Panel1.SuspendLayout();
            this.splitContainerEditorMain.Panel2.SuspendLayout();
            this.splitContainerEditorMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
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
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileSetToolStripMenuItem});
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // tileSetToolStripMenuItem
            // 
            this.tileSetToolStripMenuItem.Name = "tileSetToolStripMenuItem";
            this.tileSetToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.tileSetToolStripMenuItem.Text = "Tile Set";
            this.tileSetToolStripMenuItem.Click += new System.EventHandler(this.tileSetToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
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
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // statusStripEditorMain
            // 
            this.statusStripEditorMain.Location = new System.Drawing.Point(0, 537);
            this.statusStripEditorMain.Name = "statusStripEditorMain";
            this.statusStripEditorMain.Size = new System.Drawing.Size(692, 22);
            this.statusStripEditorMain.TabIndex = 1;
            this.statusStripEditorMain.Text = "statusStrip1";
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
            // toolStripContainerMain
            // 
            // 
            // toolStripContainerMain.ContentPanel
            // 
            this.toolStripContainerMain.ContentPanel.Controls.Add(this.splitContainerEditorMain);
            this.toolStripContainerMain.ContentPanel.Size = new System.Drawing.Size(692, 488);
            this.toolStripContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainerMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainerMain.Name = "toolStripContainerMain";
            this.toolStripContainerMain.Size = new System.Drawing.Size(692, 513);
            this.toolStripContainerMain.TabIndex = 3;
            this.toolStripContainerMain.Text = "toolStripContainer1";
            // 
            // toolStripContainerMain.TopToolStripPanel
            // 
            this.toolStripContainerMain.TopToolStripPanel.Controls.Add(this.toolStripMain);
            // 
            // splitContainerEditorMain
            // 
            this.splitContainerEditorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEditorMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEditorMain.Name = "splitContainerEditorMain";
            // 
            // splitContainerEditorMain.Panel1
            // 
            this.splitContainerEditorMain.Panel1.Controls.Add(this.treeViewMain);
            // 
            // splitContainerEditorMain.Panel2
            // 
            this.splitContainerEditorMain.Panel2.Controls.Add(this.flowLayoutPanelEditorMain);
            this.splitContainerEditorMain.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerEditorMain_Panel2_Paint);
            this.splitContainerEditorMain.Size = new System.Drawing.Size(692, 488);
            this.splitContainerEditorMain.SplitterDistance = 111;
            this.splitContainerEditorMain.TabIndex = 3;
            // 
            // treeViewMain
            // 
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMain.ImageIndex = 0;
            this.treeViewMain.ImageList = this.imageListMain;
            this.treeViewMain.Location = new System.Drawing.Point(0, 0);
            this.treeViewMain.Name = "treeViewMain";
            treeNode14.ImageIndex = 19;
            treeNode14.Name = "NodeQuests";
            treeNode14.SelectedImageIndex = 19;
            treeNode14.Text = "Quests";
            treeNode14.ToolTipText = "All quests.";
            treeNode15.ImageIndex = 21;
            treeNode15.Name = "NodeActors";
            treeNode15.SelectedImageIndex = 21;
            treeNode15.Text = "Maps";
            treeNode15.ToolTipText = "All maps";
            treeNode16.ImageIndex = 7;
            treeNode16.Name = "NodeGems";
            treeNode16.SelectedImageIndex = 7;
            treeNode16.Text = "Gems";
            treeNode17.ImageIndex = 9;
            treeNode17.Name = "NodeWeapon";
            treeNode17.SelectedImageIndex = 9;
            treeNode17.Text = "Weapons";
            treeNode18.ImageIndex = 17;
            treeNode18.Name = "NodeArmor";
            treeNode18.SelectedImageIndex = 17;
            treeNode18.Text = "Armor";
            treeNode19.ImageIndex = 20;
            treeNode19.Name = "NodeContainers";
            treeNode19.SelectedImageIndex = 20;
            treeNode19.Text = "Containers";
            treeNode20.ImageIndex = 23;
            treeNode20.Name = "NodeKeys";
            treeNode20.SelectedImageIndex = 23;
            treeNode20.Text = "Keys";
            treeNode21.ImageIndex = 2;
            treeNode21.Name = "NodeItems";
            treeNode21.SelectedImageIndex = 2;
            treeNode21.Text = "Items";
            treeNode21.ToolTipText = "All items";
            treeNode22.ImageIndex = 3;
            treeNode22.Name = "NodeActors";
            treeNode22.Text = "Actors";
            treeNode22.ToolTipText = "All non-player controlled actors";
            treeNode23.ImageIndex = 5;
            treeNode23.Name = "NodeSpells";
            treeNode23.SelectedImageIndex = 5;
            treeNode23.Text = "Spells";
            treeNode23.ToolTipText = "Create and Edit Spells";
            treeNode24.ImageIndex = 29;
            treeNode24.Name = "NodeGlobal";
            treeNode24.SelectedImageIndex = 29;
            treeNode24.Text = "Global";
            treeNode25.ImageIndex = 4;
            treeNode25.Name = "NodeScripts";
            treeNode25.SelectedImageIndex = 4;
            treeNode25.Text = "Scripts";
            treeNode25.ToolTipText = "Scripts from the global namespace.";
            treeNode26.ImageIndex = 24;
            treeNode26.Name = "NodeTileSets";
            treeNode26.SelectedImageIndex = 24;
            treeNode26.Text = "Tile Sets";
            this.treeViewMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26});
            this.treeViewMain.SelectedImageIndex = 0;
            this.treeViewMain.Size = new System.Drawing.Size(111, 488);
            this.treeViewMain.TabIndex = 0;
            // 
            // flowLayoutPanelEditorMain
            // 
            this.flowLayoutPanelEditorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelEditorMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelEditorMain.Name = "flowLayoutPanelEditorMain";
            this.flowLayoutPanelEditorMain.Size = new System.Drawing.Size(577, 488);
            this.flowLayoutPanelEditorMain.TabIndex = 1;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonTileSets,
            this.toolStripDropDownButtonScripts,
            this.toolStripDropDownButtonMaps});
            this.toolStripMain.Location = new System.Drawing.Point(3, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(256, 25);
            this.toolStripMain.TabIndex = 0;
            // 
            // toolStripDropDownButtonTileSets
            // 
            this.toolStripDropDownButtonTileSets.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonTileSets.Image")));
            this.toolStripDropDownButtonTileSets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonTileSets.Name = "toolStripDropDownButtonTileSets";
            this.toolStripDropDownButtonTileSets.Size = new System.Drawing.Size(79, 22);
            this.toolStripDropDownButtonTileSets.Text = "Tile Sets";
            this.toolStripDropDownButtonTileSets.Click += new System.EventHandler(this.toolStripDropDownButtonTileSets_Click);
            // 
            // toolStripDropDownButtonScripts
            // 
            this.toolStripDropDownButtonScripts.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonScripts.Image")));
            this.toolStripDropDownButtonScripts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonScripts.Name = "toolStripDropDownButtonScripts";
            this.toolStripDropDownButtonScripts.Size = new System.Drawing.Size(71, 22);
            this.toolStripDropDownButtonScripts.Text = "Scripts";
            this.toolStripDropDownButtonScripts.Click += new System.EventHandler(this.toolStripDropDownButtonScripts_Click);
            // 
            // toolStripDropDownButtonMaps
            // 
            this.toolStripDropDownButtonMaps.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonMaps.Image")));
            this.toolStripDropDownButtonMaps.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonMaps.Name = "toolStripDropDownButtonMaps";
            this.toolStripDropDownButtonMaps.Size = new System.Drawing.Size(94, 22);
            this.toolStripDropDownButtonMaps.Text = "Map Editor";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 559);
            this.Controls.Add(this.toolStripContainerMain);
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
            this.toolStripContainerMain.ContentPanel.ResumeLayout(false);
            this.toolStripContainerMain.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerMain.TopToolStripPanel.PerformLayout();
            this.toolStripContainerMain.ResumeLayout(false);
            this.toolStripContainerMain.PerformLayout();
            this.splitContainerEditorMain.Panel1.ResumeLayout(false);
            this.splitContainerEditorMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditorMain)).EndInit();
            this.splitContainerEditorMain.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripEditorMain;
        private System.Windows.Forms.StatusStrip statusStripEditorMain;
        private System.Windows.Forms.ImageList imageListMain;
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
        private System.Windows.Forms.ToolStripMenuItem tileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerEditorMain;
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEditorMain;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonTileSets;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonScripts;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonMaps;
    }
}