"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CalculateTravelTime = exports.Interpolate = exports.DestroyObject = exports.ClientEngineMethods = exports.ClientObjectCount = exports.ClientObjects = void 0;
var EnemyNpc_1 = require("../Characters/EnemyNpc");
var FriendlyNpc_1 = require("../Characters/FriendlyNpc");
var Vector2D_1 = require("../Helpers/Vector2D");
var PassableObstacle_1 = require("../Obstacles/PassableObstacle");
var ImpassableObstacle_1 = require("../Obstacles/ImpassableObstacle");
var CommonArmor_1 = require("../Items/Equipables/Armors/ArmorRarities/CommonArmor");
var LegendaryArmor_1 = require("../Items/Equipables/Armors/ArmorRarities/LegendaryArmor");
var CommonWeapon_1 = require("../Items/Equipables/Weapons/WeaponRarities/CommonWeapon");
var LegendaryWeapon_1 = require("../Items/Equipables/Weapons/WeaponRarities/LegendaryWeapon");
var CommonFood_1 = require("../Items/Consumables/Foods/FoodRarities/CommonFood");
var LegendaryFood_1 = require("../Items/Consumables/Foods/FoodRarities/LegendaryFood");
var CommonPotion_1 = require("../Items/Consumables/Potions/PotionRarities/CommonPotion");
var LegendaryPotion_1 = require("../Items/Consumables/Potions/PotionRarities/LegendaryPotion");
var Projectile_1 = require("../Characters/Projectile");
exports.ClientObjects = {}; //objects that have been created
exports.ClientObjectCount = 0;
exports.ClientEngineMethods = {};
exports.ClientEngineMethods["CreateClientObject"] = CreateClientObject;
exports.ClientEngineMethods["RemoveAllObjects"] = RemoveAllObjects;
function CreateClientObject(serverRequest) {
    CreateNewObject(serverRequest.RequestObjectGuid, serverRequest.RequestData);
}
function CreateNewObject(guid, objectData) {
    console.log("CREATE " + objectData);
    if (exports.ClientObjects[guid] === undefined) {
        var newObject = void 0;
        switch (objectData.objectType) {
            case "FriendlyNpc":
                newObject = new FriendlyNpc_1.FriendlyNpc(guid, objectData);
                break;
            case "EnemyNpc":
                newObject = new EnemyNpc_1.EnemyNpc(guid, objectData);
                break;
            case "ImpassableObstacle":
                newObject = new ImpassableObstacle_1.ImpassableObstacle(guid, objectData);
                break;
            case "PassableObstacle":
                newObject = new PassableObstacle_1.PassableObstacle(guid, objectData);
                break;
            case "CommonArmor":
                newObject = new CommonArmor_1.CommonArmor(guid, objectData);
                break;
            case "LegendaryArmor":
                newObject = new LegendaryArmor_1.LegendaryArmor(guid, objectData);
                break;
            case "CommonWeapon":
                newObject = new CommonWeapon_1.CommonWeapon(guid, objectData);
                break;
            case "LegendaryWeapon":
                newObject = new LegendaryWeapon_1.LegendaryWeapon(guid, objectData);
                break;
            case "CommonPotion":
                newObject = new CommonPotion_1.CommonPotion(guid, objectData);
                break;
            case "LegendaryPotion":
                newObject = new LegendaryPotion_1.LegendaryPotion(guid, objectData);
                break;
            case "CommonFood":
                newObject = new CommonFood_1.CommonFood(guid, objectData);
                break;
            case "LegendaryFood":
                newObject = new LegendaryFood_1.LegendaryFood(guid, objectData);
                break;
            case "Projectile":
                newObject = new Projectile_1.Projectile(guid, objectData);
                break;
        }
        if (newObject !== null) {
            exports.ClientObjects[guid] = newObject;
            exports.ClientObjectCount++;
        }
    }
}
function RemoveAllObjects(guid, objectData) {
    exports.ClientObjects = {};
    exports.ClientObjectCount = 0;
}
function DestroyObject(guid) {
    if (exports.ClientObjectCount > 0) {
        delete exports.ClientObjects[guid];
        exports.ClientObjectCount -= 1;
    }
}
exports.DestroyObject = DestroyObject;
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
