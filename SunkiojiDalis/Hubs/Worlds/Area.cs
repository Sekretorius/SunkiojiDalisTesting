using System.Collections.Generic;

namespace SignalRWebPack.Hubs.Worlds
{
    public class Area
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Dictionary<int, Player> players { get; private set; } = new Dictionary<int, Player>();

        public Area(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void AddPlayer(Player player)
        {
            players[player.getId()] = player;
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player.getId());
        }

        public void UpdatePlayer(Player player)
        {
            players[player.getId()] = player;
        }
    }
}