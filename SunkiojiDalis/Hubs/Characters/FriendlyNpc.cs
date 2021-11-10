using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Engine;

namespace SignalRWebPack.Characters
{
    public class FriendlyNpc : NPC
    {
        public FriendlyNpc() { }
        public FriendlyNpc(
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
            bool moving = false) : base(name, health, sprite, areaId, position, width, height, frameX, frameY, speed, moving){}

        public List<Vector2D> targets;
        public override void Init()
        {
            base.Init();
            Random random = new Random();

            targets = new List<Vector2D>()
            {
                new Vector2D(random.Next(50, 750), random.Next(50, 450)),
                new Vector2D(random.Next(50, 750), random.Next(50, 450)),
                new Vector2D(random.Next(50, 750), random.Next(50, 450)),
                new Vector2D(random.Next(50, 750), random.Next(50, 450))
            };
        }
        int c = 0;
        public override void Update()
        {
            Shout();
            Move();
            Attack();
            Die();
            if(this.moveAlgorithm == null) return;
            if(targets[c] == Position)
            {
                c++;
                if(c >= targets.Count){
                    c = 0;   
                }
            }
            this.Position = this.moveAlgorithm.Move(this.Position, targets[c], speed);
            SyncDataWithGroup(AreaId, "SyncPosition", $"{{\"x\":\"{this.Position.X}\", \"y\":\"{this.Position.Y}\"}}");
        }

        public override void Shout(){}
        public override void Move(){}
        public override void Attack(){}
        public override void Die(){}

        public override Dictionary<string, string> OnClientSideCreation()
        {
            Dictionary<string, string> friendlyNpcData = base.OnClientSideCreation();
            friendlyNpcData["objectType"] = nameof(ServerObjectType.FriendlyNpc);
            
            return friendlyNpcData;
        }
    }
}