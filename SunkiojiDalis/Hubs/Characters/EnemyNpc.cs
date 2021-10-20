using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Engine;

namespace SignalRWebPack.Character
{
    public class EnemyNpc : NPC
    {
        public EnemyNpc(
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
            bool moving = false) : base(name, health, sprite, areaId, position, width, height, frameX, frameY, speed, moving){ this.collider = new Collider(new Rect(position, new Vector2D(width, height)), this); }

        private List<Vector2D> targets = new List<Vector2D>()
        {
            new Vector2D(100, 0)
        };
        int c = 0;
        public override void Update()
        {
            if(targets[c] == Position)
            {
                c++;
                if(c >= targets.Count){
                    c = 0;
                }
            }
            this.Position = MoveAlgorithm.Move(this.Position, targets[c], speed);
            //SyncDataWithClients("SyncPosition", $"{{\"x\":\"{this.Position.X}\", \"y\":\"{this.Position.Y}\"}}");
        }

        public override void Shout(){}
        public override void SetAttackAlgorithm(AttackAlgorithm attackAlgorithm){}
        //public override void SetMoveAlgorithm(MoveAlgorithm moveAlgorithm){}
        public override AttackAlgorithm GetAttackAlgorithm(){ return null; }
        public override MoveAlgorithm GetMoveAlgorithm(){ return null; }
        public override void Move(){}
        public override void Attack(){}
        public override void Die(){}

        public override void OnCollision(Collision collision)
        {
            Console.WriteLine(collision.Collider.GameObject.GUID);
        }
        public override Dictionary<string, string> OnClientSideCreation()
        {
            Dictionary<string, string> friendlyNpcData = base.OnClientSideCreation();
            friendlyNpcData["objectType"] = nameof(ServerObjectType.EnemyNpc);
            
            return friendlyNpcData;
        }
    }
}