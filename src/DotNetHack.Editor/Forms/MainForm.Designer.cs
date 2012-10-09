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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripEditorMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripEditorMain = new System.Windows.Forms.StatusStrip();
            this.splitContainerEditorMain = new System.Windows.Forms.SplitContainer();
            this.mapViewControl1 = new DotNetHack.Shared.Controls.MapViewControl();
            this.menuStripEditorMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEditorMain)).BeginInit();
            this.splitContainerEditorMain.Panel2.SuspendLayout();
            this.splitContainerEditorMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripEditorMain
            // 
            this.menuStripEditorMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tilesToolStripMenuItem});
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
            // tilesToolStripMenuItem
            // 
            this.tilesToolStripMenuItem.Name = "tilesToolStripMenuItem";
            this.tilesToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.tilesToolStripMenuItem.Text = "&Tileset";
            this.tilesToolStripMenuItem.Click += new System.EventHandler(this.tilesToolStripMenuItem_Click);
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
            // splitContainerEditorMain.Panel2
            // 
            this.splitContainerEditorMain.Panel2.Controls.Add(this.mapViewControl1);
            this.splitContainerEditorMain.Size = new System.Drawing.Size(692, 513);
            this.splitContainerEditorMain.SplitterDistance = 230;
            this.splitContainerEditorMain.TabIndex = 2;
            // 
            // mapViewControl1
            // 
            this.mapViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewControl1.Location = new System.Drawing.Point(0, 0);
            this.mapViewControl1.Map = ((DotNetHack.Core.Game.World.Map)(resources.GetObject("mapViewControl1.Map")));
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
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStripEditorMain.ResumeLayout(false);
            this.menuStripEditorMain.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem tilesToolStripMenuItem;
    }
}