using System.Collections.Generic;
using Newtonsoft.Json;
using SignalRWebPack.Engine;
using SignalRWebPack.Network;

namespace SignalRWebPack.Obstacles
{
  [JsonObject(MemberSerialization.OptOut)]
  public abstract class Obstacle : NetworkObject {
    public int Id;
    public string Sprite;
    public int X;
    public int Y;
    public Obstacle(int Id, string Sprite, int X, int Y, string areaId = ""): base() {
      this.Id = Id;
      this.Sprite = Sprite;
      this.AreaId = areaId;
      this.X = X;
      this.Y = Y;
    }

    public int getId() {
      return this.Id;
    }

    public override Dictionary<string, string> OnClientSideCreation() {
      Dictionary<string, string> obstacleData = new Dictionary<string, string>() {
        { "objectType", nameof(ServerObjectType.None) },
        { "id", Id.ToString() },
        { "sprite", Sprite },
        { "areaId", AreaId},
        { "x", X.ToString() },
        { "y", Y.ToString() }
      };
      return obstacleData;
    }
  }

  public enum ObstacleType {
    Passable,
    Impassable
  }
}