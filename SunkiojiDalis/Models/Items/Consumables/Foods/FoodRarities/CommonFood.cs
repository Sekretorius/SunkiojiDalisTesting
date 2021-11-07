using System.Collections.Generic;
using SignalRWebPack.Engine;

namespace SignalRWebPack{
  public class CommonFood: AbstractFood {
    public CommonFood(int id, string sprite, string name, int weight, int quantity, int x, int y, int belongsTo, int health) {
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
      Dictionary<string, string> commonFoodData = base.OnClientSideCreation();
      commonFoodData["health"] = this.Health.ToString();
      commonFoodData["objectType"] = nameof(ServerObjectType.CommonFood);
      return commonFoodData;
    }
  }
}