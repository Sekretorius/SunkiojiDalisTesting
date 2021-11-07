using System.Collections.Generic;
using SignalRWebPack.Engine;

namespace SignalRWebPack.Obstacles
{
  public class PassableObstacle: Obstacle {
    public string Type;
    public PassableObstacle(int Id = -1, string Sprite = "", int X = -1, int Y = -1, string AreaId = "", string Type = "") : base(Id, Sprite, X, Y, AreaId){
      this.Type = "";
    }

    public override Dictionary<string, string> OnClientSideCreation() {
      Dictionary<string, string> impassableObstacleData = base.OnClientSideCreation();
      impassableObstacleData["type"] = this.Type;
      impassableObstacleData["objectType"] = nameof(ServerObjectType.ImpassableObstacle);
      return impassableObstacleData;
    }
  }
}