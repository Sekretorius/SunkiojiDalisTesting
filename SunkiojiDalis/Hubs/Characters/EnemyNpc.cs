using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using SunkiojiDalis.Engine;

namespace SunkiojiDalis.Character
{
    public class EnemyNpc : NPC
    {
        public EnemyNpc(
            string name = null, 
            float health = 0, 
            string sprite = null, 
            int areaId = 0, 
            int x = 0, 
            int y = 0, 
            int width = 0, 
            int height = 0, 
            int frameX = 0, 
            int frameY = 0, 
            int speed = 0,
            bool moving = false) : base(name, health, sprite, areaId, x, y, width, height, frameX, frameY, speed, moving){}

        public override void Update()
        {
            MoveAlgorithm.Move(ref x, ref y, speed);
            SyncDataWithClients("SyncPosition", $"{{\"x\":\"{x}\", \"y\":\"{y}\"}}");
        }

        public override void Shout(){}
        public override void SetAttackAlgorithm(AttackAlgorithm attackAlgorithm){}
        //public override void SetMoveAlgorithm(MoveAlgorithm moveAlgorithm){}
        public override AttackAlgorithm GetAttackAlgorithm(){ return null; }
        public override MoveAlgorithm GetMoveAlgorithm(){ return null; }
        public override void Move(){}
        public override void Attack(){}
        public override void Die(){}


        public override Dictionary<string, string> OnClientSideCreation()
        {
            Dictionary<string, string> friendlyNpcData = base.OnClientSideCreation();
            friendlyNpcData["objectType"] = nameof(ServerObjectType.EnemyNpc);
            
            return friendlyNpcData;
        }
    }
}