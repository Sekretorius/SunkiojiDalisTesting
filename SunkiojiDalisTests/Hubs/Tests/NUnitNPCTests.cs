
using NUnit.Framework;
using SignalRWebPack.Characters;
using SignalRWebPack.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

            FriendlyNpc npc = new FriendlyNpc(position: new Vector2D(0, 0));

            Assert.AreEqual(0, npc.Position.X);
            Assert.AreEqual(0, npc.Position.Y);

        }

        [Test]
        public void MovementTest()
        {

            EnemyNpc npc = new EnemyNpc(speed: 5, position: new Vector2D(0,0) );
            npc.SetMoveAlgorithm(new Walk());

            float initialX = npc.Position.X;
            ServerEngine.Instance.UpdateTime = 1;
            npc.Update();

            Assert.AreEqual(npc.speed * ServerEngine.Instance.UpdateTime + initialX, npc.Position.X);

            initialX = npc.Position.X;
            ServerEngine.Instance.UpdateTime = 1;
            npc.Update();

            Assert.AreEqual(npc.speed * ServerEngine.Instance.UpdateTime + initialX, npc.Position.X);
        }

        [Test]
        public void DamageTest()
        {
            float damage = 69;
            float health = 100;
            EnemyNpc enemy = new EnemyNpc(health: health, position: new Vector2D(0, 0));
            enemy.TakeDamage(damage);

            Assert.AreEqual(health-damage, enemy.health);
        }
    }
}