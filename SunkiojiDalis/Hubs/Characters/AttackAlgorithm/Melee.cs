using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Characters
{
    public class Melee : AttackAlgorithm
    {
        private float attackDelay = 0;
        private string areaId;
        public Melee(string areaId, float attackDelay, float damage) : base(damage)
        {
            this.areaId = areaId;
            this.attackDelay = attackDelay;
        }

        public override float Attack(Vector2D attacker, Vector2D target)
        {
            Projectile p = new Projectile(areaId, "resources/items/weapon/weapon4.png", attacker, new Rect(attacker, new Vector2D(32, 32)), 0, new Vector2D(0,0), 0.5f);
            return attackDelay;
        }
    }
}