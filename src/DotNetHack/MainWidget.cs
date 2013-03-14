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
        /// MainWidget
        /// </summary>
        public MainWidget()
            : base("DotNetHack")
        {

        }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();

            var progressBar1 = new ProgressBar("Testing");
            progressBar1.Visible = true;

            this.Add(progressBar1);
        }
    }
}
