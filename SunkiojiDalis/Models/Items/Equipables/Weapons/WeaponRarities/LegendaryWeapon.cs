namespace SignalRWebPack{
  public class LegendaryWeapon: AbstractWeapon {
    public LegendaryWeapon(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int damage) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.BelongsTo = -1;
      this.Damage = damage;
    }
  }
}