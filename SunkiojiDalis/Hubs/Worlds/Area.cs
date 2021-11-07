using System.Collections.Generic;
using SignalRWebPack.Characters;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack.Hubs.Worlds
{
    public class Area
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Dictionary<int, Player> players { get; private set; } = new Dictionary<int, Player>();
        public Dictionary<int, Item> items { get; private set; } = new Dictionary<int, Item>();
        public Dictionary<string, NPC> npcs { get; private set; } = new Dictionary<string, NPC>();
        public Dictionary<int, Obstacle> obstacles { get; private set; } = new Dictionary<int, Obstacle>();
        public string background;

        public Area(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void ChangeCoordinates(int x, int y) {
            this.x = x;
            this.y = y;
        }
        // Players
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
        public void AddItem(Item item)
        {
            items[item.Id] = item;
        }
        public void RemoveItem(Item item)
        {
            players.Remove(item.Id);
        }
        public void UpdateItem(Item item)
        {
            items[item.Id] = item;
        }

        // NPCs
        public void AddNPC(NPC npc)
        {
            npcs[npc.getName()] = npc;
        }
        public void RemoveNPC(NPC npc)
        {
            npcs.Remove(npc.getName());
        }
        public void UpdateNPC(NPC npc)
        {
            npcs[npc.getName()] = npc;
        }

        // Obstacles
        public void AddObstacle(Obstacle obstacle)
        {
            obstacles[obstacle.Id] = obstacle;
        }
        public void RemoveObstacle(Obstacle obstacle)
        {
            obstacles.Remove(obstacle.Id);
        }
        public void UpdateObstacle(Obstacle obstacle)
        {
            obstacles[obstacle.Id] = obstacle;
        }

        public virtual int DoSpecialEvent() {
            return -1;
        }
    }
}