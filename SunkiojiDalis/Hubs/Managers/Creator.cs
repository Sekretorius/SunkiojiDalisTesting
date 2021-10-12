using System;
using System.Collections.Generic;
using SunkiojiDalis.Engine;
using SunkiojiDalis.Character;

namespace SunkiojiDalis.Managers
{
    public interface Creator
    {
        NPC FactoryMethod(NpcType npcType);
    }
}