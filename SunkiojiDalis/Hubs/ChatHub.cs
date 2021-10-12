using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SunkiojiDalis.Engine;

namespace SunkiojiDalis.Hubs
{
    [JsonObject(MemberSerialization.Fields)]
    public class Player {
        private int id;
        private int x;
        private int y;
        private int width;
        private int height;
        private int frameX;
        private int frameY;
        private int speed;
        private bool moving;
        private string sprite;

        public Player(int id, int x, int y, int width, int height, int frameX, int frameY, int speed, bool moving, string sprite) {
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
            //to do: sync other actions 
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getId() {
            return this.id;
        }
    }

    public static class PlayersList {
        public static Dictionary<int, Player> players = new Dictionary<int, Player>();
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
            await Clients.All.SendAsync("RecieveInfoAboutOtherPlayers", Newtonsoft.Json.JsonConvert.SerializeObject(PlayersList.players.Values.ToList()));
            await ServerEngine.NetworkManager.OnNewClientConnected(Clients.Caller);
        }

        public async Task UpdatePlayerInfo(string player)
        {
            var convertedPlayer = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(player);
            PlayersList.players[convertedPlayer.getId()] = convertedPlayer;
            await Clients.All.SendAsync("RecieveInfoAboutOtherPlayers", Newtonsoft.Json.JsonConvert.SerializeObject(PlayersList.players.Values.ToList()));
        }

        public async Task HandleClientRequest(string data)
        {
            await Task.Run(()=>{ ServerEngine.NetworkManager.HandleClientRequest(data);});
        }
        //to do: handle player disconnect
        //to do: handle player reconnect

    }
}