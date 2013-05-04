using DotNetHack.Model;
using DotNetHack.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            DotNetGUI.GUI.Instance.Run(new MainWindow(gameModel));


          //  frmMainWindow.Show();


           // Console.ReadKey();
         //   DotNetHack.Serialization.Persisted.Write(substrate, "map.dat");



     
            

        }
    }
}
