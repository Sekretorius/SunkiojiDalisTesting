using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace SignalRWebPack.Characters
{
    public class MixedMove : MoveAlgorithm
    {
        private int stepIteration = 0;
        private int stepCounter = 0;

        private bool isMoving = true;
        public MixedMove(int stepIteration)
        {
            this.stepIteration = stepIteration;
        }

        public override Vector2D Move(Vector2D currentPosition, Vector2D targetPosition, float speed)
        {
            if(++stepCounter >= stepIteration)
            {
                stepCounter = 0;
                isMoving = !isMoving;
            }

            if(isMoving)
            {
                return new Walk().Move(currentPosition, targetPosition, speed);
            }
            else
            {
                return new Stand().Move(currentPosition, targetPosition, speed);
            }
        }

        public override MoveAlgorithm DeepCopy()
        {
            return (MixedMove)this.MemberwiseClone();
        }
        public override MoveAlgorithm ShallowCopy()
        {
            return (MixedMove)this.MemberwiseClone();
        }
    }
}