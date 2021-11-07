using System.Collections.Generic;
using SignalRWebPack.Engine;

namespace SignalRWebPack{
  public class CommonWeapon: AbstractWeapon {
    public CommonWeapon(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int damage) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.BelongsTo = -1;
      this.AreaId = AreaId;
      this.Damage = damage;
    }
    public override Dictionary<string, string> OnClientSideCreation() {
      Dictionary<string, string> commonWeaponData = base.OnClientSideCreation();
      commonWeaponData["damage"] = this.Damage.ToString();
      commonWeaponData["objectType"] = nameof(ServerObjectType.CommonWeapon);
      return commonWeaponData;
    }
  }
}