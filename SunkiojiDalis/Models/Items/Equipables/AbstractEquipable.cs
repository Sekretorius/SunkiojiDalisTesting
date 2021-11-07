namespace SignalRWebPack{
  public abstract class AbstractEquipable: Item {
    public AbstractEquipable(int Id = -1, string Sprite = "", int Weight = -1, int Quantity = -1, int X = -1, int Y = -1, int BelongsTo = -1, string areaId = "") : base(Id, Sprite, Weight, Quantity, X, Y, BelongsTo, areaId){}
    public int Equip(){
      return 0;
    }
    public int Unequip(){
      return 0;
    }
  }
}

