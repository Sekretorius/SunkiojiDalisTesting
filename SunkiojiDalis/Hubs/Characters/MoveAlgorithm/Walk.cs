using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using SunkiojiDalis.Engine;

namespace SunkiojiDalis.Character
{
    public class Walk : MoveAlgorithm
    {
        private float t = 0;
        private int c = 0;

        public override void Move(ref float x, ref float y, float speed)
        {
            if(t > 3)
            {
                c++;
                t = 0;
            }
            t += ServerEngine.Instance.UpdateTime;

            switch (c)
            {
                case 0:
                    x += speed * ServerEngine.Instance.UpdateTime;
                    break;
                case 1:
                    y += speed * ServerEngine.Instance.UpdateTime;
                    break;
                case 2:
                    x -= speed * ServerEngine.Instance.UpdateTime;
                    break;
                case 3:
                    y -= speed * ServerEngine.Instance.UpdateTime;
                    break;
                default:
                    c = 0;
                    break;
            }
        }
    }
}