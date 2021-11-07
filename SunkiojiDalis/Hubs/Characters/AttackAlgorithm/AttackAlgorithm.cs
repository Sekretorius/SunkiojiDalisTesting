using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Characters
{
    public enum AttackType
    {
        Melee,
        Ranged,
        Mixed
    }
    public abstract class AttackAlgorithm
    {
        protected float damage;

        public AttackAlgorithm(float damage)
        {
            this.damage = damage;
        }

        public abstract float Attack(Vector2D attacker, Vector2D target); //should have more parametres (like maybe sprite or something)
    }
}
