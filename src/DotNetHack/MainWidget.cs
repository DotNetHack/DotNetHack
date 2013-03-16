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
    public class MainWidget : Window
    {
        /// <summary>
        /// 
        /// </summary>
        private ProgressBar progressBar = null;

        /// <summary>
        /// MainWidget
        /// </summary>
        public MainWidget()
            : base("DotNetHack")
        {
            KeyboardEvent += MainWidget_KeyboardEvent;
            progressBar = new ProgressBar("Testing");
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

            progressBar = new ProgressBar("Testing", 5, 5);
            progressBar.Visible = true;

            this.Add(progressBar);
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();
        }
    }
}
