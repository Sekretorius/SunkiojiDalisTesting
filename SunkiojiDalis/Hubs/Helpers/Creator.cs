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
    public interface Creator<T, Ty>
    {
        T FactoryMethod(Ty type, string subtype, string area);
    }
}