namespace DotNetHack.Editor.Forms
{
    partial class TileSetEditor
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
            this.statusStripTileEditMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxSecondary = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxMapping = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddMapping = new System.Windows.Forms.Button();
            this.buttonRemoveMapping = new System.Windows.Forms.Button();
            this.textBoxTileSetPath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.propertyGridMain = new System.Windows.Forms.PropertyGrid();
            this.contextMenuStripTileSet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.createActorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.potionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chestpieceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shouldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.handsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wristsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogTileSetImage = new System.Windows.Forms.OpenFileDialog();
            this.statusStripTileEditMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecondary)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.contextMenuStripTileSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripTileEditMain
            // 
            this.statusStripTileEditMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStripTileEditMain.Location = new System.Drawing.Point(0, 435);
            this.statusStripTileEditMain.Name = "statusStripTileEditMain";
            this.statusStripTileEditMain.Size = new System.Drawing.Size(773, 22);
            this.statusStripTileEditMain.TabIndex = 0;
            this.statusStripTileEditMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(773, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(773, 411);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 2;
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
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxSecondary);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(257, 411);
            this.splitContainer2.SplitterDistance = 92;
            this.splitContainer2.TabIndex = 0;
            // 
            // pictureBoxSecondary
            // 
            this.pictureBoxSecondary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxSecondary.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSecondary.Name = "pictureBoxSecondary";
            this.pictureBoxSecondary.Size = new System.Drawing.Size(257, 92);
            this.pictureBoxSecondary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSecondary.TabIndex = 1;
            this.pictureBoxSecondary.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxMapping, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTileSetPath, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.22939F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.77061F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(257, 315);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listBoxMapping
            // 
            this.listBoxMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMapping.FormattingEnabled = true;
            this.listBoxMapping.Location = new System.Drawing.Point(3, 3);
            this.listBoxMapping.Name = "listBoxMapping";
            this.listBoxMapping.Size = new System.Drawing.Size(251, 239);
            this.listBoxMapping.TabIndex = 0;
            this.listBoxMapping.SelectedIndexChanged += new System.EventHandler(this.listBoxMapping_SelectedIndexChanged);
            this.listBoxMapping.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxMapping_MouseDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel2.Controls.Add(this.buttonAddMapping, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonRemoveMapping, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 248);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(251, 39);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // buttonAddMapping
            // 
            this.buttonAddMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddMapping.Location = new System.Drawing.Point(3, 3);
            this.buttonAddMapping.Name = "buttonAddMapping";
            this.buttonAddMapping.Size = new System.Drawing.Size(93, 33);
            this.buttonAddMapping.TabIndex = 0;
            this.buttonAddMapping.Text = "Map Tile";
            this.buttonAddMapping.UseVisualStyleBackColor = true;
            this.buttonAddMapping.Click += new System.EventHandler(this.buttonAddMapping_Click);
            // 
            // buttonRemoveMapping
            // 
            this.buttonRemoveMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveMapping.Location = new System.Drawing.Point(102, 3);
            this.buttonRemoveMapping.Name = "buttonRemoveMapping";
            this.buttonRemoveMapping.Size = new System.Drawing.Size(146, 33);
            this.buttonRemoveMapping.TabIndex = 1;
            this.buttonRemoveMapping.Text = "Remove Mapping";
            this.buttonRemoveMapping.UseVisualStyleBackColor = true;
            this.buttonRemoveMapping.Click += new System.EventHandler(this.buttonRemoveMapping_Click);
            // 
            // textBoxTileSetPath
            // 
            this.textBoxTileSetPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTileSetPath.Location = new System.Drawing.Point(3, 293);
            this.textBoxTileSetPath.Name = "textBoxTileSetPath";
            this.textBoxTileSetPath.Size = new System.Drawing.Size(251, 20);
            this.textBoxTileSetPath.TabIndex = 4;
            this.textBoxTileSetPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxTileSetPath_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 411);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.AutoScroll = true;
            this.splitContainer4.Panel1.Controls.Add(this.pictureBoxMain);
            this.splitContainer4.Panel1.Cursor = System.Windows.Forms.Cursors.Cross;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.propertyGridMain);
            this.splitContainer4.Size = new System.Drawing.Size(512, 411);
            this.splitContainer4.SplitterDistance = 342;
            this.splitContainer4.TabIndex = 1;
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxMain.Location = new System.Drawing.Point(-1, 0);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(157, 174);
            this.pictureBoxMain.TabIndex = 1;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Click += new System.EventHandler(this.pictureBoxMain_Click);
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            this.pictureBoxMain.Move += new System.EventHandler(this.pictureBoxMain_Move);
            // 
            // propertyGridMain
            // 
            this.propertyGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridMain.Location = new System.Drawing.Point(0, 0);
            this.propertyGridMain.Name = "propertyGridMain";
            this.propertyGridMain.Size = new System.Drawing.Size(166, 411);
            this.propertyGridMain.TabIndex = 2;
            // 
            // contextMenuStripTileSet
            // 
            this.contextMenuStripTileSet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRemove,
            this.createActorToolStripMenuItem,
            this.createItemToolStripMenuItem});
            this.contextMenuStripTileSet.Name = "contextMenuStripAddRemove";
            this.contextMenuStripTileSet.Size = new System.Drawing.Size(153, 92);
            // 
            // toolStripMenuItemRemove
            // 
            this.toolStripMenuItemRemove.Name = "toolStripMenuItemRemove";
            this.toolStripMenuItemRemove.Size = new System.Drawing.Size(140, 22);
            this.toolStripMenuItemRemove.Text = "Remove";
            this.toolStripMenuItemRemove.Click += new System.EventHandler(this.toolStripMenuItemRemove_Click);
            // 
            // createActorToolStripMenuItem
            // 
            this.createActorToolStripMenuItem.Name = "createActorToolStripMenuItem";
            this.createActorToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.createActorToolStripMenuItem.Text = "Create Actor";
            this.createActorToolStripMenuItem.Click += new System.EventHandler(this.createActorToolStripMenuItem_Click);
            // 
            // createItemToolStripMenuItem
            // 
            this.createItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weaponToolStripMenuItem,
            this.containerToolStripMenuItem,
            this.consumableToolStripMenuItem,
            this.armorToolStripMenuItem});
            this.createItemToolStripMenuItem.Name = "createItemToolStripMenuItem";
            this.createItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createItemToolStripMenuItem.Text = "Create Item";
            // 
            // weaponToolStripMenuItem
            // 
            this.weaponToolStripMenuItem.Name = "weaponToolStripMenuItem";
            this.weaponToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.weaponToolStripMenuItem.Text = "Weapon";
            this.weaponToolStripMenuItem.Click += new System.EventHandler(this.weaponToolStripMenuItem_Click);
            // 
            // containerToolStripMenuItem
            // 
            this.containerToolStripMenuItem.Name = "containerToolStripMenuItem";
            this.containerToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.containerToolStripMenuItem.Text = "Container";
            // 
            // consumableToolStripMenuItem
            // 
            this.consumableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.potionToolStripMenuItem,
            this.foodToolStripMenuItem,
            this.scrollToolStripMenuItem});
            this.consumableToolStripMenuItem.Name = "consumableToolStripMenuItem";
            this.consumableToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.consumableToolStripMenuItem.Text = "Consumable";
            // 
            // potionToolStripMenuItem
            // 
            this.potionToolStripMenuItem.Name = "potionToolStripMenuItem";
            this.potionToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.potionToolStripMenuItem.Text = "Potion";
            // 
            // foodToolStripMenuItem
            // 
            this.foodToolStripMenuItem.Name = "foodToolStripMenuItem";
            this.foodToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.foodToolStripMenuItem.Text = "Food";
            // 
            // scrollToolStripMenuItem
            // 
            this.scrollToolStripMenuItem.Name = "scrollToolStripMenuItem";
            this.scrollToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.scrollToolStripMenuItem.Text = "Scroll";
            // 
            // armorToolStripMenuItem
            // 
            this.armorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.armorToolStripMenuItem1,
            this.ringToolStripMenuItem});
            this.armorToolStripMenuItem.Name = "armorToolStripMenuItem";
            this.armorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.armorToolStripMenuItem.Text = "Equipment";
            // 
            // armorToolStripMenuItem1
            // 
            this.armorToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helmToolStripMenuItem,
            this.chestpieceToolStripMenuItem,
            this.legsToolStripMenuItem,
            this.shouldersToolStripMenuItem,
            this.backToolStripMenuItem,
            this.handsToolStripMenuItem,
            this.wristsToolStripMenuItem});
            this.armorToolStripMenuItem1.Name = "armorToolStripMenuItem1";
            this.armorToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.armorToolStripMenuItem1.Text = "Armor";
            // 
            // helmToolStripMenuItem
            // 
            this.helmToolStripMenuItem.Name = "helmToolStripMenuItem";
            this.helmToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.helmToolStripMenuItem.Text = "Head";
            // 
            // chestpieceToolStripMenuItem
            // 
            this.chestpieceToolStripMenuItem.Name = "chestpieceToolStripMenuItem";
            this.chestpieceToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.chestpieceToolStripMenuItem.Text = "Chest";
            // 
            // legsToolStripMenuItem
            // 
            this.legsToolStripMenuItem.Name = "legsToolStripMenuItem";
            this.legsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.legsToolStripMenuItem.Text = "Legs";
            // 
            // shouldersToolStripMenuItem
            // 
            this.shouldersToolStripMenuItem.Name = "shouldersToolStripMenuItem";
            this.shouldersToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.shouldersToolStripMenuItem.Text = "Shoulders";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.backToolStripMenuItem.Text = "Back";
            // 
            // handsToolStripMenuItem
            // 
            this.handsToolStripMenuItem.Name = "handsToolStripMenuItem";
            this.handsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.handsToolStripMenuItem.Text = "Hands";
            // 
            // wristsToolStripMenuItem
            // 
            this.wristsToolStripMenuItem.Name = "wristsToolStripMenuItem";
            this.wristsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.wristsToolStripMenuItem.Text = "Wrists";
            // 
            // ringToolStripMenuItem
            // 
            this.ringToolStripMenuItem.Name = "ringToolStripMenuItem";
            this.ringToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.ringToolStripMenuItem.Text = "Ring";
            // 
            // openFileDialogTileSetImage
            // 
            this.openFileDialogTileSetImage.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|BMP Images|*.bmp";
            this.openFileDialogTileSetImage.Title = "Select Tileset Image Source";
            // 
            // TileSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 457);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStripTileEditMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "TileSetEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TileEditor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TileEditor_Load);
            this.statusStripTileEditMain.ResumeLayout(false);
            this.statusStripTileEditMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecondary)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.contextMenuStripTileSet.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripTileEditMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.PictureBox pictureBoxSecondary;
        private System.Windows.Forms.ListBox listBoxMapping;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PropertyGrid propertyGridMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonAddMapping;
        private System.Windows.Forms.Button buttonRemoveMapping;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTileSet;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemove;
        private System.Windows.Forms.TextBox textBoxTileSetPath;
        private System.Windows.Forms.OpenFileDialog openFileDialogTileSetImage;
        private System.Windows.Forms.ToolStripMenuItem createActorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weaponToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consumableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem potionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chestpieceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shouldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem handsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wristsToolStripMenuItem;

    }
}