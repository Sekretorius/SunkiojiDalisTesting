using System.Collections.Generic;
using SignalRWebPack.Engine;

namespace SignalRWebPack{
  public class LegendaryArmor: AbstractArmor {
    public LegendaryArmor(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int defense) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.BelongsTo = -1;
      this.AreaId = AreaId;
      this.Defense = defense;
    }
    public override Dictionary<string, string> OnClientSideCreation() {
      Dictionary<string, string> legendaryArmorData = base.OnClientSideCreation();
      legendaryArmorData["defense"] = this.Defense.ToString();
      legendaryArmorData["objectType"] = nameof(ServerObjectType.LegendaryArmor);
      return legendaryArmorData;
    }
  }
}