using DotNetHack.Model;
using DotNetHack.Serialization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;

namespace DotNetHack.Server
{
    /// <summary>
    /// DNHPacketHandler
    /// </summary>
    public class DNHPacketHandler : DNHService.Iface
    {
        /// <summary>
        /// GameModel
        /// </summary>
        internal static GameModel GameModel { get; set; }

        /// <summary>
        /// DNHPacketHandler
        /// </summary>
        static DNHPacketHandler()
        {
            if (File.Exists(@"c:\DNH.dat"))
                GameModel = @"c:\DNH.dat".Read<GameModel>();
            else
            {
                GameModel = new GameModel();
                GameModel.Write(@"c:\DNH.dat");
            }
        }

        /// <summary>
        /// DNHPacketHandler
        /// </summary>
        public DNHPacketHandler()
        {

        }

        public DNHActionResult MoveTo(int playerId, int x, int y, int z)
        {
            Console.WriteLine("{0},{1},{2}", x, y, z);

            return new DNHActionResult();
        }

        public DNHActionResult Pickup(int playerId)
        {
            throw new NotImplementedException();
        }

        public DNHActionResult DropItem(int playerId, int itemId)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// EntryPoint for DotNetHack Server
    /// </summary>
    class EntryPoint
    {
        [STAThread]
        static void Main(string[] args)
        {
            DNHPacketHandler handler = new DNHPacketHandler();
            DNHService.Processor processor = new DNHService.Processor(handler);

            TServerTransport serverTransport = new TServerSocket(9090);
            TServer server = new TThreadPoolServer(processor, serverTransport);

            Console.WriteLine("Starting the server...");
            server.Serve();
        }
    }
}
