using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebPack.Characters
{
    public class SwordAttackDecorator: Decorator
    {
        public SwordAttackDecorator(Character chars) : base(chars){}
        public override void Attack(){
            swordAttack();

            base.Attack();
        }

        public void swordAttack(){
            Console.WriteLine("Kardo attacka");
        }
    }
}