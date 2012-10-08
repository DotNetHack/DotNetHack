
namespace DotNetHack.Forms
{
    partial class Main
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
            this.gameEngineController = new DotNetHack.Components.GameEngineController(this.components);
            this.mapViewControl = new DotNetHack.Controls.MapViewControl();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.splitContainerMainVertical = new System.Windows.Forms.SplitContainer();
            this.splitContainerMainHorizontal = new System.Windows.Forms.SplitContainer();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainVertical)).BeginInit();
            this.splitContainerMainVertical.Panel2.SuspendLayout();
            this.splitContainerMainVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainHorizontal)).BeginInit();
            this.splitContainerMainHorizontal.Panel1.SuspendLayout();
            this.splitContainerMainHorizontal.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapViewControl
            // 
            this.mapViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewControl.Location = new System.Drawing.Point(0, 0);
            this.mapViewControl.Name = "mapViewControl";
            this.mapViewControl.Size = new System.Drawing.Size(464, 442);
            this.mapViewControl.TabIndex = 0;
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 583);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(702, 22);
            this.statusStripMain.TabIndex = 0;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // splitContainerMainVertical
            // 
            this.splitContainerMainVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainVertical.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMainVertical.Name = "splitContainerMainVertical";
            // 
            // splitContainerMainVertical.Panel2
            // 
            this.splitContainerMainVertical.Panel2.Controls.Add(this.splitContainerMainHorizontal);
            this.splitContainerMainVertical.Size = new System.Drawing.Size(702, 559);
            this.splitContainerMainVertical.SplitterDistance = 234;
            this.splitContainerMainVertical.TabIndex = 1;
            // 
            // splitContainerMainHorizontal
            // 
            this.splitContainerMainHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainHorizontal.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainHorizontal.Name = "splitContainerMainHorizontal";
            this.splitContainerMainHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMainHorizontal.Panel1
            // 
            this.splitContainerMainHorizontal.Panel1.Controls.Add(this.mapViewControl);
            this.splitContainerMainHorizontal.Size = new System.Drawing.Size(464, 559);
            this.splitContainerMainHorizontal.SplitterDistance = 442;
            this.splitContainerMainHorizontal.TabIndex = 0;
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.gameToolStripMenuItem.Text = "GAME";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.helpToolStripMenuItem.Text = "HELP";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.editorToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(702, 24);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.editorToolStripMenuItem.Text = "EDITOR";
            this.editorToolStripMenuItem.Click += new System.EventHandler(this.editorToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 605);
            this.Controls.Add(this.splitContainerMainVertical);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Name = "Main";
            this.Text = "DotNetHack";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainerMainVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainVertical)).EndInit();
            this.splitContainerMainVertical.ResumeLayout(false);
            this.splitContainerMainHorizontal.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainHorizontal)).EndInit();
            this.splitContainerMainHorizontal.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMainVertical;
        private System.Windows.Forms.SplitContainer splitContainerMainHorizontal;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private DotNetHack.Components.GameEngineController gameEngineController;
        private Controls.MapViewControl mapViewControl;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
    }
}

