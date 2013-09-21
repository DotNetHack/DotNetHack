
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

            var frmMain = new MainWindow();
            frmMain.InitializeWidget();
            DotNetGUI.GUI.Instance.Run(frmMain);
        }
    }
}
