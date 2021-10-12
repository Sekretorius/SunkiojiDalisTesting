using System;
using System.Collections.Generic;
using SunkiojiDalis.Engine;
using SunkiojiDalis.Character;

namespace SunkiojiDalis.Managers
{
    public class NpcCreator : Creator
    {
        public NPC FactoryMethod(NpcType npcType)
        {
            switch (npcType)
            {
                case NpcType.Friendly:
                    return new FriendlyNpc("Friendly", x: 50, y: 50, width: 32, height: 48, sprite: "resources/characters/player-green.png", speed: 30);
                case NpcType.Enemy:
                    return new EnemyNpc("Enemy", x: 10, y: 10, width: 32, height: 48, sprite: "resources/characters/player-blue.png", speed: 30);
                default:
                    return null;
            }
        }
    }
}