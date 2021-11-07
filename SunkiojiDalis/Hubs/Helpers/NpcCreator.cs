using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Characters;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack.Managers
{
    public class NpcCreator : Creator<NPC, NpcType>
    {
        public NPC FactoryMethod(NpcType npcType, string subtype, string area)
        {
            switch (npcType)
            {
                case NpcType.Friendly:
                    return new FriendlyNpc("Friendly", areaId: area, position: new Vector2D(50, 50), width: 32, height: 48, sprite: "resources/characters/player-green.png", speed: 30);
                case NpcType.Enemy:
                    Random random1 = new Random();
                    if(subtype == "fast_enemy"){
                         return new EnemyNpc("fast_enemy", areaId: area, position: new Vector2D(random1.Next(50, 750), random1.Next(50, 450)), width: 32, height: 48, sprite: "resources/characters/player-green.png", speed: 60);
                    }

                    if(subtype == "slow_enemy"){
                         return new EnemyNpc("slow_enemy", areaId: area, position: new Vector2D(random1.Next(50, 750), random1.Next(50, 450)), width: 32, height: 48, sprite: "resources/characters/player-brown.png", speed: 15);
                    }

                    return new EnemyNpc("normal_enemy", areaId: area, position: new Vector2D(random1.Next(50, 750), random1.Next(50, 450)), width: 32, height: 48, sprite: "resources/characters/player-blue.png", speed: 30);
                case NpcType.Animal:
                    Random random2 = new Random();
                    return new AnimalNpc("animal", areaId: area, position: new Vector2D(random2.Next(50, 750), random2.Next(50, 450)), width: 48, height: 48, sprite: "resources/characters/lion.png", speed: 5);
                default:
                    return null;
            }
        }
    }
}