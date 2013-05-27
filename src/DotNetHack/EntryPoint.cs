using DotNetHack.Engine;
using DotNetHack.Model;
using DotNetHack.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace DotNetHack
{
    /// <summary>
    /// EntryPoint
    /// </summary>
    class EntryPoint
    {


        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            var gameModel = new GameModel();
            var gameEngine = new GameEngine(GameEngine.GameEngineFlags.Debug);
            var frmMain = new MainWindow(gameModel, gameEngine);
            frmMain.InitializeWidget();
            DotNetGUI.GUI.Instance.Run(frmMain);


            //  frmMainWindow.Show();


            // Console.ReadKey();
            //   DotNetHack.Serialization.Persisted.Write(substrate, "map.dat");

        }
    }
}
