using DotNetHack.Engine;
using DotNetHack.GUI;
using DotNetHack.GUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;
using UI = DotNetHack.GUI.GUI;

namespace DotNetHack
{
    /// <summary>
    /// EntryPoint
    /// </summary>
    static class EntryPoint
    {
        [STAThread]
        static void Main(string[] args)
        {

            TTransport transport = new TSocket("localhost", 9090);
            TProtocol protocol = new TBinaryProtocol(transport);
            /**
DNHService.Client client = new DNHService.Client(protocol);

transport.Open();
transport.Close();**/

            UI.Instance.Run(new LoginWindow());
        }

        /// <summary>
        /// GameEngine
        /// </summary>
        public static GameEngine GameEngine { get; set; }
    }
}
