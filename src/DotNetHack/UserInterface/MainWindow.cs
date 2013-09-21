using DotNetGUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetHack.UserInterface
{
    /// <summary>
    /// MainWindow
    /// </summary>
    public class MainWindow : DotNetGUI.Widgets.Window
    {
        /// <summary>
        /// 
        /// </summary>
        DNHClient client = new DNHClient();

        /// <summary>
        /// MainWindow
        /// </summary>
        public MainWindow()
            : base("DotNetHack", DotNetGUI.GUI.ScreenSize)
        {
            System.Console.WriteLine("UserName: ");
            client.Login(System.Console.ReadLine());

            var p = client.GameState.Objects.FirstOrDefault(o => o.Id == client.PlayerID);

            X = p.X;
            Y = p.Y;
            Z = p.Z;

            GUI.Instance.KeyboardCallback += Instance_KeyboardCallback;

            ThreadPool.QueueUserWorkItem((object o) => {
                while (true)
                {
                    client.Update();

                    Refresh();
                    Show();
                    Thread.Sleep(1000);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        void Instance_KeyboardCallback(ConsoleKeyInfo obj)
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

            
            if (!client.MoveTo(X, Y, Z))
            {
                Debugger.Break();
            }

            Show();
        }


        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();

            foreach (var o in client.GameState.Objects)
            {
                System.Console.SetCursorPosition(o.X, o.Y);
                System.Console.Write('@');
            }

            Console.Invalidate();
        }

        int X;
        int Y;
        int Z;

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
