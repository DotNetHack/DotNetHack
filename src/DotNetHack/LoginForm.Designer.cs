namespace DotNetHack
{
    partial class LoginForm
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
            this.statusStripLogin = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarLogin = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelLogin = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxDNHLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxAuthentication = new System.Windows.Forms.GroupBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonAuthenticate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBoxPassword = new System.Windows.Forms.MaskedTextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.groupBoxChangeLog = new System.Windows.Forms.GroupBox();
            this.richTextBoxChangeLog = new System.Windows.Forms.RichTextBox();
            this.dnhClientComponent = new DotNetHack.ExperimentalGUI.DNHClientComponent(this.components);
            this.statusStripLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDNHLogo)).BeginInit();
            this.groupBoxAuthentication.SuspendLayout();
            this.groupBoxChangeLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripLogin
            // 
            this.statusStripLogin.BackColor = System.Drawing.Color.Black;
            this.statusStripLogin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarLogin,
            this.toolStripStatusLabel});
            this.statusStripLogin.Location = new System.Drawing.Point(0, 310);
            this.statusStripLogin.Name = "statusStripLogin";
            this.statusStripLogin.Size = new System.Drawing.Size(704, 22);
            this.statusStripLogin.TabIndex = 0;
            this.statusStripLogin.Text = "statusStrip1";
            // 
            // toolStripProgressBarLogin
            // 
            this.toolStripProgressBarLogin.Name = "toolStripProgressBarLogin";
            this.toolStripProgressBarLogin.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel.Text = "Connecting ...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(704, 310);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanelLogin
            // 
            this.tableLayoutPanelLogin.ColumnCount = 2;
            this.tableLayoutPanelLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 423F));
            this.tableLayoutPanelLogin.Controls.Add(this.pictureBoxDNHLogo, 0, 0);
            this.tableLayoutPanelLogin.Controls.Add(this.groupBoxAuthentication, 0, 1);
            this.tableLayoutPanelLogin.Controls.Add(this.groupBoxChangeLog, 1, 1);
            this.tableLayoutPanelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLogin.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLogin.Name = "tableLayoutPanelLogin";
            this.tableLayoutPanelLogin.RowCount = 2;
            this.tableLayoutPanelLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.82353F));
            this.tableLayoutPanelLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.17647F));
            this.tableLayoutPanelLogin.Size = new System.Drawing.Size(704, 310);
            this.tableLayoutPanelLogin.TabIndex = 2;
            // 
            // pictureBoxDNHLogo
            // 
            this.tableLayoutPanelLogin.SetColumnSpan(this.pictureBoxDNHLogo, 2);
            this.pictureBoxDNHLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxDNHLogo.Image = global::DotNetHack.Properties.Resources.logoDotNetHack;
            this.pictureBoxDNHLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxDNHLogo.Name = "pictureBoxDNHLogo";
            this.pictureBoxDNHLogo.Size = new System.Drawing.Size(698, 176);
            this.pictureBoxDNHLogo.TabIndex = 1;
            this.pictureBoxDNHLogo.TabStop = false;
            // 
            // groupBoxAuthentication
            // 
            this.groupBoxAuthentication.BackColor = System.Drawing.Color.Black;
            this.groupBoxAuthentication.Controls.Add(this.buttonExit);
            this.groupBoxAuthentication.Controls.Add(this.buttonAuthenticate);
            this.groupBoxAuthentication.Controls.Add(this.label2);
            this.groupBoxAuthentication.Controls.Add(this.label1);
            this.groupBoxAuthentication.Controls.Add(this.maskedTextBoxPassword);
            this.groupBoxAuthentication.Controls.Add(this.textBoxUserName);
            this.groupBoxAuthentication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAuthentication.ForeColor = System.Drawing.Color.White;
            this.groupBoxAuthentication.Location = new System.Drawing.Point(3, 185);
            this.groupBoxAuthentication.Name = "groupBoxAuthentication";
            this.groupBoxAuthentication.Size = new System.Drawing.Size(275, 122);
            this.groupBoxAuthentication.TabIndex = 0;
            this.groupBoxAuthentication.TabStop = false;
            this.groupBoxAuthentication.Text = "Authentication";
            // 
            // buttonExit
            // 
            this.buttonExit.ForeColor = System.Drawing.Color.Brown;
            this.buttonExit.Location = new System.Drawing.Point(130, 70);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(58, 24);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonAuthenticate
            // 
            this.buttonAuthenticate.ForeColor = System.Drawing.Color.Black;
            this.buttonAuthenticate.Location = new System.Drawing.Point(194, 71);
            this.buttonAuthenticate.Name = "buttonAuthenticate";
            this.buttonAuthenticate.Size = new System.Drawing.Size(75, 23);
            this.buttonAuthenticate.TabIndex = 4;
            this.buttonAuthenticate.Text = "Authenticate";
            this.buttonAuthenticate.UseVisualStyleBackColor = true;
            this.buttonAuthenticate.Click += new System.EventHandler(this.buttonAuthenticate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name:";
            // 
            // maskedTextBoxPassword
            // 
            this.maskedTextBoxPassword.Location = new System.Drawing.Point(100, 45);
            this.maskedTextBoxPassword.Name = "maskedTextBoxPassword";
            this.maskedTextBoxPassword.Size = new System.Drawing.Size(169, 20);
            this.maskedTextBoxPassword.TabIndex = 1;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(100, 19);
            this.textBoxUserName.MaxLength = 32;
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(169, 20);
            this.textBoxUserName.TabIndex = 0;
            // 
            // groupBoxChangeLog
            // 
            this.groupBoxChangeLog.BackColor = System.Drawing.Color.Black;
            this.groupBoxChangeLog.Controls.Add(this.richTextBoxChangeLog);
            this.groupBoxChangeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxChangeLog.ForeColor = System.Drawing.Color.White;
            this.groupBoxChangeLog.Location = new System.Drawing.Point(284, 185);
            this.groupBoxChangeLog.Name = "groupBoxChangeLog";
            this.groupBoxChangeLog.Size = new System.Drawing.Size(417, 122);
            this.groupBoxChangeLog.TabIndex = 6;
            this.groupBoxChangeLog.TabStop = false;
            this.groupBoxChangeLog.Text = "Change Log";
            // 
            // richTextBoxChangeLog
            // 
            this.richTextBoxChangeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxChangeLog.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxChangeLog.Name = "richTextBoxChangeLog";
            this.richTextBoxChangeLog.Size = new System.Drawing.Size(411, 103);
            this.richTextBoxChangeLog.TabIndex = 0;
            this.richTextBoxChangeLog.Text = "";
            // 
            // dnhClientComponent
            // 
            this.dnhClientComponent.HostName = "localhost";
            this.dnhClientComponent.Port = 9090;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 332);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStripLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DotNetHack Authentication";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.statusStripLogin.ResumeLayout(false);
            this.statusStripLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanelLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDNHLogo)).EndInit();
            this.groupBoxAuthentication.ResumeLayout(false);
            this.groupBoxAuthentication.PerformLayout();
            this.groupBoxChangeLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripLogin;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLogin;
        private System.Windows.Forms.GroupBox groupBoxAuthentication;
        private System.Windows.Forms.PictureBox pictureBoxDNHLogo;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAuthenticate;
        private System.Windows.Forms.GroupBox groupBoxChangeLog;
        private System.Windows.Forms.RichTextBox richTextBoxChangeLog;
        private System.Windows.Forms.Button buttonExit;
        private ExperimentalGUI.DNHClientComponent dnhClientComponent;
    }
}