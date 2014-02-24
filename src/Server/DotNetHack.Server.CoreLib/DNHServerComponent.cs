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
    /// DNHServerComponent
    /// </summary>
    public partial class DNHServerComponent : Component
    {
        /// <summary>
        /// _syncRoot
        /// </summary>
        private readonly object _syncRoot = new object();

        /// <summary>
        /// DNH request handler
        /// </summary>
        readonly DNHRequestHandler _handler = new DNHRequestHandler();

        /// <summary>
        /// the server object
        /// </summary>
        private TSimpleServer _server;

        /// <summary>
        /// _processor
        /// </summary>
        private DNHService.Processor _processor;

        /// <summary>
        /// _serverTransport
        /// </summary>
        private TServerSocket _serverTransport;

        /// <summary>
        /// _running
        /// </summary>
        private volatile bool _running;

        /// <summary>
        /// The server port
        /// </summary>
        public int Port { get; set; }
        
        /// <summary>
        /// Running
        /// </summary>
        public bool Running { get { return _running; } }

        /// <summary>
        /// DNHServerComponent
        /// </summary>
        public DNHServerComponent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DNHServerComponent
        /// </summary>
        /// <param name="container"></param>
        public DNHServerComponent(IContainer container)
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

            Debug.Write("Initializing processor ... ");
            _processor = new DNHService.Processor(_handler);
            Debug.WriteLine("OK");

            Debug.Write("Initializing server transport ... ");
            _serverTransport = new TServerSocket(Port);
            Debug.WriteLine("OK");

            Debug.Write("Created threaded server ... ");
            _server = new TSimpleServer(_processor, _serverTransport);
            Debug.WriteLine("OK");

            Debug.Write("Starting the server ... ");
            _running = ThreadPool.QueueUserWorkItem(Run);
            Debug.WriteLineIf(_running, "OK");
        }

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="state"></param>
        private void Run(object state)
        {
            // blocking
            _server.Serve();
            
            Thread.Sleep(ThreadSleepWait);

            _running = false;

            Debug.WriteLine("Stopped");
        }

        /// <summary>
        /// Stop the server
        /// </summary>
        public void Stop()
        {
            Debug.Write("Stopping ");
            Thread.Sleep(ThreadSleepWait);

            _server.Stop();
            
            do
            {
                Debug.Write('.');
                Thread.Sleep(ThreadSleepWait / 3);
            } while (Running);
        }

        const int ThreadSleepWait = 100;
    }
}
