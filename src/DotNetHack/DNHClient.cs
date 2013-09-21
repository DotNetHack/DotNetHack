using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace DotNetHack
{
    public partial class DNHClient : IDisposable
    {
        /// <summary>
        /// transport
        /// </summary>
        private readonly TSocket transport;

        /// <summary>
        /// client
        /// </summary>
        private readonly DNHService.Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetHack.Engine.GameEngine"/> class.
        /// </summary>
        public DNHClient()
        {
            transport = new TSocket("localhost", 9090);
            transport.Open();

            client = new DNHService.Client(new TBinaryProtocol(transport));
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Login(string name)
        {
            var tmpReturn = client.Login(name, string.Empty);

            PlayerID = tmpReturn.PlayerID;
            GameState = tmpReturn.GameState;
            LastSeq = tmpReturn.Seq;
            loggedIn = tmpReturn.Success;
            return loggedIn;
        }

        /// <summary>
        /// MoveTo
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="z">z</param>
        /// <returns></returns>
        public bool MoveTo(int x, int y, int z)
        {
            var tmpReturn = client.MoveTo(PlayerID, x, y, z);
            GameState = tmpReturn.GameState;
            LastSeq = tmpReturn.Seq;
            return tmpReturn.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DNHGameState Update()
        {
            var tmpReturn = client.Update(PlayerID);
            GameState = tmpReturn.GameState;
            LastSeq = tmpReturn.Seq;
            return GameState;
        }

        // TODO: Wrap all these in a central place

        /// <summary>
        /// PlayerID
        /// </summary>
        public int PlayerID { get; private set; }

        /// <summary>
        /// GameState
        /// </summary>
        public DNHGameState GameState { get; private set; }

        /// <summary>
        /// LastSeq
        /// </summary>
        public long LastSeq { get; private set; }

        /// <summary>
        /// loggedIn
        /// </summary>
        bool loggedIn = false;

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (transport != null && transport.IsOpen)
            {
                transport.Close();
            }
        }
    }
}
