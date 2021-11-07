using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Characters
{
    public enum MoveType
    {
        Stand,
        Walk,
        Fly
    }
    public abstract class MoveAlgorithm
    {
        public abstract Vector2D Move(Vector2D currentPosition, Vector2D targetPosition, float speed);

        public abstract MoveAlgorithm DeepCopy();
        public abstract MoveAlgorithm ShallowCopy();

    }
}