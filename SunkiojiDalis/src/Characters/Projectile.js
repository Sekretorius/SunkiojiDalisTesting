"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Projectile = void 0;
var Vector2D_1 = require("../Helpers/Vector2D");
var ClientEngine_1 = require("../Managers/ClientEngine");
var Projectile = /** @class */ (function () {
    function Projectile(guid, projectileData) {
        this.frameX = 0;
        this.frameY = 0;
        this.guid = guid;
        this.sprite = projectileData.sprite;
        this.position = new Vector2D_1.Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));
        this.width = parseInt(projectileData.width);
        this.height = parseInt(projectileData.height);
        this.speed = parseFloat(projectileData.speed);
        this.targetPosition = new Vector2D_1.Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));
        this.originPosition = new Vector2D_1.Vector2D(parseFloat(projectileData.x), parseFloat(projectileData.y));
    }
    Projectile.prototype.SyncPosition = function (syncData) {
        console.log(syncData);
        this.position = this.targetPosition;
        this.targetPosition = new Vector2D_1.Vector2D(parseFloat(syncData.RequestData.x), parseFloat(syncData.RequestData.y));
    };
    Projectile.prototype.Destroy = function (data) {
        (0, ClientEngine_1.DestroyObject)(this.guid);
    };
    return Projectile;
}());
exports.Projectile = Projectile;
