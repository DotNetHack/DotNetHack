using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using DotNetHack.RPC;
using DotNetHack.Server.CoreLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Server.CoreLib.Test
{
    [TestClass]
    public class DNHRequestHandlerTest
    {
        [TestMethod]
        public void DNHRequestHandlerCtorTest()
        {
            using (var dnhServer = new DNHServer())
            {
                dnhServer.Port = 9090;
                dnhServer.Start();
                Thread.Sleep(5000);
            }
        }
    }
}
