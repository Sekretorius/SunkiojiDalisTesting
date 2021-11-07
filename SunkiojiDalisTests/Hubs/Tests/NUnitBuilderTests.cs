using NUnit.Framework;
using SignalRWebPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunkiojiDalisTests.Hubs.Tests
{
    [TestFixture]
    class NUnitBuilderTests
    {
        [Test]
        public void DirectorTest()
        {
            var director = new Director();
            var builder = new DesertBuilder(2, 3);
            director.Builder = builder;
            director.BuildArea();
            var desert = builder.GetProduct();

            Assert.NotNull(desert);

            var forestBuilder = new ForestBuilder(4, 3);
            director.Builder = forestBuilder;
            director.BuildArea();
            var forest = forestBuilder.GetProduct();

            Assert.NotNull(forest);
        }

        [Test]
        public void ForestCreationTest()
        {
            int npcCount = 2;
            int obstacleCount = 23;
            int itemsCount = 4;

            ForestBuilder forestBuilder = new ForestBuilder(2, 2);

            Assert.IsNotNull(forestBuilder.forest);

            forestBuilder.AddNPCs();

            Assert.AreEqual(npcCount,forestBuilder.forest.npcs.Count);

            forestBuilder.AddObstacles();

            Assert.AreEqual(obstacleCount, forestBuilder.forest.obstacles.Count);

            forestBuilder.AddItems();

            Assert.AreEqual(itemsCount, forestBuilder.forest.items.Count);
        }

        [Test]
        public void DesertCreationTest()
        {
            int npcCount = 3;
            int obstacleCount = 5;
            int itemsCount = 1;

            DesertBuilder desertBuilder = new DesertBuilder(2, 2);

            Assert.IsNotNull(desertBuilder.desert);

            desertBuilder.AddNPCs();

            Assert.AreEqual(npcCount, desertBuilder.desert.npcs.Count);

            desertBuilder.AddObstacles();

            Assert.AreEqual(obstacleCount, desertBuilder.desert.obstacles.Count);

            desertBuilder.AddItems();

            Assert.AreEqual(itemsCount, desertBuilder.desert.items.Count);
        }
    }
}
