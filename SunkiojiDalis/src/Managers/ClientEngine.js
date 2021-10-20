"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CalculateTravelTime = exports.Interpolate = exports.ClientEngineMethods = exports.ClientObjectCount = exports.ClientObjects = void 0;
var EnemyNpc_1 = require("../Characters/EnemyNpc");
var FriendlyNpc_1 = require("../Characters/FriendlyNpc");
var Vector2D_1 = require("../Helpers/Vector2D");
exports.ClientObjects = {}; //objects that have been created
exports.ClientObjectCount = 0;
exports.ClientEngineMethods = {};
exports.ClientEngineMethods["CreateClientObject"] = CreateClientObject;
function CreateClientObject(serverRequest) {
    CreateNewObject(serverRequest.RequestObjectGuid, serverRequest.RequestData);
}
function CreateNewObject(guid, objectData) {
    if (exports.ClientObjects[guid] === undefined) {
        var newObject = void 0;
        switch (objectData.objectType) {
            case "FriendlyNpc":
                newObject = new FriendlyNpc_1.FriendlyNpc(guid, objectData);
                break;
            case "EnemyNpc":
                newObject = new EnemyNpc_1.EnemyNpc(guid, objectData);
                break;
        }
        if (newObject !== null) {
            exports.ClientObjects[guid] = newObject;
            exports.ClientObjectCount++;
        }
    }
}
function Interpolate(currentPosition, targetPosition, speed, elapsedTime) {
    if (Vector2D_1.Vector2D.Equals(currentPosition, targetPosition) || speed === 0 || elapsedTime === 0) {
        return currentPosition;
    }
    var direction = currentPosition.DirectionTo(targetPosition);
    return Vector2D_1.Vector2D.Add(currentPosition, Vector2D_1.Vector2D.Multiply(direction.Normalize(), speed * elapsedTime));
}
exports.Interpolate = Interpolate;
function CalculateTravelTime(oringV, targetV, speed) {
    if (speed !== 0) {
        var length_1 = oringV.DirectionTo(targetV).GetMagnidute();
        return length_1 / speed;
    }
    return 0;
}
exports.CalculateTravelTime = CalculateTravelTime;
