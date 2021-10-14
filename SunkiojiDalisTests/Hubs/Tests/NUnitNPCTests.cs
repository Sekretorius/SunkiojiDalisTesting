
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
    public class NUnitNPCTests
    {
        [Test]
        public void CreationTest()
        {
            
            FriendlyNpc npc = new FriendlyNpc();
            FriendlyNpc npc1 = new FriendlyNpc();
            EnemyNpc enemy = new EnemyNpc();

            Assert.AreEqual(3, ServerEngine.Instance.waitingObjects.Count);
        }

        [Test]
        public void PositionTest()
        {

            FriendlyNpc npc = new FriendlyNpc();

            Assert.AreEqual(0, npc.x);
            Assert.AreEqual(0, npc.y);
        }

        [Test]
        public void MovementTest()
        {

            FriendlyNpc npc = new FriendlyNpc(speed: 5);
            npc.SetMoveAlgorithm(new Walk());

            float initialX = npc.x;
            ServerEngine.Instance.UpdateTime = 1;
            npc.Update();

            Assert.AreEqual(npc.speed * ServerEngine.Instance.UpdateTime + initialX, npc.x);

            initialX = npc.x;
            ServerEngine.Instance.UpdateTime = 1;
            npc.Update();

            Assert.AreEqual(npc.speed * ServerEngine.Instance.UpdateTime + initialX, npc.x);
        }

        [Test]
        public void DamageTest()
        {
            float damage = 69;
            float health = 100;
            EnemyNpc enemy = new EnemyNpc(health: health);
            enemy.TakeDamage(damage);

            Assert.AreEqual(health-damage, enemy.health);
        }
    }
}