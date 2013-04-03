namespace DotNetHack.Shared.Controls
{
    partial class InventoryItemControl
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
            this.contextMenuStripInventoryItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTipInventoryItem = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripInventoryItem
            // 
            this.contextMenuStripInventoryItem.Name = "contextMenuStripInventoryItem";
            this.contextMenuStripInventoryItem.ShowImageMargin = false;
            this.contextMenuStripInventoryItem.Size = new System.Drawing.Size(36, 4);
            // 
            // toolTipInventoryItem
            // 
            this.toolTipInventoryItem.UseAnimation = false;
            this.toolTipInventoryItem.UseFading = false;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            // 
            // InventoryItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStripInventoryItem;
            this.Controls.Add(this.pictureBoxImage);
            this.Name = "InventoryItemControl";
            this.Size = new System.Drawing.Size(30, 30);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripInventoryItem;
        private System.Windows.Forms.ToolTip toolTipInventoryItem;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}
