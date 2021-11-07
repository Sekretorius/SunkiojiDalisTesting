using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebPack.Characters
{
    public abstract class Decorator: Character
    {
        protected Character character;
       public Decorator(Character chars){
            this.character = chars;
       }

        public override void Attack(){
            if(character != null){
                character.Attack();
            }
        }
        public override void Move(){
            character.Move();
        }

        public override AttackAlgorithm GetAttackAlgorithm(){
            return character.GetAttackAlgorithm();
        }

        public override MoveAlgorithm GetMoveAlgorithm(){
            return character.GetMoveAlgorithm();
        }

        public override void Die()
        {
            character.Die();
        }
    }
}