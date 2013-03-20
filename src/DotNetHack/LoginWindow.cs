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
            : base("DNH Login", new GUI.Size(20, 20))
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
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();

            txtBoxUserName = new TextBox(this, 3, 2, 5) { Visible = true };
            this.Add(txtBoxUserName);

            txtBoxPassword = new TextBox(this, 3, 4, 5) { Visible = true };
            this.Add(txtBoxPassword);

            btnOkay = new Button(this, "OK", 3, 6, Button.ButtonDecoration.AngleBracket) { Visible = true };
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
