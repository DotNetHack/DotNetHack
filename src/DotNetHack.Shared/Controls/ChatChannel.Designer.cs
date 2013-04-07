namespace DotNetHack.Shared.Controls
{
    partial class ChatChannel
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
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.dnhClientComponent = new DotNetHack.Shared.Components.DNHClientComponent();
            this.SuspendLayout();
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxChat.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBoxChat.Size = new System.Drawing.Size(150, 130);
            this.richTextBoxChat.TabIndex = 5;
            this.richTextBoxChat.Text = "";
            // 
            // textBoxChat
            // 
            this.textBoxChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxChat.Location = new System.Drawing.Point(0, 130);
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.Size = new System.Drawing.Size(150, 20);
            this.textBoxChat.TabIndex = 4;
            // 
            // dnhClientComponent
            // 
            this.dnhClientComponent.HostName = null;
            this.dnhClientComponent.Port = 0;
            // 
            // ChatChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxChat);
            this.Controls.Add(this.textBoxChat);
            this.Name = "ChatChannel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.TextBox textBoxChat;
        private Components.DNHClientComponent dnhClientComponent;
    }
}
