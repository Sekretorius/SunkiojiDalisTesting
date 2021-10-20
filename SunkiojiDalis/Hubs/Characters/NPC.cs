using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Character
{
    public abstract class NPC : Character
    {
        public NPC(
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
            bool moving = false) : base(name, health, sprite, areaId, position, width, height, frameX, frameY, speed, moving){}
        
        public abstract void Shout();
        public virtual void SetAttackAlgorithm(AttackAlgorithm attackAlgorithm)
        {
            AttackAlgorithm = attackAlgorithm;
        }
        public virtual void SetMoveAlgorithm(MoveAlgorithm moveAlgorithm)
        {
            MoveAlgorithm = moveAlgorithm;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
        }
    }

    public enum NpcType
    {
        Friendly,
        Enemy
    }
}