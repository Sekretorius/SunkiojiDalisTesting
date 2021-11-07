import { EnemyNpc } from '../Characters/EnemyNpc';
import { FriendlyNpc } from '../Characters/FriendlyNpc';
import { Vector2D } from '../Helpers/Vector2D';
import { NetworkRequest } from './NetworkManager'
import { PassableObstacle } from "../Obstacles/PassableObstacle"
import { ImpassableObstacle } from "../Obstacles/ImpassableObstacle"
import { CommonArmor } from '../Items/Equipables/Armors/ArmorRarities/CommonArmor';
import { LegendaryArmor } from '../Items/Equipables/Armors/ArmorRarities/LegendaryArmor';
import { CommonWeapon } from '../Items/Equipables/Weapons/WeaponRarities/CommonWeapon';
import { LegendaryWeapon } from '../Items/Equipables/Weapons/WeaponRarities/LegendaryWeapon';
import { CommonFood } from '../Items/Consumables/Foods/FoodRarities/CommonFood';
import { LegendaryFood } from '../Items/Consumables/Foods/FoodRarities/LegendaryFood';
import { CommonPotion } from '../Items/Consumables/Potions/PotionRarities/CommonPotion';
import { LegendaryPotion } from '../Items/Consumables/Potions/PotionRarities/LegendaryPotion';
import { Projectile } from '../Characters/Projectile';

export var ClientObjects: any = {}; //objects that have been created
export var ClientObjectCount: number = 0;

export var ClientEngineMethods: any = {};
ClientEngineMethods["CreateClientObject"] = CreateClientObject;
ClientEngineMethods["RemoveAllObjects"] = RemoveAllObjects;

function CreateClientObject(serverRequest: NetworkRequest) {
    CreateNewObject(serverRequest.RequestObjectGuid, serverRequest.RequestData);
}

function CreateNewObject(guid: string, objectData: any) {
    console.log("CREATE " + objectData);
    if(ClientObjects[guid] === undefined){
        let newObject;
        switch(objectData.objectType)
        {
            case "FriendlyNpc":
                newObject = new FriendlyNpc(guid, objectData);
                break;
            case "EnemyNpc":
                newObject = new EnemyNpc(guid, objectData);
                break;
            case "ImpassableObstacle":
                newObject = new ImpassableObstacle(guid, objectData);
                break;
            case "PassableObstacle":
                newObject = new PassableObstacle(guid, objectData);
                break;
            case "CommonArmor":
                newObject = new CommonArmor(guid, objectData);
                break;
            case "LegendaryArmor":
                newObject = new LegendaryArmor(guid, objectData);
                break;
            case "CommonWeapon":
                newObject = new CommonWeapon(guid, objectData);
                break;
            case "LegendaryWeapon":
                newObject = new LegendaryWeapon(guid, objectData);
                break;
            case "CommonPotion":
                newObject = new CommonPotion(guid, objectData);
                break;
            case "LegendaryPotion":
                newObject = new LegendaryPotion(guid, objectData);
                break;
            case "CommonFood":
                newObject = new CommonFood(guid, objectData);
                break;
            case "LegendaryFood":
                newObject = new LegendaryFood(guid, objectData);
                break;
            case "Projectile":
                newObject = new Projectile(guid, objectData);
                break;
        }
        if(newObject !== null)
        {
            ClientObjects[guid] = newObject;
            ClientObjectCount++;
        }
    }
}

function RemoveAllObjects(guid: string, objectData: any) {
    ClientObjects = {};
    ClientObjectCount = 0;
}

export function DestroyObject(guid: string){
    if(ClientObjectCount > 0){
        delete ClientObjects[guid]; 
        ClientObjectCount -= 1;
    }
}

export function Interpolate(currentPosition: Vector2D, targetPosition: Vector2D, speed: number, elapsedTime: number): Vector2D {
    if(Vector2D.Equals(currentPosition, targetPosition) || speed === 0 || elapsedTime === 0)
    { 
        return currentPosition;
    }
    let direction = currentPosition.DirectionTo(targetPosition);
    return Vector2D.Add(currentPosition, Vector2D.Multiply(direction.Normalize(), speed * elapsedTime));
}

export function CalculateTravelTime(oringV: Vector2D, targetV: Vector2D, speed: number): number {
    if(speed !== 0)
    {
        let length = oringV.DirectionTo(targetV).GetMagnidute();
        return length / speed;
    }
    return 0;
}
