using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Engine;
using SignalRWebPack.Hubs.Worlds;

namespace SignalRWebPack.Hubs
{
    [JsonObject(MemberSerialization.Fields)]
    public class Player
    {
        private int id;
        public int x;
        public int y;
        private int width;
        private int height;
        private int frameX;
        private int frameY;
        private int speed;
        private bool moving;
        private string sprite;
        public int worldX;
        public int worldY;

        public Player(int id, int x, int y, int width, int height, int frameX, int frameY, int speed, bool moving, string sprite, int worldX, int worldY) {
            this.id = id;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.frameX = frameX;
            this.frameY = frameY;
            this.speed = speed;
            this.moving = moving;
            this.sprite = sprite;
            this.worldX = worldX;
            this.worldY = worldY;
            //to do: sync other actions 
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getId() {
            return this.id;
        }

        public void MoveToArea(int stepX, int stepY, int x, int y)
        {
            worldX += stepX;
            worldY += stepY;
            this.x = x;
            this.y = y;
        }

        public string GetGroupId()
        {
            return $"{worldX},{worldY}";
        }
    }

    public static class PlayersList {
        public static Dictionary<int, Player> players = new Dictionary<int, Player>();
    }

    public static class ItemsList {
        public static Dictionary<int, Item> items = new Dictionary<int, Item>();

        public static void AddItemToList(Item item) {
            items[item.Id] = item;
        }

        public static Item GenerateItem() {
            Random rd = new Random();
            int randNum = rd.Next(1, 9);
            int randomItemId = rd.Next(1, 99999);
            AbstractItemFactory factory;
            if(randNum > 7) {
                factory = new LegendaryItemFactory();
                Console.WriteLine("Item rarity: Legendary");
            } else {
                factory = new CommonItemFactory();
                Console.WriteLine("Item rarity: Common");
            }
            string spritePath = "";
            GenerateRandomItemAttributes(out int id, 
                                         out string name,
                                         out int weight,
                                         out int quantity,
                                         out int x,
                                         out int y);
            switch(randNum) {
                case 1 or 2:
                    spritePath = PickRandomItemSprite("resources/items/armor/armor");
                    Console.WriteLine("Creating armor");
                    return factory.CreateArmor(id, spritePath, name, weight, quantity, x, y, -1, rd.Next(1,11));
                case 3 or 4:
                    spritePath = PickRandomItemSprite("resources/items/weapon/weapon");
                    Console.WriteLine("Creating weapon");
                    return factory.CreateWeapon(id, spritePath, name, weight, quantity, x, y, -1, rd.Next(1,11));
                case 5 or 6:
                    spritePath = PickRandomItemSprite("resources/items/food/food");
                    Console.WriteLine("Creating food");
                    return factory.CreateFood(id, spritePath, name, weight, quantity, x, y, -1, rd.Next(1,101));
                case 7 or 8:
                    spritePath = PickRandomItemSprite("resources/items/potion/potion");
                    Console.WriteLine("Creating potion");
                    return factory.CreatePotion(id, spritePath, name, weight, quantity, x, y, -1, "Useless ability");
                default:
                    break;
            }
            var nullItem = factory.CreateArmor(-1, spritePath, "", -1, -1, -1, -1, -1, -1);
            return nullItem;
        }

        public static void GenerateRandomItemAttributes(out int id, out string name, out int weight, out int quantity, out int x, out int y) {
            Random rd = new Random();
            id = rd.Next(1, 99999);
            while(items.ContainsKey(id)) {
                id = rd.Next(1, 99999);
            }
            name = "item_" + id.ToString();
            weight = rd.Next(1, 11);
            quantity = rd.Next(1,4);
            x = rd.Next(20, 780);
            y = rd.Next(20, 480);
        }

        public static string PickRandomItemSprite(string prefix) {
            Random rd = new Random();
            string filename = prefix + (rd.Next(0, 10)).ToString() + ".png";
            return filename;
        }
    }

    public class ChatHub : Hub
    {
        
        public async Task JoinGame(string player)
        {   
            Random rd = new Random();
            int rand_num = rd.Next(1, 99999);
            var convertedPlayer = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(player);
            convertedPlayer.setId(rand_num);
            PlayersList.players[rand_num] = convertedPlayer;
            await Clients.Caller.SendAsync("RecieveId", Newtonsoft.Json.JsonConvert.SerializeObject(convertedPlayer.getId()));

            World.Instance.AddPlayer(PlayersList.players[rand_num]);
            await Groups.AddToGroupAsync(Context.ConnectionId,convertedPlayer.GetGroupId());
            await Clients.Group(convertedPlayer.GetGroupId()).SendAsync("RecieveInfoAboutOtherPlayers", JsonConvert.SerializeObject(World.Instance.GetPlayers(convertedPlayer.worldX, convertedPlayer.worldY) ));

            await ServerEngine.NetworkManager.OnNewClientConnected(Clients.Caller);
        }

        public async Task MovePlayer(Player convertedPlayer, int worldX, int worldY, int x, int y)
        {
            World.Instance.MoveToArea(convertedPlayer, worldX, worldY, x, y);

            // Leaving the group
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, PlayersList.players[convertedPlayer.getId()].GetGroupId());
            await Clients.Group(PlayersList.players[convertedPlayer.getId()].GetGroupId()).SendAsync("RecieveInfoAboutOtherPlayers", JsonConvert.SerializeObject(World.Instance.GetPlayers(convertedPlayer.worldX, convertedPlayer.worldY)));

            // Entering new group
            PlayersList.players[convertedPlayer.getId()] = convertedPlayer;
            await Groups.AddToGroupAsync(Context.ConnectionId, convertedPlayer.GetGroupId());
            await Clients.Group(convertedPlayer.GetGroupId()).SendAsync("RecieveInfoAboutOtherPlayers", JsonConvert.SerializeObject(World.Instance.GetPlayers(convertedPlayer.worldX, convertedPlayer.worldY)));
        }

        public async Task UpdatePlayerInfo(string player)
        {
            var convertedPlayer = JsonConvert.DeserializeObject<Player>(player);


            if (convertedPlayer.x <= World.transitionOffset)
            {
                if (convertedPlayer.worldX > 0)
                {
                    await MovePlayer(convertedPlayer, -1 , 0, 700, convertedPlayer.y);
                }
            }
            else if (convertedPlayer.x >= World.canvasWidth - World.transitionOffset)
            {
                if (convertedPlayer.worldX < World.width-1)
                {
                    await MovePlayer(convertedPlayer, 1 , 0, 100, convertedPlayer.y);
                }
            }
            else if (convertedPlayer.y <= World.transitionOffset)
            {
                if (convertedPlayer.worldY > 0)
                {
                    await MovePlayer(convertedPlayer, 0, -1, convertedPlayer.x, 400);
                }
            }
            else if (convertedPlayer.y >= World.canvasHeight - World.transitionOffset)
            {
                if (convertedPlayer.worldY < World.height-1)
                {
                    await MovePlayer(convertedPlayer, 0, 1, convertedPlayer.x, 100);
                }
            }

            PlayersList.players[convertedPlayer.getId()] = convertedPlayer;
            World.Instance.UpdatePlayer(convertedPlayer);
            await Clients.Group(convertedPlayer.GetGroupId()).SendAsync("RecieveInfoAboutOtherPlayers", JsonConvert.SerializeObject(World.Instance.GetPlayers(convertedPlayer.worldX, convertedPlayer.worldY)));
        }

        public async Task SendItemsListToPlayers() {
            await Clients.All.SendAsync("RecieveItemInfo", Newtonsoft.Json.JsonConvert.SerializeObject(ItemsList.items.Values.ToList()));
        }

        public async Task UpdateItemsList(string item) {
            var convertedItem = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(item);
            ItemsList.AddItemToList(convertedItem);
            await Clients.All.SendAsync("RecieveItemInfo", Newtonsoft.Json.JsonConvert.SerializeObject(ItemsList.items.Values.ToList()));
        }

        public async Task HandleClientRequest(string data)
        {
            await Task.Run(() => { ServerEngine.NetworkManager.HandleClientRequest(data); });
        }
        //to do: handle player disconnect
        //to do: handle player reconnect

    }
}
