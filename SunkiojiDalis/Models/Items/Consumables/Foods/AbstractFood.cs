namespace SignalRWebPack{
  public abstract class AbstractFood: AbstractConsumable {
    public int Health;

    public AbstractFood(int Id = -1, string Sprite = "", int Weight = -1, int Quantity = -1, int X = -1, int Y = -1, int BelongsTo = -1, string areaId = "", int Health = -1) : base(Id, Sprite, Weight, Quantity, X, Y, BelongsTo, areaId){
      this.Health = Health;
    }
  }
}

