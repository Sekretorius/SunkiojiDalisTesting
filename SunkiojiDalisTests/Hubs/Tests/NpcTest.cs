using Moq;
using NUnit.Framework;
using SignalRWebPack.Characters;
using SignalRWebPack.Engine;
using SignalRWebPack.Network;
using SunkiojiDalisTests.Hubs.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SunkiojiDalisTests.Hubs.Tests
{
    [TestFixture]
    class NpcTest
    {
        [Test]
        public void FriendlyNpcConstructorTest()
        {
            FriendlyNpc friendlyNpc = new FriendlyNpc("name", 100, "sprite", "area", new Vector2D(10, 10), 100, 25, 10, 10, 5, true);
            Assert.AreNotEqual(friendlyNpc, null);

            Assert.AreEqual(friendlyNpc.name, "name");
            Assert.AreEqual(friendlyNpc.health, 100);
            Assert.AreEqual(friendlyNpc.sprite, "sprite");
            Assert.AreEqual(friendlyNpc.AreaId, "area");
            Assert.AreEqual(friendlyNpc.Position.X, 10);
            Assert.AreEqual(friendlyNpc.Position.Y, 10);
            Assert.AreEqual(friendlyNpc.width, 100);
            Assert.AreEqual(friendlyNpc.height, 25);
            Assert.AreEqual(friendlyNpc.frameX, 10);
            Assert.AreEqual(friendlyNpc.frameY, 10);
            Assert.AreEqual(friendlyNpc.speed, 5);
            Assert.AreEqual(friendlyNpc.moving, true);
        }


        [Test]
        public void EnemyNpcConstructorTest()
        {
            EnemyNpc enemyNpc = new EnemyNpc("name", 100, "sprite", "area", new Vector2D(10, 10), 100, 25, 10, 10, 5, true);
            Assert.AreNotEqual(enemyNpc, null);

            Assert.AreEqual(enemyNpc.name, "name");
            Assert.AreEqual(enemyNpc.health, 100);
            Assert.AreEqual(enemyNpc.sprite, "sprite");
            Assert.AreEqual(enemyNpc.AreaId, "area");
            Assert.AreEqual(enemyNpc.Position.X, 10);
            Assert.AreEqual(enemyNpc.Position.Y, 10);
            Assert.AreEqual(enemyNpc.width, 100);
            Assert.AreEqual(enemyNpc.height, 25);
            Assert.AreEqual(enemyNpc.frameX, 10);
            Assert.AreEqual(enemyNpc.frameY, 10);
            Assert.AreEqual(enemyNpc.speed, 5);
            Assert.AreEqual(enemyNpc.moving, true);
        }
        [Test]
        public void AnimalNpcConstructorTest()
        {
            AnimalNpc animalNpc = new AnimalNpc("name", 100, "sprite", "area", new Vector2D(10, 10), 100, 25, 10, 10, 5, true);
            Assert.AreNotEqual(animalNpc, null);

            Assert.AreEqual(animalNpc.name, "name");
            Assert.AreEqual(animalNpc.health, 100);
            Assert.AreEqual(animalNpc.sprite, "sprite");
            Assert.AreEqual(animalNpc.AreaId, "area");
            Assert.AreEqual(animalNpc.Position.X, 10);
            Assert.AreEqual(animalNpc.Position.Y, 10);
            Assert.AreEqual(animalNpc.width, 100);
            Assert.AreEqual(animalNpc.height, 25);
            Assert.AreEqual(animalNpc.frameX, 10);
            Assert.AreEqual(animalNpc.frameY, 10);
            Assert.AreEqual(animalNpc.speed, 5);
            Assert.AreEqual(animalNpc.moving, true);
        }

        [Test]
        public void NpcMoveAlgorithmSetTest()
        {
            NPC npc = new FriendlyNpc();
            Stand stand = new Stand();
            npc.SetMoveAlgorithm(stand);

            Assert.AreEqual(stand, npc.GetMoveAlgorithm());
        }

        [Test]
        public void NpcInitTest()
        {
            FriendlyNpc npc = new FriendlyNpc();

            npc.Init();

            Assert.AreNotEqual(npc.targets, null);

        }

        [Test]
        public void FriendlyNpcUpdateTest()
        {
            SetupEngine();
            FriendlyNpc npc = new FriendlyNpc("name", 100, "sprite", "area", new Vector2D(10, 10), 100, 25, 10, 10, 5, true);

            npc.SetMoveAlgorithm(new Walk());

            ServerEngine.Instance.UpdateTime = 10;

            npc.targets = new List<Vector2D>() { new Vector2D(20, 20) };
            npc.Update();

            Assert.AreNotEqual(npc.Position.X, 10);
            Assert.AreNotEqual(npc.Position.Y, 10);
        }

        [Test]
        public void EnemyNpcUpdateTest()
        {
            SetupEngine();
            EnemyNpc npc = new EnemyNpc("name", 100, "sprite", "area", new Vector2D(10, 10), 100, 25, 10, 10, 5, true);

            npc.SetMoveAlgorithm(new Walk());

            ServerEngine.Instance.UpdateTime = 10;

            npc.targets = new List<Vector2D>() { new Vector2D(20, 20) };
            npc.Update();

            Assert.AreNotEqual(npc.Position.X, 10);
            Assert.AreNotEqual(npc.Position.Y, 10);
        }

        [Test]
        public void NpcUpdateDestroy()
        {

            Mock<FriendlyNpc> mock = new Mock<FriendlyNpc>();
            mock.Setup(x => x.SyncDataWithGroup(null, "Destroy", null));

            mock.Verify(x => x.SyncDataWithGroup(null, "Destroy", null), Times.AtLeastOnce());
            //bad 
        }

        [Test]
        public void NpcTestShallowCopy()
        {
            FriendlyNpc npc = new FriendlyNpc("name", 100, "sprite", "area", new Vector2D(10, 10), 100, 25, 10, 10, 5, true);

            npc.SetMoveAlgorithm(new Walk());
            npc.SetAttackAlgorithm(new Melee("", 0, 0));

            FriendlyNpc shallowCopy = (FriendlyNpc)npc.ShallowCopy();

            Assert.AreEqual(npc.name, shallowCopy.name);
            Assert.AreEqual(npc.health, shallowCopy.health);
            Assert.AreEqual(npc.sprite, shallowCopy.sprite);
            Assert.AreEqual(npc.areaId, shallowCopy.areaId);
            Assert.AreEqual(npc.Position, shallowCopy.Position);
            Assert.AreEqual(npc.width, shallowCopy.width);
            Assert.AreEqual(npc.height, shallowCopy.height);
            Assert.AreEqual(npc.frameX, shallowCopy.frameX);
            Assert.AreEqual(npc.frameY, shallowCopy.frameY);
            Assert.AreEqual(npc.speed, shallowCopy.speed);
            Assert.AreEqual(npc.moving, shallowCopy.moving);

            Assert.AreEqual(npc.Position.GetHashCode(), shallowCopy.Position.GetHashCode());
            Assert.AreEqual(npc.GetMoveAlgorithm().GetHashCode(), shallowCopy.GetMoveAlgorithm().GetHashCode());

        }

        [Test]
        public void NpcTestDeepCopy()
        {
            FriendlyNpc npc = new FriendlyNpc("name", 100, "sprite", "area", new Vector2D(10, 10), 100, 25, 10, 10, 5, true);

            npc.SetMoveAlgorithm(new Walk());

            FriendlyNpc deepCopy = (FriendlyNpc)npc.DeepCopy();

            Assert.AreEqual(npc.name, deepCopy.name);
            Assert.AreEqual(npc.health, deepCopy.health);
            Assert.AreEqual(npc.sprite, deepCopy.sprite);
            Assert.AreEqual(npc.areaId, deepCopy.areaId);
            Assert.AreEqual(npc.width, deepCopy.width);
            Assert.AreEqual(npc.height, deepCopy.height);
            Assert.AreEqual(npc.frameX, deepCopy.frameX);
            Assert.AreEqual(npc.frameY, deepCopy.frameY);
            Assert.AreEqual(npc.speed, deepCopy.speed);
            Assert.AreEqual(npc.moving, deepCopy.moving);

            Assert.AreNotEqual(npc.Position.GetHashCode(), deepCopy.Position.GetHashCode());
            Assert.AreNotEqual(npc.GetMoveAlgorithm().GetHashCode(), deepCopy.GetMoveAlgorithm().GetHashCode());

        }

        [Test]
        public void NpcClientSideCreation()
        {
            FriendlyNpc npc = new FriendlyNpc("name", 100, "sprite", "area", new Vector2D(10, 10), 100, 25, 10, 10, 5, true);

            Dictionary<string, string> data = npc.OnClientSideCreation();

            Assert.AreNotEqual(data, null);
        }

        public static Mock<ServerEngine> SetupEngine()
        {
            Mock<ServerEngine> ServerEngineMock = new Mock<ServerEngine>();

            ServerEngineMock.Object.SetInstance(ServerEngineMock.Object);
            ServerEngineMock.Object.SetNetworkManager(new NetworkManagerMock());

            ServerEngineMock.Object.Initialize();

            return ServerEngineMock;
        }
    }
}
