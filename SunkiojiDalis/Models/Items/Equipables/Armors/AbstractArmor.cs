namespace SignalRWebPack{
  public abstract class AbstractArmor: AbstractEquipable {
    public int Defense;
    public AbstractArmor(int Id = -1, string Sprite = "", int Weight = -1, int Quantity = -1, int X = -1, int Y = -1, int BelongsTo = -1, string areaId = "", int Defense = -1) : base(Id, Sprite, Weight, Quantity, X, Y, BelongsTo, areaId){
      this.Defense = Defense;
    }
  }
}

