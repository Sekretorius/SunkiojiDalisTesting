namespace SignalRWebPack{
  public class CommonFood: AbstractFood {
    public CommonFood(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int health) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.BelongsTo = -1;
      this.Health = health;
    }
  }
}