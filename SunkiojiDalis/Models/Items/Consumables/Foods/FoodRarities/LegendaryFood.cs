using System.Collections.Generic;
using SignalRWebPack.Engine;

namespace SignalRWebPack{
  public class LegendaryFood: AbstractFood {
    public LegendaryFood(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int health) {
      this.Id = id;
      this.Sprite = sprite;
      this.Name = name;
      this.Weight = weight;
      this.Quantity = quantity;
      this.X = x;
      this.Y = y;
      this.BelongsTo = -1;
      this.AreaId = AreaId;
      this.Health = health;
    }
    public override Dictionary<string, string> OnClientSideCreation() {
      Dictionary<string, string> legendaryFoodData = base.OnClientSideCreation();
      legendaryFoodData["health"] = this.Health.ToString();
      legendaryFoodData["objectType"] = nameof(ServerObjectType.LegendaryFood);
      return legendaryFoodData;
    }
  }
}