using DotNetHack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.UserInterface
{
    /// <summary>
    /// MainWindow
    /// </summary>
    public class MainWindow : DotNetGUI.Widgets.Window
    {
        /// <summary>
        /// MainWindow
        /// </summary>
        public MainWindow(GameModel model)
            : base("DotNetHack", DotNetGUI.GUI.ScreenSize)
        {
            GUIModel = new GUIModel(this, model);
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();
        }

        /// <summary>
        /// This display model
        /// </summary>
        public GUIModel GUIModel { get; private set; }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();
        }
    }
}
