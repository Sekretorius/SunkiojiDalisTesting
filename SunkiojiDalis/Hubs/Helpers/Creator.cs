using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Character;

namespace SignalRWebPack.Managers
{
    public interface Creator
    {
        NPC FactoryMethod(NpcType npcType);
    }
}