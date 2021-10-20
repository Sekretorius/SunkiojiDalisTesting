using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Engine;
using SignalRWebPack.Network;

namespace SignalRWebPack.Character
{
    [JsonObject(MemberSerialization.OptOut)]
    public abstract class Character : NetworkObject
    {
        public string name;
        public float health;
        public string sprite;
        public int areaId;
        public int width;
        public int height;
        public int frameX;
        public int frameY;

        public MoveAlgorithm MoveAlgorithm;
        public AttackAlgorithm AttackAlgorithm;
        public int speed;
        public bool moving;

        public Character(
            string name = null, 
            float health = 0, 
            string sprite = null, 
            int areaId = 0, 
            Vector2D position = null,
            int width = 0, 
            int height = 0, 
            int frameX = 0, 
            int frameY = 0, 
            int speed = 0, 
            bool moving = false) : base()
        {
            this.name = name;
            this.health = health;
            this.sprite = sprite;
            this.areaId = areaId;

            this.Position = position;
            this.speed = speed;
            this.moving = moving;

            this.width = width;
            this.height = height;
            this.frameX = frameX;
            this.frameY = frameY;
        }

        public abstract AttackAlgorithm GetAttackAlgorithm();
        public abstract MoveAlgorithm GetMoveAlgorithm();
        public abstract void Move();
        public abstract void Attack();
        public abstract void Die();

        public override Dictionary<string, string> OnClientSideCreation()
        {
            Dictionary<string, string> characterData = new Dictionary<string, string>()
            {
                { "objectType", nameof(ServerObjectType.None) },
                { "name", name },
                { "health", health.ToString() },
                { "sprite", sprite },
                { "areaId", areaId.ToString() },
                { "x", Position.X.ToString() },
                { "y", Position.Y.ToString() },
                { "speed", speed.ToString() },
                { "width", width.ToString() },
                { "height", height.ToString() },
                { "frameX", frameX.ToString() },
                { "frameY", frameY.ToString() },
            };
            return characterData;
        }
    }
}