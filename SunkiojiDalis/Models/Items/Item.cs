using Newtonsoft.Json;
using SignalRWebPack.Network;
using System.Collections.Generic;
using SignalRWebPack.Engine;

namespace SignalRWebPack{
  [JsonObject(MemberSerialization.OptOut)]
  public abstract class Item : NetworkObject {
    public int Id;
    public string Sprite;
    public string Name;
    public int Weight;
    public int Quantity;
    public int X;
    public int Y;
    public int BelongsTo;

    public Item(int Id, string Sprite, int Weight, int Quantity, int X, int Y, int BelongsTo, string areaId = ""): base() {
      this.Id = Id;
      this.Sprite = Sprite;
      this.Weight = Weight;
      this.Quantity = Quantity;
      this.X = X;
      this.Y = Y;
      this.BelongsTo = BelongsTo;
      this.AreaId = areaId;
    }
    public override Dictionary<string, string> OnClientSideCreation() {
      Dictionary<string, string> itemData = new Dictionary<string, string>() {
        { "objectType", nameof(ServerObjectType.None) },
        { "id", Id.ToString() },
        { "sprite", Sprite },
        { "weight", Weight.ToString() },
        { "quantity", Quantity.ToString() },
        { "x", X.ToString() },
        { "y", Y.ToString() },
        { "belongsTo", BelongsTo.ToString() },
        { "areaId", AreaId}
      };
      return itemData;
    }
  }
}

