
using NUnit.Framework;
using SunkiojiDalis.Character;
using SunkiojiDalis.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class NUnitManagerTests
    {
        [Test]
        public void testTest()
        {
            
            FriendlyNpc npc = new FriendlyNpc();

            Assert.AreEqual(1, ServerEngine.Instance.waitingObjects.Count);
        }

        [Test]
        public void testTest1()
        {

            FriendlyNpc npc = new FriendlyNpc();

            Assert.AreEqual(0, npc.x);
            Assert.AreEqual(0, npc.y);
        }

        [Test]
        public void testTest2()
        {

            FriendlyNpc npc = new FriendlyNpc(speed: 5);
            npc.SetMoveAlgorithm(new Walk());
            ServerEngine.Instance.UpdateTime = 1;
            npc.Update();

            Assert.AreNotEqual(0, npc.x);
            //Assert.AreNotEqual(0, npc.y);
        }
    }
}