namespace SignalRWebPack{
  public abstract class AbstractPotion: AbstractConsumable {
    public string Ability;
    public AbstractPotion(int Id = -1, string Sprite = "", int Weight = -1, int Quantity = -1, int X = -1, int Y = -1, int BelongsTo = -1, string areaId = "", string Ability = "") : base(Id, Sprite, Weight, Quantity, X, Y, BelongsTo, areaId){
      this.Ability = Ability;
    }
  }
}

