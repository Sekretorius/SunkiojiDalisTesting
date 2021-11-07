using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebPack.Characters
{
    public class SpearAttackDecorator: Decorator
    {
        public SpearAttackDecorator(Character chars) : base(chars){
        }
        public override void Attack(){
            spearAttack();

            base.Attack();
        }
        public void spearAttack(){
            Console.WriteLine("Ieties attacka");
        }
    }
}