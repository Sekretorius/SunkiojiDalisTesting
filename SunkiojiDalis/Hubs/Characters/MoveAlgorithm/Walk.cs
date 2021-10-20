using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Engine;

namespace SignalRWebPack.Character
{
    public class Walk : MoveAlgorithm
    {
        public override Vector2D Move(Vector2D currentPosition, Vector2D targetPosition, float speed)
        {
            Vector2D direction = currentPosition.DirectionTo(targetPosition);
            float magnitude = direction.GetMagnidute();
            float moveDistance = speed * ServerEngine.Instance.UpdateTime;
            if(magnitude <= moveDistance)
            {
                return targetPosition;
            }
            return currentPosition + direction.Normalize() * moveDistance;
        }
    }
}