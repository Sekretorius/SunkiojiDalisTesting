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

        [OneTimeSetUp]
        public void Setup()
        {
            var director = new Director();
            var builder = new DesertBuilder(2, 3);
            director.Builder = builder;
            director.BuildArea();
            desert = builder.GetProduct();

            var forestBuilder = new ForestBuilder(4, 3);
            director.Builder = forestBuilder;
            director.BuildArea();
            forest = forestBuilder.GetProduct();

            GenerateRandomItemAttributes(out int id,
                 out string name,
                 out int weight,
                 out int quantity,
                 out int x,
                 out int y,
                 out int worldX,
                 out int worldY);

            item = new CommonPotion(id, "", name, weight, quantity, x, y, -1, "");
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
            Assert.Greater(World.Instance.GetItems(desert.x, desert.y).Count,0);
            EnemyNpc enemy = new EnemyNpc();
            enemy.name = "test";
            desert.AddNPC(enemy);
            Assert.Greater(World.Instance.GetNPCs(desert.x, desert.y).Count,0);
            desert.AddObstacle(new PassableObstacle(AreaId: "", Id: 1, Sprite: "resources/obstacles/passable/bush.png", X: 2, Y: 3, Type: "Harmless"));
            Assert.Greater(World.Instance.GetObstacles(desert.x, desert.y).Count,0);
            desert.AddPlayer(new Player(0, 0, 0, 0, 0, 0, 0, speed: 1, false, null, 0, 0, null));
            Assert.Greater(World.Instance.GetPlayers(desert.x, desert.y).Count,0);
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
