using DotNetHack.GUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack
{
    /// <summary>
    /// LoginWindow
    /// </summary>
    class LoginWindow : Window
    {
        /// <summary>
        /// Creates a new LoginWindow
        /// </summary>
        public LoginWindow()
            : base("DNH Login", new GUI.Size(32, 8))
        {
            KeyboardEvent += LoginWindow_KeyboardEvent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LoginWindow_KeyboardEvent(object sender, GUI.Events.GUIKeyboardEventArgs e)
        {

        }

        /// <summary>
        /// txtBoxUserName
        /// </summary>
        private TextBox txtBoxUserName = null;

        /// <summary>
        /// txtBoxPassword
        /// </summary>
        private TextBox txtBoxPassword;

        /// <summary>
        /// btnOkay
        /// </summary>
        private Button btnOkay;

        /// <summary>
        /// lblPassword
        /// </summary>
        private Label lblPassword;

        /// <summary>
        /// lblUserName
        /// </summary>
        private Label lblUserName;

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            const int LEFT_ALIGN = 5;
            base.InitializeWidget();

            BackgroundColor = ConsoleColor.Magenta;

            txtBoxUserName = new TextBox(this, LEFT_ALIGN, 2, 20) { Visible = true };
            lblUserName = new Label(this, "U:", txtBoxUserName) { Visible = true };
            this.Add(txtBoxUserName);
            this.Add(lblUserName);

            txtBoxPassword = new TextBox(this, LEFT_ALIGN, 4, 20) { Visible = true };
            lblPassword = new Label(this, "P:", txtBoxPassword) { Visible = true };
            this.Add(txtBoxPassword);
            this.Add(lblPassword);

            btnOkay = new Button(this, "OK", LEFT_ALIGN, 6, Button.ButtonDecoration.AngleBracket) { Visible = true };
            btnOkay.OkayEvent += btnOkay_OkayEvent;
            this.Add(btnOkay);
        }

        /// <summary>
        /// btnOkay_OkayEvent
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        void btnOkay_OkayEvent(object sender, GUI.Events.GUIEventArgs e)
        {
            var tmpUserName = txtBoxUserName.Text;
            var tmpPassword = txtBoxPassword.Text;
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();
        }

        /// <summary>
        /// Hide
        /// </summary>
        public override void Hide()
        {
            base.Hide();
        }
    }
}
