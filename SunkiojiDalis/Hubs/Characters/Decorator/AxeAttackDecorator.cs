using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SignalRWebPack.Characters
{
    public class AxeAttackDecorator: Decorator
    {
        public AxeAttackDecorator(Character chars) : base(chars){}
        public override void Attack(){
            axeAttack();

            base.Attack();
        }

        public void axeAttack(){
            Console.WriteLine("Kirvio attacka");
        }
    }
}