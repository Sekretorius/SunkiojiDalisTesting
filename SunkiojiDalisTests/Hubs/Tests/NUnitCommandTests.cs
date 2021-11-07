using NUnit.Framework;
using SignalRWebPack.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunkiojiDalisTests.Hubs.Tests
{
    [TestFixture]
    class NUnitCommandTests
    {
        [Test]
        public void UpCommandTest()
        {
            Player player = new Player(0, 0, 0, 0, 0, 0, 0, speed : 1, false, null, 0, 0, null);

            player.control.MoveUp();
            player.control.MoveUp();
            player.control.MoveUp();

            Assert.AreEqual(-3,player.y);

            player.control.Undo();
            player.control.Undo();

            Assert.AreEqual(-1, player.y);
        }

        [Test]
        public void DownCommandTest()
        {
            Player player = new Player(0, 0, 0, 0, 0, 0, 0, speed: 1, false, null, 0, 0, null);

            player.control.MoveDown();
            player.control.MoveDown();

            Assert.AreEqual(2, player.y);

            player.control.Undo();
            player.control.Undo();

            Assert.AreEqual(0, player.y);
        }

        [Test]
        public void LeftCommandTest()
        {
            Player player = new Player(0, 0, 0, 0, 0, 0, 0, speed: 1, false, null, 0, 0, null);

            player.control.MoveLeft();
            player.control.MoveLeft();
            player.control.MoveLeft();
            player.control.MoveLeft();

            Assert.AreEqual(-4, player.x);

            player.control.Undo();

            Assert.AreEqual(-3, player.x);
        }

        [Test]
        public void RightCommandTest()
        {
            Player player = new Player(0, 0, 0, 0, 0, 0, 0, speed: 1, false, null, 0, 0, null);

            player.control.MoveRight();

            Assert.AreEqual(1, player.x);

            player.control.Undo();

            Assert.AreEqual(0, player.x);
        }
    }
}
