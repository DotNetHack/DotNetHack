using DotNetHack.GUI;
using DotNetHack.GUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack
{
    /// <summary>
    /// MainWidget
    /// </summary>
    public class MainWindow : Window
    {
        /// <summary>
        /// progressBar
        /// </summary>
        private ProgressBar progressBar = null;

        /// <summary>
        /// buttonOkay
        /// </summary>
        private Button buttonOkay = null;

        /// <summary>
        /// TextBox
        /// </summary>
        private TextBox txtBox = null;

        /// <summary>
        /// MainWidget
        /// </summary>
        public MainWindow()
            : base("DotNetHack", new Size(GUI.GUI.ScreenSize.Width - 1, GUI.GUI.ScreenSize.Height - 1))
        {
            KeyboardEvent += MainWidget_KeyboardEvent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWidget_KeyboardEvent(object sender, GUI.Events.GUIKeyboardEventArgs e)
        {
            if (progressBar.Value < 100)
                progressBar.Value++;
        }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();

            // create new progress bar
            progressBar = new ProgressBar("Testing", 5, 5);
            progressBar.Visible = true;
            this.Add(progressBar);

            // Add an okay button to this window
            buttonOkay = new Button("Okay", 5, 7);
            buttonOkay.Visible = true;
            buttonOkay.KeyboardEvent += buttonOkay_KeyboardEvent;
            this.Add(buttonOkay);

            // add a text box to this window
            txtBox = new TextBox(5, 9, 15);
            txtBox.Visible = true;
            txtBox.OnEntered = (string s) => { };
            this.Add(txtBox);

            // Add the main menu bar
            this.Add(new MenuBar(this, 
                new Menu.MenuItem() { Name = "File" }, 
                new Menu.MenuItem() { Name = "Edit" }) 
                {
                    Visible = true                
                });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void buttonOkay_KeyboardEvent(object sender, GUI.Events.GUIKeyboardEventArgs e)
        {
            switch (e.ConsoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    break;
                default:
                    break;
            }
        }
    }
}
