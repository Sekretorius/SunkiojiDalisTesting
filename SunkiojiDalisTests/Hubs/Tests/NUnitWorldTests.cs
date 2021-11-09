using NUnit.Framework;
using SignalRWebPack;
using SignalRWebPack.Characters;
using SignalRWebPack.Hubs;
using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Obstacles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunkiojiDalisTests.Hubs.Tests
{
    [TestFixture]
    class NUnitWorldTests
    {
        DesertArea desert;
        ForestArea forest;

        Item item;
        EnemyNpc enemy;
        Player player;
        PassableObstacle _object;

        [OneTimeSetUp]
        public void Setup()
        {
            var director = new Director();
            var builder = new DesertBuilder(2, 3);
            director.Builder = builder;
            director.BuildArea();
            desert = builder.GetProduct();
            World.Instance.SwapArea(desert);

            var forestBuilder = new ForestBuilder(4, 3);
            director.Builder = forestBuilder;
            director.BuildArea();
            forest = forestBuilder.GetProduct();
            World.Instance.SwapArea(forest);

            GenerateRandomItemAttributes(out int id,
                 out string name,
                 out int weight,
                 out int quantity,
                 out int x,
                 out int y,
                 out int worldX,
                 out int worldY);

            item = new CommonPotion(333, "", name, weight, quantity, x, y, -1, "");
            _object = new PassableObstacle(AreaId: "", Id: 1, Sprite: "resources/obstacles/passable/bush.png", X: 2, Y: 3, Type: "Harmless");
            player = new Player(0, 0, 0, 0, 0, 0, 0, speed: 1, false, null, 2, 3, null);
            enemy = new EnemyNpc(areaId:"2,3");
            enemy.name = "test";
        }

        [Test]
        public void SwapAreaTest()
        {

            World.Instance.SwapArea(desert);

            Assert.IsTrue(World.Instance.world[desert.x,desert.y] is DesertArea);

            World.Instance.SwapArea(forest);

            Assert.IsTrue(World.Instance.world[forest.x, forest.y] is ForestArea);
            
        }

        [Test]
        public void GetAreaDataTest()
        {          
            desert.AddItem(item);
            desert.UpdateItem(item);
            Assert.Greater(World.Instance.GetItems(desert.x, desert.y).Count,0);
            World.Instance.AddNPC(enemy);
            World.Instance.UpdateNPC(enemy);
            //desert.AddNPC(enemy);
            //desert.UpdateNPC(enemy);
            Assert.Greater(World.Instance.GetNPCs(desert.x, desert.y).Count,0);
            desert.AddObstacle(_object);
            desert.UpdateObstacle(_object);
            Assert.Greater(World.Instance.GetObstacles(desert.x, desert.y).Count,0);
            World.Instance.AddPlayer(player);
            World.Instance.UpdatePlayer(player);
            Assert.Greater(World.Instance.GetPlayers(desert.x, desert.y).Count,0);
        }

        [Test]
        public void DeleteAreaData()
        {
            desert.AddItem(item);
            desert.RemoveItem(item);
            Assert.IsFalse(desert.items.ContainsKey(item.Id));
            desert.AddNPC(enemy);
            World.Instance.RemoveNPC(enemy);
            //desert.RemoveNPC(enemy);
            Assert.IsFalse(desert.npcs.ContainsKey(enemy.name));
            desert.AddPlayer(player);
            World.Instance.RemovePlayer(player);
            //desert.RemovePlayer(player);
            Assert.IsFalse(desert.players.ContainsKey(player.getId()));
            desert.RemoveObstacle(_object);
            desert.obstacles.Remove(_object.getId());
            Assert.IsFalse(desert.obstacles.ContainsKey(_object.getId()));
        }

        [Test]
        public void DoSpecialEventsTest()
        {
            Assert.AreNotEqual(-1, desert.DoSpecialEvent());
            Assert.AreNotEqual(-1, forest.DoSpecialEvent());
        }

        [Test]
        public void MiscellaneousTests()
        {
            Assert.AreEqual("resources/backgrounds/desert.png", World.Instance.GetBackground(desert.x, desert.y));

            desert.ChangeCoordinates(1,1);
            Assert.IsTrue(1 == desert.x && 1 == desert.y);
            
            Player testPlayer = new Player(99, 0, 0, 0, 0, 0, 0, speed: 1, false, null, 2, 2, null);
            World.Instance.AddPlayer(testPlayer);
            World.Instance.MoveToArea(testPlayer, 0, 0, 0, 0);
            Assert.IsTrue(testPlayer.worldX == 0 && testPlayer.worldY == 0);

            World.Instance.GetPlayers(desert.x, desert.y);

        }


        public static void GenerateRandomItemAttributes(out int id, out string name, out int weight, out int quantity, out int x, out int y, out int worldX, out int worldY)
        {
            Random rd = new Random();
            id = rd.Next(1, 99999);
            name = "item_" + id.ToString();
            weight = rd.Next(1, 11);
            quantity = rd.Next(1, 4);
            x = rd.Next(20, 780);
            y = rd.Next(20, 480);
            worldX = 0;
            worldY = 0;
        }

    }
}
