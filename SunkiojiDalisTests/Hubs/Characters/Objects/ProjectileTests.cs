using NUnit.Framework;
using SignalRWebPack.Engine;
using SunkiojiDalisTests.Hubs.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ProjectileTests
    {
        private Projectile projectile;

        [SetUp]
        public void CreateProjectile()
        {
            projectile = new Projectile("area", "sprite", new Vector2D(10, 10), new Rect(new Vector2D(0, 0), new Vector2D(0, 0)), 5, new Vector2D(1, 1), 30);
        }

        [Test]
        public void ProjectileTest()
        {
            Assert.IsTrue(projectile != null);
        }

        [Test]
        public void UpdateTest()
        {
            NpcTest.SetupEngine();

            ServerEngine.Instance.UpdateTime = 1;

            projectile.Update();

            Assert.AreNotEqual(projectile.Position.X, 10);
            Assert.AreNotEqual(projectile.Position.Y, 10);
        }

        [Test]
        public void OnClientSideCreationTest()
        {
            Dictionary<string, string> data = projectile.OnClientSideCreation();

            Assert.AreNotEqual(data, null);
        }
    }
}