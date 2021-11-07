using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Characters
{
    public class Ranged : AttackAlgorithm
    {
        private float attackRange;
        private string areaId;
        private float attackDelay = 0;
        public Ranged(string areaId, float attackDelay, float damage, float attackRange) : base(damage) 
        {
            this.attackRange = attackRange;
            this.areaId = areaId;
            this.attackDelay = attackDelay;
        }

        public override float Attack(Vector2D attacker, Vector2D target)
        {
            Projectile p = new Projectile(areaId, "resources/items/weapon/arrow.png", attacker, new Rect(attacker, new Vector2D(32, 6)), 200, target);
            return attackDelay;
        }
    }
}