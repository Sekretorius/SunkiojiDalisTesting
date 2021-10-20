import { EnemyNpc } from '../Characters/EnemyNpc';
import { FriendlyNpc } from '../Characters/FriendlyNpc';
import { Vector2D } from '../Helpers/Vector2D';
import { NetworkRequest } from './NetworkManager'

export var ClientObjects: any = {}; //objects that have been created
export var ClientObjectCount: number = 0;

export var ClientEngineMethods: any = {};
ClientEngineMethods["CreateClientObject"] = CreateClientObject;


function CreateClientObject(serverRequest: NetworkRequest) {
    CreateNewObject(serverRequest.RequestObjectGuid, serverRequest.RequestData);
}

function CreateNewObject(guid: string, objectData: any) {
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
        }
        if(newObject !== null)
        {
            ClientObjects[guid] = newObject;
            ClientObjectCount++;
        }
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