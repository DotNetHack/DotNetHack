using System;
using DotNetHack.RPC;
using Thrift.Protocol;
using Thrift.Transport;

namespace DotNetHack
{
    class EntryPoint
    {
        [STAThread]
        static void Main(string[] args)
        {
            TTransport transport = new TSocket("localhost", 9090);
            TProtocol protocol = new TBinaryProtocol(transport);
            var client = new DNHService.Client(protocol);
            transport.Open();

            Console.Write("Username: ");
            var userName = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            var session = client.BeginSession(userName, password);

            while(true)
            {
                var k = Console.ReadKey();

                switch (k.Key)
                {
                    case ConsoleKey.LeftArrow:
                        client.Move(session, Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        client.Move(session, Direction.Right);
                        break;
                    case ConsoleKey.UpArrow:
                        client.Move(session, Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        client.Move(session, Direction.Down);
                        break;
                }
            }
        }
    }
}
