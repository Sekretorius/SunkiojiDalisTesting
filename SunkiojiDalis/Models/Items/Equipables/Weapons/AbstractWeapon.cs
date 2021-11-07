namespace SignalRWebPack{
  public abstract class AbstractWeapon: AbstractEquipable {
    public int Damage;

    public AbstractWeapon(int Id = -1, string Sprite = "", int Weight = -1, int Quantity = -1, int X = -1, int Y = -1, int BelongsTo = -1, string areaId = "", int Damage = -1) : base(Id, Sprite, Weight, Quantity, X, Y, BelongsTo, areaId){
      this.Damage = Damage;
    }
  }
}

