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
exports.EnemyNpc = void 0;
var NPC_1 = require("./NPC");
var EnemyNpc = /** @class */ (function (_super) {
    __extends(EnemyNpc, _super);
    function EnemyNpc(guid, characterData) {
        return _super.call(this, guid, characterData) || this;
    }
    EnemyNpc.prototype.GetAttackAlgorithm = function () {
        //maybe use this for visual showing
    };
    EnemyNpc.prototype.GetMoveAlgorithm = function () {
        //maybe use this for visual showing
    };
    EnemyNpc.prototype.SetAttackAlgorithm = function () {
        //maybe use this for visual showing
    };
    EnemyNpc.prototype.SetMoveAlgorithm = function () {
        //maybe use this for visual showing
    };
    EnemyNpc.prototype.Attack = function () {
    };
    EnemyNpc.prototype.Move = function () {
    };
    EnemyNpc.prototype.Die = function () {
    };
    return EnemyNpc;
}(NPC_1.NPC));
exports.EnemyNpc = EnemyNpc;
