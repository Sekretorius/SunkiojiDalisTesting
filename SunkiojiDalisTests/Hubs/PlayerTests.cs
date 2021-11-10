using NUnit.Framework;
using SignalRWebPack.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebPack.Hubs.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;

        [SetUp]
        protected void CreatePlayer()
        {
            player = new(0, 0, 0, 0, 0, 0, 0, 0, false, "", 0, 0, "");
        }

        [Test]
        public void PlayerTest()
        {
            Assert.IsTrue(player != null);
        }

        [Test]
        public void InitTest()
        {
            player.Init();
            Assert.IsTrue(player.control != null);
        }

        [Test]
        public void setIdTest()
        {
            player.setId(5);

            Assert.IsTrue(player.getId() == 5);
        }

        [Test]
        public void MoveToAreaTest()
        {
            player.MoveToArea(5, 6, 7, 8);
            Assert.IsTrue(player.worldX == 5);
            Assert.IsTrue(player.worldY == 6);
            Assert.IsTrue(player.x == 7);
            Assert.IsTrue(player.y == 8);
        }

        [Test]
        public void GetGroupIdTest()
        {
            player.MoveToArea(5, 6, 7, 8);

            Assert.IsTrue(player.GetGroupId() == $"{5},{6}");
        }

        [Test]
        public void UpdateTest()
        {
            player.Update("Update");
        }

        [Test]
        public void NotifyTest()
        {
            player.Notify();
        }
    }
}