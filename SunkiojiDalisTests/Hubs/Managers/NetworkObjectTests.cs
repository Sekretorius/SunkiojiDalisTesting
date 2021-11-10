
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
    public class NetworkObjectTests
    {
        private NetworkObject networkObject;
        [SetUp]
        protected void Create()
        {
            networkObject = new NetworkObject() { CreateOnClient = true, GUID ="", IsDestroyed = false};
        }

        [Test]
        public void NetworkObjectTest()
        {
            Assert.IsTrue(networkObject != null);
        }
    }
}