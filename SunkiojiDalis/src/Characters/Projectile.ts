import { Vector2D } from "../Helpers/Vector2D";
import { DestroyObject } from "../Managers/ClientEngine";

export class Projectile
{
    guid: string;
    sprite: string;
    areaId: number;
    position: Vector2D;
    
    width: number;
    height: number;
    
    speed: number;
    targetPosition: Vector2D;
    originPosition: Vector2D;

    frameX: number = 0;
    frameY: number = 0;

    constructor(guid: string, projectileData: any)
    {
        this.guid = guid;
        this.sprite = projectileData.sprite;
        this.position = new Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));

        this.width = parseInt(projectileData.width);
        this.height = parseInt(projectileData.height);

        this.speed = parseFloat(projectileData.speed);

        this.targetPosition = new Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));
        this.originPosition = new Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));
    }

    SyncPosition(syncData)
    {
        console.log(syncData);
        this.position = this.targetPosition;
        this.targetPosition = new Vector2D(parseFloat(syncData.RequestData.x), parseFloat(syncData.RequestData.y)); 
    }

    Destroy(data: string)
    {
        DestroyObject(this.guid);
    }
}