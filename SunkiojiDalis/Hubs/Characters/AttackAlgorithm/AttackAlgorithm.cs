using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Character
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

        public abstract void Attack(float x, float y); //should have more parametres (like maybe sprite or something)
    }
}