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
            : base("DotNetHack", new Size(GUI.GUI.ScreenSize.Width - 1, GUI.GUI.ScreenSize.Height - 2))
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
            buttonOkay.OkayCallback = () => { };
            buttonOkay.KeyboardEvent += buttonOkay_KeyboardEvent;
            this.Add(buttonOkay);

            // add a text box to this window
            txtBox = new TextBox(5, 9, 15);
            txtBox.Visible = true;
            txtBox.OnEntered = (string s) => { };
            txtBox.WidgetSelectedEvent += txtBox_WidgetSelectedEvent;
            this.Add(txtBox);

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void txtBox_WidgetSelectedEvent(object sender, GUI.Events.GUISelectionEventArgs e)
        {
            var w = ((Widget)sender);
            switch (e.Type)
            {
                case GUI.Events.GUISelectionEventArgs.SelectionEventType.Deselected:
                                w.Console.ForegroundColor = ConsoleColor.Magenta;
                                w.Console.Write("!");
                            w.Console.Invalidate();
                            break;
                case GUI.Events.GUISelectionEventArgs.SelectionEventType.Selected:
                                                    w.Console.ForegroundColor = ConsoleColor.Yellow;
                                w.Console.Write("@");
                            w.Console.Invalidate();
                            break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void buttonOkay_KeyboardEvent(object sender, GUI.Events.GUIKeyboardEventArgs e)
        {

        }
    }
}
