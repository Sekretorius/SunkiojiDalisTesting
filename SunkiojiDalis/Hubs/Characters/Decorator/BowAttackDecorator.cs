using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebPack.Characters
{
    public class BowAttackDecorator : Decorator
    {
        public BowAttackDecorator(Character chars) : base(chars){}
        public override void Attack(){
            bowAttack();

            base.Attack();
        }

        public void bowAttack(){
            Console.WriteLine("Lanko attacka");
        }
    }
}