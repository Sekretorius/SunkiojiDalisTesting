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
    class NUnitAbstractFactoyTests
    {
        [Test]
        public void CommonItemCreationTest()
        {
            int itemCount = 5;

            AbstractItemFactory factory = new CommonItemFactory();
            GenerateRandomItemAttributes(out int id,
                             out string name,
                             out int weight,
                             out int quantity,
                             out int x,
                             out int y,
                             out int worldX,
                             out int worldY);

            List<Item> items = new List<Item>();

            for (int i = 0; i < itemCount; i++)
            {
                items.Add(factory.CreatePotion(id, "", name, weight, quantity, x, y, -1, "Useless ability"));
                items.Add(factory.CreateFood(id, "", name, weight, quantity, x, y, -1, 50));
                items.Add(factory.CreateArmor(id, "", name, weight, quantity, x, y, -1, 50));
                items.Add(factory.CreateWeapon(id, "", name, weight, quantity, x, y, -1, 50));
            }

            Assert.AreEqual(itemCount * 4, items.Count);
        }

        [Test]
        public void LegendaryItemCreationTest()
        {
            int itemCount = 5;

            AbstractItemFactory factory = new LegendaryItemFactory();
            GenerateRandomItemAttributes(out int id,
                             out string name,
                             out int weight,
                             out int quantity,
                             out int x,
                             out int y,
                             out int worldX,
                             out int worldY);

            List<Item> items = new List<Item>();

            for (int i = 0; i < itemCount; i++)
            {
                items.Add(factory.CreatePotion(id, "", name, weight, quantity, x, y, -1, "Useless ability"));
                items.Add(factory.CreateFood(id, "", name, weight, quantity, x, y, -1, 50));
                items.Add(factory.CreateArmor(id, "", name, weight, quantity, x, y, -1, 50));
                items.Add(factory.CreateWeapon(id, "", name, weight, quantity, x, y, -1, 50));
            }

            Assert.AreEqual(itemCount * 4, items.Count);
        }

        [Test]
        public void UseItemsTest()
        {
            GenerateRandomItemAttributes(out int id,
                 out string name,
                 out int weight,
                 out int quantity,
                 out int x,
                 out int y,
                 out int worldX,
                 out int worldY);

            AbstractConsumable consumable = new CommonPotion(id, "", name, weight, quantity, x, y, -1, "");
            Assert.AreEqual(consumable.Consume(),0);
            consumable = new LegendaryPotion(id, "", name, weight, quantity, x, y, -1, "");
            Assert.AreEqual(consumable.Consume(), 0);
            consumable = new CommonFood(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.AreEqual(consumable.Consume(), 0);
            consumable = new LegendaryFood(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.AreEqual(consumable.Consume(), 0);

            AbstractEquipable equipable = new CommonArmor(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.AreEqual(equipable.Equip(), 0);
            Assert.AreEqual(equipable.Unequip(), 0);
            equipable = new LegendaryArmor(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.AreEqual(equipable.Equip(), 0);
            Assert.AreEqual(equipable.Unequip(), 0);
            equipable = new CommonWeapon(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.AreEqual(equipable.Equip(), 0);
            Assert.AreEqual(equipable.Unequip(), 0);
            equipable = new LegendaryWeapon(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.AreEqual(equipable.Equip(), 0);
            Assert.AreEqual(equipable.Unequip(), 0);
        }

        [Test]
        public void OnClientSideCreationTest()
        {
            GenerateRandomItemAttributes(out int id,
                 out string name,
                 out int weight,
                 out int quantity,
                 out int x,
                 out int y,
                 out int worldX,
                 out int worldY);

            AbstractConsumable consumable = new CommonPotion(id, "", name, weight, quantity, x, y, -1, "");
            Assert.Greater(consumable.OnClientSideCreation().Count,0);
            consumable = new LegendaryPotion(id, "", name, weight, quantity, x, y, -1, "");
            Assert.Greater(consumable.OnClientSideCreation().Count, 0);
            consumable = new CommonFood(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.Greater(consumable.OnClientSideCreation().Count, 0);
            consumable = new LegendaryFood(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.Greater(consumable.OnClientSideCreation().Count, 0);

            AbstractEquipable equipable = new CommonArmor(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.Greater(equipable.OnClientSideCreation().Count,0);
            equipable = new LegendaryArmor(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.Greater(equipable.OnClientSideCreation().Count,0);
            equipable = new CommonWeapon(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.Greater(equipable.OnClientSideCreation().Count,0);
            equipable = new LegendaryWeapon(id, "", name, weight, quantity, x, y, -1, 50);
            Assert.Greater(equipable.OnClientSideCreation().Count,0);
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
