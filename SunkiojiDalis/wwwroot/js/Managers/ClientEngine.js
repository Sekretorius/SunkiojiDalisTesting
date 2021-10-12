

ClientObjects = {} //objects that have been created
ClientObjectCount = 0;

ClientEngineMethods = {};
ClientEngineMethods["CreateClientObject"] = CreateClientObject;


function CreateClientObject (serverRequest) {
    CreateNewObject(serverRequest.RequestObjectGuid, serverRequest.RequestData);
}

function CreateNewObject(guid, objectData) {
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

class Vector2D{
    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    GetMagnidute(){
        return Math.sqrt(this.x ** 2 + this.y ** 2);
    }

    Normalize(){
        let magnitude = this.GetMagnidute();
        return new Vector2D(this.x / magnitude, this.y / magnitude);
    }

    DirectionTo(v){
        return new Vector2D(v.x - this.x, v.y - this.y);
    }
    
    Lerp(origin, target, t){
        let direction = origin.Direction(target);
        return new Vector2D(origin.x + direction.x * t, origin.y + direction.y * t);
    }

    ProjectOn(v){
        let normaizedV = v.Normalize();
        let dotProduct = normaizedV.x * this.x + normaizedV.y * this.y;
        return new Vector2D(normaizedV.x * dotProduct, normaizedV.y * dotProduct);
    }
    Equals(v){
        return this.x == v.x && this.y == v.y;
    }
}

function Interpolate(oringV, targetV, elapsedTime, travelTime)
{
    let direction = oringV.DirectionTo(targetV);
    let t = elapsedTime / travelTime;
    if(t > 1.01){
        t = 1.01;
    }
    return new Vector2D(oringV.x + direction.x * t, oringV.y + direction.y * t);
}

function CalculateTravelTime(oringV, targetV, speed)
{
    if(speed !== 0)
    {
        let length = oringV.DirectionTo(targetV).GetMagnidute();
        return length / speed;
    }
    return 0;
}