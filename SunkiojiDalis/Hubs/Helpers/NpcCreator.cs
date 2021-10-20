using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Character;

namespace SignalRWebPack.Managers
{
    public class NpcCreator : Creator
    {
        public NPC FactoryMethod(NpcType npcType)
        {
            switch (npcType)
            {
                case NpcType.Friendly:
                    return new FriendlyNpc("Friendly", position: new Vector2D(50, 50), width: 32, height: 48, sprite: "resources/characters/player-green.png", speed: 30);
                case NpcType.Enemy:
                    return new EnemyNpc("Enemy", position: new Vector2D(100, 100), width: 32, height: 48, sprite: "resources/characters/player-blue.png", speed: 30);
                default:
                    return null;
            }
        }
    }
}