namespace SignalRWebPack {
  public class CommonItemFactory: AbstractItemFactory {
    public override CommonWeapon CreateWeapon(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int damage) {
      return new CommonWeapon(id, sprite, name, weight, quantity, x, y, belongsTo, damage);
    }
    public override CommonArmor CreateArmor(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int defense) {
      return new CommonArmor(id, sprite, name, weight, quantity, x, y, belongsTo, defense);
    }
    public override CommonPotion CreatePotion(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, string ability) {
      return new CommonPotion(id, sprite, name, weight, quantity, x, y, belongsTo, ability);
    }
    public override CommonFood CreateFood(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int health) {
      return new CommonFood(id, sprite, name, weight, quantity, x, y, belongsTo, health);
    }
  }
}