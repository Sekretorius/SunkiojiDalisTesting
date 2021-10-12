using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using SunkiojiDalis.Engine;

namespace SunkiojiDalis.Character
{
    public abstract class NPC : Character
    {
        public NPC(
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
        
        public abstract void Shout();
        public virtual void SetAttackAlgorithm(AttackAlgorithm attackAlgorithm)
        {
            AttackAlgorithm = attackAlgorithm;
        }
        public virtual void SetMoveAlgorithm(MoveAlgorithm moveAlgorithm)
        {
            MoveAlgorithm = moveAlgorithm;
        }
    }

    public enum NpcType
    {
        Friendly,
        Enemy
    }
}