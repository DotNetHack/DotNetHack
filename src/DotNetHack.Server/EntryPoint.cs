using DotNetHack.Core.Game;
using DotNetHack.Core.Serialization;
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
        /// gameState
        /// </summary>
        DNHGameState gameState = new DNHGameState();

        /// <summary>
        /// DNHPacketHandler
        /// </summary>
        public DNHPacketHandler()
        {
            gameState.Objects = new List<DNHObject>();
        }

        public DNHActionResult MoveTo(int playerId, int x, int y, int z)
        {
            Console.WriteLine(playerId + ": {0},{1},{2}", x, y, z);

            var player = gameState.Objects.FirstOrDefault(o => o.Id == playerId);

            if (player == null)
            {
                return new DNHActionResult() { Success = false };
            }

            player.X = x;
            player.Y = y;
            player.Z = z;

            return new DNHActionResult()
            {
                GameState = gameState,
                Seq = DateTime.Now.Ticks,
                Success = true,
                PlayerID = playerId,
            };
        }

        public DNHActionResult Pickup(int playerId)
        {
            throw new NotImplementedException();
        }

        public DNHActionResult DropItem(int playerId, int itemId)
        {
            throw new NotImplementedException();
        }

        public DNHActionResult Login(string name, string hash)
        {
            Console.WriteLine("Login: " + name);

            if (!_players.ContainsKey(name))
            {
                _players.Add(name, players);

                gameState.Objects.Add(new DNHObject() { Type = ObjectType.PLAYER, Id = players, X = 5, Y = 5, Z = 5 });

                players++;
            }

            return new DNHActionResult()
            {
                GameState = gameState,
                PlayerID = _players[name],
                Seq = DateTime.Now.Ticks,
                Success = true,
            };
        }

        private int players = 0;
        private readonly Dictionary<string, int> _players = new Dictionary<string, int>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public DNHActionResult Update(int playerId)
        {
            return new DNHActionResult()
            {
                GameState = gameState,
                PlayerID = playerId,
                Seq = DateTime.Now.Ticks,
                Success = true,
            };
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
