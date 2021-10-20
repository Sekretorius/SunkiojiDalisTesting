using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Character
{
    public class Fly : MoveAlgorithm
    {
        public override Vector2D Move(Vector2D currentPosition, Vector2D targetPosition, float speed)
        {
            return currentPosition;
        }
    }
}