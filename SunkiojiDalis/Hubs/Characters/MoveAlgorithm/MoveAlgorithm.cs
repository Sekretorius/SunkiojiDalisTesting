using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using SunkiojiDalis.Engine;

namespace SunkiojiDalis.Character
{
    public enum MoveType
    {
        Stand,
        Walk,
        Fly
    }
    public abstract class MoveAlgorithm
    {
        public abstract void Move(ref float x, ref float y, float speed);
    }
}