using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace DotNetHack.ExperimentalGUI
{
    [DebuggerDisplay("{HostName}:{Port}")]
    [ToolboxItem(true)]
    [Description("DotNetHack Client Compoennt")]
    public partial class DNHClientComponent : Component, IDisposable, DNHService.Iface, IComponent
    {
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
        /// The host name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// The port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// DNHClientComponent
        /// </summary>
        public DNHClientComponent()
        {
            InitializeComponent();

            transport = new TSocket(HostName, Port);
            protocol = new TBinaryProtocol(transport);
            client = new DNHService.Client(protocol);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public DNHClientComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
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
    }
}
