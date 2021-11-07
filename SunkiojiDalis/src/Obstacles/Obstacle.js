"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Obstacle = void 0;
var Obstacle = /** @class */ (function () {
    function Obstacle(guid, itemData) {
        this.guid = guid;
        this.Id = itemData.id;
        this.Sprite = itemData.sprite;
        this.X = itemData.x;
        this.Y = itemData.y;
    }
    Obstacle.prototype.getId = function () {
        return this.Id;
    };
    return Obstacle;
}());
exports.Obstacle = Obstacle;
