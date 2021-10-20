namespace SignalRWebPack {
  public class LegendaryItemFactory: AbstractItemFactory {
    public override LegendaryWeapon CreateWeapon(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int damage) {
      return new LegendaryWeapon(id, sprite, name, weight, quantity, x, y, belongsTo, damage);
    }
    public override LegendaryArmor CreateArmor(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int defense) {
      return new LegendaryArmor(id, sprite, name, weight, quantity, x, y, belongsTo, defense);
    }
    public override LegendaryPotion CreatePotion(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, string ability) {
      return new LegendaryPotion(id, sprite, name, weight, quantity, x, y, belongsTo, ability);
    }
    public override LegendaryFood CreateFood(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int health) {
      return new LegendaryFood(id, sprite, name, weight, quantity, x, y, belongsTo, health);
    }
  }
}