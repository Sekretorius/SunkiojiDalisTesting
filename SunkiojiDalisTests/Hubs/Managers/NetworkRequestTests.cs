using NUnit.Framework;
using SignalRWebPack.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebPack.Network.Tests
{
    [TestFixture]
    public class NetworkRequestTests
    {
        [Test]
        public void NetworkRequestTest()
        {
            NetworkRequest networkRequest = new NetworkRequest("test", "test", "test");

            Assert.IsTrue(networkRequest.RequestData == "test");
            Assert.IsTrue(networkRequest.RequestMethod == "test");
            Assert.IsTrue(networkRequest.RequestObjectGuid == "test");
        }
    }
}