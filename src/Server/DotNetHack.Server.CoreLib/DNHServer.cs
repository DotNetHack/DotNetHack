using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using DotNetHack.RPC;
using Thrift.Server;
using Thrift.Transport;

namespace DotNetHack.Server.CoreLib
{
    /// <summary>
    /// DNHServer
    /// </summary>
    public partial class DNHServer : Component, IDisposable
    {
        /// <summary>
        /// DNH request handler
        /// </summary>
        readonly DNHRequestHandler _handler = new DNHRequestHandler();

        /// <summary>
        /// the server object
        /// </summary>
        TThreadedServer _server;

        /// <summary>
        /// _syncRoot
        /// </summary>
        private readonly object _syncRoot = new object();

        /// <summary>
        /// The server port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Running
        /// </summary>
        public bool Running { get; set; }

        /// <summary>
        /// DNHServer
        /// </summary>
        public DNHServer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DNHServer
        /// </summary>
        /// <param name="container"></param>
        public DNHServer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            _handler.Initialize(new DNHRequestHandler.DNHServerParameters());

            Running = ThreadPool.QueueUserWorkItem(Run);
        }

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="state"></param>
        private void Run(object state)
        {
            Debug.WriteLine("Starting the server...");

            lock (_syncRoot)
            {
                var processor = new DNHService.Processor(_handler);
                var serverTransport = new TServerSocket(Port);
                _server = new TThreadedServer(processor, serverTransport);
            }

            _server.Serve();

            Debug.WriteLine("Stopping");
        }

        /// <summary>
        /// Stop the server
        /// </summary>
        public void Stop()
        {
            _server.Stop();

            Running = false;
        }

        public new void Dispose()
        {
            if (Running)
                Stop();

            base.Dispose();
        }
    }
}
