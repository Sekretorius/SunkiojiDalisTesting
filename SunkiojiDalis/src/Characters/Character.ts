import { Vector2D } from '../Helpers/Vector2D';
import { DestroyObject } from '../Managers/ClientEngine';

export class Character
{
    guid: string;
    name: string;
    health: number;
    sprite: string;
    areaId: string;
    position: Vector2D;
    width: number;
    height: number;
    frameX: number;
    frameY: number;
    speed: number;
    targetPosition: Vector2D;
    originPosition: Vector2D;
    travelTime: number;
    elapsedTime: number;

    constructor(guid: string, characterData: any)
    {
        this.guid = guid;
        this.name = characterData.name;
        this.health = parseFloat(characterData.health);
        this.sprite = characterData.sprite;
        this.areaId = characterData.areaId;
        this.position = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.width = parseInt(characterData.width);
        this.height = parseInt(characterData.height);
        this.frameX = parseInt(characterData.frameX);
        this.frameY = parseInt(characterData.frameY);
        this.speed = parseFloat(characterData.speed);

        this.targetPosition = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.originPosition = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
    }

    GetAttackAlgorithm(){
        //maybe use this for visual showing
    }

    GetMoveAlgorithm(){
        //maybe use this for visual showing
    }

    Attack(){

    }

    Move(){

    }

    Die(){

    }

    Destroy(data: string)
    {
        DestroyObject(this.guid);
    }
}