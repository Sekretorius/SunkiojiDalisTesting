using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Characters
{
    public class Stand : MoveAlgorithm
    {
        public override Vector2D Move(Vector2D currentPosition, Vector2D targetPosition, float speed)
        {
            return currentPosition;
        }

        public override MoveAlgorithm DeepCopy()
        {
            return (Stand)this.MemberwiseClone();
        }
        public override MoveAlgorithm ShallowCopy()
        {
            return (Stand)this.MemberwiseClone();
        }
    }
}