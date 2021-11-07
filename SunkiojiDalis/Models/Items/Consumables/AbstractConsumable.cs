namespace SignalRWebPack{
  public abstract class AbstractConsumable: Item {
    public AbstractConsumable(int Id = -1, string Sprite = "", int Weight = -1, int Quantity = -1, int X = -1, int Y = -1, int BelongsTo = -1, string areaId = "") : base(Id, Sprite, Weight, Quantity, X, Y, BelongsTo, areaId){}
    public int Consume(){
      return 0;
    }
  }
}

