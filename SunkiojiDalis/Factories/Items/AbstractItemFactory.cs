namespace SignalRWebPack {
  public abstract class AbstractItemFactory {
    public abstract AbstractWeapon CreateWeapon(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int damage);
    public abstract AbstractArmor CreateArmor(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int defense);
    public abstract AbstractPotion CreatePotion(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, string ability);
    public abstract AbstractFood CreateFood(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int health);
  }
}