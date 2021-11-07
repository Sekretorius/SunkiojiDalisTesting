"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Character = void 0;
var Vector2D_1 = require("../Helpers/Vector2D");
var ClientEngine_1 = require("../Managers/ClientEngine");
var Character = /** @class */ (function () {
    function Character(guid, characterData) {
        this.guid = guid;
        this.name = characterData.name;
        this.health = parseFloat(characterData.health);
        this.sprite = characterData.sprite;
        this.areaId = characterData.areaId;
        this.position = new Vector2D_1.Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.width = parseInt(characterData.width);
        this.height = parseInt(characterData.height);
        this.frameX = parseInt(characterData.frameX);
        this.frameY = parseInt(characterData.frameY);
        this.speed = parseFloat(characterData.speed);
        this.targetPosition = new Vector2D_1.Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
        this.originPosition = new Vector2D_1.Vector2D(parseFloat(characterData.x), parseFloat(characterData.y));
    }
    Character.prototype.GetAttackAlgorithm = function () {
        //maybe use this for visual showing
    };
    Character.prototype.GetMoveAlgorithm = function () {
        //maybe use this for visual showing
    };
    Character.prototype.Attack = function () {
    };
    Character.prototype.Move = function () {
    };
    Character.prototype.Die = function () {
    };
    Character.prototype.Destroy = function (data) {
        (0, ClientEngine_1.DestroyObject)(this.guid);
    };
    return Character;
}());
exports.Character = Character;
