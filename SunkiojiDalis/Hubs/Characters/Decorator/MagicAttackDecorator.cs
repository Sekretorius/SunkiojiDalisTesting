using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebPack.Characters
{
    public class MagicAttackDecorator : Decorator
    {
        public MagicAttackDecorator(Character chars) : base(chars){}
        public override void Attack(){
            magicAttack();

            base.Attack();
        }

        public void magicAttack(){
            Console.WriteLine("Magic attacka");
        }
    }
}