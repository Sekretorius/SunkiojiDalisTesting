using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Characters
{
    public class Mixed : AttackAlgorithm
    {
        private string areaId;
        private int value = -1;
        public Mixed(string areaId, float damage) : base(damage)
        {
            this.areaId = areaId;
        }
        public override float Attack(Vector2D attacker, Vector2D target)
        {
            Random random = new Random();
            if (++value == 2) value = 0;
            switch(value)
            {
                case 0:
                    return new Ranged(areaId, 10, 5, 100).Attack(attacker, target);
                case 1:
                    return new Melee(areaId, 20, 5).Attack(attacker, target);
                default:
                    return 0;
            }
        }
    }
}