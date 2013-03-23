using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace DotNetHack.ExperimentalGUI
{
    /// <summary>
    /// DNHClient encapsulates RPC calls on the client side.
    /// </summary>
    public class DNHClient : IDisposable, DNHService.Iface
    {
        /// <summary>
        /// DNHClient
        /// </summary>
        public DNHClient(string hostName, int port) 
        {
            transport = new TSocket(hostName, port);
            protocol = new TBinaryProtocol(transport);
            client = new DNHService.Client(protocol);
        }

        #region IFace

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="userName">the user name</param>
        /// <param name="passwordHash">the password hash</param>
        /// <returns></returns>
        public DNHAuthResponse Authenticate(string userName, string passwordHash)
        {
            return client.Authenticate(userName, passwordHash);
        }

        #endregion

        /// <summary>
        /// Open
        /// </summary>
        public void Open() { transport.Open(); }

        /// <summary>
        /// Close
        /// </summary>
        public void Close() 
        {
            if (transport.IsOpen)
            {
                transport.Flush();
                transport.Close();
            }
        }

        /// <summary>
        /// client
        /// </summary>
        private readonly DNHService.Client client;

        /// <summary>
        /// transport
        /// </summary>
        private readonly TTransport transport;
        
        /// <summary>
        /// protocol
        /// </summary>
        private readonly TProtocol protocol;

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
