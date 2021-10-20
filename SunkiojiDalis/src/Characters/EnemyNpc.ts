import { NPC } from './NPC';

export class EnemyNpc extends NPC
{
    constructor(guid: string, characterData: any)
    {
        super(guid, characterData);
    }

    GetAttackAlgorithm(){
        //maybe use this for visual showing
    }

    GetMoveAlgorithm(){
        //maybe use this for visual showing
    }

    SetAttackAlgorithm(){
        //maybe use this for visual showing
    }

    SetMoveAlgorithm(){
        //maybe use this for visual showing
    }

    Attack(){

    }

    Move(){

    }

    Die(){

    }
}