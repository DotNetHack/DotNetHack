using System;
using System.Collections.Generic;
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
        /// DNHPacketHandler
        /// </summary>
        public DNHPacketHandler()
        {

        }

        /// <summary>
        /// sendPacket
        /// </summary>
        /// <param name="packet"></param>
        public void sendPacket(DNHPacket packet)
        {
            packets.Enqueue(packet);
        }

        /// <summary>
        /// retrievePacket
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DNHPacket retrievePacket(int uid)
        {
            return new DNHPacket() 
            {
                Uid = 0,
                Data = "",
            };
        }

        /// <summary>
        /// packets
        /// </summary>
        Queue<DNHPacket> packets = new Queue<DNHPacket>(1024);
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
            TServer server = server = new TThreadPoolServer(processor, serverTransport);

            Console.WriteLine("Starting the server...");
            server.Serve();
        }
    }
}
