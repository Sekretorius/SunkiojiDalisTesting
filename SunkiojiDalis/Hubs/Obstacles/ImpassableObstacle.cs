using System.Collections.Generic;
using SignalRWebPack.Engine;

namespace SignalRWebPack.Obstacles
{
  public class ImpassableObstacle: Obstacle {
    public string Effect;
    public ImpassableObstacle(int Id = -1, string Sprite = "", int X = -1, int Y = -1, string AreaId = "", string Effect = "") : base(Id, Sprite, X, Y, AreaId){
      this.Effect = "";
    }

    public override Dictionary<string, string> OnClientSideCreation() {
      Dictionary<string, string> impassableObstacleData = base.OnClientSideCreation();
      impassableObstacleData["effect"] = this.Effect;
      impassableObstacleData["objectType"] = nameof(ServerObjectType.ImpassableObstacle);
      return impassableObstacleData;
    }
  }
}