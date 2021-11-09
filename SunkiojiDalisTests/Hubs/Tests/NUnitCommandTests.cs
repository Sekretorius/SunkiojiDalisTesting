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
        [TestCase(5,2)]
        public void UpCommandTest(int count,int undo)
        {
            Player player = new Player(0, 0, 0, 0, 0, 0, 0, speed : 1, false, null, 0, 0, null);

            for (int i = 0; i < count; i++)
                player.control.MoveUp();

            Assert.AreEqual(-count,player.y);

            for (int i = 0; i < undo; i++)
                player.control.Undo();

            Assert.AreEqual(-(count-undo), player.y);
        }

        [TestCase(2, 2)]
        public void DownCommandTest(int count, int undo)
        {
            Player player = new Player(0, 0, 0, 0, 0, 0, 0, speed: 1, false, null, 0, 0, null);

            for (int i = 0; i < count; i++)
                player.control.MoveDown();

            Assert.AreEqual(count, player.y);

            for (int i = 0; i < undo; i++)
                player.control.Undo();

            Assert.AreEqual(count-undo, player.y);
        }

        [TestCase(4, 1)]
        public void LeftCommandTest(int count, int undo)
        {
            Player player = new Player(0, 0, 0, 0, 0, 0, 0, speed: 1, false, null, 0, 0, null);

            for (int i = 0; i < count; i++)
                player.control.MoveLeft();

            Assert.AreEqual(-count, player.x);

            for (int i = 0; i < undo; i++)
                player.control.Undo();

            Assert.AreEqual(-(count - undo), player.x);
        }

        [TestCase(1, 1)]
        public void RightCommandTest(int count, int undo)
        {
            Player player = new Player(0, 0, 0, 0, 0, 0, 0, speed: 1, false, null, 0, 0, null);

            for (int i = 0; i < count; i++)
                player.control.MoveRight();

            Assert.AreEqual(count, player.x);

            for (int i = 0; i < undo; i++)
                player.control.Undo();

            Assert.AreEqual(count-undo, player.x);
        }
    }
}
