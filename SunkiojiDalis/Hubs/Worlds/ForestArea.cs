using System;

namespace SignalRWebPack.Hubs.Worlds
{
  public class ForestArea: Area {
    public ForestArea(int x, int y): base(x, y) {
      this.background = "resources/backgrounds/forest.png";
    }

    public override int DoSpecialEvent(){
      return CreateFire();
    }

    public int CreateFire() {
      Random rnd = new Random();
      return rnd.Next(0, 20);
    }
  }
}