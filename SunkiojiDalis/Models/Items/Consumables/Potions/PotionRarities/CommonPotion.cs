namespace SignalRWebPack{
  public class CommonPotion: AbstractPotion {
    public CommonPotion(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, string ability) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.BelongsTo = -1;
      this.Ability = ability;
    }
  }
}