using System.Collections.Generic;
using System.Linq;

namespace SignalRWebPack.Hubs.Worlds
{
    public class World
    {
        public const int width = 5;
        public const int height = 5;

        public const int canvasWidth = 800;
        public const int canvasHeight = 500;

        public const int transitionOffset = 50;

        private static World instance;
        public static World Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new World();
                }
                return instance;
            }
        }

        private Area[,] world = new Area[width, height];

        public Dictionary<int, Player> players = new Dictionary<int, Player>();

        public World()
        {
            for (int i = 0; i < world.GetLength(0); i++)
                for (int t = 0; t < world.GetLength(1); t++)
                    world[i, t] = new Area(i, t);
        }

        public List<Player> GetPlayers(int x, int y)
        {
            return world[x, y].players.Values.ToList();
        }

        public void AddPlayer(Player player)
        {
            world[player.worldX, player.worldY].AddPlayer(player);
        
        }

        public void RemovePlayer(Player player)
        {
            world[player.worldX, player.worldY].RemovePlayer(player);
        }

        public void UpdatePlayer(Player player)
        {
            world[player.worldX, player.worldY].UpdatePlayer(player);
        }

        public void MoveToArea(Player player, int worldX, int worldY, int x, int y)
        {
            RemovePlayer(player);
            player.MoveToArea(worldX, worldY, x, y);
            AddPlayer(player);
        }
    } 
}