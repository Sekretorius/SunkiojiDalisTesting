using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Character
{
    public class Ranged : AttackAlgorithm
    {
        public Ranged(float damage) : base(damage) {}

        public override void Attack(float x, float y)
        {

        }
    }
}