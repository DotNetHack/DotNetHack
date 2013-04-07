namespace DotNetHack.Editor
{
    partial class MapEditor
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerSub1 = new System.Windows.Forms.SplitContainer();
            this.mapViewControl = new DotNetHack.Shared.Controls.MapViewControl();
            this.splitContainerMapEditorMain = new System.Windows.Forms.SplitContainer();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub1)).BeginInit();
            this.splitContainerSub1.Panel1.SuspendLayout();
            this.splitContainerSub1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMapEditorMain)).BeginInit();
            this.splitContainerMapEditorMain.Panel2.SuspendLayout();
            this.splitContainerMapEditorMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLocation});
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(641, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStripMapEditor";
            // 
            // toolStripStatusLabelLocation
            // 
            this.toolStripStatusLabelLocation.Name = "toolStripStatusLabelLocation";
            this.toolStripStatusLabelLocation.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabelLocation.Text = "Location";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStripMapEditor";
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
            // 
            // splitContainerSub1
            // 
            this.splitContainerSub1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSub1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSub1.Name = "splitContainerSub1";
            this.splitContainerSub1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSub1.Panel1
            // 
            this.splitContainerSub1.Panel1.Controls.Add(this.mapViewControl);
            this.splitContainerSub1.Size = new System.Drawing.Size(464, 364);
            this.splitContainerSub1.SplitterDistance = 306;
            this.splitContainerSub1.TabIndex = 0;
            // 
            // mapViewControl
            // 
            this.mapViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewControl.Location = new System.Drawing.Point(0, 0);
            this.mapViewControl.Name = "mapViewControl";
            this.mapViewControl.Size = new System.Drawing.Size(464, 306);
            this.mapViewControl.TabIndex = 0;
            this.mapViewControl.LocationChangedEvent += new System.EventHandler<DotNetHack.Shared.Events.LocationChangedEventArgs>(this.mapViewControl_LocationChangedEvent);
            this.mapViewControl.Load += new System.EventHandler(this.mapViewControl_Load);
            // 
            // splitContainerMapEditorMain
            // 
            this.splitContainerMapEditorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMapEditorMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMapEditorMain.Name = "splitContainerMapEditorMain";
            // 
            // splitContainerMapEditorMain.Panel2
            // 
            this.splitContainerMapEditorMain.Panel2.Controls.Add(this.splitContainerSub1);
            this.splitContainerMapEditorMain.Size = new System.Drawing.Size(641, 364);
            this.splitContainerMapEditorMain.SplitterDistance = 173;
            this.splitContainerMapEditorMain.TabIndex = 2;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 410);
            this.Controls.Add(this.splitContainerMapEditorMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainerSub1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSub1)).EndInit();
            this.splitContainerSub1.ResumeLayout(false);
            this.splitContainerMapEditorMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMapEditorMain)).EndInit();
            this.splitContainerMapEditorMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private Shared.Controls.MapViewControl mapViewControl;
        private System.Windows.Forms.SplitContainer splitContainerSub1;
        private System.Windows.Forms.SplitContainer splitContainerMapEditorMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLocation;

    }
}