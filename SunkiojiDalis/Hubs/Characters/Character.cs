using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Engine;
using SignalRWebPack.Network;

namespace SignalRWebPack.Characters
{
    [JsonObject(MemberSerialization.OptOut)]
    public abstract class Character : NetworkObject
    {
        public string name;
        public float health;
        public string sprite;
        public int width;
        public int height;
        public int frameX;
        public int frameY;
        public int areaId;
        protected MoveAlgorithm moveAlgorithm; //must be private
        protected AttackAlgorithm attackAlgorithm; //must be private
        public int speed;
        public bool moving;

        public Character(
            string name = null, 
            float health = 0, 
            string sprite = null, 
            Vector2D position = null,
            int width = 0, 
            int height = 0, 
            int frameX = 0, 
            int frameY = 0,
            string areaId = "",
            int speed = 0, 
            bool moving = false) : base()
        {
            this.name = name;
            this.health = health;
            this.sprite = sprite;
            this.AreaId = areaId;
            this.Position = position;
            this.speed = speed;
            this.moving = moving;

            this.width = width;
            this.height = height;
            this.frameX = frameX;
            this.frameY = frameY;
        }

        public virtual AttackAlgorithm GetAttackAlgorithm()
        {
            return this.attackAlgorithm;
        }
        public virtual MoveAlgorithm GetMoveAlgorithm()
        {
            return this.moveAlgorithm;
        }
        public virtual void SetAttackAlgorithm(AttackAlgorithm attackAlgorithm)
        {
            this.attackAlgorithm = attackAlgorithm;
        }
        public virtual void SetMoveAlgorithm(MoveAlgorithm moveAlgorithm)
        {
            this.moveAlgorithm = moveAlgorithm;
        }
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
                { "areaId", AreaId.ToString() },
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
        public Character ShallowCopy(){
            return (Character)this.MemberwiseClone();
        }

        public Character DeepCopy(){
        
            var charas = (Character)this.MemberwiseClone();
            charas.Position = new Vector2D(this.Position.X, this.Position.Y);
            charas.SetMoveAlgorithm(this.GetMoveAlgorithm().DeepCopy());

           return charas;
        } 
    }
}
