"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.NPC = void 0;
var Character_1 = require("./Character");
var Vector2D_1 = require("../Helpers/Vector2D");
var NPC = /** @class */ (function (_super) {
    __extends(NPC, _super);
    function NPC(guid, characterData) {
        return _super.call(this, guid, characterData) || this;
    }
    NPC.prototype.SetAttackAlgorithm = function () {
        //maybe use this for visual showing
    };
    NPC.prototype.SetMoveAlgorithm = function () {
        //maybe use this for visual showing
    };
    NPC.prototype.Attack = function () {
    };
    NPC.prototype.Move = function () {
    };
    NPC.prototype.Die = function () {
    };
    NPC.prototype.SyncPosition = function (syncData) {
        this.position = this.targetPosition;
        this.targetPosition = new Vector2D_1.Vector2D(parseFloat(syncData.RequestData.x), parseFloat(syncData.RequestData.y));
        //this.originPosition = new Vector2D(this.position.x, this.position.y);
        //this.elapsedTime = 0;
        //this.travelTime = CalculateTravelTime(this.originPosition, this.targetPosition, this.speed);
    };
    return NPC;
}(Character_1.Character));
exports.NPC = NPC;
