using System;

namespace SignalRWebPack.Hubs.Worlds
{
  public class DesertArea: Area {
    public DesertArea(int x, int y): base(x, y) {
      this.background = "resources/backgrounds/desert.png";
    }

    public override int DoSpecialEvent(){
      return CreateSandstorm();
    }

    public int CreateSandstorm() {
      Random rnd = new Random();
      return rnd.Next(0, 10);
    }
  }
}