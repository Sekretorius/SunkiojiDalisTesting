using System.Collections.Generic;
using System.Linq;
using SignalRWebPack.Characters;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack.Hubs.Worlds
{
    public class World : Subject
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

        public Area[,] world = new Area[width, height];

        public World()
        {
            for (int i = 0; i < world.GetLength(0); i++)
                for (int t = 0; t < world.GetLength(1); t++) {
                    world[i, t] = new Area(i, t);
                    world[i, t].background = "resources/backgrounds/grass_background.png";
                }
        }

        public void SwapArea(Area area)
        {
            world[area.x, area.y] = area;
        }

        public string GetBackground(int x, int y){
            return world[x, y].background;
        }

        public List<Player> GetPlayers(int x, int y)
        {
            return world[x, y].players.Values.ToList();
        }

        public List<Item> GetItems(int x, int y)
        {
            return world[x, y].items.Values.ToList();
        }

        public List<NPC> GetNPCs(int x, int y)
        {
            return world[x, y].npcs.Values.ToList();
        }

        public List<Obstacle> GetObstacles(int x, int y)
        {
            return world[x, y].obstacles.Values.ToList();
        }

        public void AddNPC(NPC npc)
        {
            var indexes = ParseStringToIntArray(npc.AreaId);
            world[indexes[0], indexes[1]].AddNPC(npc);
        }

        public void RemoveNPC(NPC npc)
        {
            var indexes = ParseStringToIntArray(npc.AreaId);
            world[indexes[0], indexes[1]].RemoveNPC(npc);
        }

        public void UpdateNPC(NPC npc)
        {
            var indexes = ParseStringToIntArray(npc.AreaId);
            world[indexes[0], indexes[1]].UpdateNPC(npc);
        }

        public void AddPlayer(Player player)
        {
            world[player.worldX, player.worldY].AddPlayer(player);

            Attatch(player);
            ReceiveFromClient($"Player {player.getId()} joined the game!");
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

            ReceiveFromClient($"Player {player.getId()} entered {player.GetGroupId()}!");
        }

        public static int[] ParseStringToIntArray(string arr)
        {
            return arr.Split(',').Select(int.Parse).ToArray();
        }


    } 
}