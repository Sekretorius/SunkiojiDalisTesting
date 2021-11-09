using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Characters
{
    public abstract class NPC : Character
    {
        public NPC(
            string name = null, 
            float health = 0, 
            string sprite = null, 
            string areaId = "", 
            Vector2D position = null, 
            int width = 0, 
            int height = 0, 
            int frameX = 0, 
            int frameY = 0, 
            int speed = 0,
            bool moving = false) : base(name, health, sprite, position, width, height, frameX, frameY, areaId, speed, moving){}
        
        public abstract void Shout();
        public string getName() {
            return this.name;
        }
    }

    public enum NpcType
    {
        Friendly,
        Enemy,
        Animal,
        Unknown
    }
}
