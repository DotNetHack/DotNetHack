using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using DotNetHack.RPC;
using DotNetHack.Server.CoreLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thrift.Protocol;
using Thrift.Transport;

namespace Server.CoreLib.Test
{
    [TestClass]
    public class DNHRequestHandlerTest
    {
        

        [TestMethod]
        public void DNHRequestHandlerCtorTest()
        {
            const int millisecondsTimeout = 10000;

            var dnhServer = new DNHServerComponent { Port = 9090 };

            dnhServer.Start();

            Thread.Sleep(1000);

            // force scope
            {
                TTransport transport = new TSocket("localhost", 9090);
                TProtocol protocol = new TBinaryProtocol(transport);
                var client = new DNHService.Client(protocol);
                transport.Open();

                var session = client.BeginSession("DEBUG", "DEBUG");
                Assert.IsNotNull(session, "result of begin session was null");

                var tmpReturn = client.Cast(session, new Spell
                {
                    Name = "Generic Healing Spell",
                    Effect = new Effect
                    {
                        Type = new EffectType(),
                        Expression = "",
                        Duration = 1,
                    },
                    SpellType = SpellType.Restoration,
                }, new TargetSelector()
                {
                    SelectorType = TargetType.TargetSelf,
                });
                Assert.IsNotNull(tmpReturn, "result of move was null");

                transport.Close();
            }

            Thread.Sleep(millisecondsTimeout);

            dnhServer.Stop();
        }
    }
}
