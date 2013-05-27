using DotNetGUI;
using DotNetHack.Engine;
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
        public MainWindow(GameModel model, GameEngine engine)
            : base("DotNetHack", DotNetGUI.GUI.ScreenSize)
        {
            GameEngine = engine;
            GUIModel = new GUIModel(this, model);
            GUI.Instance.KeyboardCallback += Instance_KeyboardCallbacka;
        }

        void Instance_KeyboardCallbacka(ConsoleKeyInfo obj)
        {
            switch (obj.Key)
            {
                case ConsoleKey.UpArrow:
                    Y--;
                    break;
                case ConsoleKey.DownArrow:
                    Y++;
                    break;
                case ConsoleKey.LeftArrow:
                    X--;
                    break;
                case ConsoleKey.RightArrow:
                    X++;
                    break;
                case ConsoleKey.PageDown:
                    Z--;
                    break;
                case ConsoleKey.PageUp:
                    Z++;
                    break;
            }

            GameEngine.OnMoveEvent(new Events.DNHMoveEventArgs(
                new DNHLocation() { X = X, Y = Y, Z = Z },
                new DNHLocation() { X = X, Y = Y, Z = Z }));
        }


        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();
        }

        int X;
        int Y;
        int Z;

        /// <summary>
        /// This display model
        /// </summary>
        public GUIModel GUIModel { get; private set; }

        /// <summary>
        /// GameEngine
        /// </summary>
        public GameEngine GameEngine { get; private set; }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();
        }
    }
}
