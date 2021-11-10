using NUnit.Framework;
using SignalRWebPack.Characters;
using SignalRWebPack.Engine;
using SignalRWebPack.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebPack.Engine.Tests
{
    [TestFixture]
    public class ServerObjectTests
    {
        [Test]
        public void ServerObjectTest()
        {
            ServerObject serverObject = new();

            Assert.IsTrue(serverObject != null);
        }

        [Test]
        public void InitTest()
        {
            ServerObject serverObject = new() { Position = new Vector2D(0, 0)};
            serverObject.Init();

            Assert.IsTrue(serverObject.AreaId == null);
            Assert.IsTrue(serverObject.Collider == null);
            Assert.IsTrue(serverObject.GUID == string.Empty);
            Assert.IsTrue(serverObject.IsDestroyed == false);
            Assert.IsTrue(serverObject.Position == new Vector2D(0, 0));
        }

        [Test]
        public void UpdateTest()
        {
            ServerObject serverObject = new();
            serverObject.Init();
        }

        [Test]
        public void DestroyTest()
        {
            ServerObject serverObject = new();
            serverObject.Destroy();
        }
    }
}