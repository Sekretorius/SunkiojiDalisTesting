import { Vector2D } from '../Helpers/Vector2D';

export class Character
{
    guid: string;
    name: string;
    health: number;
    sprite: string;
    areaId: number;
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
        this.areaId = parseInt(characterData.areaId);
        this.position = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.width = parseInt(characterData.width);
        this.height = parseInt(characterData.height);
        this.frameX = parseInt(characterData.frameX);
        this.frameY = parseInt(characterData.frameY);
        this.speed = parseFloat(characterData.speed);

        this.targetPosition = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.originPosition = new Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));

        this.travelTime = 0;
        this.elapsedTime = 0;
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
}